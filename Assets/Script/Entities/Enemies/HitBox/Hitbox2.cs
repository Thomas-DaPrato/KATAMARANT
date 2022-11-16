using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Hitbox2 : MonoBehaviour
{
    public Enemies enemy1;
    public Enemies enemy2;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
            LauchFight();
    }

    public void LauchFight()
    {
        gameObject.tag = "ToFight";
        FightManager1Vs2.enemies.Add(enemy1.gameObject);
        FightManager1Vs2.enemies.Add(enemy2.gameObject);
        SceneManager.LoadScene("FightScene1Vs2");
    }

}
