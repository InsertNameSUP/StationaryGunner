using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    public static List<Enemy> allEnemies = new List<Enemy>();
    public struct Stats
    {
        public int value;
        public int maxHealth;
        public int health;
        public float speed;
        public int damage;
    }
    public Stats attributes = new Stats
    {
        value = 250,
        maxHealth = 100,
        health = 100,
        damage = 10,
        speed = 5
    };
    public virtual void Awake()
    {
        allEnemies.Add(this);
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnDestroy()
    {
        allEnemies.Remove(this);
    }
    public int? Damage(int amount, bool addScore = true)
    {
        attributes.health = Mathf.Max(attributes.health - amount, 0); // If under 0, return 0
        if(attributes.health == 0)
        {
            ScoreManager.AddScore(attributes.value);
            // Kill them with PostProcessing
            Destroy(gameObject);
            return null;
        }
        return attributes.health;
    }
    public void MoveTowardsPlayer(float speed, float maxSpeed)
    {
        if (rb == null || Gunner.instance == null) return;
            if (rb.velocity.sqrMagnitude > maxSpeed) return;
        // Change with a more sophisticated algorythm later
        rb.AddForce((Gunner.instance.transform.position - transform.position).normalized * speed * Time.deltaTime * 10);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Pop.
    }
}
