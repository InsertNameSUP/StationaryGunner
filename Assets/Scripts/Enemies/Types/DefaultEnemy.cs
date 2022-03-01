using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : Enemy
{
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        attributes = new Stats
        {
            maxHealth = 10,
            health = 10,
            damage = 10,
            speed = 5
        };
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer(attributes.speed, 10);
    }
}
