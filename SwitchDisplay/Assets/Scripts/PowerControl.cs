using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerControl : MonoBehaviour {

    [SerializeField]
    int No = 1;

    public Slider UIobj;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        //UIobj = GetComponent<Image>();
        UIobj.value = DisplayManager.GetPlayerPower(No);


    }
}
