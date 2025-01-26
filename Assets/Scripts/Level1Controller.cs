using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controller : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager.currentCoins++;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("CheckPoint"))
        {
            StartCoroutine(TakeBoost());
        }
    }

    IEnumerator TakeBoost()
    {
        GameManager.currentSpeed = GameManager.boostSpeed;
        yield return new WaitForSeconds(2.5f);
        GameManager.currentSpeed = GameManager.defaultSpeed;
    }
}
