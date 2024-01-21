using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    [SerializeField] private float shieldPickupSpeed;

    private void Update()
    {
        transform.Translate(shieldPickupSpeed * Time.deltaTime * Vector2.down);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.GetComponent<HealthStat>())
        {
            collision.GetComponent<HealthStat>().GainShield();
            Destroy(gameObject);
        }
    }
}
