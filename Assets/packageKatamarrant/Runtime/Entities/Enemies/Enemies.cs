using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Enemies : MonoBehaviour
{
    public int hp;

    public string typeOfEnemy;

    public List<RuntimeAnimatorController> animatorsController;

    public int order;

    public List<Actions> enemyActions = new List<Actions>();

    public int percentageNormalAttack;

    public Sprite sprite;

    public bool canTakeDamage;

    public void Start(){
        switch (typeOfEnemy){
            case "Basic":
                enemyActions.Add(new BasicNormalAttack());
                enemyActions.Add(new BasicBuffStat());
                break;
            case "Support":
                enemyActions.Add(new SupportAttack());
                enemyActions.Add(new SupportAttackHeal());
                break;
            case "Tank":
                enemyActions.Add(new TankNormalAttack());
                enemyActions.Add(new TankDevastingAttack());
                break;
        }
    }

    public Actions GetAction(int buffIsActive){
        int i = Random.Range(0, 100);
        if (buffIsActive > 1)
            return enemyActions[0];
        else if (i <= percentageNormalAttack)
            return enemyActions[0];
        else
            return enemyActions[1];
    }

    

   
}
