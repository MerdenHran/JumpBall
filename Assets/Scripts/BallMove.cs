using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Moving _currentDirection = Moving.Stop;
    private Moving _lastDirection = Moving.Down;

    public Moving CurrentDirection {
        get => _currentDirection;
        set {
            _currentDirection = value;
            Debug.Log($"Current direction: [{_currentDirection.ToString().ToUpper()}]");
        }
    }

    public Moving LastDirection {
        get => _lastDirection;
        set {
            _lastDirection = value;
            Debug.Log($"Last direction: [{_lastDirection.ToString().ToUpper()}]");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ChangeDirection();

        switch (CurrentDirection) {
            case Moving.Up:
                transform.Translate(0, _speed * Time.deltaTime, 0);
                break;
            case Moving.Down:
                transform.Translate(0, -1 * _speed * Time.deltaTime, 0);
                break;
            case Moving.Stop:
                //_currentDirection = _lastDirection;
                break;
        }
    }

    private void ChangeDirection()
    {
        if (CurrentDirection == Moving.Stop) {
            if (LastDirection == Moving.Up) {
                CurrentDirection = Moving.Down;
                //_lastDirection = Moving.Down;
            }
            else if (LastDirection == Moving.Down){
                CurrentDirection = Moving.Up;
                //_lastDirection = Moving.Down;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CurrentDirection != Moving.Stop) {
            LastDirection = CurrentDirection;
            CurrentDirection = Moving.Stop;
        }
    }
}
