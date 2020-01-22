using NUnit.Framework;
using FairyLights;
using System;

namespace NUnitTestProject
{
    [TestFixture]
    public class TestGameModel
    {
        [TestCase(0, 1)]
        [TestCase(1, 7)]
        [TestCase(2, 19)]
        public void CreateTestPositive(int rank, int countLights)
        {
            Random rnd = new Random();
            int wight = rnd.Next();
            int height = rnd.Next();

            var game = new GameModel(wight, height, rank);

            Assert.AreEqual(6, GameModel.FormFactor);
            Assert.AreEqual(countLights, game.Lights.Length);
            Assert.That(game.Lights, Is.Not.Null);
            Assert.That(game.Lights, Is.Unique);
            Assert.That(game.Param, Is.Not.Null);
        }

        [TestCase(-1)]
        [TestCase(-5)]
        public void CreateTestNegative(int rank)
        {
            Random rnd = new Random();
            int wight = rnd.Next();
            int height = rnd.Next();

            Assert.Catch<Exception>(() => new GameModel(wight, height, rank));
        }
    }
}
