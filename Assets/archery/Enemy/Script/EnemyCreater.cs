using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    [SerializeField]
    private GameObject CreateGameObject = null;
    [SerializeField]
    private float RespawnTime = 0.0f;
    [SerializeField]
    private float RespawnTimeRange = 1.0f;
    private float RespawnTimeAddNum;
    float countTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        RespawnTimeAddNum = Random.Range(-RespawnTimeRange, RespawnTimeRange);
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if (countTime > RespawnTime + RespawnTimeAddNum)
        {
            float x = Random.Range(-2.0f, 2.0f);
            float y = Random.Range(   0  , 2.0f);
            float z = Random.Range(-2.0f, 2.0f);
            GameObject cloneObj = Instantiate(CreateGameObject);
            cloneObj.transform.position = this.gameObject.transform.position + new Vector3(x, y, z);
            cloneObj.name = CreateGameObject.name;
            countTime = 0;
            RespawnTimeAddNum = Random.Range(-RespawnTimeRange, RespawnTimeRange);
        }
    }
}
