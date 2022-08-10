using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject deathScreenObj;
    public GameObject winnerScreenObj;

    public GameObject player;
    public void DeathScreenActive()
    {
        deathScreenObj.SetActive(true);
    }
    
    public void WinnerScreenActive()
    {
        winnerScreenObj.SetActive(true);
    }
    public void Respawn()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            WinnerScreenActive();
        }
    }



}
