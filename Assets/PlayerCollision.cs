using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
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
        if(other.transform.tag == "EnemyAttackEffect")
        {
            GameObject effect = null;
            WaterAttack water = other.gameObject.GetComponent<WaterAttack>();
            if(water != null)
            {
                effect = water.GetHitEffect();
            }
            if (effect == null)
            {
                effect = other.gameObject.GetComponent<FireAttack>().GetHitEffect();
            }
            Instantiate(effect,transform);
            Destroy(other.gameObject);
        }
    }
}
