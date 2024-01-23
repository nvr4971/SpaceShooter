using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField] private Projectile projectilePf;
    [SerializeField] private Transform projectileFirePoint;
    [SerializeField] private float minFireRate;
    [SerializeField] private float maxFireRate;

    private float attackTimer;
    private bool canAttack;

    private void Start()
    {
        attackTimer = 0;
        canAttack = false;
    }

    private void Update()
    {
        EnemyAttack();
    }

    private void EnemyAttack()
    {
        if (attackTimer <= 0 && canAttack)
        {
            Shoot();
            attackTimer = Random.Range(minFireRate, maxFireRate);
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        SoundManager.Instance.PlaySound(SoundEffect.EnemyShoot);
        Instantiate(projectilePf, projectileFirePoint.position, Quaternion.identity);
    }

    public void SetAttack()
    {
        canAttack = true;
    }
}
