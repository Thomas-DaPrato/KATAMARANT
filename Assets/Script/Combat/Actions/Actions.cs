using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actions 
{
    public abstract int GetPriority();
    public abstract void DoAction();

    public abstract string GetEntitie();

}