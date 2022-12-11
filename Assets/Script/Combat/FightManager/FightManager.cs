using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public List<GameObject> enemiesDisplayEditor;
    public static List<GameObject> enemiesDisplay;
    public static List<Slider> enemiesHP ;

    //Turn
    public static List<Actions> actions;
    public static Actions actionPlayer;

    //Animator
    public static Animator playerAnimator;

    public static List<Animator> enemiesAnimator ;

    public static int whichEnemyToFight;
    public static int whichEnemyAttack;

    //Button
    public static GameObject listOffensiveAttack;
    public static GameObject listSecretTechnic;
    public static GameObject listInventory;
    public static GameObject inventoryBag;
    public static GameObject inventorySpecialObject;

    //GameObject
    public GameObject choiceEnemies;
    public GameObject reaction;

    //variables
    public static bool endOfFightTuto = false;
    public static bool canClickOnButton ;
    public static Dictionary<int, int> enemiesStunt;
    public static int buffStatPlayer;
    public static int buffStatPlayerTimer;
    public static Dictionary<int, int> buffStatEnemy;
    public static string typeOfEnemy;
    public static string whosIsDead;

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
        reaction.SetActive(false);
        InitStaticVariable();
        if (howManyEnemy != fight.oneEnemy)
            endOfFightTuto = true;
        InitPlayer();
        InitEnemies();
        InitChoiceEnemie();
        InitButton();
        InitAnimator();
        if (typeOfEnemy != "Lever")
            actions.Add(enemies[whichEnemyAttack].GetComponent<Enemies>().GetAction(buffStatEnemy[whichEnemyAttack]));
        DonjonManager.rooms[DonjonManager.currentRoom].SetActive(false);
        DonjonManager.player.SetActive(false);
    }

    public void InitPlayer(){
        playerHp = playerDisplay.GetComponentInChildren<Slider>();
        playerHp.maxValue = player.GetComponent<Player>().maxHp;
        playerHp.value = player.GetComponent<Player>().maxHp;
        playerDisplay.transform.GetChild(1).GetComponent<ChangeStatus>().DisableStatus();
    }

    public void InitEnemies(){
        for (int i = 0; i < enemies.Count; i += 1){
            enemiesDisplay[i].GetComponent<Image>().sprite = enemies[i].GetComponent<Enemies>().sprite;
            enemiesDisplay[i].transform.GetChild(1).GetComponent<ChangeStatus>().DisableStatus();
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

    public void InitStaticVariable(){
        enemiesStunt = new Dictionary<int, int>();
        buffStatEnemy = new Dictionary<int, int>();
        enemiesDisplay = enemiesDisplayEditor; 
        canClickOnButton = true;
        buffStatPlayer = 1;
        buffStatPlayerTimer = 0;
        whosIsDead = "";
        enemiesAnimator = new List<Animator>();
        enemiesHP = new List<Slider>();
        actions = new List<Actions>();
        whichEnemyToFight = 0;
        whichEnemyAttack = 0;
        for(int i = 0; i < 3; i+= 1){
            enemiesStunt.Add(i, 0);
            buffStatEnemy.Add(i, 1);
        }
    }



    public void DoActions(){
        if (endOfFightTuto && canClickOnButton){
            canClickOnButton = false;               
            StartCoroutine(LaunchAnimation());
        }

    }

    public IEnumerator LaunchAnimation(){
        enemiesAnimator[whichEnemyAttack].SetInteger("position", whichEnemyAttack);
        foreach (Actions action in actions){
            if (action.GetEntitie() == "Player"){
                playerAnimator.SetBool(action.GetAnimation() + whichEnemyToFight, true);
            }
                
            else{
                if (enemiesAnimator[whichEnemyAttack] != null){
                    enemiesAnimator[whichEnemyAttack].SetBool(action.GetAnimation(), true);
                }
            }
                
            yield return new WaitForSeconds(1);
            

            action.DoAction();
            if (action.GetEntitie() == "Player")
                playerAnimator.SetBool(action.GetAnimation() + whichEnemyToFight, false);
            else
                if (enemiesAnimator[whichEnemyAttack] != null){
                enemiesAnimator[whichEnemyAttack].SetBool(action.GetAnimation(), false);
                
            }
            yield return new WaitForSeconds(0.5f);
            if (CheckIfEndOfFight() || actions.Count == 1)
                break;
        }
        EndOfTurn();

    }

    public bool CheckIfEndOfFight() {
        bool enemiesDead = false;

        foreach (Slider slider in enemiesHP){
            if (slider.value != 0){
                enemiesDead = false;
                break;
            }
            else
                enemiesDead = true;
        }

        if(typeOfEnemy != "Lever")
            for(int i = 0; i < enemiesHP.Count; i+=1){
                if(enemiesHP[i].value == 0){
                    enemiesDisplay[i].SetActive(false);
                    if (actions.Count > 1 && enemies[i].GetComponent<Enemies>().typeOfEnemy == actions[1].GetEntitie())  
                        actions.Remove(actions[1]);
                    if(choiceEnemies != null)
                        choiceEnemies.GetComponent<Choice>().DisableChoice(i);
                }
            }


        if (playerHp.value == 0){
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
        whichEnemyAttack += 1;
        if (whichEnemyAttack >= enemiesDisplay.Count)
            whichEnemyAttack = 0;
        if (enemiesDisplay[whichEnemyAttack].GetComponentInChildren<Slider>().value == 0)
            whichEnemyAttack += 1;
        if (whichEnemyAttack >= enemiesDisplay.Count)
            whichEnemyAttack = 0;

        if (whosIsDead == "")
        {
            actions = new List<Actions>();
            if (typeOfEnemy != "Lever"){
                bool canAddAction;

                
                if (enemiesStunt[whichEnemyAttack] > 0){
                    enemiesStunt[whichEnemyAttack] -= 1;
                    canAddAction = false;
                }
                else
                    canAddAction = true;
                    
                if (enemiesStunt[whichEnemyAttack] == 0 && buffStatEnemy[whichEnemyAttack] == 1){
                    enemiesDisplay[whichEnemyAttack].transform.GetChild(1).GetComponent<ChangeStatus>().DisableStatus();
                    enemiesStunt[whichEnemyAttack] = 0;
                    canAddAction = true;
                }

                
                if(canAddAction)
                    actions.Add(enemies[whichEnemyAttack].GetComponent<Enemies>().GetAction(buffStatEnemy[whichEnemyAttack]));

            }
                
            if (buffStatPlayerTimer > 0)
                buffStatPlayerTimer -= 1;
            if (buffStatPlayerTimer == 0){
                buffStatPlayer = 1;
                playerDisplay.transform.GetChild(1).GetComponent<ChangeStatus>().DisableStatus();
            }
                
            canClickOnButton = true;
        }
        else if (whosIsDead == "Player")
        {
            Destroy(DonjonManager.player);
            Destroy(GameObject.Find("DonjonManager"));
            DisplayEndText.gameOver = true;
            SceneManager.LoadScene("EndScene");
        }
        else
        {
            canClickOnButton = true;
            DonjonManager.rooms[DonjonManager.currentRoom].SetActive(true);

            if (typeOfEnemy == "Lever")
            {
                GameObject.Find("LeverToFight").GetComponent<SpriteRenderer>().sprite = enemiesDisplay[0].GetComponent<Image>().sprite;
                Destroy(GameObject.Find("LeverToFight").transform.parent.GetComponent<BoxCollider2D>()  );
                GameObject.Find("LeverToFight").GetComponent<SpriteRenderer>().flipX = true;
                foreach (GameObject blockedDoor in DonjonManager.bloockedDoors)
                    blockedDoor.tag = "Untagged";
            }
            else
                Destroy(GameObject.FindGameObjectWithTag("ToFight"));


            foreach (GameObject go in DonjonManager.rooms[DonjonManager.currentRoom].GetComponent<RoomManager>().componentsInRoom)
                if (go.tag == "ToFight")
                {
                    DonjonManager.rooms[DonjonManager.currentRoom].GetComponent<RoomManager>().componentsInRoom.Remove(go);
                    break;
                }
            if (GameObject.FindGameObjectWithTag("HitBox") == null || GameObject.FindGameObjectWithTag("HitBox").GetComponent<Hitbox>().typeOfEnemy == "Lever")
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

    public void StartCoroutineLever(){
        StartCoroutine(LaunchReactionActionAgainstLever());
    }
    public void StartCoroutineItem(){
        StartCoroutine(LaunchReactionActionItem());
    }


    public IEnumerator LaunchReactionActionAgainstLever(){
        reaction.SetActive(true);
        reaction.GetComponent<TextMeshProUGUI>().text = "Je dois faire quelque chose avant";
        yield return new WaitForSeconds(2);
        reaction.GetComponent<TextMeshProUGUI>().text = "";
        reaction.SetActive(false);
    }

    public IEnumerator LaunchReactionActionItem()
    {
        reaction.SetActive(true);
        reaction.GetComponent<TextMeshProUGUI>().text = "Cela n'a aucun effet";
        yield return new WaitForSeconds(2);
        reaction.GetComponent<TextMeshProUGUI>().text = "";
        reaction.SetActive(false);
    }


}
