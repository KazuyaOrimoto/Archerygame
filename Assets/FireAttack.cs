using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    private Rigidbody rigit;
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.transform.LookAt(player.transform);
        rigit = GetComponent<Rigidbody>();
        rigit.AddForce(this.transform.forward * Time.deltaTime * speed, ForceMode.Impulse);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag == "Player")
    //    {
    //        Instantiate(hitEffect, collision.gameObject.transform);
    //    }
    //}

    public GameObject GetHitEffect()
    {
        return hitEffect;
    }
}
