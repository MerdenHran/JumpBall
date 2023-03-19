using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static bool isGameStarted = false;
    [SerializeField] private PlatformSpawner _spawner;
    [SerializeField] private BallMove _ballMove;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private TextMeshProUGUI _scorePrintField;

    // Boundaries of the game zone
    private float _xLevel = -10f;
    private float _yLevel = 5f;

    void Start()
    {
        Time.timeScale = 0;
        _spawner.StartSpawn();
    }

    void Update()
    {
        _scorePrintField.text = $"Score: {_ballMove.Score}";

        if (!CheckBallAllowPosition()) {
            PauseGame();
            _pauseButton.onClick.Invoke();
        }
    }

    public void StartGame()
    {
        if(!CheckBallAllowPosition())
            _ballMove.SetDefault();
        
        Time.timeScale = 1;
        isGameStarted = true;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isGameStarted = false;
    }

    private bool CheckBallAllowPosition()
    {
        if (_ballMove.transform.position.x < _xLevel || _ballMove.transform.position.y > _yLevel || _ballMove.transform.position.y < -1 * _yLevel)
            return false;
        return true;
    }

    public void ExitGame() => Application.Quit();
}
