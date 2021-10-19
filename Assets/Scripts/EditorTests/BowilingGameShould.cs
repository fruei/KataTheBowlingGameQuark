using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BowilingGameShould
    {
        GameObject go;
        BowlingGame _bowlingGame;

        [SetUp]
        public void Setup()
        {
            go = new GameObject();
            _bowlingGame = go.AddComponent<BowlingGame>();
        }

        [Test]
        public void Have10Turns()
        {
            /// Assert
            Assert.AreEqual(10, _bowlingGame.turns);
        }

        [Test]
        public void Have10BowlingsEachTurn()
        {
            /// Assert
            Assert.AreEqual(10, _bowlingGame.currentPinesCount);
        }

        [Test]
        public void PlayerMake2ShootsEachTurn()
        {
            /// Act
            var result = _bowlingGame.PlayerMakeShoot();

            /// Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void PlayerDontShoot10BowlingPines_TotalTurnPointsAreTotalBowlinPinesShooted()
        {
            /// Arrange
            _bowlingGame
            /// Act
            var result = _bowlingGame.GetTotalShootedBowlingPines();

            /// Assert
            Assert.AreEqual();
        }

    }
}
