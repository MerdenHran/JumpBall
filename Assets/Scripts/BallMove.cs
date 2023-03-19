using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Moving _moveDirection = Moving.Stop;
    private bool _stop = false;
    private int _score = 0;

    public int Score { get => _score; }

    public void SetDefault(int freezeTime = 0)
    {
        transform.position = new Vector3(0, 0, 0);
        _score = 0;
        _moveDirection = Moving.Stop;
        _stop = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameController.isGameStarted)
            ChangeDirection();

        if (!_stop)
            switch (_moveDirection)
            {
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
        _score++;
        _stop = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _stop = false;
    }

    private void ChangeDirection()
    {
        if (_moveDirection == Moving.Stop)
            _moveDirection = Moving.Up;

        if (_stop)
        {
            switch (_moveDirection)
            {
                case Moving.Up:
                    _moveDirection = Moving.Down;
                    break;
                case Moving.Down:
                    _moveDirection = Moving.Up;
                    break;
            }

            _stop = false;
        }
    }
}
