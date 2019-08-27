using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private TargetObj targetFintObj;
    private GameObject targetObj;
    private GameObject goalObject;
    private Barrier barrier;
    private Animator anim;
    [SerializeField]
    private float moveSpeed = 0.0f;

    public int target { get; set; }

    private bool moveStop;

    private int targetNum = 1;

    // Start is called before the first frame update

    private float x;
    private float y;
    private float z;


    void Start()
    {
        if(targetFintObj == null)
        {
            string targetName = this.tag + "Target";
            targetFintObj = GameObject.Find(targetName).GetComponent<TargetObj>();
        }
        target = 0;
        if (targetObj == null)
        {
            targetObj = targetFintObj.GetTargetObject(targetNum, this);
            this.transform.LookAt(targetObj.transform);
            transform.Rotate(new Vector3(0, 1, 0), 180);
        }

        moveStop = false;
        x = Random.Range(-2.0f, 2.0f);
        if(tag == "Frog" || tag == "Frog2")
        {
            y = 0.0f;
        }
        else
        {
            y = Random.Range(0, 2.0f);
        }
        z = Random.Range(-2.0f, 2.0f);

        goalObject = GameObject.Find("EnemyGoal");
        barrier = GameObject.Find("Barrier").GetComponent<Barrier>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tag == "Frog" || tag == "Frog2")
        {
            y = 0.0f;
            transform.position = new Vector3(transform.position.x,0.65f,transform.position.z);
        }
        if(moveStop)
        {
            return;
        }
        if(this.gameObject.transform.position != targetObj.transform.position)
        {
            Vector3 movePos = (targetObj.transform.position + new Vector3(x,y,z)) - this.gameObject.transform.position;
            //移動する距離が移動スピードより短ければ
            if(movePos.magnitude < moveSpeed)
            {
                if(goalObject == targetObj)
                {
                    BarrierAttack();
                }
                else
                {
                    targetNum++;
                    targetObj = targetFintObj.GetTargetObject(targetNum, this);
                    if(goalObject == targetObj)
                    {
                        x = Random.Range(-1.5f, 1.5f);
                        if (tag == "Frog" || tag == "Frog2")
                        {
                            y = 0.0f;
                        }
                        else
                        {
                             y = Random.Range(-0.0f, 2.5f);
                        }
                        z = 0.0f;
                    }
                    else
                    {
                        x = Random.Range(-1.5f, 1.5f);
                        if (tag == "Frog" || tag == "Frog2")
                        {
                            y = 0.0f;
                        }
                        else
                        {
                            y = Random.Range(0, 1.5f);
                        }
                        z = Random.Range(-1.5f, 1.5f);
                    }
                    this.transform.LookAt(targetObj.transform);
                    transform.Rotate(new Vector3(0, 1, 0), 180);
                }
            }
            else
            {
                this.gameObject.transform.position += movePos.normalized * moveSpeed * Time.deltaTime;
            }

        }
    }

    public void BarrierAttackAnim()
    {
        barrier.AttackedEnemy();
    }

    private void BarrierAttack()
    {
        if(anim == null)
        {
            anim = transform.GetChild(0).GetComponent<Animator>();
        }
        anim.SetTrigger("BarrierAttack");
        transform.forward =new Vector3(0.0f, 0.0f, 1.0f).normalized;
    }

    public void MoveStop()
    {
        moveStop = true;
    }

    public void MoveRestart()
    {
        moveStop = false;
    }

    public void SetTarget(GameObject game)
    {
        targetObj = game;
        this.transform.LookAt(targetObj.transform);
        transform.Rotate(new Vector3(0, 1, 0), 180);
    }
}
