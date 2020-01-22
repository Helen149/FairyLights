using NUnit.Framework;
using FairyLights;

namespace NUnitTestProject
{
    [TestFixture]
    public class TestAddWires
    {
        [TestCase(1)]
        [TestCase(5)]
        public void CreateTest(int countWires)
        {
            var param = new ParamInModel(20, 20, 0);
            var light = new LightsInModel(new Point(0, 0), true, 5);

            for(int i=0; i<countWires; i++)
                light.AddWires(0, param);

            Assert.That(light.Wires, Is.All.Not.Null);
            Assert.That(light.Wires, Is.All.TypeOf(typeof(Wires)));
        }

        [Test]
        public void CheckParamWires()
        {
            var param = new ParamInModel(20, 20, 0);
            var light = new LightsInModel(new Point(0, 0), true, 5);
            var direction = 0;
            
            light.AddWires(direction, param);

            Assert.AreEqual(light.Light.Coordinate, light.Wires[0].CoordinateStart);
            Assert.AreEqual(direction, light.Wires[0].Direction);
            Assert.AreEqual(param.Length, light.Wires[0].Length);
        }
    }
}
