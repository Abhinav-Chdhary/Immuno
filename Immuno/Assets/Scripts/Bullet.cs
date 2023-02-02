using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float speed = 500.0f;
    public float maxLifeTime = 5.0f;

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody2D>();
    }
    public void Project(Vector2 direction)
    {
        _rigidbody.AddForce(direction*speed);

        Destroy(gameObject, maxLifeTime);
    }
}
