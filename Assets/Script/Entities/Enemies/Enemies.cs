using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    public int hp;

    public string typeOfEnemy;

    public AnimatorController animatorController;

    void OnTriggerEnter2D(Collider2D col){
        if(col.name == "Player")
            print("combat");
            gameObject.tag = "ToFight"; 
            FightManager.typeOfEnemy = typeOfEnemy;
            SceneManager.LoadScene("FightScene");
    }
}
