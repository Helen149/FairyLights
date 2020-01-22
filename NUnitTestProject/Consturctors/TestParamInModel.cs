using NUnit.Framework;
using FairyLights;
using System;

namespace NUnitTestProject
{
    [TestFixture]
    public class TestParamInModel
    {

        [TestCase(800, 800, 2, 80, 13)]
        [TestCase(800, 800, 5, 36, 12)]
        [TestCase(800, 800, 11, 16, 5)]
        [TestCase(1000, 800, 11, 16, 5)]
        [TestCase(0, 0, 0, 0, 0)]
        public void CreateTest(int wight,int height, int rank, int length, int radius)
        {
            var param = new ParamInModel(wight, height, rank);

            Assert.AreEqual(length, param.Length);
            Assert.AreEqual(radius, param.Radius);
            Assert.AreEqual(6, param.Offset.Length);
            Assert.That(param.Offset, Is.All.Not.Null);
            Assert.That(param.Offset, Is.Unique);
        }
    }
}