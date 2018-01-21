using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpDown : MonoBehaviour {
    string move = "down";
    Vector3 tempPos;
    float speed = 2;
    bool removeBump;
	// Use this for initialization
	void Start () {
        tempPos = transform.position;
        removeBump = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.O))
        {
            removeBump = true;
        }
        if (move == "up")
        {
            tempPos.y += speed * Time.deltaTime;
            transform.position = tempPos;
        }
        else if (move == "down")
        {
            //print(gameObject.tag + "update");
            tempPos.y -= speed * Time.deltaTime;
            transform.position = tempPos;
        }
	}

    public void OnTriggerEnter(Collider collision)
    {
        if (removeBump && collision.gameObject.tag == "Rocket")
        {

        }
        else if(collision.gameObject.tag == "Rocket")
        {
            SceneManager.LoadScene(1);
        }
        else if (move == "up")
        {
            move = "down";
        }
        else if (move == "down")
        {
            move = "up";
        }
    }
}
