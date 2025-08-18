using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SanityBarScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Sanity Bar Settings")]
    [SerializeField] Slider slider;
    [SerializeField] float decreaseRate = 5f;
    float decreaseRateFloat;

    [Header("Game Over Setting")]
    public GameOverScript gameOverScript;

    void Start()
    {
        StartCoroutine(DecreaseSlider());
    }

    IEnumerator DecreaseSlider()
    {
        while (slider.value > 0)
        {
            decreaseRateFloat = decreaseRate/ 100f;
            slider.value = Mathf.MoveTowards(slider.value, 0, decreaseRateFloat * Time.deltaTime);

            yield return null; // wait for next frame
        }
        if(slider.value <= 0)
        {
            Debug.Log("Sanity bar is empty. Game Over or similar logic can be implemented here.");
            gameOverScript.GameOver();
        }
    }

    public void IncreaseSanity(float amount)
    {
        slider.value = Mathf.Clamp(slider.value + amount, 0, slider.maxValue);
    }

    public void ReduceSanityRate(float amount)
    {
        decreaseRate = Mathf.Clamp(decreaseRate - amount, 0, 100f);
    }
}


