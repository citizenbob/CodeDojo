using Xunit;

namespace Parrot.Tests
{
    public class ParrotTest
    {
        [Fact]
        public void GetSpeedNorwegianBlueParrot_nailed()
        {
            var parrot = Parrot.CreateNorwegianBlue(0, false);
            Assert.Equal(0.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedNorwegianBlueParrot_nailed_with_voltage()
        {
            var parrot = Parrot.CreateNorwegianBlue(1.5, true);
            Assert.Equal(0.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedNorwegianBlueParrot_not_nailed()
        {
            var parrot = Parrot.CreateNorwegianBlue(1.5, false);
            Assert.Equal(18.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedNorwegianBlueParrot_not_nailed_high_voltage()
        {
            var parrot = Parrot.CreateNorwegianBlue(4,  false);
            Assert.Equal(24.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedOfAfricanParrot_With_No_Coconuts()
        {
            var parrot = Parrot.CreateAfrican(0);
            Assert.Equal(12.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedOfAfricanParrot_With_One_Coconut()
        {
            var parrot = Parrot.CreateAfrican(1);
            Assert.Equal(3.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedOfAfricanParrot_With_Two_Coconuts()
        {
            var parrot = Parrot.CreateAfrican(2);
            Assert.Equal(0.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedOfEuropeanParrot()
        {
            var parrot = Parrot.CreateEuropean();
            Assert.Equal(12.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetCryOfEuropeanParrot()
        {
            var parrot = Parrot.CreateEuropean();
            Assert.Equal("Sqoork!", parrot.GetCry());
        }

        [Fact]
        public void GetCryOfAfricanParrot()
        {
            var parrot = Parrot.CreateAfrican(0);
            Assert.Equal("Sqaark!", parrot.GetCry());
        }

        [Fact]
        public void GetCryNorwegianBlueParrot_high_voltage()
        {
            var parrot = Parrot.CreateNorwegianBlue(4, false);
            Assert.Equal("Bzzzzzz", parrot.GetCry());
        }

        [Fact]
        public void GetCryNorwegianBlueParrot_no_voltage()
        {
            var parrot = Parrot.CreateNorwegianBlue(0, false);
            Assert.Equal("...", parrot.GetCry());
        }
    }
}