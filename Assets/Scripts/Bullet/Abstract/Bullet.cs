using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), (typeof(SpriteRenderer)))]
public abstract class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public event Action<Bullet> BecameInvisible;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0f;
    }

    private void OnBecameInvisible()
    {
        BecameInvisible?.Invoke(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDestroyable destroyable))
        {
            destroyable.Destroy();
            BecameInvisible?.Invoke(this);
        }
    }

    public void AddForce(float magnitude)
    {
        _rigidbody2D.velocity = transform.right * magnitude;
    }
}