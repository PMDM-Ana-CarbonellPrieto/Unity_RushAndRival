using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.currentCoins = 0;
    }

    public void Click()
    {
        SceneManager.LoadScene("Level1Scene");
    }
}
