using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float timers = 3f;
    public GameObject gameText;
    public GameObject gameOverText;

    public float maxTime = 60f;

    public bool _playing = false;
    private bool playCtn = false;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Timing();
        if (_playing == true)
        {
            maxTime -= Time.deltaTime;
            if (maxTime > 0)
            {
                timerText.GetComponent<Text>().text = "Time : " + Mathf.Ceil(maxTime).ToString();
            }
            else if (maxTime <= 0)
            {
                StartCoroutine(GameOver());
                timerText.GetComponent<Text>().text = "Time : 0";
                maxTime = 60f;

            }
        }
    }

    public IEnumerator Delay()
    {
        if (playCtn == false)
        {
            gameText.SetActive(true);
            playCtn = true;
            yield return new WaitForSeconds(3f);
            _playing = true;
            gameText.SetActive(false);
        }
    }

    IEnumerator GameOver()
    {
        gameOverText.SetActive(true);
        _playing = false;
        yield return new WaitForSeconds(3f);
        timers = 3f;
        playCtn = false;
        gameOverText.SetActive(false);
    }


    void Timing()
    {
        if (playCtn)
        {
            
            if (timers != 0)
            {
                timers -= Time.deltaTime;
                if (timers <= 0)
                {
                    timers = 0;
                }
            }
            //Text t = GetComponent<Text>();
            gameText.GetComponent<Text>().text = Mathf.Ceil(timers).ToString() + "초 뒤 시작합니다.";
        }
    }
}
