using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PassiveMob : MonoBehaviour
{
    public List<string> reactions;
    
    public void OnTriggerEnter2D(Collider2D col){
        if(col.name == "Player"){
            GameObject.Find("Player").GetComponent<Player>().reaction.SetActive(true);
            GameObject.Find("Player").GetComponent<Player>().reaction.GetComponentInChildren<TextMeshProUGUI>().text = reactions[Random.Range(0,reactions.Count)];
        }
        
    }

    public void OnTriggerExit2D(Collider2D col){
        GameObject.Find("Player").GetComponent<Player>().reaction.SetActive(false);
    }

}
