using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBag : MonoBehaviour
{
    public void DisplayInventory(){
        FightManager.inventoryBag.SetActive(true);
        FightManager.inventorySpecialObject.SetActive(false);
    }
}
