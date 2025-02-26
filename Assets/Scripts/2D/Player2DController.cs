using UnityEngine;
public class Player2DController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _movement;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movement.normalized * _speed;
    }
}