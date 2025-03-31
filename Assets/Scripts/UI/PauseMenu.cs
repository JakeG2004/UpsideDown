using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool _isPaused = false;
    private GameManager _gm;

    void Start()
    {
        _gm = FindObjectsByType<GameManager>(FindObjectsSortMode.None)[0];
    }

    public bool GetPauseState()
    {
        return _isPaused;
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;

        if(_isPaused)
        {
            PauseGame();
        }

        else
        {
            UnpauseGame();
        }
    }

    public void PauseGame()
    {
        _isPaused = true;
        this.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void UnpauseGame()
    {
        _isPaused = false;
        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
    }

    public void RestartPressed()
    {
        TogglePause();
        _gm.RestartLevel();
    }

    public void MainMenuPressed()
    {
        TogglePause();
        _gm.LoadLevel("MainMenu");
    }

    public void QuitPressed()
    {
        TogglePause();
        _gm.QuitGame();
    }

    public void LoadNextLevel(string nextLevel)
    {
        TogglePause();
        _gm.LoadLevel(nextLevel);
    }
}
