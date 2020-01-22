using NUnit.Framework;
using FairyLights;
using System;

namespace NUnitTestProject
{
    [TestFixture]
    public class TestPoint
    {

        [Test]
        public void CreateTest()
        {
            Random rnd = new Random();
            int x = rnd.Next();
            int y = rnd.Next();

            var point = new Point(x, y);

            Assert.AreEqual(x, point.X);
            Assert.AreEqual(y, point.Y);
        }
    }
}
