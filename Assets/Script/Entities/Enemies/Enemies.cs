using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    public int hp;

    void OnTriggerEnter2D(Collider2D col){
        print(col.name);
        if(col.name == "Player")
            print("combat");
            gameObject.tag = "ToFight";
            SceneManager.LoadScene("scene_combat");
    }
}
