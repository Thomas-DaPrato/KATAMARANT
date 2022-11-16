using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Hitbox3 : MonoBehaviour
{
    public Enemies enemy1;
    public Enemies enemy2;
    public Enemies enemy3;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
            LauchFight();
    }

    public void LauchFight()
    {
        gameObject.tag = "ToFight";
        FightManager1Vs3.enemies.Add(enemy1.gameObject);
        FightManager1Vs3.enemies.Add(enemy2.gameObject);
        FightManager1Vs3.enemies.Add(enemy3.gameObject);
        SceneManager.LoadScene("FightScene1Vs3");
    }

}
