using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NarrativeIntro : MonoBehaviour
{
    public List<string> sentences;
    public static int indice = 0;

    public void Update(){
        if(!DonjonManager.endOfNarrativeIntro)
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = sentences[indice];
            if(Input.GetKeyDown(KeyCode.Space)){
                indice += 1;
                if(indice >= sentences.Count){
                    DonjonManager.endOfNarrativeIntro = true;
                    gameObject.SetActive(false);
                }
                    
            }
    }
}
