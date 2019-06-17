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
        Debug.Log("Hit");
    }

    public int GetCombo()
    {
        return comboCount;
    }

    public float GetComboBonus()
    {
        int comboBonus = (comboCount / 10);
        if(comboBonus > 5)
        {
            comboBonus = 5;
        }
        float bonus = 1.0f + (comboBonus / 10);
        return bonus;
    }

    public void ResetComboCount()
    {
        comboCount = 0;
        Debug.Log("Reset");
    }

}
