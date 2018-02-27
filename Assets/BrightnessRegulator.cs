using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour {
	Material myMaterial;

	private float minEmission = 0.3f;   //Emissionの最小値
	private float magEmission = 0.2f;   //Emissionの強度
	private int degree = 0;   //角度
	private int speed = 10;   //発光速度
	Color defaultColor=Color.white;   //ターゲットのデフォルトの色

	// Use this for initialization
	void Start () {
		//タグによって光らせる色を変える
		if (tag == "SmallStarTag") {
			this.defaultColor = Color.white;
		} else if (tag == "LargeStarTag") {
			this.defaultColor = Color.yellow;
		} else if (tag == "SmallCloudTag" || tag == "LargeCloudTag") {
			this.defaultColor = Color.blue;
		}

		this.myMaterial = GetComponent<Renderer> ().material;//オブジェクトにアタッチしているmaterialを取得

		myMaterial.SetColor ("_EmissionColor", this.defaultColor * minEmission);//オブジェクトの最初の色を設定

	}
	
	// Update is called once per frame
	void Update () {
		if (this.degree >= 0) {
			//光らせる強度を計算する
			Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad)
			                      * this.magEmission);
			//エミッションに色を設定する
			myMaterial.SetColor ("_EmissionColor", emissionColor);
			//現在の角度を小さくする
			this.degree -= this.speed;
		}
	}
	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other){
		//角度を１８０に設定
		this.degree = 180;

	}
}
