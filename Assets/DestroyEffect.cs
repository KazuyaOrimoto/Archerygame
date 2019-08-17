using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(ParticleWorking());
    }

    IEnumerator ParticleWorking()
    {
        var particle = GetComponent<ParticleSystem>();

        yield return new WaitWhile(() => particle.IsAlive(true));

        Destroy(this.gameObject);
    }
}
