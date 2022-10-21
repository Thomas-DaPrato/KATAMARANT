using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStunt : MonoBehaviour
{
    public void Stunt(){
        FightManager.actionsTurn.Add(new StuntPlayer());
    }
}
