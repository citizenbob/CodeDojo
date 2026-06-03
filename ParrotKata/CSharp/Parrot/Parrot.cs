using System;

namespace Parrot
{
    // Make Parrot abstract and remove the switches
    // You can't have a parrot that isn't one of the three types.
    // There's no such thing as a plain Parrot in this domain. 
    public abstract class Parrot
    {
        // `abstract` Every Parrot will answer GetSpeed(), but I'm not saying how.
        // The subclasses are what keep the promise. `override` on each
        // subclass is the fulfillment of that contract.
        // On the base class this means, GetSpeed and GetCry are questions each Parrot
        // has to answer
        public abstract double GetSpeed();
        public abstract string GetCry();
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
    }

    public class NorwegianBlueParrot : Parrot
    {
        // Each subclass answers it in exactly the way that makes sense for what it is.
        // Norwegian Blue knows about voltage and nails
        private readonly double _voltage;
        private readonly bool   _isNailed;
        public NorwegianBlueParrot(double voltage, bool isNailed) { _voltage  = voltage; _isNailed = isNailed; }
        public override double GetSpeed() => _isNailed ? 0 : Math.Min(24.0, _voltage * 12.0);
        public override string GetCry()   => _voltage > 0 ? "Bzzzzzz" : "...";
    }

    public class AfricanParrot : Parrot
    {
        // Each subclass answers it in exactly the way that makes sense for what it is.
        // African knows about coconuts
        private readonly int _numberOfCoconuts;
        public AfricanParrot(int numberOfCoconuts) { _numberOfCoconuts = numberOfCoconuts; }
        public override double GetSpeed() => Math.Max(0, 12.0 - 9.0 * _numberOfCoconuts);
        public override string GetCry()   => "Sqaark!";
    }

    public class EuropeanParrot() : Parrot
    {
        // Each subclass answers it in exactly the way that makes sense for what it is.
        // European just returns 12.0 because that's all it needs to know.
        public override double GetSpeed() => 12.0;
        public override string GetCry() => "Sqoork!";
    }
}