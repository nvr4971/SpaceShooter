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

    private Vector2 cameraBounds;
    private float playerSpriteWidth;
    private float playerSpriteHeight;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = SpriteAssets.Instance.GetPlayerSprite();

        cameraBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Screen.width,
                Screen.height,
                Camera.main.transform.position.z
            )
        );

        playerSpriteWidth = GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2f;
        playerSpriteHeight = GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2f;

        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(PlayerSpawnIn());
    }

    IEnumerator PlayerSpawnIn()
    {
        lockControl = true;
        vertical = 1;
        horizontal = 0;

        yield return new WaitForSeconds(0.3f);

        lockControl = false;

        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void Update()
    {
        if (!lockControl)
        {
            PlayerMove();
        }
        
    }

    private void LateUpdate()
    {
        PlayerBounds();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (playerMoveSpeed * Time.fixedDeltaTime * new Vector2(horizontal, vertical).normalized));
    }

    private void PlayerMove()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void PlayerBounds()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, cameraBounds.x * -1 + playerSpriteWidth, cameraBounds.x - playerSpriteWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, cameraBounds.y * -1 + playerSpriteHeight, cameraBounds.y - playerSpriteHeight);
        transform.position = viewPos;
    }
}
