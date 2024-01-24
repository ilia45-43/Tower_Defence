using UnityEngine;

public class BulletScr : MonoBehaviour
{
    public int _damage;
    public EnemyMovement _currentEnemy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.GetComponent<EnemyMovement>() == _currentEnemy)
            {
                other.GetComponent<enemyHealthSystem>().TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }

    private void Awake()
    {
        Destroy(gameObject, 1f);
    }
}
