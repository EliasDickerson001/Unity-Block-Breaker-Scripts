using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	private Ball ball;
	public bool autoPlay = false;
	public float minX, maxX;

	void Start (){
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay){
			MoveWithMouse();
		} else {
			AutoPlay();
		}
		
	}
//		To move paddle with mouse
	void MoveWithMouse (){
		Vector3 paddlePos = new Vector3 (this.transform.position.x, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}

//		To move paddle with ball	
	void AutoPlay(){
		Vector3 ballPosition = new Vector3 (ball.transform.position.x,this.transform.position.y,0f);
		this.transform.position = ballPosition;	
	}
}
