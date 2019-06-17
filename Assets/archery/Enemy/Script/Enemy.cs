using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyDieEffect;
    [SerializeField]
    private int hp = 450;
    [SerializeField]
    private Combo ComboCountObject;
    // Start is called before the first frame update
    void Start()
    {
        ComboCountObject = GameObject.Find("ComboCheck").GetComponent<Combo>();
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
                int damege = (int)(arrow.damege * ComboCountObject.GetComboBonus());
                Debug.Log(damege);
                hp -= damege;
                Combo comboCheckScript = GameObject.Find("ComboCheck").GetComponent<Combo>();
                comboCheckScript.ArrowHit();
                int combo = comboCheckScript.GetCombo();

                ArrowDeleteCount arrowDeleteCount = arrow.DeleteAreaObject.GetComponent<ArrowDeleteCount>();
                arrowDeleteCount.HitArrow();
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
