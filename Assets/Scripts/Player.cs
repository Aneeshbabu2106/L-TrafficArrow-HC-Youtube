using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 8f;

    private Vector2 moveDirection;

    private void Awake()
    {
        moveDirection = Vector2.up;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(-mousePos.x, mousePos.y);
            moveDirection = (mousePos2D - (Vector2)transform.position).normalized;

            float cosAngle = Mathf.Acos(moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, cosAngle * (moveDirection.y > 0 ? 1f : -1f));
        }
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
        if (collision.CompareTag("Obstacle"))
        {
            GamePlayManager.Instance.GameEnded();
            Destroy(gameObject);
            return;
        }
    }
}
