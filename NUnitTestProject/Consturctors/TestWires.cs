using NUnit.Framework;
using FairyLights;
using System;

namespace NUnitTestProject
{
    [TestFixture]
    public class TestWires
    {

        [Test]
        public void CreateTest()
        {
            Random rnd = new Random();
            var point = new Point(rnd.Next(), rnd.Next());
            int direction = rnd.Next();
            int length = rnd.Next();

            var wires = new Wires(point, direction,length);

            Assert.AreEqual(point, wires.CoordinateStart);
            Assert.AreEqual(direction, wires.Direction);
            Assert.AreEqual(length, wires.Length);
        }
    }
}

