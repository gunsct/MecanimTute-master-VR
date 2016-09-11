using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
public class PlayerCtr : MonoBehaviour {
		private Animator anim;
		private AnimatorStateInfo currentBaseState;

		private float plus = 1.0f;//가속값
		private float speed = 0.0f;
		private float turn = 0.0f;

		public bool useCurves;
		private CapsuleCollider col;
	// Use this for initialization
	void Start () {
				anim = GetComponent<Animator> ();
				col = GetComponent<CapsuleCollider>();
				col.height = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
				float v = Input.GetAxis ("Vertical");
				float t = Input.GetAxis ("Horizontal");

				if (Input.GetKey (KeyCode.LeftShift)) {//run
						if (plus < 2.0f)
								plus += 0.02f;
				} else {//not run
						if (plus > 1.0f)
								plus -= 0.02f;
				}

				speed = v * plus;
				turn = t * plus;

				anim.SetFloat ("speed", speed);
				anim.SetFloat ("turn", turn);

				if (Input.GetKeyDown (KeyCode.Space)) 
						anim.SetBool ("jump", true);
				else anim.SetBool ("jump", false);
				col.height = anim.GetFloat ("ColliderHeight");
				col.center = new Vector3 (0.0f, (2 / col.height), 0.0f);

				/*if (currentBaseState.nameHash == Animator.StringToHash ("Base Layer.Jump")) {
						
								if(useCurves)
										// ..set the collider height to a float curve in the clip called ColliderHeight
								col.height = anim.GetFloat("ColliderHeight");

								// reset the Jump bool so we can jump again, and so that the state does not loop 
								anim.SetBool("Jump", false);

				}*/

		}
}
