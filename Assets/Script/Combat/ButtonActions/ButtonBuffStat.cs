using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBuffStat : MonoBehaviour
{
    public void BuffStat(){
        FightManager.actionsTurn.Add(new BuffStat());
    }
}
