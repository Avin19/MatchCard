using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header(" Layout Selection UI")]
    [SerializeField] private TMP_Dropdown rowsInput;



    [Header(" Game Manager ")]
    [SerializeField] private GameController gameController;
    [Header("UI Elements")]
    [SerializeField] private Button startBtn;
    [SerializeField] private Button restartbtn;
    [SerializeField] private Button quitBtn;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject layourSelectorPanel;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI statusText;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        gameOverPanel.SetActive(false);
        startBtn.onClick.AddListener(OnStartGame);
        statusText.text = "";
        UpdateScore(0);
        restartbtn.onClick.AddListener(OnRestartGame);
        quitBtn.onClick.AddListener(() => Application.Quit());

    }

    private void OnRestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void UpdateScore(int score)
    {

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
    public void ShowStatus(string message)
    {
        if (statusText != null)
        {
            statusText.text = message;
        }
    }

    public void ShowGameOver()
    {
        ShowStatus("Game Over!");
        gameOverPanel.SetActive(true);
    }
    private void OnStartGame()
    {
        string selected = rowsInput.options[rowsInput.value].text;
        string[] parts = selected.Split('X');
        int rows = int.Parse(parts[0]);
        int cols = int.Parse(parts[1]);
        layourSelectorPanel.SetActive(false);
        gameController.StartGameWithLayout(rows, cols);
    }
}
