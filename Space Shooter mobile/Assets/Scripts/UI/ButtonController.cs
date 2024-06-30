using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    public void LoadLevelString(string levelName)
    {
        FadeCanvas.fader.FadeLoad(levelName);
    }
    public void LoadLevelInt(int levelIndex)
    {
        FadeCanvas.fader.FadeLoadInt(levelIndex);
    }
    public void RestartLevel()
    {
        FadeCanvas.fader.FadeLoadInt(SceneManager.GetActiveScene().buildIndex);
    } 
}
