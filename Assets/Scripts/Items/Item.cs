using Unity.VisualScripting;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private GameObject player;
    private Collider2D playerCollider;
    private Collider2D itemCollider;
    [SerializeField] private int spawnTime;
    private float timer;
    [SerializeField] private ItemType type = ItemType.Null;


    private void Start()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        itemCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (itemCollider.IsTouching(playerCollider))
        {
            Effect();
            Destroy(this.gameObject);
        }
        timer += Time.deltaTime;
        if (timer >= spawnTime) Destroy(this.gameObject);
    }

    public ItemType GetItemType() { return type; }

    public abstract void Effect();
}
