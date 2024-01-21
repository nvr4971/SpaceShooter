using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteLoader : MonoBehaviour
{
    public static PlayerSpriteLoader Instance { get; private set; }

    private void Awake()
    {
        if (PlayerSpriteLoader.Instance != null)
        {
            Destroy(PlayerSpriteLoader.Instance.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private SpriteSet playerSpriteSet;

    public void SetPlayerSpriteSet(SpriteSet set)
    {
        playerSpriteSet = set;
    }

    public Sprite GetPlayerSprite()
    {
        return playerSpriteSet.playerSprite;
    }

    public Sprite GetPlayerUISprite()
    {
        return playerSpriteSet.playerUISprite;
    }

    public Projectile GetPlayerProjectile1Sprite()
    {
        return playerSpriteSet.playerProjectilePower1;
    }

    public Projectile GetPlayerProjectile2Sprite()
    {
        return playerSpriteSet.playerProjectilePower2;
    }

    public Projectile GetPlayerProjectile3Sprite()
    {
        return playerSpriteSet.playerProjectilePower3;
    }

    public Projectile GetPlayerProjectile4Sprite()
    {
        return playerSpriteSet.playerProjectilePower4;
    }

    public GameObject GetExplosionPrefab()
    {
        return playerSpriteSet.explosionPf;
    }
}
