using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    public float speed;
    [SerializeField] float spawnTime = 0.4f;
    [SerializeField] int obstaclesCount = 2;
    private float timer = 0;
    private int counter = 0;
    [SerializeField] private List<GameObject> itemPrefabs;
    [SerializeField] private List<GameObject> obstaclesPrefabs;

    // Update is called once per frame
    void Update()
    {
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime) 
        {
            Spawn();
            timer = 0;
        }
    }

    private void Spawn()
    {
        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        ItemType itemType = spawnPoint.GetComponent<SpawnPoint>().itemSpawned();
        GameObject item = itemPrefabs.Find(item => item.GetComponent<Item>().GetItemType() == itemType);

        GameObject spawnedItem = Instantiate(item, spawnPoint.transform.position, Quaternion.identity);
        Rigidbody2D objectRB = spawnedItem.GetComponent<Rigidbody2D>();
        objectRB.linearVelocity = Vector2.left * speed;
    }
}
