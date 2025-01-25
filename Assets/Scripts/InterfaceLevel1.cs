using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterfaceLevel1 : MonoBehaviour
{
    public TMP_Text count;
    public TMP_Text objective;
    public TMP_Text timer;
    public Transform player;
    public bool showCoins = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.currentTimer = 0;
        StartCoroutine(StartRound());
    }

    // Update is called once per frame
    void Update()
    {
        if (showCoins)
        {
            objective.text = GameManager.currentCoins + "/4";
        }
    }

    private IEnumerator StartRound()
    {
        objective.text = "";
        GameManager.defaultSpeed = 0;

        int seconds = 3;
        while (seconds > 0)
        {
            count.text = seconds.ToString();
            yield return new WaitForSeconds(1f);
            seconds--;
        }

        count.text = "Start";
        yield return new WaitForSeconds(1f);
        count.text = "";

        GameManager.defaultSpeed = 70;
        GameManager.currentCoins = 0;
        showCoins = true;

        int maxTimePlay = 50;
        while (maxTimePlay > 0)
        {
            timer.text = maxTimePlay.ToString();
            yield return new WaitForSeconds(1f);
            maxTimePlay--;
        }
        timer.text = "Fail level";
        showCoins = false;
        yield return new WaitForSeconds(1f);
        timer.text = "";
        objective.text = "";
        GameManager.defaultSpeed = 0;
        
    }
}
