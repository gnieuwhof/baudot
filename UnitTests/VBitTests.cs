namespace UnitTests
{
    using nl.gn.Baudot;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class VBitTests
    {
        private static VBit CastCreateVBit(int val)
        {
            return (VBit)val;
        }


        [Test]
        public void TestDefaultVBit()
        {
            var vbit = new VBit();

            Assert.AreEqual(default(byte), vbit.Value);
        }

        [Test]
        public void TestCreateVBit()
        {
            var vbit = CastCreateVBit(22);

            Assert.AreEqual(22, vbit.Value);
        }

        [Test]
        public void TestOverflowVBit()
        {
            Assert.Throws<ArgumentException>(() => CastCreateVBit(32));
        }

        [Test]
        public void TestNegativeVBit()
        {
            Assert.Throws<ArgumentException>(() => CastCreateVBit(-1));
        }

        [Test]
        public void TestVBitEquals()
        {
            var a = (VBit)11;
            var b = new VBit(11);

            Assert.IsTrue(a.Equals(b));
        }

        [Test]
        public void TestVBitEqualsItself()
        {
            var a = (VBit)19;

            Assert.IsTrue(a.Equals(a));
        }

        [Test]
        public void TestVBitEqualsNull()
        {
            var a = (VBit)7;

            Assert.IsFalse(a.Equals(null));
        }

        [Test]
        public void TestVBitDoubleEquals()
        {
            var a = (VBit)28;
            var b = new VBit(28);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
        }

        [Test]
        public void TestVBitTripleEquals()
        {
            var a = (VBit)0;
            var b = new VBit();
            var c = new VBit(0);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(c));
            Assert.IsTrue(a.Equals(c));
        }

        [Test]
        public void TestVBitEqualsOperator()
        {
            var a = (VBit)3;
            var b = new VBit(3);

            Assert.IsTrue(a == b);
        }

        [Test]
        public void TestVBitNegativeEqualsOperator()
        {
            var a = (VBit)3;
            var b = new VBit(21);

            Assert.IsFalse(a == b);
        }

        [Test]
        public void TestVBitNotEqualsOperator()
        {
            var a = (VBit)30;
            var b = new VBit(14);

            Assert.IsTrue(a != b);
        }

        [Test]
        public void TestVBitNegativeNotEqualsOperator()
        {
            var a = (VBit)30;
            var b = new VBit(30);

            Assert.IsFalse(a != b);
        }
    }
}
