using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject carModel;
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
        if (GameManager.currentObjective == tag)
        {
            speed = GameManager.currentSpeed - 10;
        } else
        {
            speed = GameManager.currentSpeed;
        }
        car.transform.position = rb.position - new Vector3(0, .5f, 0);
        car.transform.eulerAngles += new Vector3(0, Input.GetAxis("Horizontal") * .25f, 0);
        carModel.transform.eulerAngles = car.transform.eulerAngles + new Vector3(0, 180 + Input.GetAxis("Horizontal") * 25, 0);
    }

    private void FixedUpdate()
    {
        rb.AddForce(car.transform.forward * Input.GetAxis("Vertical") * speed, ForceMode.Acceleration);
        rb.AddForce(Vector3.down * 50, ForceMode.Acceleration);
    }
}
