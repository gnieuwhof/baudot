namespace UnitTests
{
    using nl.gn.Baudot;
    using NUnit.Framework;

    [TestFixture]
    public class BaudotTests
    {
        [Test]
        public void ToCodeLsbFirstAlphabetTest()
        {
            string alphabet =
                "abcdefghijklmnopqrstuvwxyz";

            var expected = new[] {
                new VBit(24), new VBit(19),
                new VBit(14), new VBit(18),
                new VBit(16), new VBit(22),
                new VBit(11), new VBit(5),
                new VBit(12), new VBit(26),
                new VBit(30), new VBit(9),
                new VBit(7), new VBit(6),
                new VBit(3), new VBit(13),
                new VBit(29), new VBit(10),
                new VBit(20), new VBit(1),
                new VBit(28), new VBit(15),
                new VBit(25), new VBit(23),
                new VBit(21), new VBit(17)
            };

            var code = Baudot.ToCode(alphabet, true);

            Assert.AreEqual(expected, code);
        }

        [Test]
        public void ToCodeMsbFirstAlphabetTest()
        {
            string alphabet =
                "abcdefghijklmnopqrstuvwxyz";

            var expected = new[] {
                new VBit(3), new VBit(25),
                new VBit(14), new VBit(9),
                new VBit(1), new VBit(13),
                new VBit(26), new VBit(20),
                new VBit(6), new VBit(11),
                new VBit(15), new VBit(18),
                new VBit(28), new VBit(12),
                new VBit(24), new VBit(22),
                new VBit(23), new VBit(10),
                new VBit(5), new VBit(16),
                new VBit(7), new VBit(30),
                new VBit(19), new VBit(29),
                new VBit(21), new VBit(17)
            };

            var code = Baudot.ToCode(alphabet, false);

            Assert.AreEqual(expected, code);
        }

        [Test]
        public void ToCodeLsbFirstFiguresTest()
        {
            string numeric = "0123456789!$&'()+,-./:=?";

            var expected = new[] {
                new VBit(27), // Shift to figures
                new VBit(13), new VBit(29),
                new VBit(25), new VBit(16),
                new VBit(10), new VBit(1),
                new VBit(21), new VBit(28),
                new VBit(12), new VBit(3),
                new VBit(22), new VBit(5),
                new VBit(11), new VBit(20),
                new VBit(30), new VBit(9),
                new VBit(17), new VBit(6),
                new VBit(24), new VBit(7),
                new VBit(23), new VBit(14),
                new VBit(15), new VBit(19)
            };

            var code = Baudot.ToCode(numeric, true);

            Assert.AreEqual(expected, code);
        }

        [Test]
        public void ToCodeMsbFirstFiguresTest()
        {
            string numeric = "0123456789!$&'()+,-./:=?";

            var expected = new[] {
                new VBit(27), // Shift to figures
                new VBit(22), new VBit(23),
                new VBit(19), new VBit(1),
                new VBit(10), new VBit(16),
                new VBit(21), new VBit(7),
                new VBit(6), new VBit(24),
                new VBit(13), new VBit(20),
                new VBit(26), new VBit(5),
                new VBit(15), new VBit(18),
                new VBit(17), new VBit(12),
                new VBit(3), new VBit(28),
                new VBit(29), new VBit(14),
                new VBit(30), new VBit(25)
            };

            var code = Baudot.ToCode(numeric, false);

            Assert.AreEqual(expected, code);
        }

        [Test]
        public void ToCodeLsbFirstDoubleShiftTest()
        {
            string bothShiftChars = "\0\r\n ";

            var expected = new[] {
                new VBit(0), new VBit(2),
                new VBit(8), new VBit(4)
            };

            var code = Baudot.ToCode(bothShiftChars, true);

            Assert.AreEqual(expected, code);
        }

        [Test]
        public void ToCodeMsbFirstDoubleShiftTest()
        {
            string bothShiftChars = "\0\r\n ";

            var expected = new[] {
                new VBit(0), new VBit(8),
                new VBit(2), new VBit(4)
            };

            var code = Baudot.ToCode(bothShiftChars, false);

            Assert.AreEqual(expected, code);
        }

        [Test]
        public void ToCodeLsbFirstDoubleShiftInFiguresTest()
        {
            string bothShiftChars = "-\0\r\n ";

            var expected = new[] {
                new VBit(27), // Shift to figures.
                new VBit(24), // -
                new VBit(0), new VBit(2),
                new VBit(8), new VBit(4)
            };

            var code = Baudot.ToCode(bothShiftChars, true);

            Assert.AreEqual(expected, code);
        }

        [Test]
        public void ToCodeMsbFirstDoubleShiftInFiguresTest()
        {
            string bothShiftChars = "-\0\r\n ";

            var expected = new[] {
                new VBit(27), // Shift to figures.
                new VBit(3), // -
                new VBit(0), new VBit(8),
                new VBit(2), new VBit(4)
            };

            var code = Baudot.ToCode(bothShiftChars, false);

            Assert.AreEqual(expected, code);
        }
    }
}
