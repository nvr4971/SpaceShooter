using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldDisplay : MonoBehaviour
{
    public static ShieldDisplay Instance { get; private set; }

    [SerializeField] private Image shieldCount;
    [SerializeField] private HealthStat playerHealthStat;

    public void UpdateShieldUI(int shield)
    {
        shieldCount.sprite = SpriteAssets.Instance.GetNumberSprite(shield);
    }

    private void Awake()
    {
        if (ShieldDisplay.Instance != null)
        {
            Destroy(ShieldDisplay.Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
