using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyDieEffect;
    [SerializeField]
    private int hp = 300;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            GameObject effect = Instantiate(enemyDieEffect,this.gameObject.transform.position,this.gameObject.transform.rotation);
        }
    }

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "projectile")
        {
            DestroyObject(collision.gameObject);
            DestroyObject(this.gameObject);
            GameObject effect = Instantiate(enemyDieEffect, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "projectile")
        {
            Arrow arrow = other.GetComponent<Arrow>();
            if (arrow != null)
            {
                hp -= arrow.damege;
            }
            DestroyObject(other.gameObject);
        }
        if (hp <= 0)
        {
            DestroyObject(this.gameObject);
            GameObject effect = Instantiate(enemyDieEffect, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }
}
