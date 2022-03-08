using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HomingBullet : Bullet
{
    Vector3 direction;
    [Tooltip("How Quickly the bullet builds up the desire to hit an enemy (being less careful about hitting player)")]public float attackGreed = 1f;
    float avoidWeighting = 6f;
    [Tooltip("How Quickly the bullet tracks the enemy")] public float bulletSpeed = 7f;
    float attackWeighting = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        MoveToEnemy(5, 200);

    }
    private void FixedUpdate()
    {

    }
    void MoveToEnemy(float speed, float rotSpeed)
    {
        avoidWeighting = Mathf.Lerp(avoidWeighting, 4f, Time.deltaTime * attackGreed);
        attackWeighting = Mathf.Lerp(attackWeighting, 6f, Time.deltaTime * attackGreed);
        print(avoidWeighting);
        if (rb == null || GetClosestEnemy() == null) return;
        direction = ((GetClosestEnemy().transform.position - transform.position).normalized * (attackWeighting / Vector3.Distance(Gunner.instance.transform.position, transform.position))) // Account for moving towards closest enemy. The further away + longer time the bullets alive, the more enticing it is to move towards enemy.
                    + (transform.position - Gunner.instance.transform.position).normalized * 1/((Vector3.Distance(Gunner.instance.transform.position, transform.position))/ avoidWeighting); // Account for Gunner and move away. The further away + longer time the bullet is alive, the less it takes this into account.
        direction.Normalize();
        transform.up = direction;
        transform.position = Vector3.Lerp(transform.position, transform.position + direction, Time.deltaTime * bulletSpeed);

    }
    Enemy GetClosestEnemy()
    {
        Enemy closestEnemy = null;
        for(int i = 0; i < Enemy.allEnemies.Count; i ++)
        {
            if (i == 0) { closestEnemy = Enemy.allEnemies[0]; continue; }
            if(Vector3.Distance(transform.position, Enemy.allEnemies[i].transform.position) < Vector3.Distance(transform.position, closestEnemy.transform.position))
            {
                closestEnemy = Enemy.allEnemies[i];
            }
        }
        return closestEnemy;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Gunner.instance.transform.position, 1);
        Gizmos.DrawRay(transform.position + transform.up, direction);
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }
}
