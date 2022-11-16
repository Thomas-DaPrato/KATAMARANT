using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoFight : MonoBehaviour
{

    public List<GameObject> tutoElements;

    public static int indice = 0;
    void Update()
    {
        if(!FightManager1Vs1.endOfFightTuto){
            if(tutoElements[indice].tag == "DisplayObject")
                tutoElements[indice].GetComponent<ObjectToDisplay>().displaying.Invoke();
            tutoElements[indice].SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)){
                tutoElements[indice].SetActive(false);
                indice += 1;
                if(indice >= tutoElements.Count){
                    FightManager1Vs1.endOfFightTuto = true;
                }
                    
            }
        }
            
    }
}
