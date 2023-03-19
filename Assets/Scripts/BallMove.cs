using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Moving _currentMoveDirection = Moving.Stop;
    private Moving _lastMoveDirection = Moving.Down;

    public Moving CurrentMoveDirection {
        get => _currentMoveDirection;
        set {
            _currentMoveDirection = value;
            Debug.Log($"Current direction: [{_currentMoveDirection.ToString().ToUpper()}]");
        }
    }

    public Moving LastMoveDirection {
        get => _lastMoveDirection;
        set {
            _lastMoveDirection = value;
            Debug.Log($"Last direction: [{_lastMoveDirection.ToString().ToUpper()}]");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameController.isGameStarted)
            ChangeDirection();

        switch (CurrentMoveDirection) {
            case Moving.Up:
                transform.Translate(0, _speed * Time.deltaTime, 0);
                break;
            case Moving.Down:
                transform.Translate(0, -1 * _speed * Time.deltaTime, 0);
                break;
        }
    }

    private void ChangeDirection()
    {
        if (CurrentMoveDirection == Moving.Stop) {
            if (LastMoveDirection == Moving.Up) {
                CurrentMoveDirection = Moving.Down;
            }
            else if (LastMoveDirection == Moving.Down){
                CurrentMoveDirection = Moving.Up;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (CurrentMoveDirection != Moving.Stop) {
            LastMoveDirection = CurrentMoveDirection;
            CurrentMoveDirection = Moving.Stop;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollision EXIT");
        if(CurrentMoveDirection == Moving.Stop)
            CurrentMoveDirection = LastMoveDirection;
    }
}
