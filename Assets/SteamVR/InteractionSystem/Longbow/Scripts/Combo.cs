using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    private int comboCount = 0;
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
        comboCount++;
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

}
