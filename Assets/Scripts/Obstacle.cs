using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Collider2D playerCollider;
    private Collider2D obstacleCollider;
    [SerializeField] private ObstacleType type = ObstacleType.Null;
    [SerializeField] private int spawnTime;
    private float timer;

    private void Start()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        obstacleCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (obstacleCollider.IsTouching(playerCollider))
        {
            Debug.Log("Bateu!");
        }
        timer += Time.deltaTime;
        if (timer >= spawnTime) Destroy(this.gameObject); 

    }

    public ObstacleType GetObstacleType() { return type; }
}
