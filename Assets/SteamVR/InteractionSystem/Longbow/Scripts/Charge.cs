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
        private ParticleSystem system;
        private ParticleSystem childSystem1;
        private ParticleSystem childSystem2;
        private GameObject chargeObject;
        private GameObject shotObject;
        private Combo comboChecker = null;
        private const float chargeTime = 1.1f;
        private float chargeTimeBonus = 0.0f;
        // Start is called before the first frame update
        void Start()
        {
            chargeObject = Instantiate(chargeEffect, this.gameObject.transform);
            system = chargeObject.GetComponent<ParticleSystem>();
            //childSystem1 = chargeObject.transform.GetChild(1).GetComponent<ParticleSystem>();
            //childSystem2 = chargeObject.transform.GetChild(2).GetComponent<ParticleSystem>();
            system.Stop();


            shotObject = Instantiate(shotEffect, this.gameObject.transform);
            shotObject.GetComponent<ParticleSystem>().Stop();

            counting = false;
            bonusArrowNum = 0;

            comboChecker = GameObject.Find("ComboCheck").GetComponent<Combo>();
        }

        // Update is called once per frame
        void Update()
        {
            if (counting)
            {
                countTime += Time.deltaTime;
                if(countTime >= chargeTime)
                {
                    bonusArrowNum++;
                    //childSystem2.Clear();
                    //childSystem2.Play();
                    countTime = 0;
                    if (bonusArrowNum > 2)
                    {
                        bonusArrowNum = 2;
                    }
                    else
                    {
                        //system.Clear();
                        //system.Play();
                    }
                }
            }
        }

        public void StartCount()
        {
            if (!counting)
            {
                counting = true;
                countTime = 0;
                system.Play();
                //chargeTimeBonus = comboChecker.GetComboBonus();
            }
        }

        public void EndCount()
        {
            counting = false;
            //childSystem1.Clear();
            //childSystem2.Clear();
            system.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            bonusArrowNum = 0;
        }

        public int GetArrowNum()
        {
            //childSystem1.Clear();
            //childSystem2.Clear();
            system.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            shotObject.GetComponent<ParticleSystem>().Play();

            return bonusArrowNum;
        }
    }


}

