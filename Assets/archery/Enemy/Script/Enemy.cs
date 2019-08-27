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
    [SerializeField]
    private GameObject ChaegeEffect = null;
    [SerializeField]
    private GameObject AttackEffect = null;
    private MoveEnemy move;

    GameObject effect;

    bool attack = false;
    bool attacked = false;
    bool charged = false;
    bool charge = false;
    // Start is called before the first frame update
    void Start()
    {
        ComboCountObject = GameObject.Find("ComboCheck").GetComponent<Combo>();
        UiObject = GameObject.Find("UIObject").GetComponent<UI>();
        attack = false;
        player = GameObject.FindGameObjectWithTag("Player");
        move = transform.parent.GetComponent<MoveEnemy>();
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
        if (attack)
        {
            Attack();
        }

    }

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            DestroyObject(collision.gameObject);
            DestroyObject(this.transform.parent.gameObject);
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
                DestroyObject(other.gameObject);
            }
            else
            {
                SpecialSkill specialSkill = other.GetComponent<SpecialSkill>();
                if (specialSkill != null)
                {
                    ComboCountObject.ArrowHit();
                    hp = 0;
                }
            }
            int comboNum = ComboCountObject.GetCombo();
            GameObject ui = UiObject.GetNumber(comboNum);
            ui.transform.position = this.transform.position;
            if (hp <= 0)
            {
                DestroyObject(this.transform.parent.gameObject);
                GameObject effect = Instantiate(enemyDieEffect, this.gameObject.transform.position, this.gameObject.transform.rotation);
            }
            else
            {
                GameObject effect = Instantiate(enemyHitEffect, this.gameObject.transform.position, this.gameObject.transform.rotation);
            }
        }

        if (other.gameObject.tag == "PlayerArea")
        {
            attack = true;
            MoveStop();
            this.transform.parent.LookAt(player.transform);
            transform.parent.Rotate(new Vector3(0, 1, 0), 180);
        }
    }

    public void BarrierAttackAnim()
    {
        move.BarrierAttackAnim();
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
        //チャージした後だったら
        if (charged)
        {
            //攻撃した後だったら
            if (attacked)
            {
                effect = null;
                charge = false;
                charged = false;
                attacked = false;
            }
            //攻撃してたら
            else
            {
                if (effect == null)
                {
                    attacked = true;
                }
            }
        }
        //チャージしてなかったら
        else
        {
            //何もエフェクトを使ってなかったら
            if (!charge)
            {
                effect = Instantiate(ChaegeEffect, transform.parent);
                charge = true;
            }
            else
            {
                if (charge)
                {
                    if (effect == null)
                    {
                        effect = Instantiate(AttackEffect, transform.parent);
                        effect.transform.LookAt(player.transform);
                        charged = true;
                    }
                }
            }
        }
    }
}
