using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceFail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.currentCoins = 0;
        GameManager.currentTimer = 0;
    }

    public void Click_level1()
    {
        SceneManager.LoadScene("Level1Scene");
    }

    public void Click_level2()
    {
        SceneManager.LoadScene("Level2Scene");
    }

    public void Click_title()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

