using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackAreaTrigger : MonoBehaviour
{
    public string targetTag = "Enemy"; //�U���Ώۂ̃^�O

    void OnTriggerter2D(Collider2D other)
    {
        if(other.CompareTag(targetTag))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

           if(enemyHealth != null)
           {
           enemyHealth.TakeDamage(enemyHealth.damageReceivedFromPlayerAttack);
           }
        }
    }
}
