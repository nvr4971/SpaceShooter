using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    public static LivesDisplay Instance { get; private set; }

    [SerializeField] private Image livesImage;
    [SerializeField] private Image livesCount;

    private void Awake()
    {
        if (LivesDisplay.Instance != null)
        {
            Destroy(LivesDisplay.Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        livesImage.sprite = SpriteAssets.Instance.GetPlayerUISprite();
    }

    public void UpdateLivesUI(int lives)
    {
        livesCount.sprite = SpriteAssets.Instance.GetNumberSprite(lives);
    }
}
