using NUnit.Framework;
using FairyLights;

namespace NUnitTestProject
{
    [TestFixture]
    public class TestDefinitionLinks
    {
        [TestCase(0, 3, 0, 5)]
        [TestCase(9, 5, 2, 5)]
        [TestCase(18, 3, 4, 5)]
        [TestCase(0, 3, 0, 3)]
        public void PositiveTestCreate(int numberLight, int countInRow, int row, int countRow)
        {
            var light = new LightsInModel(new Point(0,0), true, 5);

            light.DefinitionLinks(numberLight,countInRow,row,countInRow);

            // Проверяем, что в массиве нет пустых элементов
            Assert.That(light.Links, Is.All.Not.Null);
            // Проверяем уникальность                 
            Assert.That(light.Links, Is.Unique);
        }

        [TestCase(-1,-1, -1, -1)]
        [TestCase(0, 0, 0, 0)]
        [TestCase(0, 0, 0, 1)]
        [TestCase(0, 0, 0, 2)]
        [TestCase(0, 0, 0, 3)]
        [TestCase(0, 0, 0, 4)]
        [TestCase(0, 0, 0, 5)]
        [TestCase(0, 1, 0, 1)]
        [TestCase(0, 2, 0, 2)]
        [TestCase(0, 2, 0, 3)]
        public void NegativeTestCreate(int numberLight, int countInRow, int row, int countRow)
        {
            var light = new LightsInModel(new Point(0, 0), true, 5);

            light.DefinitionLinks(numberLight, countInRow, row, countInRow);

            Assert.That(light.Links, Is.All.Not.Null);               
            Assert.That(light.Links, Is.Not.Unique);
        }

        [TestCase(0, 5, 4, 5)]
        [TestCase(2, 5, 4, 5)]
        [TestCase(3, 5, 3, 4)]
        [TestCase(5, 5, 3, 4)]
        public void TopLinkChecking(int row, int countRow, int link0, int link1)
        {
            var light = new LightsInModel(new Point(0, 0), true, 5);

            light.DefinitionLinks(9, 5, row, countRow);

            Assert.AreEqual(link0, light.Links[0]);
            Assert.AreEqual(link1, light.Links[1]);
        }

        [TestCase(0, 5, 15, 14)]
        [TestCase(2, 5, 14, 13)]
        [TestCase(3, 5, 14, 13)]
        [TestCase(5, 5, 14, 13)]
        public void BottomLinkChecking(int row, int countRow, int link3, int link4)
        {
            var light = new LightsInModel(new Point(0, 0), true, 5);

            light.DefinitionLinks(9, 5, row, countRow);

            Assert.AreEqual(link3, light.Links[3]);
            Assert.AreEqual(link4, light.Links[4]);
        }

        [TestCase(0, 1, -1)]
        [TestCase(9, 10, 8)]
        [TestCase(18, 19, 17)]
        public void MidleLinkChecking(int numberLight, int link2, int link5)
        {
            var light = new LightsInModel(new Point(0, 0), true, 5);

            light.DefinitionLinks(numberLight, 3, 0, 5);

            Assert.AreEqual(link2, light.Links[2]);
            Assert.AreEqual(link5, light.Links[5]);
        }
    }
}
