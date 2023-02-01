using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool _thrusting;
    private float _turnDirection;
    public float _thrustSpeed = 1.0f;
    public float _turnSpeed = 1.0f;

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDirection= 1.0f;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDirection = -1.0f;
        }
        else
        {
            _turnDirection = 0.0f;
        }
        
    }
    private void FixedUpdate()
    {
        if(_thrusting )
        {
            _rigidbody.AddForce(transform.up * _thrustSpeed);
        }
        if (_turnDirection != 0.0f)
        {
            _rigidbody.AddTorque(_turnDirection*_turnSpeed);
        }
    }
}
