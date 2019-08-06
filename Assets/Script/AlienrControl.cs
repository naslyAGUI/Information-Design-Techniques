using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienControl : MonoBehaviour {

	Rigidbody2D rb2;
	 GameObject target;
	float moveSpeed;
	Vector3 directionToTarget;
    
    void Start () {
		target = GameObject.Find ("Player");
		rb2 = GetComponent<Rigidbody2D> ();
		moveSpeed = Random.Range (0.7f, 1.0f);
        //GameOverText.text = "";

    }
	
	
	void Update () {
		MoveAlien ();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		switch (col.gameObject.tag) {

		case "Player":
               
                  target = null;
                
                break;
            

        }
	}

	void MoveAlien ()
	{
		if (target != null) {
			directionToTarget = (target.transform.position - transform.position).normalized;
			rb2.velocity = new Vector2 (directionToTarget.x * moveSpeed,
										directionToTarget.y * moveSpeed);
		}
		else
			rb2.velocity = Vector3.zero;
	}
}
