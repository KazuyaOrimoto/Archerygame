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
    [SerializeField]
    private GameObject chargeEffect = null;

    private GameObject charge = null;

    private bool create1 = false;
    private bool create2 = false;
    private bool create3 = false;

    // Start is called before the first frame update
    void Start()
    {
        comboCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (comboCount >= 10)
        {
            if (!create1)
            {
                create1 = true;
                CreateChargeEffect();
            }
        }
        if (comboCount >= 25)
        {
            if (!create2)
            {
                create2 = true;
                CreateChargeEffect();
            }
        }
        if (!create3 && comboCount >= canUseSpecialNum)
        {
            create3 = true;
            CreateChargeEffect();
        }
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
        create1 = false;
        create2 = false;
        create3 = false;
        canUseSpecialNum = 40;
    }

    public GameObject GetSpecialSkill()
    {
        if (comboCount >= 10)
        {
            if (!used1)
            {
                used1 = true;
                if(charge != null)
                {
                    Destroy(charge);
                }
                return specialSkill1;
            }
        }
        if (comboCount >= 25)
        {
            if(!used2)
            {
                used2 = true;
                if (charge != null)
                {
                    Destroy(charge);
                }
                return specialSkill2;
            }
        }
        if (comboCount >= canUseSpecialNum)
        {
            if (charge != null)
            {
                Destroy(charge);
            }
            canUseSpecialNum += 10;
            create3 = false;
            return specialSkill3;
        }

        return null;
    }

    private void CreateChargeEffect()
    {
        GameObject longbow = GameObject.FindGameObjectWithTag("LongBow");
        if(longbow != null)
        {
            charge = Instantiate(chargeEffect, longbow.transform);
        }
    }

}
