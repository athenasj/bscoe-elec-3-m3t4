using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftRight : MonoBehaviour {

    string move = "left";
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
        if (move == "left")
        {
            tempPos.x += speed * Time.deltaTime;
            transform.position = tempPos;
        }
        else if (move == "right")
        {
            //print(gameObject.tag + "update");
            tempPos.x -= speed * Time.deltaTime;
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
        else if (move == "left")
        {
            move = "right";
        }
        else if (move == "right")
        {
            move = "left";
        }
    }


}
