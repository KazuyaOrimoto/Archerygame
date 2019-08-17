using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer.ToString() == "Enemy")
        {
            Debug.Log("Hit Enemy!!!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.ToString() == "Enemy")
        {
            Debug.Log("Hit Enemy!!!");
        }
    }
}
