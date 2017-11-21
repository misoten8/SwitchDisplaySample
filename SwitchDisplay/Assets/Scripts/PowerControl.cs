using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerControl : MonoBehaviour {

    [SerializeField]
    int No = 1;

    public Image UIobj;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        //UIobj = GetComponent<Image>();
        UIobj.fillAmount = DisplayManager.GetPlayerPower(No);


    }
}
