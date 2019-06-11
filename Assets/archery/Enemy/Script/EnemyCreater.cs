using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    [SerializeField]
    private GameObject CreateGameObject;
    [SerializeField]
    private float RespawnTime;
    float countTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if(countTime > RespawnTime)
        {
            GameObject cloneObj = Instantiate(CreateGameObject);
            cloneObj.transform.position = this.gameObject.transform.position;
            countTime = 0;
        }
    }
}
