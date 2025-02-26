using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _stopDistance = 1f;

    private void Update()
    {
        if (_player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if (distanceToPlayer > _stopDistance)
        {
            Vector2 direction = (_player.position - transform.position).normalized;
            transform.position += (Vector3)direction * _speed * Time.deltaTime;
        }
    }
}