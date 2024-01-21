using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour
{
    [SerializeField] private float powerupSpeed;

    private void Update()
    {
        transform.Translate(powerupSpeed * Time.deltaTime * Vector2.down);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerGlobalStats.Instance.AddPower(1);
            Destroy(gameObject);
        }
    }
}
