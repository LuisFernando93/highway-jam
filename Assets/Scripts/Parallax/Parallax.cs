using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] bool scrollLeft;

    private float singleTextureWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupTexture();
        if (scrollLeft) moveSpeed = -moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
        CheckReset();
    }

    void SetupTexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singleTextureWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }

    void Scroll()
    {
        float delta = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(delta, 0, 0);
    }

    void CheckReset()
    {
        if ( (Mathf.Abs(transform.position.x) - singleTextureWidth) > 0)
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
    }
}
