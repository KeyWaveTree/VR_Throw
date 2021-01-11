using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ballhit : MonoBehaviour
{
    public Text score;
    public static int ballScore = 0;
    public int getPoint = 1;
    private GameObject timer;
    private void Awake()
    {
        timer = GameObject.FindGameObjectWithTag("TimerManager");
    }

    private void OnTriggerEnter(Collider other) { if (other.CompareTag("Ball")) ballScore += getPoint; }
    private void Update()
    {
        if (timer.GetComponent<Timer>()._playing == false)
        {
            ballScore = 0;
            score.GetComponent<Text>().text = ballScore.ToString();
        }
        score.GetComponent<Text>().text = ballScore.ToString();
    }
}



