using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject deathScreenObj;

    public GameObject player;
    public void DeathScreenActive()
    {
        deathScreenObj.SetActive(true);
    }
    public void Respawn()
    {
        SceneManager.LoadScene("MainScene");
    }
}
