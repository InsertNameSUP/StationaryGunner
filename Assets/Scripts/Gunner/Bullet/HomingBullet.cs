using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }
    private void FixedUpdate()
    {
        MoveToEnemy(100, 100);
    }
    void MoveToEnemy(float maxSpeed, float accel)
    {
        if (rb == null) return;
        if (rb.velocity.sqrMagnitude > maxSpeed) return;
        // Change with a more sophisticated algorythm later
        transform.up = (GetClosestEnemy().transform.position - transform.position).normalized;
        rb.AddForce(transform.up * accel * Time.deltaTime, ForceMode2D.Force);
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
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }
}
