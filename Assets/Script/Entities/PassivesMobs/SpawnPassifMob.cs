using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPassifMob : MonoBehaviour
{
    public void Spawn()
    {
        print("spawn");
        GameObject mob = Instantiate(DonjonManager.passivesMobs[Random.Range(0,DonjonManager.passivesMobs.Length)]) as GameObject;
        mob.name = mob.name.Replace("(Clone)", "");
        print(mob.name);
        DontDestroyOnLoad(mob);
        mob.transform.position = gameObject.transform.position;
        mob.transform.SetParent(gameObject.transform.parent);
        Destroy(gameObject);
    }

    
}
