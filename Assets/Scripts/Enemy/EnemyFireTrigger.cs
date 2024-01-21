using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && collision.GetComponent<EnemyAttackController>())
        {
            collision.GetComponent<EnemyAttackController>().SetAttack();
        }
    }
}
