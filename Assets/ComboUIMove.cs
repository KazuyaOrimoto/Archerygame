﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboUIMove : MonoBehaviour
{
    private GameObject player;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);
        transform.Rotate(new Vector3(0, 1, 0), 180);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 1.0f)
        {
            Destroy(this.gameObject);
        }
    }
}