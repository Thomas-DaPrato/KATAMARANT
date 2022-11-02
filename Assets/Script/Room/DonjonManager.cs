using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonjonManager : MonoBehaviour
{
    public static Dictionary<string, GameObject> rooms = new Dictionary<string, GameObject>();

    public  static string currentRoom = "";

    public static GameObject player;

    public static Object[] passivesMobs ;

    public static bool endOfNarrativeIntro = false;

    public void Start(){
        passivesMobs = Resources.LoadAll("Prefabs/Entities/PassivesMobs");

        print("size : " + passivesMobs.Length);

        for(int i = 1; i < 11; i+=1)
            AddRoom("Room"+i);

        SpawnPassivesMobs();
        AddSpawnLever();
        DisableRooms();


        player = Instantiate(Resources.Load("Prefabs/Entities/Player/Player") as GameObject);
        player.name = "Player";
        player.GetComponent<Player>().initPlayer(rooms[currentRoom].GetComponent<RoomManager>(),rooms[currentRoom].GetComponent<RoomManager>().widthRoom/2,0);
        DontDestroyOnLoad(player);

    }

    public void AddRoom(string nameRoom){
        rooms.Add(nameRoom, Instantiate(Resources.Load("Prefabs/Donjon/Rooms/" + nameRoom) as GameObject));
        rooms[nameRoom].name = nameRoom;
        rooms[nameRoom].transform.SetParent(gameObject.transform);
        rooms[nameRoom].GetComponent<RoomManager>().InitRoom();
    }

    public void AddSpawnLever(){
        List<string> potentialRoomForLever = new List<string>();
        foreach(string key in rooms.Keys){
            if(rooms[key].GetComponent<RoomManager>().spawnLever != null)
                potentialRoomForLever.Add(key);
        }
        string roomLever = potentialRoomForLever[Random.Range(0,potentialRoomForLever.Count)];
        foreach(string key in rooms.Keys){
            if(rooms[key].GetComponent<RoomManager>().spawnLever != null && key != roomLever)
                Destroy(rooms[key].GetComponent<RoomManager>().spawnLever);
        }
        

    }

    public void DisableRooms(){
        foreach(string key in rooms.Keys){
            rooms[key].SetActive(false);       
        }
    }

    public void SpawnPassivesMobs(){
        GameObject[] spawner = GameObject.FindGameObjectsWithTag("Spawner");
        foreach(GameObject go in spawner){
            go.GetComponent<SpawnPassifMob>().Spawn();
        }
    }
}
