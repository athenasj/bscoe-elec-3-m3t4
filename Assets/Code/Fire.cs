using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public ParticleSystem party;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            party.Emit(1);
        }
	}
}
