using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCurrentRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DonjonManager.rooms[DonjonManager.currentRoom].SetActive(true);
    }

    
}
