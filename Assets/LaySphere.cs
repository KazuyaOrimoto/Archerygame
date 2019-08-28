using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaySphere : MonoBehaviour
{
    GameObject target = null;
    [SerializeField]
    private float moveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        target = this.transform.parent.GetComponent<LayScript>().GetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = target.transform.position - transform.position;
        if ((moveVector).magnitude < 1.0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.transform.position += moveVector * Time.deltaTime * moveSpeed;
        }
    }
}
