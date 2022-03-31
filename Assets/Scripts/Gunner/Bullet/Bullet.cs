using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]public Rigidbody2D rb;
    public GameObject deathAnim;
    public int bulletLifetime = 10;
    float currentLifetime = 0;
    public int damage = 10;
    float deathTime = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        deathTime = Time.time + bulletLifetime;
    }
    private void OnDestroy()
    {
    }
    // Update is called once per frame
    public virtual void Update()
    {
        currentLifetime = Time.time;
        if (currentLifetime > deathTime)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Enemy"))
        {
            Enemy hit = collision.gameObject.GetComponent<Enemy>();
            hit.Damage(damage);
            Instantiate(deathAnim, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag.Equals("Player"))
        {

            Instantiate(deathAnim, transform.position, Quaternion.identity);
            Gunner.Damage(damage);
            Destroy(gameObject);
        }
    }
}
