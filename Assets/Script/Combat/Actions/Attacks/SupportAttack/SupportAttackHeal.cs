using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupportAttackHeal : Actions
{
    public override void DoAction()
    {
        foreach(Slider slider in FightManager.enemiesHP){
            if (slider == null)
                continue;
            if(slider.value != 0)
                slider.value += 3;
        }
    }

    public override string GetAnimation()
    {
        return "SupportHealAttack";
    }

    public override string GetEntitie()
    {
        return "Support";
    }

}
