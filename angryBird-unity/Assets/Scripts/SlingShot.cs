using UnityEngine;
using System.Collections;

namespace AngryBird{

public class SlingShot : MonoBehaviour {
		[SerializeField] LineRenderer leftRender,rightRender;
		[SerializeField]Rigidbody bird;

		private Vector3 MousePos;
		private const float DeltaX =1f;
		private const float DeltaY =1f;

		// Use this for initialization
		void Start () {
				//leftRender.SetPosition (0,new Vector3(0,1.8));
		}
		
		// Update is called once per frame
		void Update () {
			
			if(Input.GetMouseButton(0)){

				// get mouse postion;
				//MousePos = Camera.main.ScreenToViewportPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,-2f));
				MousePos = Camera.main.ScreenToViewportPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,-2f));

				// set ball position;
				bird.transform.position = MousePos;

				// set line position;
				leftRender.SetPosition(0,new Vector3(MousePos.x*DeltaX,MousePos.y*DeltaY,MousePos.z-0.5f));
				rightRender.SetPosition(0,new Vector3(MousePos.x*DeltaX,MousePos.y*DeltaY,MousePos.z-0.5f));

				Debug.Log ("mouse possition: "+MousePos.x+" ,"+MousePos.y+" ,"+MousePos.z);
			}

			if(Input.GetMouseButtonUp(0)){

				// get mouse postion;
				MousePos = Camera.main.ScreenToViewportPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,-2f));

				// set ball position;
				bird.transform.position = MousePos;

				Vector3 vecL = new Vector3(-2f-MousePos.x,1.8f-MousePos.y,0f-MousePos.z);
				Vector3 vecR = new Vector3(2f-MousePos.x,1.8f-MousePos.y,0f-MousePos.z);
				Vector3 dir = (vecL + vecR).normalized;
				bird.AddForce (dir*10f,ForceMode.Impulse);
				// set line position;
				leftRender.SetPosition(0,new Vector3(0f,1.8f,0f));
				rightRender.SetPosition(0,new Vector3(0f,1.8f,0f));

 			}
		}
}

}