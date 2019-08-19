using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttack : MonoBehaviour
{
    private Rigidbody rigit;
    [SerializeField]
    private float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.transform.LookAt(player.transform);
        rigit = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigit.AddForce(this.transform.forward * Time.deltaTime * speed, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
