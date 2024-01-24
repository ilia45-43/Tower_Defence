using System;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class enemyHealthSystem : MonoBehaviour
{
    public int damageForBoss;

    [SerializeField] private int health;
    [SerializeField] private int amountMoney;

    private MoneySystem moneySystem;
    private Animator animator;

    public GameObject _bloodParticle;
    public GameObject _deathParticle;

    public HealthBar healthBar;
    public GameObject _coin;

    private bool isDeath = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        moneySystem = GameObject.FindGameObjectWithTag("MoneySystem").GetComponent<MoneySystem>();
        healthBar.SetMaxHealth(health);
    }

    public void TakeDamage(int amount)
    {
        Instantiate(_bloodParticle, gameObject.transform);
        health -= amount;

        healthBar.SetHealth(health);

        if (health <= 0)
        {
            if (!isDeath)
            {
                isDeath = true;
                Death();
                var a = Instantiate(_coin);
                a.transform.position = gameObject.transform.position;
                Destroy(a, 1f);
                moneySystem.AddMoney(amountMoney);
            }
        }
    }

    private void Death()
    {
        Instantiate(_deathParticle, gameObject.transform);
        Destroy(gameObject, 0.5f);
    }

    public void BossClick()
    {
        TakeDamage(damageForBoss);
    }
}
