using UnityEngine;

public class ScoreItem : Item
{
    [SerializeField] private int score = 50;
    public override void Effect()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().AddScore(score);
    }
}
