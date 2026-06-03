using System;
using System.Collections.Generic;

namespace Parrot
{
    public class Parrot
    {
        private readonly bool _isNailed;
        private readonly int _numberOfCoconuts;
        private readonly ParrotTypeEnum _type;
        private readonly double _voltage;

        public Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            _type = type;
            _numberOfCoconuts = numberOfCoconuts;
            _voltage = voltage;
            _isNailed = isNailed;
        }

        // Factory — The strangler fig plan is to swap new Parrot( to Parrot.Create( in tests
        // The Parrot.Create() factory takes a type, a number of coconuts, voltage decimal, and nailed modifier params
        public static Parrot Create(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            return type switch // Parrot.Create() returns a static type
            {
                ParrotTypeEnum.EUROPEAN => new EuropeanParrot(),
                ParrotTypeEnum.AFRICAN => new AfricanParrot(numberOfCoconuts),
                ParrotTypeEnum.NORWEGIAN_BLUE => new NorwegianBlueParrot(voltage, isNailed),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
        }

        // this method knows about three different _types
        // of parrots and separate logic for each
        public double GetSpeed()
        {
            switch (_type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return GetEuropeanSpeed();
                case ParrotTypeEnum.AFRICAN:
                    return GetAfricanSpeed();
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return GetNorwegianSpeed();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        // extracted case into a private method that returns decimals
        private double GetEuropeanSpeed() => GetBaseSpeed();

        // extracted case into a private method that returns decimals
        private double GetAfricanSpeed() => Math.Max(0, GetBaseSpeed() - GetLoadFactor() * _numberOfCoconuts);

        // extracted case into a private method that returns decimals
        private double GetNorwegianSpeed() => _isNailed ? 0 : GetBaseSpeed(_voltage);

        private double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * GetBaseSpeed());
        }

        private double GetLoadFactor()
        {
            return 9.0;
        }

        private double GetBaseSpeed()
        {
            return 12.0;
        }

        public string GetCry()
        {
            string value;
            switch (_type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    value = "Sqoork!";
                    break;
                case ParrotTypeEnum.AFRICAN:
                    value = "Sqaark!";
                    break;
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    value = _voltage > 0 ? "Bzzzzzz" : "...";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return value;
        }
    }

    //Create empty classes extending Parrot
    public class NorwegianBlueParrot : Parrot
    {
        public NorwegianBlueParrot(double voltage, bool isNailed) : base(ParrotTypeEnum.NORWEGIAN_BLUE, 0, voltage, isNailed) { }
    }

    public class AfricanParrot : Parrot
    {
        //Private read-onlys are for inside jokes only:
        //It's a simple question of weight ratios!
        //A five-ounce bird could not carry a one-pound coconut.
        //An African swallow maybe, but not a European swallow;
        //That's my point.
        private readonly int _numberOfCoconuts;

        public AfricanParrot(int numberOfCoconuts) : base(ParrotTypeEnum.AFRICAN, numberOfCoconuts, 0, false)
        {
            _numberOfCoconuts = numberOfCoconuts;
        }
        public new virtual double GetSpeed() => Math.Max(0, 12.0 - 9.0 * _numberOfCoconuts);
        public new virtual string GetCry()   => "Sqaark!";
    }

    public class EuropeanParrot() : Parrot(ParrotTypeEnum.EUROPEAN, 0, 0, false)
    {
        // a virtual method is bound at runtime based on the actual object type
        public new virtual double GetSpeed() => 12.0;
        public new virtual string GetCry() => "Sqoork!";
    }
}