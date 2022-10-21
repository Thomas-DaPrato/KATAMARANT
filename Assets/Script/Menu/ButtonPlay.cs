using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlay : MonoBehaviour
{
    public void Play(){
        GameObject donjonManager = Instantiate(Resources.Load("Prefabs/Donjon/DonjonManager") as GameObject);
        donjonManager.name = "DonjonManager";
        DontDestroyOnLoad(donjonManager);
    }
}
