using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BowlingGamev2 : MonoBehaviour
{
    public int maxturns = 10;
    public int pinesPerTurn = 10;
    public int availablesRolls = 2;
    public int currentPoints;
    public int currentTurn;
    public TextMeshProUGUI currentPointsUIText;

    public void Roll(int pines)
    {
        pinesPerTurn -= pines;
        currentPoints += pines;
        currentPointsUIText.text = currentPoints.ToString();
        availablesRolls--;
    }
}
