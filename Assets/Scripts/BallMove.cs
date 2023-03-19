using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Moving _currentMoveDirection = Moving.Stop;
    private Moving _lastMoveDirection = Moving.Down;

    public void SetDefaultMoveDirection() {
        _currentMoveDirection = Moving.Stop;
        _lastMoveDirection = Moving.Down;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameController.isGameStarted)
            ChangeDirection();

        switch (_currentMoveDirection) {
            case Moving.Up:
                transform.Translate(0, _speed * Time.deltaTime, 0);
                break;
            case Moving.Down:
                transform.Translate(0, -1 * _speed * Time.deltaTime, 0);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_currentMoveDirection != Moving.Stop) {
            _lastMoveDirection = _currentMoveDirection;
            _currentMoveDirection = Moving.Stop;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(_currentMoveDirection == Moving.Stop)
            _currentMoveDirection = _lastMoveDirection;
    }

    private void ChangeDirection()
    {
        if (_currentMoveDirection == Moving.Stop)
        {
            if (_lastMoveDirection == Moving.Up)
            {
                _currentMoveDirection = Moving.Down;
            }
            else if (_lastMoveDirection == Moving.Down)
            {
                _currentMoveDirection = Moving.Up;
            }
        }
    }
}
