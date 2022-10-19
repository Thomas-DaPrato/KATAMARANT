using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public static GameObject listOffensiveAttack;
    public static GameObject listSecretTechnic;

    public static GameObject inventory;

    public static Slider hpPlayer;
    public static Slider hpEnemy;

    public static List<Actions> actionsTurn = new List<Actions>();

    public static Animator animator;
    

    public void Awake(){
        listOffensiveAttack = GameObject.Find("ListOffensiveAttack");
        listSecretTechnic = GameObject.Find("ListSecretTechnic");
        inventory = GameObject.Find("Inventory");
        hpPlayer = GameObject.Find("HP_Player").GetComponent<Slider>();
        hpEnemy = GameObject.Find("HP_Enemy").GetComponent<Slider>();
        animator = GameObject.Find("PlayerDisplay").GetComponent<Animator>();
    }

    public void Start(){
        listOffensiveAttack.SetActive(false);
        listSecretTechnic.SetActive(false);
        inventory.SetActive(false);
        GameObject.Find("EnemyDisplay").GetComponent<Image>().sprite = GameObject.FindWithTag("ToFight").GetComponent<SpriteRenderer>().sprite;

        hpPlayer.maxValue = GameObject.Find("Player").GetComponent<Player>().maxHp;
        hpPlayer.value = GameObject.Find("Player").GetComponent<Player>().hp;

        hpEnemy.maxValue = GameObject.FindWithTag("ToFight").GetComponent<Enemies>().hp;
        hpEnemy.value = hpEnemy.maxValue;

        actionsTurn.Add(new AttackEnemy());

        RoomManager.DisableComponentsInRoom();
    }

    public static void AdjustPriority(){
        if(actionsTurn[0].GetPriority() > actionsTurn[1].GetPriority()){
            Actions temp = actionsTurn[0];
            actionsTurn[0] = actionsTurn[1];
            actionsTurn[1] = temp;
        }
    }

    public void DoAction(){
        AdjustPriority();
        StartCoroutine(launchAnimation()); 
    }

    public IEnumerator launchAnimation(){
        foreach(Actions action in actionsTurn){
            if(action.GetEntitie() == "Player")
                animator.SetBool("isAttacking",true);
            yield return new WaitForSeconds(1);
            action.DoAction();
            animator.SetBool("isAttacking",false);
        }
        actionsTurn = new List<Actions>();
    }


}
