using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static bool isGameStarted = false;
    [SerializeField] private PlatformSpawner _spawner;
    [SerializeField] private GameObject _ball;
    [SerializeField] private Button _pauseButton;

    // Boundaries of the game zone
    private float _xLevel = -10f;
    private float _yLevel = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        _spawner.StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckBallAllowPosition()) {
            PauseGame();
            _ball.transform.position = new Vector3(0, 0, 0);
            //_ball.GetComponent<BallMove>().SetDefaultMoveDirection();
            _pauseButton.onClick.Invoke();
        }
    }

    public void StartGame() {
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
        if (_ball.transform.position.x < _xLevel || _ball.transform.position.y > _yLevel || _ball.transform.position.y < -1 * _yLevel)
            return false;
        return true;
    }
}
