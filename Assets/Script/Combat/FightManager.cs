using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    public static GameObject listOffensiveAttack;
    public static GameObject listSecretTechnic;
    public static GameObject inventory;

    public static Slider hpPlayer;
    public static Slider hpEnemy;

    public static List<Actions> actionsTurn;

    public static Animator playerAnimator;
    public static Animator enemyAnimator;

    public static bool canClickOnButton = true;
    public static int timeStunt = 0;
    public static int buffStat = 0;
    public static int buffStatTimer = 0;

    public string whosIsDead;

    public static string inWichRoom = "";
    

    public void Awake(){
        InitFightManager();
    }

    

    public static void AdjustPriority(){
        if(actionsTurn[0].GetPriority() > actionsTurn[1].GetPriority()){
            Actions temp = actionsTurn[0];
            actionsTurn[0] = actionsTurn[1];
            actionsTurn[1] = temp;
        }
    }

    public void DoAction(){
        if(canClickOnButton){
            canClickOnButton = false;
            if(timeStunt == 0)
                AdjustPriority();
            StartCoroutine(launchAnimation()); 
        }
        
    }

    public IEnumerator launchAnimation(){
        foreach(Actions action in actionsTurn){
            if(action.GetEntitie() == "Player")
                playerAnimator.SetBool("playerAttacking",true);
            else
                enemyAnimator.SetBool("enemyAttacking",true);
            yield return new WaitForSeconds(1);
            action.DoAction();
            if(action.GetEntitie() == "Player")
                playerAnimator.SetBool("playerAttacking",false);
            else
                enemyAnimator.SetBool("enemyAttacking",false);
            yield return new WaitForSeconds(0.5f);
            if(CheckIfEndOfFight())
                break;
        }
        EndOfTurn();     
        
    }

    public void InitFightManager(){
        listOffensiveAttack = GameObject.Find("ListOffensiveAttack");
        listSecretTechnic = GameObject.Find("ListSecretTechnic");
        inventory = GameObject.Find("Inventory");

        listOffensiveAttack.SetActive(false);
        listSecretTechnic.SetActive(false);
        inventory.SetActive(false);

        whosIsDead = "";

        hpPlayer = GameObject.Find("HP_Player").GetComponent<Slider>();
        hpEnemy = GameObject.Find("HP_Enemy").GetComponent<Slider>();

        GameObject.Find("EnemyDisplay").GetComponent<Image>().sprite = GameObject.FindWithTag("ToFight").GetComponent<SpriteRenderer>().sprite;
        GameObject.Find("EnemyDisplay").GetComponent<Animator>().runtimeAnimatorController = GameObject.FindWithTag("ToFight").GetComponent<Enemies>().animatorController;


        playerAnimator = GameObject.Find("PlayerDisplay").GetComponent<Animator>();
        enemyAnimator = GameObject.Find("EnemyDisplay").GetComponent<Animator>();
        

        hpPlayer.maxValue = GameObject.Find("Player").GetComponent<Player>().maxHp;
        hpPlayer.value = GameObject.Find("Player").GetComponent<Player>().hp;

        hpEnemy.maxValue = GameObject.FindWithTag("ToFight").GetComponent<Enemies>().hp;
        hpEnemy.value = hpEnemy.maxValue;

        actionsTurn = new List<Actions>();
        actionsTurn.Add(new AttackEnemy());

        RoomManager.DisableComponentsInRoom();
        RoomManager.player.SetActive(false);
    }

    public bool CheckIfEndOfFight(){
        if(hpEnemy.value == 0){
            whosIsDead = "Enemy";
            return true;
        }
        else if(hpPlayer.value == 0){
            print("t mort");
            whosIsDead = "Player";
            return true;
        }
        else 
            return false;
    }

    public void EndOfTurn(){
        if(whosIsDead == ""){
            actionsTurn = new List<Actions>();
            if(timeStunt > 0)
                timeStunt -= 1;
            if(timeStunt == 0) 
                actionsTurn.Add(new AttackEnemy());
            if(buffStatTimer > 0)
                buffStatTimer -= 1;
            canClickOnButton = true;
        }
        else if(whosIsDead == "Player"){
            //TO DO
        }
        else{
            print("fin de combat");
            SceneManager.LoadScene(inWichRoom);
        }
    }


}
