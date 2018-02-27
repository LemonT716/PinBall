using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	private float visiblePosZ = -6.5f; //ボールが見える可能性のあるz軸の最大値
	private GameObject gameoverText;
	private GameObject scoreText;
	int score=0;

	// Use this for initialization
	void Start () {
		this.gameoverText = GameObject.Find ("GameOverText");
		this.scoreText = GameObject.Find ("ScoreText");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.z < this.visiblePosZ) {
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

void OnCollisionEnter(Collision other){

	if (other.gameObject.tag == "SmallStarTag") {
		score += 10;
	} else if (other.gameObject.tag == "LargeStarTag") {
		score += 20;
	}
		this.scoreText.GetComponent<Text>().text=score.ToString();
}
}
