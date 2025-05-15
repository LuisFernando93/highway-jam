using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private GameObject healthDisplay;
    [SerializeField] private GameObject scoreDisplay;
    [SerializeField] private Image gasFill;
    [SerializeField] private float gasChangeSpeed = 10f;

    [SerializeField] private float gasFillAmount = 1f;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.GetComponent<TextMeshProUGUI>().text = player.GetComponent<PlayerStats>().GetHealth().ToString();
        scoreDisplay.GetComponent<TextMeshProUGUI>().text = player.GetComponent <PlayerStats>().GetScore().ToString();

        gasFillAmount = player.GetComponent<PlayerStats>().GetGas()/player.GetComponent<PlayerStats>().GetMaxGas();
        gasFill.fillAmount = Mathf.Lerp(gasFill.fillAmount, gasFillAmount, gasChangeSpeed * Time.deltaTime);
    }
}
