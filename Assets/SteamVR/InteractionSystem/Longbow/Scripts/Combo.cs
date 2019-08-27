using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    [SerializeField]
    private GameObject specialSkill1 = null;
    private bool used1 = false;
    [SerializeField]
    private GameObject specialSkill2 = null;
    private bool used2 = false;
    [SerializeField]
    private GameObject specialSkill3 = null;
    private int comboCount = 0;
    private int canUseSpecialNum = 40;
    // Start is called before the first frame update
    void Start()
    {
        comboCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ArrowHit()
    {
        comboCount++;
    }

    public int GetCombo()
    {
        return comboCount;
    }

    public float GetComboBonus()
    {
        float comboBonus;

        comboBonus = comboCount / 10;

        if (comboBonus > 2.0)
        {
            comboBonus = 2.0f;
        }
        return comboBonus;
    }

    public void ResetComboCount()
    {
        comboCount = 0;
        used1 = false;
        used2 = false;
        canUseSpecialNum = 40;
    }

    public GameObject GetSpecialSkill()
    {
        if (comboCount >= 10)
        {
            if (!used1)
            {
                used1 = true;
                return specialSkill1;
            }
        }
        if (comboCount >= 25)
        {
            if(!used2)
            {
                used2 = true;
                return specialSkill2;
            }
        }
        if (comboCount >= canUseSpecialNum)
        {
            canUseSpecialNum += 10;
            return specialSkill3;
        }

        return null;
    }

}
