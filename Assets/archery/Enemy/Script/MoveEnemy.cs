using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private TargetObj targetFintObj;
    private GameObject targetObj;
    private GameObject goalObject;
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
        y = Random.Range(0, 2.0f);
        z = Random.Range(-2.0f, 2.0f);

        goalObject = GameObject.Find("EnemyGoal");
    }

    // Update is called once per frame
    void Update()
    {
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
                    Destroy(gameObject);
                }
                targetNum++;
                targetObj = targetFintObj.GetTargetObject(targetNum, this);
                x = Random.Range(-2.0f, 2.0f);
                y = Random.Range(0, 2.0f);
                z = Random.Range(-2.0f, 2.0f);
                this.transform.LookAt(targetObj.transform);
                transform.Rotate(new Vector3(0, 1, 0), 180);
               
            }
            else
            {
                this.gameObject.transform.position += movePos.normalized * moveSpeed * Time.deltaTime;
            }

        }
    }

    public void MoveStop()
    {
        moveStop = true;
    }

    public void MoveRestart()
    {
        moveStop = false;
    }
}
