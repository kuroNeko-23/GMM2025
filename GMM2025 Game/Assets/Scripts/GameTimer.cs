using UnityEngine;
using UnityEngine.UI;  // Only if you want to display on UI
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float playTime = 120f;   // actual game seconds
    [SerializeField] private TMP_Text timerText;      // drag TMP Text UI here
    [SerializeField] private int startHour = 0;       // starting hour
    [SerializeField] private int endHour = 6;         // ending hour

    [Header("Game Over Reference")]
    public GameOverScript gameOverScript;

    private float currentTime = 0f;

    void Update()
    {
        if (currentTime < playTime)
        {
            currentTime += Time.deltaTime;
            if (currentTime > playTime) currentTime = playTime;

            UpdateTimerUI();
        }
        else
        {
            //Debug.Log("Time is up!");
            gameOverScript.GameOver();
        }
    }

    void UpdateTimerUI()
    {
        // Map currentTime to fake hours
        float totalFakeHours = endHour - startHour;
        float fakeHoursFloat = startHour + (currentTime / playTime) * totalFakeHours;

        int fakeHours = Mathf.FloorToInt(fakeHoursFloat);

        timerText.text = string.Format("{0:00}:00", fakeHours);
    }
}
