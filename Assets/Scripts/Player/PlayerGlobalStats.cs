using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlobalStats : MonoBehaviour
{
    public static PlayerGlobalStats Instance { get; private set; }

    [Header("Player Global Stats")]
    [SerializeField] private int lives;
    [SerializeField] private int power;

    private void Awake()
    {
        if (PlayerGlobalStats.Instance != null)
        {
            Destroy(PlayerGlobalStats.Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        LivesDisplay.Instance.UpdateLivesUI(lives);
        PowerDisplay.Instance.UpdatePowerUI(power);
    }

    // Life
    public int GetLife()
    {
        return lives;
    }

    public void AddLife(int amount)
    {
        if (lives < 5)
        {
            lives += amount;

            LivesDisplay.Instance.UpdateLivesUI(lives);
        }
        else
        {
            ScoreDisplay.Instance.AddScore(100);
        }
    }

    public void RemoveLife(int amount)
    {
        lives -= amount;

        LivesDisplay.Instance.UpdateLivesUI(lives);
    }

    // Power
    public void AddPower(int amount)
    {
        if (power < 4)
        {
            power += amount;

            PlayerAttackController.Instance.UpdateProjectilePrefab(power);

            PowerDisplay.Instance.UpdatePowerUI(power);
        }
        else
        {
            ScoreDisplay.Instance.AddScore(10);
        }
    }

    public void ReducePower()
    {
        if (power <= 1) 
        {
            return;
        }
        power /= 2;

        PlayerAttackController.Instance.UpdateProjectilePrefab(power);

        PowerDisplay.Instance.UpdatePowerUI(power);
    }

    public int GetPower()
    {
        return power;
    }
}
