using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObj : MonoBehaviour
{
    [SerializeField]
    private GameObject[] target1;
    [SerializeField]
    private GameObject[] target2;
    [SerializeField]
    private GameObject[] target3;
    [SerializeField]
    private GameObject[] target4;

    private GameObject targetGoal;

    private int targetNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        targetGoal = GameObject.Find("EnemyGoal");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public GameObject GetTargetObject(int targetNumber,MoveEnemy moveEnemy)
    {
        targetNum = moveEnemy.target;
        GameObject returnObj = null;
        switch (targetNumber)
        {
            case 1: returnObj =  TargetObject1(moveEnemy);break;
            case 2: returnObj =  TargetObject2(moveEnemy);break;
            case 3: returnObj =  TargetObject3(moveEnemy);break;
            case 4: returnObj =  TargetObject4(moveEnemy);break;
        }
        if(returnObj == null)
        {
            return targetGoal;
        }
        else
        {
            return returnObj;
        }
    }

    private GameObject TargetObject1(MoveEnemy moveEnemy)
    {
        //ターゲットがない時
        if(target1.Length == 0)
        {
            return null;
        }
        //ターゲットが一つに絞られていたらそれを返す
        if(target1.Length == 1)
        {
            return target1[0];
        }
        //ターゲットが複数個あるとき
        else
        {
            //ターゲットの番号が決められていないとき
            if(targetNum == 0)
            {
                targetNum = Random.Range(1, target1.Length+1);
                moveEnemy.target = targetNum;
                return target1[targetNum-1];
            }
            //ターゲットの番号が決められているとき
            else
            {
                //ターゲットの番号が決められていて、ちゃんと設定されていれば
                if(target1[targetNum-1] != null)
                {
                    return target1[targetNum-1];
                }
                //ターゲットの番号が決められている、その番号の中身がなかった時
                else
                {
                    return null;
                }
            }
        }
    }

    private GameObject TargetObject2(MoveEnemy moveEnemy)
    {
        //ターゲットがない時
        if (target2.Length == 0)
        {
            return null;
        }
        //ターゲットが一つに絞られていたらそれを返す
        if (target2.Length == 1)
        {
            return target2[0];
        }
        //ターゲットが複数個あるとき
        else
        {
            //ターゲットの番号が決められていないとき
            if (targetNum == 0)
            {
                targetNum = Random.Range(1, target2.Length+1);
                moveEnemy.target = targetNum;
                return target2[targetNum - 1];
            }
            //ターゲットの番号が決められているとき
            else
            {
                //ターゲットの番号が決められていて、ちゃんと設定されていれば
                if (target2[targetNum - 1] != null)
                {
                    return target2[targetNum - 1];
                }
                //ターゲットの番号が決められている、その番号の中身がなかった時
                else
                {
                    return null;
                }
            }
        }
    }

    private GameObject TargetObject3(MoveEnemy moveEnemy)
    {
        //ターゲットがない時
        if (target3.Length == 0)
        {
            return null;
        }
        //ターゲットが一つに絞られていたらそれを返す
        if (target3.Length == 1)
        {
            return target3[0];
        }
        //ターゲットが複数個あるとき
        else
        {
            //ターゲットの番号が決められていないとき
            if (targetNum == 0)
            {
                targetNum = Random.Range(1, target3.Length+1);
                moveEnemy.target = targetNum;
                return target3[targetNum - 1];
            }
            //ターゲットの番号が決められているとき
            else
            {
                //ターゲットの番号が決められていて、ちゃんと設定されていれば
                if (target3[targetNum - 1] != null)
                {
                    return target3[targetNum - 1];
                }
                //ターゲットの番号が決められている、その番号の中身がなかった時
                else
                {
                    return null;
                }
            }
        }
    }

    private GameObject TargetObject4(MoveEnemy moveEnemy)
    {
        //ターゲットがない時
        if (target4.Length == 0)
        {
            return null;
        }
        //ターゲットが一つに絞られていたらそれを返す
        if (target4.Length == 1)
        {
            return target4[0];
        }
        //ターゲットが複数個あるとき
        else
        {
            //ターゲットの番号が決められていないとき
            if (targetNum == 0)
            {
                targetNum = Random.Range(1, target4.Length+1);
                moveEnemy.target = targetNum;
                return target4[targetNum - 1];
            }
            //ターゲットの番号が決められているとき
            else
            {
                //ターゲットの番号が決められていて、ちゃんと設定されていれば
                if (target4[targetNum - 1] != null)
                {
                    return target4[targetNum - 1];
                }
                //ターゲットの番号が決められている、その番号の中身がなかった時
                else
                {
                    return null;
                }
            }
        }
    }

}
