using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextMove : MonoBehaviour {

    [SerializeField]
    TextMeshProUGUI textmeshpro;
    [SerializeField]
    GameObject tmp;


    TextMeshProUGUI text = null;

    // Use this for initialization
    void Start () {
        text.text = "イベントアメ";
        text.text = "イベントアラシ";
    }
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x > -300)
        {
            this.transform.localPosition -= new Vector3(0.05f, 0, 0);
            tmp.SetActive(true);
        }
        else
        {
            tmp.SetActive(false);
        }

    }

    public void Set()
    {
        textmeshpro.transform.localPosition = new Vector3(12, 5, 0);

        //textmeshpro.text = "AAA";
        text.SetText("イベントアラシ");
        textmeshpro.SetText(string.Format(text.text));

    }

}
