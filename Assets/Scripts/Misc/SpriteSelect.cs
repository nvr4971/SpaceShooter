using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpriteSelect : MonoBehaviour
{
    [SerializeField] private List<SpriteSet> blueShips;
    [SerializeField] private List<SpriteSet> greenShips;
    [SerializeField] private List<SpriteSet> redShips;

    [SerializeField] private Image ship1;
    [SerializeField] private Image ship2;
    [SerializeField] private Image ship3;

    private readonly List<List<SpriteSet>> ships = new();
    private int color;

    private void Start()
    {
        ships.Add(blueShips); // 0

        ships.Add(greenShips); // 1

        ships.Add(redShips); // 2
    }

    private void UpdateSelectImages()
    {
        ship1.sprite = ships[color][0].playerSprite;
        ship2.sprite = ships[color][1].playerSprite;
        ship3.sprite = ships[color][2].playerSprite;
    }

    public void SelectColor(int colorIndex)
    {
        color = colorIndex;
        UpdateSelectImages();
    }

    public void SelectShip(int shipIndex)
    {
        PlayerSpriteLoader.Instance.SetPlayerSpriteSet(ships[color][shipIndex]);
        SceneManager.LoadScene(2);
    }
}
