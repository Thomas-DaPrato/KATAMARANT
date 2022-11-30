using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffStat : Actions
{
    public override void DoAction()
    {
        FightManager.buffStatPlayer = 2;
        FightManager.buffStatPlayerTimer = 3;
        GameObject.Find("PlayerDisplay").transform.GetChild(1).GetComponent<ChangeStatus>().EnableStatus();
        GameObject.Find("PlayerDisplay").transform.GetChild(1).GetComponent<ChangeStatus>().ChangeStatusToBuff();
    }

    public override string GetEntitie()
    {
        return "Player";
    }

    public override string GetAnimation()
    {
        return "BuffAttack";
    }
}
