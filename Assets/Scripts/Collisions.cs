using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {

	GameObject frontImage;
	GameObject[] text;

	//int idMaterial;
	bool collisionDetected = false;
	public float timeLimit = 2f;
	float changeImageTime;

	void Start () {

		text = GameObject.FindGameObjectsWithTag("text");
		frontImage = GameObject.Find("FrontImage");
	}

	void Update () {

		if (collisionDetected) {

			if((Time.realtimeSinceStartup - changeImageTime) >= timeLimit) {

				//Desabilita o Renderer de _frontImage e do Numero Associado:
				frontImage.gameObject.renderer.enabled = false;
				frontImage.gameObject.GetComponentInChildren<TextMesh>().renderer.enabled = false;
				setCollision(false);
				
				//Habilita o renderer dos numeros
				foreach(GameObject texto in text)
					texto.renderer.enabled = true;
			}
		}
	}

	void OnTriggerEnter (Collider collider) {
		
		setCollision(true);

		//Desabilita o renderer dos numeros
		foreach(GameObject texto in text)
			texto.renderer.enabled = false;

		//Define o Numero Associado a _fronImage:
		frontImage.gameObject.GetComponentInChildren<TextMesh>().text = this.gameObject.GetComponentInChildren<TextMesh>().text;

		//Habilida o Renderer de _frontImage e do Numero Associado:
		frontImage.gameObject.GetComponentInChildren<TextMesh>().renderer.enabled = true;
		frontImage.gameObject.renderer.enabled = true;

		//Marca o tempo da colisao
		changeImageTime = Time.realtimeSinceStartup;
	}

	void setCollision (bool detected) {

		collisionDetected = detected;
	}
}
