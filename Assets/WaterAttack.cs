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
        if(player != null)
        {
            this.transform.LookAt(player.transform);
            rigit = GetComponent<Rigidbody>();
            rigit.AddForce(this.transform.forward * Time.deltaTime * speed, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.transform.tag == "Player")
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
