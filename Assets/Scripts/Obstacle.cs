using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private ObstacleType type = ObstacleType.Null;

    // Update is called once per frame
    void Update()
    {
        
    }

    public ObstacleType GetObstacleType() { return type; }
}
