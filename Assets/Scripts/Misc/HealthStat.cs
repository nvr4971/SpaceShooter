using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthStat : MonoBehaviour
{
    [Header("HP")]
    [SerializeField] private int hp;

    [Header("Shield")]
    [SerializeField] private int shield;
    [SerializeField] private SpriteRenderer shieldPoint;

    [Header("On Death Effect")]
    [SerializeField] private GameObject explosionPrefab;

    [Header("On Death Event")]
    [SerializeField] UnityEvent onDeath;

    private void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            explosionPrefab = PlayerSpriteLoader.Instance.GetExplosionPrefab();
        }
        
        SetShield(0);
    }

    private void Update()
    {
        if (hp <= 0)
        {
            // Explode
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);

            // Update active enemy count for spawner
            onDeath?.Invoke();
        }
    }

    public void TakeDamage(int amount)
    {
        if (shield == 0)
        {
            hp -= amount;
        }
        else
        {
            SoundManager.Instance.PlaySound(SoundEffect.ShieldLose);
            SetShield(-1);
        }
    }

    public void GainShield()
    {
        if (shield < 3)
        {
            SoundManager.Instance.PlaySound(SoundEffect.ShieldGain);
            SetShield(1);
        }
        else
        {
            ScoreDisplay.Instance.AddScore(10);
        }
    }

    private void SetShield(int offset)
    {
        shield += offset;
        shieldPoint.sprite = SpriteAssets.Instance.GetShieldSprite(shield);

        if (gameObject.CompareTag("Player"))
        {
            ShieldDisplay.Instance.UpdateShieldUI(shield);
        }
    }
}
