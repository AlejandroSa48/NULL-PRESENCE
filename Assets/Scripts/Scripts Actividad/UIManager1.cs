using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager1 : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject initialUI;
    public GameObject gameUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;

    [Header("Game UI Elements")]
    public TextMeshProUGUI scoreText;
    public Image healthBar;
    public TextMeshProUGUI healthText;

    void Start()
    {
        ShowInitialUI();
    }

    public void ShowInitialUI()
    {
        initialUI.SetActive(true);
        gameUI.SetActive(false);
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    public void ShowGameUI()
    {
        initialUI.SetActive(false);
        gameUI.SetActive(true);
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void UpdateHealth(float healthPercent)
    {
        healthBar.fillAmount = healthPercent;
        healthText.text = $"Health: {(healthPercent * 100):F0}%";

        // Color según salud
        if (healthPercent > 0.5f)
        {
            healthBar.color = Color.green;
        }
        else if (healthPercent > 0.25f)
        {
            healthBar.color = Color.yellow;
        }
        else
        {
            healthBar.color = Color.red;
        }
    }


    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }
}