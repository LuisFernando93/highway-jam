using UnityEngine;

public class PlayerShift : MonoBehaviour
{
    [SerializeField] private Collider2D cellingCollider;
    [SerializeField] private PlayerStats stats;
    [SerializeField] private Sprite carSprite, planeSprite;
    [SerializeField] private AudioClip transformSFX;
    private bool isCar = true;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isCar)
            {
                ShiftToPlane();
            }
            else if (!isCar)
            {
                ShiftToCar();
            }
        }

        if (stats.GetGas() <= 0 & !isCar)
        {
            ShiftToCar();
        }
    }

    private void ShiftToCar()
    {
        SoundManager.Instance.PlaySFX(transformSFX);
        gameObject.GetComponent<SpriteRenderer>().sprite = carSprite;
        isCar = true;
        rb.gravityScale = 1f;
        Debug.Log("Agora sou um carro");
    }

    private void ShiftToPlane()
    {
        SoundManager.Instance.PlaySFX(transformSFX);
        gameObject.GetComponent<SpriteRenderer>().sprite = planeSprite;
        isCar = false;
        rb.gravityScale = 0f;
        cellingCollider.enabled = false;
        Debug.Log("Agora sou um aviao");
    }

    public bool IsCar() { return isCar; }
}
