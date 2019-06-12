﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObj;
    [SerializeField]
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if(targetObj == null)
        {
            targetObj = GameObject.Find("EnemyTarget");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position != targetObj.transform.position)
        {
            Vector3 movePos = targetObj.transform.position - this.gameObject.transform.position;
            //移動する距離が移動スピードより短ければ
            if(movePos.magnitude < moveSpeed)
            {
                Destroy(this.gameObject);

            }
            else
            {
                this.gameObject.transform.position += movePos.normalized * moveSpeed * Time.deltaTime;
            }

        }
    }
}