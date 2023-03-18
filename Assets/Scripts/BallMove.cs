using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;
    private Moving _currentDirection = Moving.Stop;
    private Moving _lastDirection = Moving.Down;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ChangeDirection();

        switch (_currentDirection) {
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
        if (_currentDirection == Moving.Stop) {
            if (_lastDirection == Moving.Up) {
                _currentDirection = Moving.Down;
                //_lastDirection = Moving.Down;
            }
            else if (_lastDirection == Moving.Down){
                _currentDirection = Moving.Up;
                //_lastDirection = Moving.Down;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _lastDirection = _currentDirection;
        _currentDirection = Moving.Stop;
    }
}
