using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    
    public void ChangeColor(string room){
        gameObject.transform.Find(DonjonManager.currentRoom).GetComponent<Image>().color = Color.white;
        gameObject.transform.Find(room).GetComponent<Image>().color = Color.blue;
    }
}
