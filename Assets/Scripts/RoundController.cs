using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour
{
    public Image countText;
    public Image finalText;
    public Sprite oneSprite;
    public Sprite twoSprite;
    public Sprite threeSprite;
    public Sprite startSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        GameManager.currentSpeed = GameManager.defaultSpeed;
        StartCoroutine(StartRound());
    }

    private IEnumerator StartRound()
    {
        GameManager.gameState = GameState.PREPARED;
        yield return new WaitForSeconds(2f);
        
        countText.gameObject.SetActive(true);
        int count = 3;
        while (count > 0)
        {
            switch (count)
            {
                case 3:
                    countText.sprite = threeSprite;
                    break;
                case 2:
                    countText.sprite = twoSprite;
                    break;
                default:
                    countText.sprite = oneSprite;
                    break;
            }
            yield return new WaitForSeconds(1f);
            count--;
        }
        countText.gameObject.SetActive(false);

        finalText.gameObject.SetActive(true);
        finalText.sprite = startSprite;
        yield return new WaitForSeconds(1f);

        finalText.gameObject.SetActive(false);
        GameManager.gameState = GameState.STARTED;
    }
}
