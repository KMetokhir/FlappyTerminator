using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), (typeof(SpriteRenderer)))]
public abstract class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0f;
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Becom Invisible " + gameObject.name);
        gameObject.SetActive(false);
    }

    public void AddForce(float magnitude)
    {
        _rigidbody2D.velocity = transform.right * magnitude;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDestroyable destroyable))
        {
            //OnDestoyableObjectAction(destroyable);
            destroyable.Destroy();
        }
    }

    /* protected abstract void OnDestoyableObjectAction(IDestroyable destroyable);*/

}
