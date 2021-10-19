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
        public void PlayerDontShoot10BowlingPines_TotalTurnPointsAreTotalShootedBowlingPines()
        {
            /// Arrange
            _bowlingGame.currentPinesCount = 8;

            /// Act
            var result = _bowlingGame.GetTotalShootedBowlingPines();

            /// Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void PlayerMakesASpare_TotalTurnPointsAre10PlusTotalShootedBowlingPinesInTheNextTurn()
        {
            /// Arrange
            _bowlingGame.currentShoot = 2;
            _bowlingGame.PlayerMakesASpare();
            _bowlingGame.currentPinesCount = 6;

            /// Act
            var result = _bowlingGame.GetTotalShootedBowlingPines();

            /// Assert
            Assert.AreEqual(14, result);
        }

        [Test]
        public void PlayerMakesAStrike_TurnsEndThen_TotalTurnPointsAre10PlusTotalShootedBowlingPinesInTheNext2Turns()
        {
            /// Arrange
            _bowlingGame.currentShoot = 1;
            _bowlingGame.PlayerMakesAStrike();
            _bowlingGame.EndTurn();

            /// Act
            _bowlingGame.currentPinesCount = 3;
            var resultTurn1 = _bowlingGame.GetTotalShootedBowlingPines();
            _bowlingGame.currentPinesCount = 8;
            var resultTurn2 = _bowlingGame.GetTotalShootedBowlingPines();

            /// Assert
            Assert.AreEqual(19, resultTurn1 + resultTurn2);
        }

        [Test]
        public void PlayerMakesStrikeInLastTurn_ThenGet2ExtraShootsForTheTurn()
        {
            /// Arrange
            _bowlingGame.turns = 0;
            _bowlingGame.currentShoot = 1;
            _bowlingGame.PlayerMakesAStrike();

            /// Act
            var result = _bowlingGame.extraShoots;

            /// Assert
            Assert.IsTrue(_bowlingGame.turns == 0, $"Expected turn 0, but was {_bowlingGame.turns}");
            Assert.AreEqual(2, result);
        }

        [Test]
        public void PlayerMakesSpareInLastTurn_ThenGet1ExtraShootsForTheTurn()
        {
            /// Arrange
            _bowlingGame.turns = 0;
            _bowlingGame.currentShoot = 2;
            _bowlingGame.PlayerMakesASpare();

            /// Act
            var result = _bowlingGame.extraShoots;

            /// Assert
            Assert.IsTrue(_bowlingGame.turns == 0, $"Expected turn 0, but was {_bowlingGame.turns}");
            Assert.AreEqual(1, result);
        }

        [Test]
        public void PlayerMakesStrikeInTheBonusTurn_DontGet2ExtraShootsForTheTurn()
        {
            /// Arrange
            _bowlingGame.turns = 0;
            _bowlingGame.currentShoot = 1;
            _bowlingGame.extraShoots=2;

            /// Act
            _bowlingGame.PlayerMakesAStrike();
            var result = _bowlingGame.extraShoots;

            /// Assert
            Assert.IsTrue(_bowlingGame.turns == 0, $"Expected turn 0, but was {_bowlingGame.turns}");
            Assert.AreEqual(1, result);
        }
    }
}
