using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    private void Awake()
    {
        StopGame();
        _startScreen.Open();
        _endGameScreen.Close();
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonPressed += OnPlayButtonPressed;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClicked;

        _bird.GameOver += OnGameOverProcessed;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonPressed -= OnPlayButtonPressed;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClicked;

        _bird.GameOver -= OnGameOverProcessed;
    }

    private void OnGameOverProcessed()
    {
        StopGame();
        _endGameScreen.Open();
    }

    private void OnRestartButtonClicked()
    {
        _endGameScreen.Close();
        StartGame();

        _enemyGenerator.Restart();
    }

    private void OnPlayButtonPressed()
    {
        _startScreen.Close();
        StartGame();

        _enemyGenerator.Generate();
    }

    private void StopGame()
    {
        Time.timeScale = 0f;
    }

    private void StartGame()
    {
        Time.timeScale = 1.0f;
        _bird.Reset();
    }
}