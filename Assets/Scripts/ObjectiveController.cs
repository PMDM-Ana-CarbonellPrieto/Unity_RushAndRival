using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    private bool hasObjective = false;
    private bool waiting = false;

    public GameObject objective;

    // Update is called once per frame
    void Update()
    {
        if (hasObjective)
        {
            objective.transform.position = transform.position + new Vector3(0, .5f, 0);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Objective")
        {
            GameManager.currentObjective = tag;
            hasObjective = true;
            objective.GetComponent<BoxCollider>().enabled = false;
        }

        if (hasObjective && other.tag == tag)
        {
            print("Finish");
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (!waiting && (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player"))
        {
            if (!hasObjective) GameManager.currentObjective = tag;
            hasObjective = !hasObjective;
            StartCoroutine(WaitForObjective());
        }
    }

    private IEnumerator WaitForObjective()
    {
        waiting = true;
        yield return new WaitForSeconds(2f);
        waiting = false;
    }
}
