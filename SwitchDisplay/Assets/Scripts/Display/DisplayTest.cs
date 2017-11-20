using UnityEngine;

/// <summary>
/// DisplayTest クラス
/// 製作者：実川
/// </summary>
public class DisplayTest : MonoBehaviour 
{
	[SerializeField]
	private ISceneCache sceneCache;

	private void OnGUI()
	{
		if(GUI.Button(new Rect(new Vector2(200,0), new Vector2(400, 100)), "ディスプレイ切り替え"))
		{
			Debug.Log("ボタンが押されました");

			switch (DisplayManager.CurrentDisplayType)
			{
				case DisplayManager.DisplayType.Logo:
					DisplayManager.SwitchDisplay(DisplayManager.DisplayType.Menu, sceneCache);
					break;
				case DisplayManager.DisplayType.Menu:
					DisplayManager.SwitchDisplay(DisplayManager.DisplayType.Logo, sceneCache);
					break;
				default:
					break;
			}
		}
	}
}