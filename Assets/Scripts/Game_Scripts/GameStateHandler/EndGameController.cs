using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private string winSceneName;
    
    [SerializeField] private string loseSceneName;
    void Start()
    {

        EventManager.OnGameOver += LoseGame;
        EventManager.OnGameWin += WinGame;
    }

    private void OnDestroy()
    {
        EventManager.OnGameOver -= LoseGame;
        EventManager.OnGameWin -= WinGame;
    }

    private void WinGame()
    {
        SceneManager.LoadScene(winSceneName);
    }

    private void LoseGame()
    {
        SceneManager.LoadScene(loseSceneName);
    }
}
