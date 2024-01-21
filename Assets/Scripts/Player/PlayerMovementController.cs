using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed;

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;

    private bool lockControl;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = SpriteAssets.Instance.GetPlayerSprite();

        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(PlayerSpawnIn());

    }

    IEnumerator PlayerSpawnIn()
    {
        lockControl = true;
        vertical = 1;
        horizontal = 0;

        yield return new WaitForSeconds(0.8f);

        lockControl = false;

        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (!lockControl)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp(pos.x, 0.05f, 0.95f);
            pos.y = Mathf.Clamp(pos.y, 0.05f, 0.95f);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (playerMoveSpeed * Time.fixedDeltaTime * new Vector2(horizontal, vertical).normalized));
    }
}
