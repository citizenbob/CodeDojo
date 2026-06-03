using System;

namespace Parrot
{
    // Anything that answers GetSpeed() and GetCry()
    // is a parrot as far as the outside world is concerned
    public interface IParrot
    {
        double GetSpeed();
        string GetCry();
    }
    public abstract class Parrot : IParrot
    {
        protected double BaseSpeed() => 12.0;
        protected double LoadFactor() => 9.0;
        protected double MaxSpeed() => 24.0;
        public abstract double GetSpeed();
        public abstract string GetCry();
        
        public static IParrot CreateEuropean() => new EuropeanParrot();
        public static IParrot CreateAfrican(int numberOfCoconuts) => new AfricanParrot(numberOfCoconuts);
        public static IParrot CreateNorwegianBlue(double voltage, bool isNailed) => new NorwegianBlueParrot(voltage, isNailed);

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