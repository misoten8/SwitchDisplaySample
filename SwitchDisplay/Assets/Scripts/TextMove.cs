﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position -= new Vector3(1, 0, 0);
        if (this.transform.position.x < -300)
        {
            Destroy( this.gameObject );
        }
    }
}
