using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreRegistration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI textForRegistration = GetComponent<TextMeshProUGUI>();  
        EndGameManager.endManager.RegistorScoreText(textForRegistration);
        textForRegistration.text = "Score: 0";
    }

   
}
