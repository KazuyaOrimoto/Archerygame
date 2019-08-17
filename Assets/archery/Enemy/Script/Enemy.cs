using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyDieEffect = null;
    [SerializeField]
    private GameObject enemyHitEffect = null;
    [SerializeField]
    private Combo ComboCountObject;
    private UI UiObject;
    private int hp = 3;
    private GameObject player;

    bool attack;
    // Start is called before the first frame update
    void Start()
    {
        ComboCountObject = GameObject.Find("ComboCheck").GetComponent<Combo>();
        UiObject = GameObject.Find("UIObject").GetComponent<UI>();
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.E))
        //{
        //    GameObject effect = Instantiate(enemyDieEffect,this.gameObject.transform.position,this.gameObject.transform.rotation);
        //}
        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    Animator animator = GetComponent<Animator>();
        //    animator.SetTrigger("Damaged");
        //}
        if(attack)
        {
            Debug.Log("Attack!!");
            Attack();
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
                hp -= arrow.damage;
                Animator animator = GetComponent<Animator>();
                animator.SetTrigger("Damaged");
                ComboCountObject.ArrowHit();
                ArrowDeleteCount arrowDeleteCount = arrow.DeleteAreaObject.GetComponent<ArrowDeleteCount>();
                arrowDeleteCount.HitArrow();
            }
            int comboNum = ComboCountObject.GetCombo();
            GameObject ui = UiObject.GetNumber(comboNum);
            ui.transform.position = this.transform.position;
            DestroyObject(other.gameObject);
            if (hp <= 0)
            {
                DestroyObject(this.gameObject);
                GameObject effect = Instantiate(enemyDieEffect, this.gameObject.transform.position, this.gameObject.transform.rotation);
            }
            else
            {
                GameObject effect = Instantiate(enemyHitEffect, this.gameObject.transform.position, this.gameObject.transform.rotation);
            }
        }

        if(other.gameObject.tag == "PlayerArea")
        {
            attack = true;
            MoveStop();
            player = GameObject.FindGameObjectWithTag("Player");
            this.transform.parent.LookAt(player.transform);
            transform.parent.Rotate(new Vector3(0, 1, 0), 180);
        }
    }

    public void MoveStop()
    {
        transform.parent.gameObject.GetComponent<MoveEnemy>().MoveStop();
    }

    public void MoveRestart()
    {
        transform.parent.gameObject.GetComponent<MoveEnemy>().MoveRestart();
    }

    private void Attack()
    {

    }
}
