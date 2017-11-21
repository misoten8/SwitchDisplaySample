using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// TitleScene クラス
/// 製作者：実川
/// </summary>
public class TitleSceneManager : SceneBase<TitleSceneManager>
{
	[SerializeField]
	TitleSceneCache _sceneCache;

	void Start ()
	{
		DisplayManager.SwitchDisplay(firstUsingDisplay, _sceneCache);
	}
	
	void Update ()
	{
		
	}

	public override void Switch (SceneType nextScene)
	{
		OnSwitchScene (this);
		SceneManager.LoadSceneAsync(SCENE_MAP[nextScene], LoadSceneMode.Single);
	}

	// デバッグ用
	#if UNITY_EDITOR
	private void OnGUI()
	{
		if(GUI.Button(new Rect(new Vector2(200,0), new Vector2(400, 100)), "ディスプレイ切り替え"))
		{
			switch (DisplayManager.CurrentDisplayType)
			{
			case DisplayManager.DisplayType.Logo:
				DisplayManager.SwitchDisplay(DisplayManager.DisplayType.Menu, _sceneCache);
				break;
			case DisplayManager.DisplayType.Menu:
				DisplayManager.SwitchDisplay(DisplayManager.DisplayType.Logo, _sceneCache);
				break;
			default:
				break;
			}
		}

		if (GUI.Button (new Rect (new Vector2 (200, 150), new Vector2 (400, 100)), "シーン切り替え")) 
		{
			Switch (SceneType.Game);
		}
	}
	#endif
}
