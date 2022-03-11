using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public float bulletSpawnOffset = 1;
    public GameObject defBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot(1) ;
        }
    }
    public void Shoot(float bulletSpeed, GameObject bulletType = null)
    {
        GameObject newBullet;
        if (bulletType == null)
        {
            newBullet = Instantiate(defBullet, transform.position + (transform.up * bulletSpawnOffset), Quaternion.identity);
        } else
        {
            newBullet = bulletType;
        }
        newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 200 * bulletSpeed); // Add initial bullet velocity
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + transform.up * bulletSpawnOffset, 0.25f);
    }
}
