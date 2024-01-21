using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerDisplay : MonoBehaviour
{
    public static PowerDisplay Instance { get; private set; }

    [SerializeField] private Image powerCount;

    public void UpdatePowerUI(int power)
    {
        powerCount.sprite = SpriteAssets.Instance.GetNumberSprite(power);
    }

    private void Awake()
    {
        if (PowerDisplay.Instance != null)
        {
            Destroy(PowerDisplay.Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
