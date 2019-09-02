using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField]
    private int BarrierHP = 5;

    [SerializeField]
    private GameObject GameEndUI = null;

    [SerializeField]
    private GameObject effect = null;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        Instantiate(effect,this.transform);
        BarrierHP--;
        audioSource.Play();
    }
}
