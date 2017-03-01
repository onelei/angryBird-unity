using UnityEngine;
using System.Collections;

namespace AngryBird{

public class SlingShot : MonoBehaviour {
		[SerializeField] LineRenderer leftRender,rightRender;
		[SerializeField]Rigidbody bird;

		private Vector3 MousePos;
		private const float DeltaX =1f;
		private const float DeltaY =1f;

		// 绳子两端的固定点;
		private Vector3 ROPE_POS_L = new Vector3(-2f,1.8f,-10f);
		private Vector3 ROPE_POS_R = new Vector3(2f,1.8f,-10f);

		// 绳子两端活动的位置;
		private Vector3 ROPE_POS_L_Active = new Vector3(0f,1.8f,-10f);
		private Vector3 ROPE_POS_R_Active = new Vector3(0f,1.8f,-10f);

		// Use this for initialization
		void Start () {
			//设置颜色
			leftRender.SetColors(Color.red, Color.yellow);
			rightRender.SetColors(Color.red, Color.yellow);

			//设置宽度
			leftRender.SetWidth(0.02f, 0.02f);
			rightRender.SetWidth(0.02f, 0.02f);
		
			//设置材质
			leftRender.material = new Material(Shader.Find("Particles/Additive"));
			rightRender.material = new Material(Shader.Find("Particles/Additive"));
		}
		
		// Update is called once per frame
		void Update () {
			
			if(Input.GetMouseButton(0)){
				//将鼠标点击的屏幕坐标转换为世界坐标
				MousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,1.0f)); 
				// set line position;
				leftRender.SetPosition(0,MousePos);
				rightRender.SetPosition(0,MousePos);

				// set bird position;
				bird.transform.position = MousePos;

			}


			if(Input.GetMouseButtonUp(0)){
				
				//将鼠标点击的屏幕坐标转换为世界坐标
				MousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,1.0f)); 

				// set ball position;
				bird.transform.position = MousePos;

				Vector3 vecL = new Vector3(ROPE_POS_L.x-MousePos.x,ROPE_POS_L.y-MousePos.y,0-MousePos.z);
				Vector3 vecR = new Vector3(ROPE_POS_R.x-MousePos.x,ROPE_POS_R.y-MousePos.y,0-MousePos.z);
				Vector3 dir = (vecL + vecR).normalized;
				bird.AddForce (dir*105f,ForceMode.Impulse);

				// set line position;
				leftRender.SetPosition(0,ROPE_POS_L_Active);
				rightRender.SetPosition(0,ROPE_POS_R_Active);

 			}
		}

		void OnGUI()
		{       
			#if UNITY_EDITOR
			GUILayout.Label("当前鼠标X轴位置：" + Input.mousePosition.x);
			GUILayout.Label("当前鼠标Y轴位置：" + Input.mousePosition.y);    
			#endif
		}
}}