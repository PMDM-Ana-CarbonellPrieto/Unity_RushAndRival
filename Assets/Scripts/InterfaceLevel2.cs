using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterfaceLevel2 : MonoBehaviour
{
    public TMP_Text count;
    public Transform player;
    public Transform enemy;
    public Transform objective;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartRound());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartRound() {
        //player.GetComponent<CarController>().enable = false;
        //enemy.GetComponent<EnemyController>().enable = false;
        GameManager.currentSpeed = 0;

        int seconds = 3;
        while (seconds > 0)
        {
            count.text = seconds.ToString();
            yield return new WaitForSeconds(1f);
            seconds--;
        }
        count.text = "Start";
        yield return new WaitForSeconds(1f);
        count.text = "";

        GameManager.currentSpeed = 70;

        //player.GetComponent<CarController>().enable = true;
        //enemy.GetComponent<EnemyController>().enable = true;
    }
}
