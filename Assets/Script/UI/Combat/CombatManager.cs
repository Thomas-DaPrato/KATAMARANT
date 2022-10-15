using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public static GameObject listOffensiveAttack;
    public static GameObject listSecretTechnic;

    public static GameObject inventory;

    public void Awake(){
        listOffensiveAttack = GameObject.Find("ListOffensiveAttack");
        listSecretTechnic = GameObject.Find("ListSecretTechnic");
        inventory = GameObject.Find("Inventory");
    }

    public void Start(){
        listOffensiveAttack.SetActive(false);
        listSecretTechnic.SetActive(false);
        inventory.SetActive(false);
        GameObject.Find("EnemyDisplay").GetComponent<Image>().sprite = GameObject.FindWithTag("ToFight").GetComponent<SpriteRenderer>().sprite;
        RoomManager.DisableComponentsInRoom();
    }

}
