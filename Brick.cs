using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int timesHit;
	private LevelManager levelManager;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	private bool isBreakable;
	public AudioClip crack;
	public GameObject smoke;
//	enum brickColor{oneHit = 1, twoHit = 2, threeHit = 3};
	
	// Use this for initialization
	void Start () {
		timesHit = 0;
		isBreakable = (this.tag == "Breakable");
		maxHits = hitSprites.Length + 1;
		if (isBreakable){
			if (maxHits==1){
				gameObject.renderer.material.color = Color.yellow;
			}else if (maxHits==2){
				gameObject.renderer.material.color = Color.magenta;
			}else if (maxHits==3){
				gameObject.renderer.material.color = Color.red;
			}
			breakableCount++;
		}			
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter2D (Collision2D collision){
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.3f);
		if (isBreakable){
			HandleHits();
		}
	}

	void HandleHits(){
		timesHit ++;
//		For showing break progress by color.
//		if (timesHit==1){
//			gameObject.renderer.material.color = Color.yellow;
//		} 
		if (timesHit>=maxHits){
			breakableCount--;
//			GameObject.Destroy(gameObject);
			Destroy(gameObject);
			PuffSmoke();
			levelManager.BrickDestroyed();
		} else {
			LoadSprites();
		}
//		SimulateWin();
	}
	
	void PuffSmoke(){
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
//		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
		smokePuff.particleSystem.startColor = gameObject.renderer.material.color;
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];		
		} else {
			Debug.LogError("No sprite to load.");
		}
	}
	
	// TODO Remove this method once we can actually win.
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}
