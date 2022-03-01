using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util.TwoD;
public class Gunner : MonoBehaviour
{
    public static GameObject instance = null;
    public float gunnerRotateSpeed = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = gameObject;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Normalize to stop rotation speeding up if mouse is far away
        transform.up = Vector3.Lerp(transform.up, (Mouse.GetMouseWorldPos()).normalized, Time.deltaTime * gunnerRotateSpeed); // Opposite Controls (Faces away from mouse)
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().Play("MC_Damaged");
    }
}
