using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class Charge : MonoBehaviour
    {
        int bonusArrowNum = 0;
        private float countTime;
        private bool counting;
        [SerializeField]
        private GameObject chargeEffect = null;
        [SerializeField]
        private GameObject shotEffect = null;
        private GameObject chargeObject;
        private GameObject shotObject;
        private Combo comboChecker = null;
        private const float chargeTime = 1.1f;
        private float chargeTimeBonus = 0.0f;
        // Start is called before the first frame update
        void Start()
        {
            //chargeObject = Instantiate(chargeEffect, this.gameObject.transform.GetChild(0).GetChild(0));

            //shotObject = Instantiate(shotEffect, this.gameObject.transform);
            //shotObject.GetComponent<ParticleSystem>().Stop();

            counting = false;

            comboChecker = GameObject.Find("ComboCheck").GetComponent<Combo>();
        }

        // Update is called once per frame
        void Update()
        {
            if (counting)
            {
                
            }
        }

        public void StartCount()
        {
            if (!counting)
            {
                counting = true;
                countTime = 0;
            }
        }

        public void EndCount()
        {
            counting = false;
            //childSystem1.Clear();
            //childSystem2.Clear();
        }

        public int GetArrowNum()
        {
            int combo = comboChecker.GetCombo();
            if(combo <= 10)
            {
                bonusArrowNum = 2;
            }
            else if(combo <= 30)
            {
                bonusArrowNum = 1;
            }
            else
            {
                bonusArrowNum = 0;
            }
            //childSystem1.Clear();
            //childSystem2.Clear();
            //shotObject.GetComponent<ParticleSystem>().Play();

            return bonusArrowNum;
        }
    }


}

