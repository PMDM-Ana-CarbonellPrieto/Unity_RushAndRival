using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controller : MonoBehaviour
{
    public Transform respawn;
    public ParticleSystem[] boosts = new ParticleSystem[3];
    private Vector3 respawnPosition;
    private int checkPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = respawn.position + Vector3.up;
        foreach (ParticleSystem boost in boosts)
        {
            boost.Stop();
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
            respawnPosition = other.transform.position;
        }
        else if (other.CompareTag("Finish") && checkPoints == 3)
        {
            GameManager.gameState = GameState.FINISHED;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Floor"))
        {
            transform.position = respawnPosition;
        }
    }

    private IEnumerator TakeBoost()
    {
        GameManager.currentSpeed = GameManager.boostSpeed;
        foreach (ParticleSystem boost in boosts)
        {
            boost.Play();
        }
        yield return new WaitForSeconds(2.5f);
        foreach (ParticleSystem boost in boosts)
        {
            boost.Stop();
        }
        GameManager.currentSpeed = GameManager.defaultSpeed;
    }
}
