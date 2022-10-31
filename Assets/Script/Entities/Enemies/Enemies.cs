using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Enemies : MonoBehaviour
{
    public int hp;

    public string typeOfEnemy;

    public AnimatorController animatorController;

    void OnTriggerEnter2D(Collider2D col){
        if(col.name == "Player"){
            if(typeOfEnemy != "lever"){
                LauchFight();
            }
            else{
                if(Player.inventorySpecialObject.Contains("lever"))
                    LauchFight();
                else
                    StartCoroutine(DisplayMsgMissingLever());
            }
            
        }
            
    }

    public void LauchFight(){
        gameObject.tag = "ToFight"; 
        FightManager.typeOfEnemy = typeOfEnemy;
        SceneManager.LoadScene("FightScene");
    }

    public IEnumerator DisplayMsgMissingLever(){
        GameObject.Find("Player").GetComponent<Player>().reaction.SetActive(true);
        GameObject.Find("Player").GetComponent<Player>().reaction.GetComponentInChildren<TextMeshProUGUI>().text = "Il me manque quelque chose";
        yield return new WaitForSeconds(1);
        GameObject.Find("Player").GetComponent<Player>().reaction.SetActive(false);
    }
}
