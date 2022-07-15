using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator anim;
    public GameObject clickToBegin;

    public void onClickBegin()
    {
        anim.enabled = true;
        Destroy(clickToBegin);
    }

    public void onNewGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void onQuit()
    {
        Application.Quit();
    }


}
