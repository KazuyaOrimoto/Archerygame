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
        // Start is called before the first frame update
        void Start()
        {
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
                    countTime -= Time.deltaTime;
                    if (countTime <= 0)
                    {
                        upCount = !upCount;
                    }
                }
                
               
            }
            Debug.Log(countTime);
        }

        public void StartCount()
        {
            if (!counting)
            {
                counting = true;
                upCount = true;
                countTime = 0;
            }
        }

        public void EndCount()
        {
            counting = false;
        }

        public int GetBowNum()
        {
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

