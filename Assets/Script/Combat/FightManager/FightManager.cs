using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    //Entities
    ///Player
    public static GameObject player;
    public GameObject playerDisplay;
    public static Slider playerHp;

    ///Enemies
    public static List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> enemiesDisplay;
    public static List<Slider> enemiesHP = new List<Slider>();

    //Turn
    public static List<Actions> actions = new List<Actions>();
    public static Actions actionPlayer;

    //Animator
    public static Animator playerAnimator;

    public static List<Animator> enemiesAnimator = new List<Animator>();

    public static int wichEnemyToFight = 0;
    public static int wichEnemyAttack = 0;

    //Button
    public static GameObject listOffensiveAttack;
    public static GameObject listSecretTechnic;
    public static GameObject listInventory;
    public static GameObject inventoryBag;
    public static GameObject inventorySpecialObject;

    public GameObject choiceEnemies;

    //variables
    public static bool endOfFightTuto = false;
    public static bool canClickOnButton = true;
    public static int timeStunt = 0;
    public static int buffStat = 0;
    public static int buffStatTimer = 0;
    public static string typeOfEnemy;
    public static string whosIsDead = "";

    public static UnityEvent DoActionsEvent = new UnityEvent();


    public enum fight {   
        oneEnemy,
        twoEnemies,
        threeEnemies
    };

    public static fight howManyEnemy;

    public void Start(){
        InitFightManager();
    }

    public void InitFightManager(){
        DoActionsEvent.AddListener(DoActions);
        if (howManyEnemy != fight.oneEnemy)
            endOfFightTuto = true;
        InitPlayer();
        InitEnemies();
        InitChoiceEnemie();
        InitButton();
        InitAnimator();
        whosIsDead = "";
        actions = new List<Actions>();
        if (typeOfEnemy != "lever")
            actions.Add(new AttackEnemy());
        print("action : " + actions.Count);
        DonjonManager.rooms[DonjonManager.currentRoom].SetActive(false);
        DonjonManager.player.SetActive(false);
    }

    public void InitPlayer(){
        playerHp = playerDisplay.GetComponentInChildren<Slider>();
        playerHp.maxValue = player.GetComponent<Player>().maxHp;
        playerHp.value = player.GetComponent<Player>().maxHp;
    }

    public void InitEnemies(){
        enemiesHP = new List<Slider>();
        for (int i = 0; i < enemies.Count; i += 1){
            enemiesDisplay[i].GetComponent<Image>().sprite = enemies[i].GetComponent<SpriteRenderer>().sprite;
            enemiesHP.Add(enemiesDisplay[i].GetComponentInChildren<Slider>());
            enemiesHP[i].maxValue = enemies[i].GetComponent<Enemies>().hp;
            enemiesHP[i].value = enemies[i].GetComponent<Enemies>().hp;
        }
            

    }

    public void InitAnimator(){
        switch (howManyEnemy){
            case fight.oneEnemy:
                enemiesDisplay[0].GetComponent<Animator>().runtimeAnimatorController = enemies[0].GetComponent<Enemies>().animatorsController[0];
                break;
            case fight.twoEnemies:
                enemiesDisplay[0].GetComponent<Animator>().runtimeAnimatorController = enemies[0].GetComponent<Enemies>().animatorsController[1];
                enemiesDisplay[1].GetComponent<Animator>().runtimeAnimatorController = enemies[1].GetComponent<Enemies>().animatorsController[1];
                break;
            case fight.threeEnemies:
                enemiesDisplay[0].GetComponent<Animator>().runtimeAnimatorController = enemies[0].GetComponent<Enemies>().animatorsController[2];
                enemiesDisplay[1].GetComponent<Animator>().runtimeAnimatorController = enemies[1].GetComponent<Enemies>().animatorsController[2];
                enemiesDisplay[2].GetComponent<Animator>().runtimeAnimatorController = enemies[2].GetComponent<Enemies>().animatorsController[2];
                break;
        }

        playerAnimator = playerDisplay.GetComponent<Animator>();
        enemiesAnimator.Add(enemiesDisplay[0].GetComponent<Animator>());
        if(1 < enemiesDisplay.Count)
            enemiesAnimator.Add(enemiesDisplay[1].GetComponent<Animator>());
        if(2 < enemiesDisplay.Count)
            enemiesAnimator.Add(enemiesDisplay[2].GetComponent<Animator>());
    }

    public void InitButton(){
        listOffensiveAttack = GameObject.Find("ListOffensiveAttack");
        listSecretTechnic = GameObject.Find("ListSecretTechnic");
        listInventory = GameObject.Find("ListInventory");
        inventoryBag = GameObject.Find("InventoryBag");
        inventorySpecialObject = GameObject.Find("InventorySpecialObjet");
        InitInventoryBag();
        InitInventorySpecialObject();
        listOffensiveAttack.SetActive(false);
        listSecretTechnic.SetActive(false);
        listInventory.SetActive(false);
        inventoryBag.SetActive(false);
        inventorySpecialObject.SetActive(false);
    }

    public void InitChoiceEnemie(){
        if(choiceEnemies != null){
            choiceEnemies.GetComponent<Choice>().InitChoice();
            choiceEnemies.SetActive(false);
        }
    }





    public void AdjustActionsPriority(){
        if (actions[0].GetPriority() > actions[1].GetPriority()){
            Actions temp = actions[0];
            actions[0] = actions[1];
            actions[1] = temp;
        }
    }

    public void DoActions(){
        if (endOfFightTuto && canClickOnButton){
            canClickOnButton = false;
            if (actions.Count > 1 && timeStunt == 0){
                AdjustActionsPriority();
            } 
                
            StartCoroutine(launchAnimation());
        }

    }

    public IEnumerator launchAnimation(){
        enemiesAnimator[wichEnemyAttack].SetInteger("position", wichEnemyAttack);
        foreach (Actions action in actions){
            if (action.GetEntitie() == "Player")
                playerAnimator.SetBool(action.GetAnimation() + wichEnemyToFight, true);
            else
                if (enemiesAnimator[wichEnemyAttack] != null)
                    enemiesAnimator[wichEnemyAttack].SetBool("enemyAttacking", true);
            yield return new WaitForSeconds(1);
            action.DoAction();
            if (action.GetEntitie() == "Player")
                playerAnimator.SetBool(action.GetAnimation() + wichEnemyToFight, false);
            else
                if (enemiesAnimator[wichEnemyAttack] != null)
                enemiesAnimator[wichEnemyAttack].SetBool("enemyAttacking", false);
            yield return new WaitForSeconds(0.5f);
            if (CheckIfEndOfFight())
                break;
        }
        EndOfTurn();

    }

    public bool CheckIfEndOfFight() {
        bool enemiesDead = false;

        foreach (Slider slider in enemiesHP){
            print("slider value " + slider.value);
            if (slider.value != 0){
                enemiesDead = false;
                break;
            }
            else{
                enemiesDead = true;
            }   
        }

        foreach(Slider slider in enemiesHP){
            if(slider.value == 0){
                Destroy(slider.gameObject.transform.parent.gameObject);
                enemiesDisplay.Remove(slider.gameObject.transform.parent.gameObject);
            }
        }


        if (playerHp.value == 0){
            print("t mort");
            whosIsDead = "Player";
            return true;
        }
        else if (enemiesDead){
            
            whosIsDead = "Enemy";
            return true;
        }
        else
            return false;
    }

    public void EndOfTurn(){
        print("whoIsdead : " + whosIsDead);
        wichEnemyAttack += 1;
        if (wichEnemyAttack == enemiesDisplay.Count)
            wichEnemyAttack = 0;
        if (whosIsDead == "")
        {
            actions = new List<Actions>();
            if (timeStunt > 0)
                timeStunt -= 1;
            if (timeStunt == 0)
                actions.Add(new AttackEnemy());
            if (buffStatTimer > 0)
                buffStatTimer -= 1;
            canClickOnButton = true;
        }
        else if (whosIsDead == "Player")
        {
            Destroy(DonjonManager.player);
            Destroy(GameObject.Find("DonjonManager"));
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            print("fin de combat");
            canClickOnButton = true;
            DonjonManager.rooms[DonjonManager.currentRoom].SetActive(true);

            if (typeOfEnemy == "lever")
            {
                GameObject.Find("LeverToFight").GetComponent<SpriteRenderer>().sprite = enemiesDisplay[0].GetComponent<Image>().sprite;
                GameObject.Find("LeverToFight").GetComponent<BoxCollider2D>().isTrigger = false;
                GameObject.Find("LeverToFight").GetComponent<SpriteRenderer>().flipX = true;
            }
            else
                Destroy(GameObject.FindGameObjectWithTag("ToFight"));


            foreach (GameObject go in DonjonManager.rooms[DonjonManager.currentRoom].GetComponent<RoomManager>().componentsInRoom)
                if (go.tag == "ToFight")
                {
                    DonjonManager.rooms[DonjonManager.currentRoom].GetComponent<RoomManager>().componentsInRoom.Remove(go);
                    break;
                }
            if (GameObject.FindGameObjectWithTag("HitBox") == null)
                DonjonManager.rooms[DonjonManager.currentRoom].GetComponent<RoomManager>().enemies = false;
            DonjonManager.player.SetActive(true);
            SceneManager.LoadScene("Room");
        }

    }

    public void InitInventoryBag()
    {
        for (int i = 0; i < Player.inventoryBag.Count; i += 1)
        {
            if (Player.inventoryBag[i] == "popo")
            {
                GameObject popo = Instantiate(Resources.Load("Prefabs/Props/Popo/PopoInInventory") as GameObject, inventoryBag.transform, true);
                popo.name = "PopoInInventory";
                popo.transform.position = new Vector2((inventoryBag.transform.position.x - 225) + (150 * i + 75), inventoryBag.transform.position.y);
                popo.GetComponent<Button>().onClick.AddListener(DoActions);
            }
        }
    }

    public void InitInventorySpecialObject()
    {
        for (int i = 0; i < Player.inventorySpecialObject.Count; i += 1)
        {
            if (Player.inventorySpecialObject[i] == "lever")
            {
                GameObject lever = Instantiate(Resources.Load("Prefabs/Props/Lever/LeverInInventory") as GameObject, inventorySpecialObject.transform, true);
                lever.name = "LeverInInventory";
                lever.transform.position = new Vector2((inventorySpecialObject.transform.position.x - 225) + (150 * i + 75), inventorySpecialObject.transform.position.y);
                lever.GetComponent<Button>().onClick.AddListener(DoActions);
            }
        }
    }


}
