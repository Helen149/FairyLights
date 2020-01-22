using NUnit.Framework;
using FairyLights;
using System;

namespace NUnitTestProject
{
    [TestFixture]
    public class TestLights
    {

        [Test]
        public void CreateTest()
        {
            Random rnd = new Random();
            var point = new Point(rnd.Next(), rnd.Next());
            bool state = rnd.Next()%2==0?true:false;
            int radius = rnd.Next();

            var lights = new Lights(point, state, radius);

            Assert.AreEqual(point, lights.Coordinate);
            Assert.AreEqual(state, lights.StateOn);
            Assert.AreEqual(radius, lights.Radius);
        }
    }
}
