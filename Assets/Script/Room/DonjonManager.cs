using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonjonManager : MonoBehaviour
{
    public static Dictionary<string, GameObject> rooms;

    public  static string currentRoom = "";

    public static GameObject player;

    public static Object[] passivesMobs ;

    public static bool endOfNarrativeIntro;

    public static List<GameObject> bloockedDoors;

    public void Start(){
        StartCoroutine(InitDonjon());
    }
    public IEnumerator InitDonjon(){
        DisplayEndText.gameOver = false;
        endOfNarrativeIntro = false;
        NarrativeIntro.indice = 0;
        rooms = new Dictionary<string, GameObject>();
        bloockedDoors = new List<GameObject>();
        passivesMobs = Resources.LoadAll("Prefabs/Entities/PassivesMobs");


        for(int i = 1; i < 11; i+=1)
            AddRoom("Room"+i);

        SpawnPassivesMobs();
        AddSpawnLever();
        AddSpawnPopo();
        yield return new WaitForFixedUpdate();
        DisableRooms();
        yield return new WaitForFixedUpdate();


        player = Instantiate(Resources.Load("Prefabs/Entities/Player/Player") as GameObject);
        player.name = "Player";
        player.GetComponent<Player>().initPlayer(rooms[currentRoom].GetComponent<RoomManager>(),rooms[currentRoom].GetComponent<RoomManager>().widthRoom/2,0);
        DontDestroyOnLoad(player);
        GameObject.Find("Player").GetComponent<Player>().map.GetComponent<Map>().ChangeColor(currentRoom);
    }

    public void AddRoom(string nameRoom){
        rooms.Add(nameRoom, Instantiate(Resources.Load("Prefabs/Donjon/Rooms/" + nameRoom) as GameObject));
        rooms[nameRoom].name = nameRoom;
        rooms[nameRoom].transform.SetParent(gameObject.transform);
        foreach (GameObject bloockedDoor in GameObject.FindGameObjectsWithTag("BlockedDoor"))
            bloockedDoors.Add(bloockedDoor);
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

    public void AddSpawnPopo()
    {
        List<string> potentialRoomForPopo = new List<string>();
        foreach (string key in rooms.Keys)
        {
            if (rooms[key].GetComponent<RoomManager>().spawnPopo != null)
                potentialRoomForPopo.Add(key);
        }
        List<string> roomsPopo = new List<string>();
        for(int i = 0; i < 2; i += 1){
            string roomPopo = potentialRoomForPopo[Random.Range(0, potentialRoomForPopo.Count)];
            roomsPopo.Add(roomPopo);
            potentialRoomForPopo.Remove(roomPopo);
        }
        
        foreach (string key in rooms.Keys)
        {
            if (rooms[key].GetComponent<RoomManager>().spawnPopo != null && !roomsPopo.Contains(key)){
                Destroy(rooms[key].GetComponent<RoomManager>().spawnPopo);
            }
                
        }


    }

    public void DisableRooms(){ 
        foreach(string key in rooms.Keys){
            rooms[key].GetComponent<RoomManager>().InitRoom();
            if(currentRoom != key)
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
