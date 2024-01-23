using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour
{
    [SerializeField] private float lifeUpSpeed;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = SpriteAssets.Instance.GetPlayerUISprite();
    }

    private void Update()
    {
        transform.Translate(lifeUpSpeed * Time.deltaTime * Vector2.down);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySound(SoundEffect.ItemPickup);
            PlayerGlobalStats.Instance.AddLife(1);
            Destroy(gameObject);
        }
    }
}
