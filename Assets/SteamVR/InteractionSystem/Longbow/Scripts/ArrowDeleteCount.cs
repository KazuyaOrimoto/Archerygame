using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class ArrowDeleteCount : MonoBehaviour
    {
        [SerializeField]
        private GameObject arrowPrefab;

        public GameObject[] arrow;

        private int arrowNum = 0;
        private int deleteArrowNum = 0;
        private int HitArrawNum = 0;
        // Start is called before the first frame update
        void Start()
        {

        }

        [System.Obsolete]
        void Update()
        {
            if (arrowNum == (HitArrawNum + deleteArrowNum))
            {
                if (arrowNum == deleteArrowNum)
                {
                    GameObject.Find("ComboCheck").GetComponent<Combo>().ResetComboCount();
                }
                DestroyObject(gameObject);
            }
        }

        public void SetArrowNum(int argArrowNum)
        {
            arrowNum = argArrowNum;
        }

        public void HitArrow()
        {
            HitArrawNum++;
        }

        [System.Obsolete]
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == arrowPrefab.tag)
            {
                Arrow arrow = other.GetComponent<Arrow>();
                if (arrow != null)
                {
                    if (arrow.DeleteAreaObject == this.gameObject)
                    {
                        DestroyObject(other.gameObject);
                        deleteArrowNum++;
                    }
                }
            }
        }
    }
}


