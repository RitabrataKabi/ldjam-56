using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float startTime;

    private float hour, minute, second, millisec;

    public Gradient gradient;

    IEnumerator Start()
    {   
        float time = startTime;
        timerText.text = time.ToString();

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);

        float unitTime = 1/startTime;

        while (time > 0)
        {
            yield return new WaitForSeconds(.1f);
            time -= .1f;

            hour = (int)(time / 3600);
            minute = (int)((time - hour * 3600) / 60);
            second = (int)(time - hour * 3600 - minute * 60);
            millisec = (int)((time - hour * 3600 - minute * 60 - second) * 10);

            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minute, second, millisec);

            timerText.color = gradient.Evaluate((startTime - time) * unitTime);

        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
