using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelTimeElapsed : MonoBehaviour
{
    public float timeElapsed;
    public TextMeshProUGUI timeText;
    public bool timerActive;

    public LevelGoalScript LGS;
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "In " + timeElapsed.ToString("F2") + ("s");
        if (timerActive)
        {
            timeElapsed += Time.deltaTime;
        }
        else if (!timerActive)
        {
            timeElapsed = timeElapsed;
        }
        
        if (LGS.complete)
        {
            timerActive = false;
        }
        else
        {
            timerActive = true;
        }
    }
}
