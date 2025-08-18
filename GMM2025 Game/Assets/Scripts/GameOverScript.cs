using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverText;

    void Start()
    {
        if(gameOverPanel!=null)
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void TimesUp()
    {
        gameOverText.text = "Time's Up";
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
