using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyGroupMovement : MonoBehaviour
{
    [SerializeField] private float enemyMoveSpeed;
    [SerializeField] private Vector2 xClamp;
    [SerializeField] private Vector2 yClamp;

    [SerializeField] private Transform rowParent;

    private Vector2 direction;
    private bool isClamp;
    private bool isEntry;

    private void Start()
    {
        direction = Vector2.down;
        isClamp = false;
        isEntry = true;
    }

    private void Update()
    {
        GroupMovement();
    }

    private void GroupMovement()
    {
        transform.Translate(enemyMoveSpeed * Time.deltaTime * direction);

        if (transform.position.y <= rowParent.position.y && isEntry)
        {
            Vector3 pos = transform.position;
            pos.y = rowParent.position.y;
            transform.position = pos;

            direction = Vector2.left;
            isClamp = true;
            isEntry = false;
        }

        if (isClamp)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp(pos.x, xClamp.x, xClamp.y);
            pos.y = Mathf.Clamp(pos.y, yClamp.x, yClamp.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);

            if (pos.x == xClamp.x || pos.x == xClamp.y)
            {
                direction *= -1;
            }
        }
    }

    public void SetRowParent(Transform row)
    {
        rowParent = row;
    }
}
