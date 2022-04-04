using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util.TwoD;
public class EnemieSpawner : MonoBehaviour
{
    [Tooltip("List Of Gameobjects the Enemy Spawner can spawn")]public GameObject[] spawnables;
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

        // Dont minus 1 from spawnables.Length because Random.Range() is not inclusive when dealing with ints.
        Instantiate(spawnables[(int)Random.Range(0, spawnables.Length)], (Random.Range(0, 2) * 2 - 1) * Geometry.PositionOnCircle(new Vector3(0, 0, 0), spawnArea, yPos), Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Gunner.instance != null ? Gunner.instance.transform.position : Vector3.zero, spawnArea);
    }
}
