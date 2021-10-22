using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

namespace Tests
{
    public class BowlingGameShouldv2
    {
        GameObject go;
        BowlingGamev2 bo;

        [SetUp]
        public void SetUp()
        {
            go = new GameObject();
            TextMeshProUGUI currentPointsUGUI = go.AddComponent<TextMeshProUGUI>();
            bo = go.AddComponent<BowlingGamev2>();
            bo.currentPointsUIText = currentPointsUGUI;
        }
        [Test]
        public void Have10Turns()
        {
            // Assert
            Assert.AreEqual(10, bo.maxturns);
        }
        [Test]
        public void Have10Pines()
        {
            // Assert
            Assert.AreEqual(10, bo.pinesPerTurn);
        }
        [Test]
        public void Have2AvailableRollsPerTurn()
        {
            // Assert
            Assert.AreEqual(2, bo.availablesRolls);
        }
        [Test]
        public void PlayerMakeRollAndTeardownNPines()
        {
            // When
            bo.Roll(4);

            // Then
            Assert.AreEqual(6, bo.pinesPerTurn);
        }
        [Test]
        public void PlayerMakeRollAndTeardown7Pines()
        {
            // When
            bo.Roll(7);

            // Then
            Assert.AreEqual(3, bo.pinesPerTurn);
        }
        [Test]
        public void PlayerMake2Roll_DontTeardownAllPines_AndGetTotalPoitnsEqualToTeardownPines()
        {
            // When
            bo.Roll(6);
            bo.Roll(3);

            // Then
            Assert.AreEqual(9, bo.currentPoints);
        }

        [Test]
        public void PlayerMakeRoll_UIPuntajeActualResponseCurrentPoints()
        {
            // When
            bo.Roll(6);

            // Then
            Assert.AreEqual("6", bo.currentPointsUIText.text);
        }
        [Test]
        public void PlayerMakeRoll_TeardownAvailableRolls()
        {
            // Given
            bo.availablesRolls = 2;

            // When
            bo.Roll(6);

            // Then
            Assert.AreEqual(1, bo.availablesRolls);
        }
        [Test]
        public void PlayerMake2Roll_CurrentTurnPlusOne()
        {
            // Given
            bo.currentTurn = 4;
            bo.availablesRolls = 2;

            // When
            bo.Roll(6);
            bo.Roll(6);

            // Then
            Assert.AreEqual(5, bo.currentTurn);
        }
    }        
}
