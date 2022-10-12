using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static GameObject listOffensiveAttack;
    public static GameObject listSecretTechnic;

    //public static GameObject invotory;

    public void Awake(){
        listOffensiveAttack = GameObject.Find("ListOffensiveAttack");
        listSecretTechnic = GameObject.Find("ListSecretTechnic");
    }

    public void Start(){
        listOffensiveAttack.SetActive(false);
        listSecretTechnic.SetActive(false);
    }

}
