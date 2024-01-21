using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [Header("Player Spawn")]
    [SerializeField] private GameObject playerPf;
    [SerializeField] private Transform playerSpawnPoint;

    [Header("UI")]
    [SerializeField] private Text readyText;
    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        if (PlayerManager.Instance != null)
        {
            Destroy(PlayerManager.Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnPlayer());
    }

    public void RespawnHandler()
    {
        if (PlayerGlobalStats.Instance.GetLife() == 1)
        {
            PlayerGlobalStats.Instance.RemoveLife(1);

            // Game over
            StartCoroutine(GameOver());
        }
        else
        {
            // Reduce life and power
            PlayerGlobalStats.Instance.RemoveLife(1);
            PlayerGlobalStats.Instance.ReducePower();

            // Respawn
            StartCoroutine(SpawnPlayer());
        }
    }

    IEnumerator SpawnPlayer()
    {
        readyText.text = "GET READY!";

        yield return new WaitForSeconds(3);

        readyText.text = "";

        Instantiate(playerPf, playerSpawnPoint.position, Quaternion.identity);
    }

    IEnumerator GameOver()
    {
        EnemySpawn.Instance.enabled = false;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        readyText.text = "GAME OVER!";

        yield return new WaitForSeconds(3);

        ScoreDisplay.Instance.SetFinalScoreText();

        gameOverPanel.SetActive(true);
    }
 }
