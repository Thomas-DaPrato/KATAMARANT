using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopoInFight : Actions
{
    public GameObject playerDisplay;

    public PopoInFight(GameObject playerDisplay)
    {

        this.playerDisplay = playerDisplay;
    }
    public override void DoAction()
    {
        playerDisplay.GetComponentInChildren<Slider>().value = playerDisplay.GetComponentInChildren<Slider>().value + 8;
    }

    public override int GetPriority()
    {
        return 1;
    }

    public override string GetEntitie()
    {
        return "Player";
    }

    public override string GetAnimation()
    {
        return "PopoInFight";
    }
}