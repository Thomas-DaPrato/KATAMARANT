using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : Actions
{
    public int priority = 5;

    public override void DoAction()
    {
        CombatManager.hpPlayer.value = CombatManager.hpPlayer.value - 3;
        GameObject.Find("PlayerDisplay").GetComponent<Animator>().SetBool("isAttacking",true);
    }

    public override int GetPriority()
    {
        return priority;
    }
}
