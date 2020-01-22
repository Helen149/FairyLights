using NUnit.Framework;
using FairyLights;
using System;

namespace NUnitTestProject
{
    [TestFixture]
    public class TestFindEndY
    {
        [TestCase(0, -10)]
        [TestCase(1, -10)]
        [TestCase(2, 0)]
        [TestCase(3, 10)]
        [TestCase(4, 10)]
        [TestCase(5, 0)]
        public void PositiveTest(int direction, int ans)
        {
            var param = new ParamInModel(20, 20, 0);
            var wire = new Wires(new Point(0, 0), direction, param.Length);

            var result = param.FindEndY(wire);

            Assert.AreEqual(ans, result);
        }

        [TestCase(6)]
        [TestCase(-1)]
        public void NegativeTest(int direction)
        {
            var param = new ParamInModel(20, 20, 0);
            var wire = new Wires(new Point(0, 0), direction, param.Length);

            Assert.Catch<Exception>(() => param.FindEndY(wire));
        }
    }
}
