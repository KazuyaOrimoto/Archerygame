using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    private void Start()
    {
        ParticleSystem partcleSystem = GetComponent<ParticleSystem>();
        //Delete object after duration.
        Destroy(this.gameObject, (float)partcleSystem.main.duration);
    }
}
