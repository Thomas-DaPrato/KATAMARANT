using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonLeverInFight : MonoBehaviour
{
    public Sprite sprite;
    public void LeverInFight(){
        FightManager1Vs1.actionsTurn.Add(new LeverInFight(sprite));
    }
}
