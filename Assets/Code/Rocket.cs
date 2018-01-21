using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Requirements for S5T4: 2 Players. 10 Units from their Landing should change colorv1blue 2 yellow land green

public class Rocket : MonoBehaviour {

    Rigidbody _rigidBody;
    public float mainFly = 650f;
    [SerializeField] float secFly = 100f;
    AudioSource bgsound;
    bool removeBump = false;

    // Use this for initialization
    void Start () {
        _rigidBody = GetComponent<Rigidbody>();
        bgsound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();

    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.O))
        {
            removeBump = true;
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidBody.AddRelativeForce(Vector3.up * mainFly * Time.deltaTime);
            if (!bgsound.isPlaying)
            {
                bgsound.Play();
            }
        }
        else
        {
            bgsound.Stop();
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * secFly * Time.deltaTime);
           
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * secFly * Time.deltaTime);
            
        }
    


    }

    private void OnCollisionEnter(Collision collision)
    {
        print("collision rocket:" + collision.gameObject.tag);
        if (removeBump)
        {
            print("Remove Bump true");
        }
        else if (collision.gameObject.tag != "Start" && collision.gameObject.tag != "Last")
        {
            print("change scene");
            SceneManager.LoadScene(1);
        }
        else if(collision.gameObject.tag == "Last")
        {
            print("End of Game");
        }

    }
}
