using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthUI : MonoBehaviour {


	private EnemyHealth enemyHealth;
	private Text text;
	// Use this for initialization
	void Start () {
		enemyHealth = GameObject.Find ("enemy_health_canvas").GetComponent<EnemyHealth> ();
		text = this.GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void LateUpdate(){
		text.text = enemyHealth.CurrentHealth.ToString ("F2");
	}
}
