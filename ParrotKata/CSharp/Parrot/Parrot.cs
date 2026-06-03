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
}