using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyHealth : MonoBehaviour {

    private AIHolder aiHolder;
    public Transform camera;
    [SerializeField]
    public Image image;
    private float armor = 2f;
    public float maxHealth = 500f;
    private float currentHealth;
    
	public float CurrentHealth{
		get{ 
			return this.currentHealth;
		}
		set{ 
			this.currentHealth = value;
		}
	}

	


	void Start () {
        currentHealth = maxHealth;
        camera = Camera.main.transform;
        aiHolder = GameObject.Find("AIHolder").GetComponent<AIHolder>();

	}
	
	void Update () {
		if (currentHealth <= 0) {
            aiHolder.enemies.Remove(this.transform.parent.gameObject);
			Destroy (this.transform.root.gameObject);
		}
	}

	void LateUpdate(){
		this.transform.LookAt (camera.position);
		image.fillAmount = currentHealth / maxHealth;
	}

	public void GetDamage(float damage){

		this.currentHealth = this.currentHealth - damage;

		CreateMessage ((damage).ToString());
	}

	public void CreateMessage(string message){
		GameObject newText = new GameObject(message.Replace(" ", "-"));

		var newTextComp = newText.AddComponent<TextMeshProUGUI>();
		/*newText.GetComponent<RectTransform> ().anchoredPosition.Set(0f, 0f);
		newText.GetComponent<RectTransform> ().sizeDelta.Set(0f,0f);
		newText.GetComponent<RectTransform> ().Rotate (new Vector3 (0, 0, 0));
		newText.GetComponent<RectTransform> ().localScale.Set (1f, 1f, 1f);*/
		newTextComp.text = message;
        newTextComp.color = Color.yellow;

		newTextComp.fontSize = 1;
		newText.GetComponent<RectTransform> ().position = this.transform.position + new Vector3 (0, 1, 0);


		newText.transform.SetParent(this.transform);
		Destroy (newText, 0.6f);
		IEnumerator coroutine = MoveDown (newText);
		StartCoroutine (coroutine);
	}
	IEnumerator MoveDown(GameObject go){
		for (float i = 0; i < 0.6f; i += 0.4f) {
			go.transform.Translate (new Vector3 (0, i, 0));
			yield return new WaitForSeconds (0.01f);
		}

	}
}
