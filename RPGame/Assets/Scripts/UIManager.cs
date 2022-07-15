using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject deathScreenObj;

    public GameObject player;
    public void DeathScreenActive()
    {
        deathScreenObj.SetActive(true);
    }
}
