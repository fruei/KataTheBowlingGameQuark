using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingGame : MonoBehaviour
{
    public int turns = 10;
    public int currentPinesCount = 10;
    public int currentShoot = 0;
    public bool spare = false;
    public bool strike = false;
    public int extraShoots = 0;

    public int PlayerMakeShoot() {
        return 2;
    }

    public int GetTotalShootedBowlingPines()
    {
        return (spare || strike) ? SpareOrStrikeThenGetPoints() : (10 - currentPinesCount);
    }

    int SpareOrStrikeThenGetPoints()
    {
        spare = false;
        strike = false;
        return (10 - currentPinesCount) + 10;
    }

    public void PlayerMakesASpare()
    {
        spare = currentShoot == 2 ? true : false;
        extraShoots = CanGetExtraShoots(spare) ? 1 : 0;
    }

    bool CanGetExtraShoots(bool canGet)
    {
        return canGet && turns == 0 && extraShoots == 0;
    }

    public void PlayerMakesAStrike()
    {
        strike = currentShoot == 1 ? true : false;
        extraShoots = CanGetExtraShoots(strike) ? 2 : 1;
    }

    public void EndTurn() {
        turns--;
        currentShoot = 0;
    }
}
