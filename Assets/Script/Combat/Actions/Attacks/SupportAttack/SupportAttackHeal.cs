using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupportAttackHeal : Actions
{
    public override void DoAction()
    {
        foreach(Slider slider in FightManager.enemiesHP){
            slider.value += 3;
        }
    }

    public override string GetAnimation()
    {
        return "SupportHealAttack";
    }

    public override string GetEntitie()
    {
        return "Enemy";
    }

    public override int GetPriority()
    {
        return 3;
    }
}
