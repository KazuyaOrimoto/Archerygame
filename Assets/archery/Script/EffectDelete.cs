using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//パーティクルシステムコンポーネントがない場合は自動追加
[RequireComponent(typeof(ParticleSystem))]

public class EffectDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem partcleSystem = GetComponent<ParticleSystem>();
        //Delete object after duration.
        Destroy(gameObject, (float)partcleSystem.main.duration);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
