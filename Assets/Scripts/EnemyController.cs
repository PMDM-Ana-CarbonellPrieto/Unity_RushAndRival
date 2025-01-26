using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform objective;
    public Transform target;
    public GameObject car;

    private float speed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = GameManager.defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        car.transform.position = rb.position - new Vector3(0, .5f, 0);
        if(GameManager.gameState != GameState.STARTED) return;
        Quaternion rotation;
        if (GameManager.currentObjective == tag)
        {
            speed = GameManager.objectiveSpeed;
            rotation = Quaternion.LookRotation(target.position - rb.transform.position);
        } else {
            speed = GameManager.defaultSpeed;
            rotation = Quaternion.LookRotation(objective.position - rb.transform.position);
        }
        float diff = (rotation.y - car.transform.rotation.y) * .9f;
        car.transform.rotation = new Quaternion(rotation.x, rotation.y - diff, rotation.z, rotation.w);
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * 50, ForceMode.Acceleration);
        if(GameManager.gameState != GameState.STARTED) return;
        rb.AddForce(car.transform.forward * speed, ForceMode.Acceleration);
    }
}
