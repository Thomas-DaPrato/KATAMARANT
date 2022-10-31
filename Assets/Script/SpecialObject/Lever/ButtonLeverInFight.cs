using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonLeverInFight : MonoBehaviour
{
    public Sprite sprite;
    public void LeverInFight(){
        FightManager.actionsTurn.Add(new LeverInFight(sprite));
    }
}
