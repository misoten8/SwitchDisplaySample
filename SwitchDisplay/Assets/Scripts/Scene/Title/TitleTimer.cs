using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTimer : MonoBehaviour 
{
	/// <summary>
	/// 経過時間
	/// </summary>
	public float ElapsedTime
	{
		get { return _elapsedTime; }
	}

	private float _elapsedTime = 0.0f;

	void Update () 
	{
		_elapsedTime += Time.deltaTime;
	}
}
