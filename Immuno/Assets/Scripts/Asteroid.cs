using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float size = 1.25f;
    public float minSize = 0.75f;
    public float maxSize = 1.75f;
    public float speed = 50.0f;
    public float maxLifeTime = 30.0f;
    public Sprite[] sprites;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody= GetComponent<Rigidbody2D>();
        _spriteRenderer= GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0,sprites.Length)];

        transform.eulerAngles = new Vector3(0,0,Random.value*360.0f);
        transform.localScale = Vector3.one * size;
        
        _rigidbody.mass= size;
    }
    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody.AddForce(direction*speed);

        Destroy(gameObject, maxLifeTime);
    }
}