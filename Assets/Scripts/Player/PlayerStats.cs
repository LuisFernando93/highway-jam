using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] PlayerShift playerShift;
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private float gas;
    [SerializeField] private float maxGas;
    [SerializeField] private float scoreIncrement = 0.1f;
    [SerializeField] private float gasUsageRate = 0.5f;
    [SerializeField] private float gasFillUpRate = 0.5f;
    private int score;
    private bool canTakeDamage;
    private Animator animator;
    private float timerScore = 0f;
    private float timerGasFill = 0f;
    private float timerGasUse = 0f;

    private void Start()
    {
        if (health < 0) health = 0;
        if (health > maxHealth) maxHealth = health;
        if (gas < 0) gas = 0;
        if (gas > maxGas) gas = maxGas;
        score = 0;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        timeScore();
        useGas();
    }

    private void LateUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("damage"))
        {
            canTakeDamage = false;
        }
        else
        {
            canTakeDamage = true;
        }
    }

    public int GetHealth() { return health; }
    public float GetGas() { return gas; }
    public float GetMaxGas() { return maxGas; }
    public int GetScore() { return score; }

    public void Heal(int heal)
    {
        health += heal;
        if (health > maxHealth) health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(canTakeDamage)
        {
            health -= damage;
            if (health < 0) health = 0;
            canTakeDamage = false;

            animator.Play("PlayerDamage");
        }
        
    }


    public void FillGas(int fill)
    {
        gas += fill;
        if (gas > maxGas) gas = maxGas;
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void timeScore()
    {
        timerScore += Time.deltaTime;
        if (timerScore >= scoreIncrement)
        {
            score++;
            timerScore = 0f;
        }
    }
    public void useGas()
    {
        if (playerShift.IsCar())
        {
            timerGasFill += Time.deltaTime;
            if (timerGasFill >= gasFillUpRate)
            {
                gas++;
                timerGasFill = 0f;
            }
        } 
        else
        {
            timerGasUse += Time.deltaTime;
            if (timerGasUse >= gasUsageRate)
            {
                gas--;
                timerGasUse = 0f;
            }
        }
        if (gas > maxGas) gas = maxGas;
        if (gas  < 0) gas = 0;
    }
}
