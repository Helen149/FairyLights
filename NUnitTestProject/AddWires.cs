using NUnit.Framework;
using FairyLights;
using System;

namespace NUnitTestProject
{
    [TestFixture]
    public class FindEndX
    {
        [TestCase(0, -5)]
        [TestCase(1, 5)]
        [TestCase(2, 10)]
        [TestCase(3, 5)]
        [TestCase(4, -5)]
        [TestCase(5, -10)]
        public void PositiveTest(int direction, int ans)
        {
            var param = new ParamInModel(20, 20, 0);
            var wire = new Wires(new Point(0, 0), direction, param.Length);

            var result = param.FindEndX(wire);

            Assert.AreEqual(ans, result);
        }

        [TestCase(6)]
        [TestCase(-1)]
        public void NegativeTest(int direction)
        {
            var param = new ParamInModel(20, 20, 0);
            var wire = new Wires(new Point(0, 0), direction, param.Length);

            Assert.Catch<Exception>(() => param.FindEndX(wire));
        }
    }
}
