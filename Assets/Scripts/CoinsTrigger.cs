using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsTrigger : MonoBehaviour
{
    int counter = 0;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            counter++;
            print("Moneda recogida. Total: " + counter);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("CheckPoint"))
        {
            StartCoroutine(BoostCar());
        }
    }

    IEnumerator BoostCar()
    {
        GameManager.currentSpeed = 140;
        yield return new WaitForSeconds(2.5f);
        GameManager.currentSpeed = 70;
    }
}
