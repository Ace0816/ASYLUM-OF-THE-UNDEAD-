using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float hP = 100f;

    EnemyAI enemyAI;

    bool isDead = false;

    private void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    public bool IsDead()
    {
        return isDead;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            TakeDamage(other.GetComponent<AttackEnemy>().weaponDamage);
            Debug.Log("Enemy Damaged");
        }
    }

    public void TakeDamage(float weaponDamage)
    {
        enemyAI.OnDamageTaken();
        hP -= weaponDamage;
        if(hP <= 0)
        {
            if(isDead) { return;  }
            isDead = true;
            GetComponent<Animator>().SetTrigger("dyingTrigger");
            GetComponent<EnemyAI>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
