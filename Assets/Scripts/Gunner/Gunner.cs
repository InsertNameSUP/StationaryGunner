using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util.TwoD;
public class Gunner : MonoBehaviour
{
    public static int health = 250;
    public static Gunner instance = null;
    public GameObject deathScreen;
    public float gunnerRotateSpeed = 1;
    public static float bulletResilience = 1.5f;
    public static bool isDead = false;
    public delegate void Death();
    public static event Death OnDeath;
    private void Awake()
    {
        instance = this;
        isDead = false;
    }
    void Start()
    {
 
    }
    // Update is called once per frame
    void Update()
    {


        // Normalize to stop rotation speeding up if mouse is far away
        if (GameStateManager.GetGameState() != GameStateManager.GameState.Paused && GameStateManager.GetGameState() != GameStateManager.GameState.Building)
        {
            transform.up = Vector3.Lerp(transform.up, (Mouse.GetMouseWorldPos()).normalized, Time.deltaTime * gunnerRotateSpeed);
        } else
        {
            transform.up = Vector3.Lerp(transform.up, Vector3.up, Time.deltaTime * gunnerRotateSpeed); // If in build mode or paused 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().Play("MC_Damaged");
    }
    public IEnumerator DeathScreenFadeIn(float speed)
    {
        CanvasGroup alphaController = deathScreen.GetComponent<CanvasGroup>();
        float a = 0;
        while (a < 1)
        {
            a += 0.05f * speed;
            alphaController.alpha = a;
            yield return null;
        }
    }
    /// <param name="amount">Amount of health to take from player</param>
    /// <returns>New Health count (null if dead)</returns>
    public static int? Damage(int amount, bool camShake = true)
    {
        health = Mathf.Max(health - amount, 0); // If under 0, return 0
        if (health == 0)
        {
            // Kill them with PostProcessing
            isDead = true;
            if (OnDeath != null) OnDeath();
            UI.instance.StartCoroutine(Gunner.instance.DeathScreenFadeIn(0.125f));
            AudioManager.instance.Play("Death");
            Destroy(instance.gameObject);
            return null;
        }
        else
        {
            AudioManager.instance.Play("Damage");
        }
        if(camShake) CameraController.instance.Shake(0.25f, 0.25f);
        return health;
    }
    public void SetHealth(int amount)
    {
        health = Mathf.Max(amount, 0);
    }
}
