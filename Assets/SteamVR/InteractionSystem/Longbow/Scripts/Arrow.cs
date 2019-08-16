//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: The arrow for the longbow
//
//=============================================================================

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class Arrow : MonoBehaviour
	{
		public ParticleSystem glintParticle;
		public Rigidbody arrowHeadRB;
		public Rigidbody shaftRB;

		public PhysicMaterial targetPhysMaterial;

		private Vector3 prevPosition;
		private Quaternion prevRotation;
		private Vector3 prevVelocity;
		private Vector3 prevHeadPosition;

		public SoundPlayOneshot fireReleaseSound;
		public SoundPlayOneshot airReleaseSound;
		public SoundPlayOneshot hitTargetSound;


		public PlaySound hitGroundSound;

		private bool inFlight;
		private bool released;
		private bool hasSpreadFire = false;

		private int travelledFrames = 0;

		private GameObject scaleParentObject = null;

        public GameObject DeleteAreaObject { get; set; }

        [SerializeField]
        private float speed = 10;

        [SerializeField]
        private GameObject ArrowFX;

        public int damage { get; set; } = 1;

        //-------------------------------------------------
        void Start()
		{
			Physics.IgnoreCollision( shaftRB.GetComponent<Collider>(), Player.instance.headCollider );
        }


		//-------------------------------------------------
		void FixedUpdate()
		{
			if ( released && inFlight )
			{
				prevPosition = transform.position;
				prevRotation = transform.rotation;
				//prevVelocity = GetComponent<Rigidbody>().velocity;
                prevHeadPosition = arrowHeadRB.transform.position;
				travelledFrames++;
                transform.position += transform.forward * speed * Time.deltaTime;
			}
		}


        //-------------------------------------------------
        public void ArrowReleased( float inputVelocity )
		{
            GameObject effect = Instantiate(ArrowFX,this.transform);

            inFlight = true;
			released = true;

            airReleaseSound.Play();


			if ( glintParticle != null )
			{
				//glintParticle.Play();
			}

			if ( gameObject.GetComponentInChildren<FireSource>().isBurning )
			{
				fireReleaseSound.Play();
			}

			// Check if arrow is shot inside or too close to an object
			RaycastHit[] hits = Physics.SphereCastAll( transform.position, 0.01f, transform.forward, 0.80f, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore );
			foreach ( RaycastHit hit in hits )
			{
				if ( hit.collider.gameObject != gameObject && hit.collider.gameObject != arrowHeadRB.gameObject && hit.collider != Player.instance.headCollider )
				{
					Destroy( gameObject );
					return;
				}
			}

			travelledFrames = 0;
			prevPosition = transform.position;
			prevRotation = transform.rotation;
			prevHeadPosition = arrowHeadRB.transform.position;
			//prevVelocity = GetComponent<Rigidbody>().velocity;

            SetCollisionMode(CollisionDetectionMode.ContinuousDynamic);

			Destroy( gameObject, 10 );

		}

        protected void SetCollisionMode(CollisionDetectionMode newMode, bool force = false)
        {
            Rigidbody[] rigidBodies = this.GetComponentsInChildren<Rigidbody>();
            for (int rigidBodyIndex = 0; rigidBodyIndex < rigidBodies.Length; rigidBodyIndex++)
            {
                if (rigidBodies[rigidBodyIndex].isKinematic == false || force)
                    rigidBodies[rigidBodyIndex].collisionDetectionMode = newMode;
            }
        }

        public void SetArrowDeleteArea(GameObject gameObject)
        {
            DeleteAreaObject = gameObject;
        }

        public int GetDamage()
        {
            return damage;
        }

		//-------------------------------------------------
		void OnDestroy()
		{
			if ( scaleParentObject != null )
			{
				Destroy( scaleParentObject );
			}
		}
	}
}
