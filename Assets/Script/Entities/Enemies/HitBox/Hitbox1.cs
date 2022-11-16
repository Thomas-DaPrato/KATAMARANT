using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Hitbox1 : MonoBehaviour
{
    public Enemies enemy;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            if (enemy.typeOfEnemy != "lever")
            {
                LauchFight();
            }
            else
            {
                if (Player.inventorySpecialObject.Contains("lever"))
                    LauchFight();
                else
                    StartCoroutine(DisplayMsgMissingLever());
            }
        }
    }

    public void LauchFight()
    {
        gameObject.tag = "ToFight";
        FightManager1Vs1.typeOfEnemy = enemy.typeOfEnemy;
        FightManager1Vs1.enemyToFight = enemy.gameObject;
        SceneManager.LoadScene("FightScene1Vs1");
    }

    public IEnumerator DisplayMsgMissingLever()
    {
        GameObject.Find("Player").GetComponent<Player>().reaction.SetActive(true);
        GameObject.Find("Player").GetComponent<Player>().reaction.GetComponentInChildren<TextMeshProUGUI>().text = "Il me manque quelque chose";
        yield return new WaitForSeconds(1);
        GameObject.Find("Player").GetComponent<Player>().reaction.SetActive(false);
    }
}
