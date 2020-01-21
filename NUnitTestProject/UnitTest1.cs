using NUnit.Framework;
using FairyLights;

namespace NUnitTestProject
{
    [TestFixture]
    public class Tests
    {
        [TestCase(0,-5)]
        public void Test1(int direction, int ans)
        {
            var param = new ParamInModel(20,20,0);
            var wire = new Wires(new Point(0, 0), direction, param.Length);

            var result = param.FindEndX(wire);

            Assert.AreEqual(ans, result);
        }
    }
}