using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] PlayerHealth pH;
    float damage = 25f;

    public void AttackHitEvent()
    {
        if (pH == null) { return; }
        pH.TakeDamage(damage);
    }
}
