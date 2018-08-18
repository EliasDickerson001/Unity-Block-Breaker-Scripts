using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelmanager;	

	void Start(){
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D (Collider2D trigger){
		levelmanager.LoadLevel("Lose");
	}
	void OnCollisionEnter2D (Collision2D collision){
	}
}
