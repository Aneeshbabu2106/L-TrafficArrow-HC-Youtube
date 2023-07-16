using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;


    private Vector2 moveDirection;

    private void Awake()
    {
        moveDirection = (new Vector2(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
            )).normalized;
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)(_moveSpeed * Time.fixedDeltaTime * moveDirection);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Side"))
        {
            moveDirection.x *= -1f;
        }
        if (collision.CompareTag("Top"))
        {
            moveDirection.y *= -1f;
        }
    }

}
