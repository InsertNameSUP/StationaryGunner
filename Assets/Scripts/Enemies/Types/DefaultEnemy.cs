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
            value = 250,
            maxHealth = 10,
            health = 10,
            damage = 10,
            speed = 5
        };
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            Gunner.Damage(attributes.damage, true);
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        transform.up = Vector3.Lerp(transform.up, rb.velocity, Time.deltaTime * 3f);
    }
    private void FixedUpdate()
    {
        MoveTowardsPlayer(attributes.speed, 10);
    }
}
