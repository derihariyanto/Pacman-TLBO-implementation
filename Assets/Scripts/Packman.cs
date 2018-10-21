using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packman : MonoBehaviour {

    public float speed = 4.0f;
    private Vector2 direct = Vector2.zero;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckInput();
        Move();
        //movecloser();
        UpdateOrientation();
	}

    void CheckInput() {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direct = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direct = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direct = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direct = Vector2.down;
        }
    }

    void Move() {
        transform.localPosition += (Vector3)(direct * speed) * Time.deltaTime;
        
    }

    void UpdateOrientation() {
        if (direct == Vector2.left)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direct == Vector2.right)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direct == Vector2.up)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0,0,90);
        }
        else if (direct == Vector2.down)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 270);
        }

        
    }
}
