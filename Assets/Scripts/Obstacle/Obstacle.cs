using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;
    private Collider2D obstacleCollider;
    [SerializeField] private ObstacleType type = ObstacleType.Null;
    [SerializeField] private int spawnTime;
    [SerializeField] private int damage = 1;
    private float timer;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        obstacleCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (obstacleCollider.IsTouching(player.GetComponent<Collider2D>()))
        {
            Debug.Log("Bateu!");
            
            player.GetComponent<PlayerStats>().TakeDamage(damage);
        }
        timer += Time.deltaTime;
        if (timer >= spawnTime) Destroy(this.gameObject); 

    }

    public ObstacleType GetObstacleType() { return type; }
}
