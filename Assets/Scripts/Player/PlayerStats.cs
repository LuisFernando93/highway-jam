using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int gas;
    [SerializeField] private int maxGas;
    private int score;

    private void Start()
    {
        if (health < 0) health = 0;
        if (health > maxHealth) maxHealth = health;
        if (gas < 0) gas = 0;
        if (gas > maxGas) gas = maxGas;
        score = 0;
    }

    private void Update()
    {
        
    }

    public int GetHealth() { return health; }
    public int GetGas() { return gas; }
    public int GetScore() { return score; }

    public void Heal(int heal)
    {
        health += heal;
        if (health > maxHealth) health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
    }

    public void FillGas(int fill)
    {
        gas += fill;
        if (gas > maxGas) gas = maxGas;
    }
}
