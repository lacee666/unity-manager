using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthUI : MonoBehaviour {


	private EnemyHealth enemyHealth;
	private Text text;

	void Start () {
        enemyHealth = this.transform.parent.parent.GetComponent<EnemyHealth>();
		text = this.GetComponent<Text> ();
	}

	void LateUpdate(){
		text.text = enemyHealth.CurrentHealth.ToString ("F2");
	}
}
