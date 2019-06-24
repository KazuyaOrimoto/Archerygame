using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Sprite[] number;
    [SerializeField]
    private GameObject comboUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetNumber(int drawNum)
    {
        GameObject NumObj = Instantiate(comboUI);
        int digitNum = 0;
        int tmp = drawNum;
        while (tmp != 0)
        {
            tmp /= 10;
            digitNum++;
        }

        for (int i = digitNum; i > 0; i--)
        {
            GameObject sprite = CreateSprite(i,drawNum);
            sprite.transform.parent = NumObj.transform;
            sprite.transform.position = new Vector3((digitNum - i) * 5.0f,0.0f,0.0f);
        }
        NumObj.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
        return NumObj;
    }

    private GameObject CreateSprite(int digitNum ,int num)
    {
        GameObject sprite = new GameObject("sprite");
        SpriteRenderer spriteRenderer = sprite.AddComponent<SpriteRenderer>() as SpriteRenderer;
        int temp = (int)Mathf.Pow(10, digitNum-1);
        int drawNum =  (int)(num / temp) % 10;
        spriteRenderer.sprite = number[drawNum];
        return sprite;
    }
}
