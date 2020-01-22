using NUnit.Framework;
using FairyLights;
using System;

namespace NUnitTestProject
{
    [TestFixture]
    public class TestLightsInModel
    {

        [Test]
        public void CreateTest()
        {
            Random rnd = new Random();
            var point = new Point(rnd.Next(), rnd.Next());
            bool state = rnd.Next() % 2 == 0 ? true : false;
            int radius = rnd.Next();

            var light = new LightsInModel(point, state, radius);

            Assert.AreEqual(point, light.Light.Coordinate);
            Assert.AreEqual(state, light.Light.StateOn);
            Assert.AreEqual(radius, light.Light.Radius);
            Assert.AreEqual(false, light.Involvement);
            Assert.AreEqual(6, light.Links.Length);
            Assert.That(light.Wires, Is.Empty);
        }
    }
}
