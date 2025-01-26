using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controller : MonoBehaviour
{
    public Transform respawn;
    private int checkPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        respawn.position += Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
        {
            transform.position = respawn.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager.currentCoins++;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("CheckPoint"))
        {
            other.GetComponent<BoxCollider>().enabled = false;
            checkPoints++;
            StartCoroutine(TakeBoost());
        }
        else if (other.CompareTag("Respawn"))
        {
            respawn = other.transform;
        }
        else if (other.CompareTag("Finish") && checkPoints == 3)
        {
            GameManager.gameState = GameState.FINISHED;
        }
    }

    private IEnumerator TakeBoost()
    {
        GameManager.currentSpeed = GameManager.boostSpeed;
        yield return new WaitForSeconds(2.5f);
        GameManager.currentSpeed = GameManager.defaultSpeed;
    }
}
