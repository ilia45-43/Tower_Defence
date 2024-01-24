using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    [SerializeField] public List<EnemyMovement> _enemes;
    [SerializeField] private EnemyMovement CurrentEnemyTarget;

    public GameObject _bullet;
    public GameObject _firePoint;
    public int _damageGun;

    private WaitForSeconds waitForSeconds;
    [SerializeField] private float delayForShoot;
    [SerializeField] private float bulletSpeed;

    [SerializeField] private GameObject _fireParticle;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyMovement newEnemy = other.GetComponent<EnemyMovement>();
            _enemes.Add(newEnemy);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyMovement enemy = other.GetComponent<EnemyMovement>();
            if (_enemes.Contains(enemy))
            {
                _enemes.Remove(enemy);
            }
        }
    }

    private void Start()
    {
        waitForSeconds = new WaitForSeconds(delayForShoot);

        StartCoroutine(ShootTurret());
    }

    private void Update()
    {
        GetCurrentenemyTarget();
        RotateTowardsTarget();
    }

    private void RotateTowardsTarget()
    {
        if (CurrentEnemyTarget == null)
            return;

        transform.rotation = Quaternion.identity;
        transform.Rotate(Vector3.forward, (Mathf.Atan2(transform.position.y - CurrentEnemyTarget.transform.position.y, 
            transform.position.x - CurrentEnemyTarget.transform.position.x) * 180 / Mathf.PI) - 270f);
    }

    private IEnumerator ShootTurret()
    {
        while (true)
        {
            if (CurrentEnemyTarget != null)
            {
                GameObject bullet = Instantiate(_bullet, _firePoint.transform.position, _firePoint.transform.rotation);
                bullet.GetComponent<BulletScr>()._damage = _damageGun;
                bullet.GetComponent<Rigidbody2D>().velocity = _firePoint.transform.up * bulletSpeed;
                bullet.GetComponent<BulletScr>()._currentEnemy = CurrentEnemyTarget;
                Instantiate(_fireParticle, _firePoint.transform);
                _audioManager.PlaySFX(_audioManager.shot);
                yield return waitForSeconds;
            }
            else
            {
                yield return null;
            }
        }
    }

    private void GetCurrentenemyTarget()
    {
        if (_enemes.Count <= 0)
        {
            CurrentEnemyTarget = null;
            return;
        }

        CurrentEnemyTarget = _enemes[0];
    }
}