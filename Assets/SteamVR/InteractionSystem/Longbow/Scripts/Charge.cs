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
        private GameObject chargeEffect;
        [SerializeField]
        private GameObject shotEffect;
        private ParticleSystem system;
        private ParticleSystem childSystem1;
        private ParticleSystem childSystem2;
        private GameObject chargeObject;
        private GameObject shotObject;
        // Start is called before the first frame update
        void Start()
        {
            chargeObject = Instantiate(chargeEffect, this.gameObject.transform);
            system = chargeObject.GetComponent<ParticleSystem>();
            childSystem1 = chargeObject.transform.GetChild(1).GetComponent<ParticleSystem>();
            childSystem2 = chargeObject.transform.GetChild(2).GetComponent<ParticleSystem>();
            system.Stop();


            shotObject = Instantiate(shotEffect, this.gameObject.transform);
            shotObject.GetComponent<ParticleSystem>().Stop();

            counting = false;
            bonusArrowNum = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (counting)
            {
                countTime += Time.deltaTime;
                if(countTime >= 3.0)
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
                        system.Clear();
                        system.Play();
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
            }
        }

        public void EndCount()
        {
            counting = false;
            childSystem1.Clear();
            childSystem2.Clear();
            system.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            bonusArrowNum = 0;
        }

        public int GetArrowNum()
        {
            childSystem1.Clear();
            childSystem2.Clear();
            system.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            shotObject.GetComponent<ParticleSystem>().Play();

            return bonusArrowNum;
        }
    }


}

