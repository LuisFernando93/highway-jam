using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType type = ItemType.Null;

    // Update is called once per frame
    void Update()
    {
        
    }

    public ItemType GetItemType() { return type; }
}
