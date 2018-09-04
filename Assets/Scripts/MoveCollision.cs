using UnityEngine;
using System.Collections;

public class MoveCollision : MonoBehaviour {

	string colliderTag;
	float xPos;
	int xLim = 21;

	GameObject hands;
	GameObject camera;
	GameObject front;
	GameObject left;
	GameObject right;

	void Start() {

		hands = GameObject.Find("HandController");
		camera = GameObject.Find("Main Camera");
		front = GameObject.Find("FrontImage");
		left = GameObject.Find("MoveLeft");
		right = GameObject.Find("MoveRight");
	}

	void Update() {

		xPos = camera.gameObject.transform.position.x;
	}
	
	void OnTriggerStay (Collider collider) {

		colliderTag = this.gameObject.tag;

		if(colliderTag.Equals("left")) {
			
			if(xPos <= -xLim)
				SetX(-xLim+0.02f);
			
			else if(xPos >= xLim+3.5f)
				SetX((xLim+3.5f)-0.02f);
			
			else
				SetTransformX(0.02f);
			
		} else if(colliderTag.Equals("right")) {
			
			if(xPos <= -xLim)
				SetX(-xLim+0.02f);
			
			else if(xPos >= xLim+3.5f)
				SetX((xLim+3.5f)-0.02f);
			
			else
				SetTransformX(-0.02f);
		}
	}
	
	void SetTransformX(float x) {

		left.transform.position -= new Vector3(x, 0, 0);
		right.transform.position -= new Vector3(x, 0, 0);
		hands.transform.position -= new Vector3(x, 0, 0);
		camera.transform.position -= new Vector3(x, 0, 0);
		front.transform.position -= new Vector3(x, 0, 0);
	}
	
	void SetX(float x) {
		
		//left.transform.position = new Vector3(x-5, left.transform.position.y, left.transform.position.z);
		//right.transform.position = new Vector3(x+5, right.transform.position.y, right.transform.position.z);
		
		left.transform.position = new Vector3(x-5, left.transform.position.y, left.transform.position.z);
		right.transform.position = new Vector3(x+5, right.transform.position.y, right.transform.position.z);
		hands.transform.position = new Vector3(x, hands.transform.position.y, hands.transform.position.z);
		camera.transform.position = new Vector3(x, camera.transform.position.y, camera.transform.position.z);
		front.transform.position = new Vector3(x, front.transform.position.y, front.transform.position.z);
	}
}
