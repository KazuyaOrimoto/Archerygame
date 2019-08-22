using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    [SerializeField]
    private GameObject specialSkill1;
    [SerializeField]
    private GameObject specialSkill2;
    [SerializeField]
    private GameObject specialSkill3;
    private int comboCount = 0;
    private int canUseSpecialNum = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ArrowHit()
    {
        comboCount++;
        Debug.Log(comboCount);
    }

    public int GetCombo()
    {
        return comboCount;
    }

    public float GetComboBonus()
    {
        float comboBonus;

        comboBonus = comboCount / 10;

        if(comboBonus > 2.0)
        {
            comboBonus = 2.0f;
        }
        return comboBonus;
    }

    public void ResetComboCount()
    {
        comboCount = 0;
    }

    public GameObject GetSpecialSkill()
    {
        if(comboCount >= 15)
        {
            return specialSkill1;
        }
        else if(comboCount >= 30)
        {
            return specialSkill2;
        }
        else if(comboCount >= canUseSpecialNum)
        {
            canUseSpecialNum += 10;
            return specialSkill3;
        }

        return null;
    }

}
