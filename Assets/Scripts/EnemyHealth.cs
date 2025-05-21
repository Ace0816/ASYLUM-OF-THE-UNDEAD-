using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float hP = 100f;

    EnemyAI enemyAI;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    public void TakeDamage(float weaponDamage)
    {
        enemyAI.OnDamageTaken();
        hP -= weaponDamage;
        if(hP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
