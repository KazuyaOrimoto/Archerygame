using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField]
    private int BarrierHP = 5;

    [SerializeField]
    private GameObject GameEndUI = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BarrierHP <= 0)
        {
            Instantiate(GameEndUI,this.transform);
        }
    }

    public void AttackedEnemy()
    {
        BarrierHP--;
    }
}
