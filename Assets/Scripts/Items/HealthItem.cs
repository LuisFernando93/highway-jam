using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HealthItem : Item
{
    [SerializeField] private int health = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Effect()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().Heal(health);
    }
}
