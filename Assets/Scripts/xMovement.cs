using UnityEngine;
using System.Collections;
using Leap;

public class xMovement : MonoBehaviour {

	Controller controller = new Controller();
	Frame frame;

	float xHand;
	float xHandAux;
	float xPos;
	float grabStr;
	int xLim = 21;

	GameObject left;
	GameObject right;
	GameObject[] text;
	GameObject frontImage;
	GameObject camera;

	void Start() {
		
		camera = GameObject.Find("Main Camera");
		frontImage = GameObject.Find("FrontImage");
		text = GameObject.FindGameObjectsWithTag("text");
		left = GameObject.Find("MoveLeft");
		right = GameObject.Find("MoveRight");
	}
	
	// Update is called once per frame
	void Update () {

		frame = controller.Frame();

		xPos = camera.gameObject.transform.position.x;
		xHand = frame.Hands.Frontmost.PalmPosition.x;
		grabStr = frame.Hands.Frontmost.GrabStrength;
		
		Debug.Log ("xPos: " + xPos + " / xHand: " + xHand + " / grabStr: " + grabStr);

		if(grabStr >= 0.8) {

			//Desabilita o renderer dos numeros
			foreach(GameObject texto in text) {
				texto.gameObject.GetComponentInChildren<TextMesh>().color = Color.gray;
				//texto.renderer.enabled = false;
			}

			if(xPos <= -xLim)
				SetX(-xLim+0.01f);
			
			else if(xPos >= xLim+3.5f)
				SetX((xLim+3.5f)-0.01f);

			else
				SetTransformX(xHand/800);
		}

		else if(frontImage.renderer.enabled == false) {

			//Habilita o renderer dos numeros
			foreach(GameObject texto in text) {
				texto.gameObject.GetComponentInChildren<TextMesh>().color = Color.black;
				//texto.renderer.enabled = true;
			}
		}

		else;
	}

	void SetTransformX(float x) {
		
		this.gameObject.transform.position -= new Vector3(x, 0, 0);

		float tempX = this.gameObject.transform.position.x;

		//left.transform.position = new Vector3(tempX-5, left.transform.position.y, left.transform.position.z);
		//right.transform.position = new Vector3(tempX+5, right.transform.position.y, right.transform.position.z);
		
		left.transform.position = new Vector3(tempX-5, left.transform.position.y, left.transform.position.z);
		right.transform.position = new Vector3(tempX+5, right.transform.position.y, right.transform.position.z);
	}
	
	void SetX(float x) {
		
		this.transform.position = new Vector3(x, this.transform.position.y, this.transform.position.z);
		
		float tempX = this.gameObject.transform.position.x;
		
		//left.transform.position = new Vector3(tempX-5, left.transform.position.y, left.transform.position.z);
		//right.transform.position = new Vector3(tempX+5, right.transform.position.y, right.transform.position.z);
		
		left.transform.position = new Vector3(tempX-5, left.transform.position.y, left.transform.position.z);
		right.transform.position = new Vector3(tempX+5, right.transform.position.y, right.transform.position.z);
	}

}
