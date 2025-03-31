using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _playersAtGoal = 0;

    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private PauseMenu _levelBeatMenu;
    
    public void IncrementPlayerGoalCount()
    {
        _playersAtGoal++;

        if(_playersAtGoal == 2)
        {
            FinishedLevel();
        }
    }

    public void FinishedLevel()
    {
        _levelBeatMenu.TogglePause();
        Time.timeScale = 1.0f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !(_levelBeatMenu.GetPauseState()))
        {
            _pauseMenu.TogglePause();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }
}
