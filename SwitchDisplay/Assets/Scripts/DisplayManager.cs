using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// DisplayManager クラス
/// 製作者：実川
/// </summary>
public class DisplayManager : SingletonMonoBehaviour<DisplayManager>
{
	public static DisplayType CurrentDisplayType
	{
		get { return Instance._currentDisplayType; }
	}

	[SerializeField]
	private DisplayType _currentDisplayType;

	public enum DisplayType
	{
		Logo,
		Menu
	}

	private static readonly Dictionary<DisplayType, string> _DISPLAY_MAP = 
		new Dictionary<DisplayType, string>
	{
		{ DisplayType.Logo, "LogoDisplay" },
		{ DisplayType.Menu, "MenuDisplay" }
	};

	private DisplayBase _currentDisplay = null;
	private DisplayBase _nextDisplay = null;

	private Scene _currentDisplayScene = new Scene();
	private Scene _nextDisplayScene = new Scene();

	private void Start()
	{
		StartDisplay(CurrentDisplayType);
	}

	public static void StartDisplay(DisplayType type)
	{
		// シーン遷移
		SceneManager.LoadSceneAsync(_DISPLAY_MAP[type], LoadSceneMode.Additive);
		Debug.Log(_DISPLAY_MAP[type] + " シーン読み込みを開始します");

		// シーンオブジェクトのAwake処理がどう呼ばれるか気になる

		SceneManager.sceneLoaded += (scene, mode) =>
		{
			Instance._currentDisplayScene = scene;
			Instance._currentDisplayType = type;
			Debug.Log(_DISPLAY_MAP[type] + " シーン読み込み完了");
		};
	}

	// シーンデータクラスを受け取る
	public static void SwitchDisplay(DisplayType type)
	{
		// 代用処理ディスプレイクラスの実装完了後に消去する
		if (SceneManager.sceneCount < 2)
			return;

		//Scene currentScene = SceneManager.GetSceneAt(1);

		// シーン遷移
		SceneManager.LoadSceneAsync(_DISPLAY_MAP[type], LoadSceneMode.Additive);
		Debug.Log(_DISPLAY_MAP[type] + " シーン読み込みを開始します");

		// シーンオブジェクトのAwake処理がどう呼ばれるか気になる

		SceneManager.sceneLoaded += (scene, mode) => 
		{
			Instance._nextDisplayScene = scene;
			SceneManager.UnloadSceneAsync(Instance._currentDisplayScene);
			Debug.Log(_DISPLAY_MAP[type] + " シーン読み込み完了\nこれより" + _DISPLAY_MAP[Instance._currentDisplayType] + " シーンの解放を行います");
		};

		SceneManager.sceneUnloaded += (secne) => 
		{
			Instance._currentDisplay = Instance._nextDisplay;
			Instance._nextDisplay = null;
			Instance._currentDisplayScene = Instance._nextDisplayScene;
			Instance._nextDisplayScene = new Scene();
			
			Debug.Log(_DISPLAY_MAP[Instance._currentDisplayType] + " シーンの開放が完了しました");
			Instance._currentDisplayType = type;
		};
	}

	// 欲しいメソッドイメージ
	// 各ディスプレイクラスのイベント関数を呼び出せる仕組み
	// しかし、ディスプレイを直接参照することを許さず、このディスプレイ管理クラスを通して参照させる
	// ここでは指定されたクラスのディスプレイインスタンスを渡す
	// そしてnullチェックも行える仕組みにする

	// ジェネリックを使用し、引数と戻り値はdisplayBaseを継承したクラスのみ許可する

	/// <summary>
	/// ディスプレイ継承クラスを取得する
	/// もし継承するメリットがない場合、インターフェイスに切り替えるIDisplay
	/// </summary>
	public static T GetInstanceDisplay<T>() where T : DisplayBase
	{

		return default(T);
	}

	public static T GetInstanceSceneCache<T>() where T : SceneCacheBase
	{
		return default(T);
	}
}
