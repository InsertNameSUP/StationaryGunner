using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util.TwoD;
public class EnemieSpawner : MonoBehaviour
{
    public GameObject test_Enemy;
    float spawnDelayTime = 0;
    [Range(1, 100)]public float spawnArea = 40f;
    [Range(0, 20)] public float spawnCooldown = 3f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
         float currentTime = Time.time;
         if (currentTime > spawnDelayTime)
         {
            SpawnEnemyAtRandom();
            spawnDelayTime = Time.time + spawnCooldown;
         }
    }
    void SpawnEnemyAtRandom()
    {
        float yPos = Random.Range(-spawnArea, spawnArea);

        Instantiate(test_Enemy, Geometry.PositionOnCircle(new Vector3(0, 0, 0), spawnArea, yPos), Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Gunner.instance != null ? Gunner.instance.transform.position : Vector3.zero, spawnArea);
    }
}
