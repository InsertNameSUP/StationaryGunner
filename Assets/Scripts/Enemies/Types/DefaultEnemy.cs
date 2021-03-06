using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : Enemy
{
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Gunner.Damage(attributes.damage, true);
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        transform.up = Vector3.Lerp(transform.up, rb.velocity, Time.deltaTime * 3f);
    }
    public void MoveTowardsPlayer(float speed, float maxSpeed)
    {
        if (rb == null || Gunner.instance == null) return;
        if (rb.velocity.sqrMagnitude > maxSpeed) return;
        // Change with a more sophisticated algorythm later
        rb.AddForce((Gunner.instance.transform.position - transform.position).normalized * speed * Time.deltaTime * 10);
    }
    private void FixedUpdate()
    {
        MoveTowardsPlayer(attributes.acceleration, attributes.maxSpeed);
    }
}
