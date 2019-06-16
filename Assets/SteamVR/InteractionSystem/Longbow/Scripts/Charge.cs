using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Valve.VR.InteractionSystem
{
    public class Charge : MonoBehaviour
    {
        private float countTime;
        private bool counting;
        private bool upCount;
        [SerializeField]
        private GameObject chargeEffect;
        [SerializeField]
        private GameObject shotEffect;
        private ParticleSystem system;
        private ParticleSystem childSystem;
        private GameObject chargeObject;
        private GameObject shotObject;
        // Start is called before the first frame update
        void Start()
        {
            chargeObject = Instantiate(chargeEffect, this.gameObject.transform);
            system = chargeObject.GetComponent<ParticleSystem>();
            childSystem = chargeObject.transform.GetChild(1).GetComponent<ParticleSystem>();
            system.Stop();

            shotObject = Instantiate(shotEffect, this.gameObject.transform);
            shotObject.GetComponent<ParticleSystem>().Stop();

            counting = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (counting)
            {
                if(upCount)
                {
                    countTime += Time.deltaTime;
                    if (countTime >= 3.0)
                    {
                        upCount = !upCount;
                    }
                }
                else
                {
                    countTime -= Time.deltaTime * 3;
                    if (countTime <= 0)
                    {
                        upCount = !upCount;
                    }
                }
                
               
            }
        }

        public void StartCount()
        {
            if (!counting)
            {
                counting = true;
                upCount = true;
                countTime = 0;

                system.Play();
            }
        }

        public void EndCount()
        {
            counting = false;
            childSystem.Clear();
            system.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        public int GetBowNum()
        {
            childSystem.Clear();
            system.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            shotObject.GetComponent<ParticleSystem>().Play();

            if (countTime > 2.0)
            {
                return 2;
            }
            else if (countTime > 1.0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }


}

