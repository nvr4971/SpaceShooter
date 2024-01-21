using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public static PlayerAttackController Instance { get; private set; }

    [Header("Player Attack Stats")]
    [SerializeField] private Transform projectileFirePoint;
    [SerializeField] private Projectile projectilePf;
    [SerializeField] private float fireRate;

    [Header("Player Projectile Prefabs")]
    [SerializeField] private Projectile projectile1;
    [SerializeField] private Projectile projectile2;
    [SerializeField] private Projectile projectile3;
    [SerializeField] private Projectile projectile4;

    private float attackTimer;

    private void Awake()
    {
        if (PlayerAttackController.Instance != null)
        {
            Destroy(PlayerAttackController.Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        attackTimer = 0f;

        projectile1 = PlayerSpriteLoader.Instance.GetPlayerProjectile1Sprite();
        projectile2 = PlayerSpriteLoader.Instance.GetPlayerProjectile2Sprite();
        projectile3 = PlayerSpriteLoader.Instance.GetPlayerProjectile3Sprite();
        projectile4 = PlayerSpriteLoader.Instance.GetPlayerProjectile4Sprite();

        UpdateProjectilePrefab(PlayerGlobalStats.Instance.GetPower());
    }

    private void Update()
    {
        PlayerAttack();
    }

    private void PlayerAttack()
    {
        if (Input.GetMouseButton(0) && attackTimer <= 0)
        {
            Shoot();
            attackTimer = fireRate;
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            attackTimer = 0;
        }
    }

    private void Shoot()
    {
        Instantiate(projectilePf, projectileFirePoint.position, Quaternion.identity);
    }

    private Projectile GetPlayerProjectileSprite(int powerlvl)
    {
        return powerlvl switch
        {
            1 => projectile1,
            2 => projectile2,
            3 => projectile3,
            4 => projectile4,
            _ => null,
        };
    }

    public void UpdateProjectilePrefab(int power)
    {
        projectilePf = GetPlayerProjectileSprite(power);
    }
}
