using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayScript : MonoBehaviour
{
    GameObject longbow = null;
    GameObject enemyObject = null;
    [SerializeField]
    GameObject CreateObject = null;
    [SerializeField]
    float CreateTime = 0.1f;
    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        longbow = GameObject.FindGameObjectWithTag("LongBow");
        enemyObject = this.transform.parent.gameObject;
        if (longbow != null)
        {
            transform.position = longbow.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(longbow != null)
        {
            transform.position = longbow.transform.position;
            time += Time.deltaTime;
            if (time > CreateTime)
            {
                time = 0;
                GameObject gameObject = Instantiate(CreateObject, this.transform);
                gameObject.transform.position = this.transform.position;
            }
        }
    }

    public GameObject GetTarget()
    {
        return enemyObject;
    }
}
