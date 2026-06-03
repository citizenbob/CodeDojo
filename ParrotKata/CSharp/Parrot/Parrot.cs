using System;

namespace Parrot
{
    public abstract class Parrot
    {
        //Magic numbers: naked constants renamed
        //as decimals accessible to the class and its
        //subclasses.
        protected double BaseSpeed() => 12.0;
        protected double LoadFactor() => 9.0;
        protected double MaxSpeed() => 24.0;
        public abstract double GetSpeed();
        public abstract string GetCry();
        public static Parrot Create(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            return type switch
            {
                ParrotTypeEnum.EUROPEAN => new EuropeanParrot(),
                ParrotTypeEnum.AFRICAN => new AfricanParrot(numberOfCoconuts),
                ParrotTypeEnum.NORWEGIAN_BLUE => new NorwegianBlueParrot(voltage, isNailed),
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
        }
    }

    public class NorwegianBlueParrot : Parrot
    {
        private readonly double _voltage;
        private readonly bool   _isNailed;
        public NorwegianBlueParrot(double voltage, bool isNailed) { _voltage  = voltage; _isNailed = isNailed; }
        public override double GetSpeed() => _isNailed ? 0 : Math.Min(MaxSpeed(), _voltage * BaseSpeed());
        public override string GetCry()   => _voltage > 0 ? "Bzzzzzz" : "...";
    }

    public class AfricanParrot : Parrot
    {
        private readonly int _numberOfCoconuts;
        public AfricanParrot(int numberOfCoconuts) { _numberOfCoconuts = numberOfCoconuts; }
        public override double GetSpeed() => Math.Max(0, BaseSpeed() - LoadFactor() * _numberOfCoconuts);
        public override string GetCry()   => "Sqaark!";
    }

    public class EuropeanParrot() : Parrot
    {
        public override double GetSpeed() => BaseSpeed();
        public override string GetCry() => "Sqoork!";
    }
}