using NUnit.Framework;
using System;
using IIG.BinaryFlag;

namespace Lab2
{
    [TestFixture()]
    public class Test
    {
        [Test]
        public void constructorWithZeroShouldThrow()
        {

            try
            {
                MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(0, true);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains("Specified argument was out of the range of valid values", e.Message);
                return;
            }

            Assert.Fail("The exception was not thrown");
        }

        [Test]
        public void constructorWithOne()
        {
            Assert.DoesNotThrow(() => new MultipleBinaryFlag(1, false));
        }

        [Test]
        public void constructorWithMaxUlong()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(18446744073709551615, true);

            Assert.True(binaryFlag.GetFlag());
        }

        [Test]
        public void constructorWithValue()
        {
            Assert.DoesNotThrow(() => new MultipleBinaryFlag(115));
        }

        [Test]
        public void getShouldReturnFalse()
        {
            MultipleBinaryFlag multipleBinaryFlag = new MultipleBinaryFlag(25, false);
            Assert.False(multipleBinaryFlag.GetFlag());
        }

        [Test]
        public void getShouldReturnTrue()
        {
            MultipleBinaryFlag multipleBinaryFlag = new MultipleBinaryFlag(25, true);
            Assert.True(multipleBinaryFlag.GetFlag());
        }

        [Test]
        public void setFlagShouldThrow()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(10, false);

            try
            {
                binaryFlag.SetFlag(10);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains("Specified argument was out of the range of valid values", e.Message);
                return;
            }

            Assert.Fail("The exception was not thrown");
        }

        [Test]
        public void validPositionsGetShouldReturnFalse()
        {
            MultipleBinaryFlag multipleBinaryFlag = new MultipleBinaryFlag(10, false);

            multipleBinaryFlag.SetFlag(9);

            Assert.False(multipleBinaryFlag.GetFlag());

        }

        [Test]
        public void setAllPositionsShouldReturnTrue()
        {
            MultipleBinaryFlag multipleBinaryFlag = new MultipleBinaryFlag(10, false);

            for (ulong i = 0; i < 10; i++)
            {
                multipleBinaryFlag.SetFlag(i);
            }

            Assert.True(multipleBinaryFlag.GetFlag());

        }

        [Test]
        public void resetValidPositionsGetShouldReturnFalse()
        {
            MultipleBinaryFlag multipleBinaryFlag = new MultipleBinaryFlag(10);

            multipleBinaryFlag.ResetFlag(5);

            Assert.False(multipleBinaryFlag.GetFlag());

        }

        [Test]
        public void resetShouldThrow()
        {
            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(10, true);

            try
            {
                binaryFlag.ResetFlag(10);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains("Specified argument was out of the range of valid values", e.Message);
                return;
            }

            Assert.Fail("The exception was not thrown");
        }

        [Test]
        public void resetAllPositionsShouldReturnFlase()
        {
            MultipleBinaryFlag multipleBinaryFlag = new MultipleBinaryFlag(10, true);

            for (ulong i = 0; i < 10; i++)
            {
                multipleBinaryFlag.ResetFlag(i);
            }

            Assert.False(multipleBinaryFlag.GetFlag());

        }

        [Test]
        public void disposeShouldSetFlagToNull()
        {

            MultipleBinaryFlag binaryFlag = new MultipleBinaryFlag(10, true);

            binaryFlag.Dispose();

            Assert.Null(binaryFlag);
        }

    }
}