using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ButtonIcon : MonoBehaviour
{
    [SerializeField] private Button[] lvlButton;
    [SerializeField] private Sprite unlockIcon;
    [SerializeField] private Sprite lockedIcon;
    [SerializeField] private int firstLevelBuildIndex;
    // Start is called before the first frame update
    private void Awake()
    {
        int unlockedLvl = PlayerPrefs.GetInt(EndGameManager.endManager.lvUnlock, firstLevelBuildIndex);
        for(int i = 0; i < lvlButton.Length; i++)
        {
            if(i + firstLevelBuildIndex <= unlockedLvl)
            {
                lvlButton[i].interactable = true;
                lvlButton[i].image.sprite = unlockIcon;
                TextMeshProUGUI textButton = lvlButton[i].GetComponentInChildren<TextMeshProUGUI>();
                textButton.text = (i + 1).ToString();
                textButton.enabled = true;
            }
            else
            {
                lvlButton[i].interactable = false;
                lvlButton[i].image.sprite= lockedIcon;
                lvlButton[i].GetComponentInChildren < TextMeshProUGUI>().enabled = false;   
            }
        }
    }
}
