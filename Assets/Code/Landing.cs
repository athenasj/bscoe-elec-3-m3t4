using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Landing : MonoBehaviour {
    public Material[] material = new Material [5];
    Renderer rendere;
    GameObject rocket1;

    Vector3 rock1Loc;
    bool collide = false;

    public int range = 5;

    // Use this for initialization
    void Start () {
        rendere = GetComponent<Renderer>();
        rendere.enabled = true;
        //rendere.sharedMaterial = material[0];
        rendere.sharedMaterial.color = Color.gray;

        rocket1 = GameObject.FindWithTag("Rocket");
        print("Scene Index: " + SceneManager.GetActiveScene().buildIndex);

    }
	
	// Update is called once per frame
	void Update () {
        rock1Loc = rocket1.transform.position;
        if (collide && gameObject.tag == "End Launch Pad")
        {
            rendere.sharedMaterial.color = Color.green;
        }
        else if (collide && gameObject.tag != "Last")
        {
            rendere.sharedMaterial.color = Color.red;
        }
        else if ((Vector3.Distance(transform.position, rock1Loc) < range) && !collide)
        {
            rendere.sharedMaterial.color = Color.blue;
        }
         else if (!collide)
        {
            rendere.sharedMaterial.color = Color.gray;
        }
        
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rocket" && gameObject.tag != "Last")
            
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            collide = true;
        }else if (collision.gameObject.tag == "Rocket")
        {
            collide = true;
            rendere.sharedMaterial.color = Color.green;
        }
        

    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Rocket")

    //    {
    //        collide = false;
    //    }
    //}
}
