using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObj;
    [SerializeField]
    private float moveSpeed = 0.0f;

    private bool moveStop;

    private int targetNum = 1;

    // Start is called before the first frame update

    private float x;
    private float y;
    private float z;


    void Start()
    {
        if(targetObj == null)
        {
            targetObj = GameObject.Find(this.gameObject.name + "EnemyTarget" + targetNum.ToString());
        }
        moveStop = false;
        x = Random.Range(-2.0f, 2.0f);
        y = Random.Range(0, 2.0f);
        z = Random.Range(-2.0f, 2.0f);
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
                targetNum++;
                targetObj = GameObject.Find(this.gameObject.name + "EnemyTarget" + targetNum.ToString());
                x = Random.Range(-2.0f, 2.0f);
                y = Random.Range(0, 2.0f);
                z = Random.Range(-2.0f, 2.0f);
                if (!targetObj)
                {
                    Destroy(gameObject);
                }
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
