using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        EndGameManager.endManager.RegisterPanelController(this);
    }

    public void ActivateWin()
    {
        canvasGroup.alpha = 1.0f;
        winScreen.SetActive(true);
    }
    public void ActivateLose()
    {
        canvasGroup.alpha = 1.0f;
        loseScreen.SetActive(true);
    }
}
