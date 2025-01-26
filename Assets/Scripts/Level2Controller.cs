using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : MonoBehaviour
{
    private bool hasObjective = false;
    private bool isWaiting = false;

    public GameObject objective;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.currentObjective == tag)
        {
            GameManager.currentSpeed = GameManager.objectiveSpeed;
        }
        else
        {
            GameManager.currentSpeed = GameManager.defaultSpeed;
        }

        if (GameManager.gameState == GameState.STARTED && hasObjective)
        {
            objective.transform.position = transform.position + new Vector3(0, .5f, 0);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Objective"))
        {
            GameManager.currentObjective = tag;
            hasObjective = true;
            objective.GetComponent<BoxCollider>().enabled = false;
        }

        if (hasObjective && other.CompareTag(tag))
        {
            GameManager.gameState = GameState.FINISHED;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(GameManager.gameState != GameState.STARTED) return;
        if (!isWaiting && (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player")))
        {
            if (!hasObjective) GameManager.currentObjective = tag;
            hasObjective = !hasObjective;
            StartCoroutine(WaitForObjective());
        }
    }

    private IEnumerator WaitForObjective()
    {
        isWaiting = true;
        yield return new WaitForSeconds(1f);
        isWaiting = false;
    }
}
