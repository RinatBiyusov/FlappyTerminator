using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    private void OnEnable()
    {
        _bird.Died += OnGameOver;
        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClicked;
    }

    private void OnDisable()
    {
        _bird.Died -= OnGameOver;
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClicked;
    }
 
    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _endGameScreen.Close();
    }

    private void OnGameOver()
    {
        _endGameScreen.Open();
    }

    private void OnRestartButtonClicked()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClicked()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.Reset();
    }
}