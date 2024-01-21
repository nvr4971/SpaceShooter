using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Stats")]
    [SerializeField] private float projectileSpeed;
    [SerializeField] private int projectileDamage;
    [SerializeField] private float projectileLifetime;

    [Header("Is Player Projectile?")]
    [SerializeField] private bool isPlayerProjectile;

    private Rigidbody2D rb;
    private Vector2 projectileDirection;
    private string checkTag;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        projectileDirection = isPlayerProjectile ? Vector2.up : Vector2.down;

        checkTag = isPlayerProjectile ? "Enemy" : "Player";
    }

    private void Update()
    {
        Destroy(gameObject, projectileLifetime);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (projectileSpeed * Time.fixedDeltaTime * projectileDirection));
    }

    public int GetProjectileDamage()
    {
        return projectileDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(checkTag) && collision.gameObject.GetComponent<HealthStat>())
        {
            collision.gameObject.GetComponent<HealthStat>().TakeDamage(projectileDamage);
            Destroy(gameObject);
        }
    }
}
