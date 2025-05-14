using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D playerCollider;
    [SerializeField] private PlayerShift playerShift;
    [SerializeField] private Collider2D floorCollider;
    [SerializeField] private Collider2D cellingCollider;
    private bool isFalling;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerShift.IsCar() & !cellingCollider.enabled)
        {
            rb.gravityScale = 1f;
            isFalling = true;
            if (floorCollider.IsTouching(playerCollider))
            {
                Debug.Log("chegou no chao");
                rb.gravityScale = 0f;
                rb.linearVelocity = Vector2.zero;
                cellingCollider.enabled = true;
                isFalling = false;
            }
        }
    }

    public bool IsFalling() { return isFalling;}
}
