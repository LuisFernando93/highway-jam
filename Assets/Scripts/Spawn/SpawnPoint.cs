using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private ItemType[] availableItems = null;
    [SerializeField] private ObstacleType[] availableObstacles = null;

    public ItemType itemSpawned()
    {
        if (availableItems != null & availableItems.Length != 0)
        {
            int rngItem = Random.Range(0, availableItems.Length);
            return availableItems[rngItem];
        }
        else
        {
            return ItemType.Null;
        }
    }

    public ObstacleType obstacleSpawned()
    { 
        if (availableObstacles != null & availableObstacles.Length != 0)
        {
            int rngObstacle = Random.Range(0,availableObstacles.Length);
            return availableObstacles[rngObstacle];
        }
        else
        {
            return ObstacleType.Null;
        }
    }
}
