using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAssets : MonoBehaviour
{
    public static SpriteAssets Instance { get; private set; }

    [Header("UI Number Sprite")]
    [SerializeField] private List<Sprite> numberSprites;

    private void Awake()
    {
        if (SpriteAssets.Instance != null)
        {
            Destroy(SpriteAssets.Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public Sprite GetNumberSprite(int num)
    {
        return numberSprites[num];
    }

    [Header("Player Sprite")]
    [SerializeField] private Sprite playerUISprite;
    [SerializeField] private Sprite playerSprite;

    private void Start()
    {
        playerSprite = PlayerSpriteLoader.Instance.GetPlayerSprite();
        playerUISprite = PlayerSpriteLoader.Instance.GetPlayerUISprite();
    }

    public Sprite GetPlayerUISprite()
    {
        return playerUISprite;
    }

    public Sprite GetPlayerSprite()
    {
        return playerSprite;
    }

    [Header("Shield Sprite")]
    [SerializeField] private Sprite shield1Sprite;
    [SerializeField] private Sprite shield2Sprite;
    [SerializeField] private Sprite shield3Sprite;

    public Sprite GetShieldSprite(int shieldlvl)
    {
        return shieldlvl switch
        {
            1 => shield1Sprite,
            2 => shield2Sprite,
            3 => shield3Sprite,
            _ => null,
        };
    }
}
