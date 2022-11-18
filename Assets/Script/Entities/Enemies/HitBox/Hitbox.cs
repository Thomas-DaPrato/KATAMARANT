using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Hitbox : MonoBehaviour
{
    public List<GameObject> enemies;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            foreach(GameObject enemy in enemies){
                if (enemy.GetComponent<Enemies>().typeOfEnemy != "lever")
                    LauchFight(col.gameObject);
                else{
                    if (Player.inventorySpecialObject.Contains("lever"))
                        LauchFight(col.gameObject);
                    else
                        StartCoroutine(DisplayMsgMissingLever());
                }
            }
            
        }
    }

    public void LauchFight(GameObject player)
    {
        gameObject.tag = "ToFight";
        FightManager.player = player;
        FightManager.enemies = enemies;
        switch (enemies.Count){
            case 1:
                FightManager.howManyEnemy = FightManager.fight.oneEnemy;
                SceneManager.LoadScene("FightScene1Vs1");
                break;
            case 2:
                FightManager.howManyEnemy = FightManager.fight.twoEnemies;
                SceneManager.LoadScene("FightScene1Vs2");
                break;
            case 3:
                FightManager.howManyEnemy = FightManager.fight.threeEnemies;
                SceneManager.LoadScene("FightScene1Vs3");
                break;
        }
        
    }

    public IEnumerator DisplayMsgMissingLever()
    {
        GameObject.Find("Player").GetComponent<Player>().reaction.SetActive(true);
        GameObject.Find("Player").GetComponent<Player>().reaction.GetComponentInChildren<TextMeshProUGUI>().text = "Il me manque quelque chose";
        yield return new WaitForSeconds(1);
        GameObject.Find("Player").GetComponent<Player>().reaction.SetActive(false);
    }
}
