using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MoveIventManager : MonoBehaviour {

    [SerializeField]
    private Transform ParentCanvas;
    [SerializeField]
    public GameObject NewsBackGround;
    [SerializeField]
    public GameObject Textmeshpro;

    //public Action onHoge;

    // Use this for initialization
    void Start()
    {

       //if(onHoge != null)
       //{
       //    onHoge.Invoke();
       //}
       //
       //onHoge?.Invoke();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void IventCreate()
    //{
    //    Instantiate.
    //}
    public void Textcreate(GameObject parent)
    {
        //Textmeshpro. = InputText.text;
        GameObject instance;
        TextMeshProUGUI component;

        //component.Cull( rect , true);
        //生成,親子付け
        instance  = Instantiate(Textmeshpro, ParentCanvas);
        component = instance.GetComponent<TextMeshProUGUI>();
        //instance.transform.position.Set(ParentCanvas.position.x * 2.0f, ParentCanvas.position.y * 1.6f, ParentCanvas.position.z);
        //component.transform.position = new Vector3(ParentCanvas.position.x * 2.0f, ParentCanvas.position.y * 2.6f, ParentCanvas.position.z);
        component.transform.position = new Vector3(30.0f, 30.0f, 0.0f);

        //入力された文字を入れる
        component.text = "アメガ フッテ キタ ヨウデス・・・";
        //文字の長さと大きさを取得しこれ自体の大きさを決める
        //文字の長さ,大きさ取得
        //int len = text.text.Length;
        //float fontsize = component.fontSize;
        ////サイズ変更
        //RectTransform textRect = instance.GetComponent<RectTransform>();
        //textRect.sizeDelta = new Vector2((fontsize - 2.0f) * len, fontsize);
        instance.transform.position = new Vector3(parent.transform.position.x + 100, parent.transform.position.y, parent.transform.position.z);
    }


    public void IventCreate()
    {
       //Textmeshpro. = InputText.text;
       // GameObject instance;
       // TextMeshProUGUI component;
       GameObject image;
       image = Instantiate( NewsBackGround , ParentCanvas);
       Textcreate(image);
       //component = instance.GetComponent<TextMeshProUGUI>();

    }



}
