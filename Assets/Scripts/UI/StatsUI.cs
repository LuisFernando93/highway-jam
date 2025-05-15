using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private GameObject healthDisplay;
    [SerializeField] private GameObject scoreDisplay;
    [SerializeField] private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.GetComponent<TextMeshProUGUI>().text = player.GetComponent<PlayerStats>().GetHealth().ToString();
        scoreDisplay.GetComponent<TextMeshProUGUI>().text = player.GetComponent <PlayerStats>().GetScore().ToString();
    }
}
