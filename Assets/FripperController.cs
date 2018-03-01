using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	private HingeJoint myHingeJoint;

	private float defaultAngle = 20;
	private float flickAngle = -20;

	private int leftFingerId = 0;
	private int rightFingerId = 0;


	// Use this for initialization
	void Start () {
		this.myHingeJoint = GetComponent<HingeJoint> ();
		SetAngle (this.defaultAngle);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
			
		foreach (Touch t in Input.touches) {
			var id = t.fingerId;
			 
				switch (t.phase) {
			case TouchPhase.Began:
				if (Screen.width / 2 > Input.GetTouch (id).position.x && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);
					leftFingerId = id;
				}
				if (Screen.width / 2 < Input.GetTouch (id).position.x && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);
					rightFingerId = id;
				}
					break;
				case TouchPhase.Moved:
				case TouchPhase.Stationary:
					Debug.LogFormat ("{0}:タッチしている", id);
					break;

			case TouchPhase.Ended:
			case TouchPhase.Canceled:
				if (id == leftFingerId && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
				}
				if (id == rightFingerId && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
				}
					break;
				}
				
			}

	}
	public void SetAngle(float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
