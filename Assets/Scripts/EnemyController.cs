using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform objective;
    public GameObject car;

    private float speed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = GameManager.currentSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        car.transform.position = rb.position - new Vector3(0, .5f, 0);
        Quaternion rotation;
        if (GameManager.currentObjective == tag)
        {
            speed = GameManager.currentSpeed - 10;
            rotation = Quaternion.LookRotation(transform.parent.position - rb.transform.position);
        } else {
            speed = GameManager.currentSpeed;
            rotation = Quaternion.LookRotation(objective.position - rb.transform.position);
        }
        float diff = (rotation.y - car.transform.rotation.y) * .9f;
        car.transform.rotation = new Quaternion(rotation.x, rotation.y - diff, rotation.z, rotation.w);
    }

    private void FixedUpdate()
    {
        rb.AddForce(car.transform.forward * speed, ForceMode.Acceleration);
        rb.AddForce(Vector3.down * 50, ForceMode.Acceleration);
    }
}
