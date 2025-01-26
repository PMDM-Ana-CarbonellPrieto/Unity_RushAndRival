using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    public TMP_Text countText;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.currentSpeed = GameManager.defaultSpeed;
        StartCoroutine(StartRound());
    }

    private IEnumerator StartRound()
    {
        GameManager.gameState = GameState.PREPARED;

        int count = 3;
        while (count > 0)
        {
            countText.text = count.ToString();
            yield return new WaitForSeconds(1f);
            count--;
        }

        countText.text = "Start";
        yield return new WaitForSeconds(1f);
        countText.text = "";

        GameManager.gameState = GameState.STARTED;
    }
}
