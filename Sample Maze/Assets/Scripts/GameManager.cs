using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGameOver = false;
    public float time = 0;
    public float startingTime = 20 * 60f;
    bool isRed = false;

    public TMP_Text timeCounter;
    public TMP_Text fpsCounter;
    public TMP_Text teamNoField;

    void Start()
    {
        time = startingTime;
        teamNoField.text = "Team " + PlayerPrefs.GetString("teamNumber");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;
        time -= Time.deltaTime;
        fpsCounter.text = (1 / Time.deltaTime).ToString("00") + " FPS";
        timeCounter.text = Helpers.ToMinuteSecond((int) time);

        if (time <= 60 * 5 && !isRed)
        {
            isRed = true;
            timeCounter.color = Color.red;
        }

        if (time <= 0)
        {
            isGameOver = true;
        }
    }

    void FGame(GameOver over)
    {
        over.FinishGame();
    }
}
