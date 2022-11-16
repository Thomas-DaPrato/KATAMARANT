using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    
    public static List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> enemiesDisplay;

    //Turn
    public List<Actions> actions = new List<Actions>();

    //Animator
    public static Animator playerAnimator;

    public static Animator enemy1Animator;
    public static Animator enemy2Animator;
    public static Animator enemy3Animator;

    public int wichEnemyToFight;
    public int wichEnemyAttack;


    //variables
    public static bool endOfFightTuto = false;
    public static bool canClickOnButton = false;

    public enum fight {   
        oneEnemy,
        twoEnemies,
        threeEnemies
    };

    public static fight howManyEnemy;

    public void InitFightManager(){
        InitDisplayEnemies();
    }

    public void InitDisplayEnemies(){
        for(int i = 0; i < enemies.Count; i += 1)
            enemiesDisplay[i].GetComponent<SpriteRenderer>().sprite = enemies[i].GetComponent<SpriteRenderer>().sprite;
    }

    public void InitAnimator(){
        switch (howManyEnemy){
            case fight.oneEnemy:
                enemiesDisplay[0].GetComponent<Animator>().runtimeAnimatorController = enemies[0].GetComponent<Enemies>().animatorController[0];
                break;
            case fight.twoEnemies:
                enemiesDisplay[0].GetComponent<Animator>().runtimeAnimatorController = enemies[0].GetComponent<Enemies>().animatorController[1];
                enemiesDisplay[1].GetComponent<Animator>().runtimeAnimatorController = enemies[1].GetComponent<Enemies>().animatorController[1];
                break;
            case fight.threeEnemies:
                enemiesDisplay[0].GetComponent<Animator>().runtimeAnimatorController = enemies[0].GetComponent<Enemies>().animatorController[2];
                enemiesDisplay[1].GetComponent<Animator>().runtimeAnimatorController = enemies[1].GetComponent<Enemies>().animatorController[2];
                enemiesDisplay[2].GetComponent<Animator>().runtimeAnimatorController = enemies[2].GetComponent<Enemies>().animatorController[2];
                break;
        }
        enemy1Animator = enemiesDisplay[0].GetComponent<Animator>();
        enemy2Animator = enemiesDisplay[1].GetComponent<Animator>();
        enemy3Animator = enemiesDisplay[2].GetComponent<Animator>();
    }

    public void AdjustActionsPriority(){
        if (actions[0].GetPriority() > actions[1].GetPriority()){
            Actions temp = actions[0];
            actions[0] = actions[1];
            actions[1] = temp;
        }
    }

    /*
    public void DoActions(){
        if (endOfFightTuto && canClickOnButton)
        {
            canClickOnButton = false;
            if (timeStunt == 0)
                AdjustActionsPriority();
            StartCoroutine(launchAnimation());
        }

    }

    public IEnumerator launchAnimation()
    {
        foreach (Actions action in actions)
        {
            if (action.GetEntitie() == "Player")
                playerAnimator.SetBool(action.GetAnimation(), true);
            else
                if (enemyAnimator != null)
                enemyAnimator.SetBool("enemyAttacking", true);
            yield return new WaitForSeconds(1);
            action.DoAction();
            yield return new WaitForSeconds(0.5f);
            if (CheckIfEndOfFight())
                break;
        }
        EndOfTurn();

    }
        */

}
