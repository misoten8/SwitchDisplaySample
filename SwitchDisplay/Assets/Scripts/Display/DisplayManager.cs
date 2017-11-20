using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections;

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

	/// <summary>
	/// ディスプレイの種類
	/// </summary>
	public enum DisplayType
	{
		Logo,
		Menu
	}

	/// <summary>
	/// ディスプレイタイプとシーンの紐付けマップ
	/// </summary>
	private static readonly Dictionary<DisplayType, string> _DISPLAY_MAP = 
		new Dictionary<DisplayType, string>
	{
		{ DisplayType.Logo, "LogoDisplay" },
		{ DisplayType.Menu, "MenuDisplay" }
	};

	private IDisplay _currentdisplay;

	private ISceneCache _currentSceneCache;

	private AsyncOperation _async = null;

	private void Start()
	{
		// シーン遷移
		Instance._async = SceneManager.LoadSceneAsync(_DISPLAY_MAP[CurrentDisplayType], LoadSceneMode.Additive);
		Instance._currentDisplayType = CurrentDisplayType;
		SceneManager.sceneLoaded += (scene, mode) => 
		{
			Instance._async = null;
			StartCoroutine(LoadDisplayScene(scene));
		};
	}

	/// <summary>
	/// ディスプレイの切り替え処理
	/// ディスプレイ遷移中に呼び出した場合、処理をスキップする
	/// </summary>
	public static void SwitchDisplay(DisplayType type, ISceneCache sceneCache)
	{
		if (Instance._async != null)
			return;

		Instance._currentSceneCache = sceneCache;

		// シーン遷移
		Instance._async = SceneManager.LoadSceneAsync(_DISPLAY_MAP[type], LoadSceneMode.Additive);
		Debug.Log(_DISPLAY_MAP[type] + " シーン読み込みを開始します");
		SceneManager.sceneLoaded += Instance.SceneLoaded;
		SceneManager.sceneUnloaded += Instance.SceneUnloaded;
	}

	// 欲しいメソッドイメージ
	// 各ディスプレイクラスのイベント関数を呼び出せる仕組み
	// しかし、ディスプレイを直接参照することを許さず、このディスプレイ管理クラスを通して参照させる
	// ここでは指定されたクラスのディスプレイインスタンスを渡す
	// そしてnullチェックも行える仕組みにする

	// ジェネリックを使用し、引数と戻り値はdisplayBaseを継承したクラスのみ許可する

	/// <summary>
	/// ディスプレイ継承クラスを取得する
	/// </summary>
	public static T GetInstanceDisplay<T>() where T : class, IDisplay
	{
		T display = Instance._currentdisplay as T;

		return display != null ? display : default(T);
	}

	private void SceneLoaded(Scene scene, LoadSceneMode mode)
	{
		DisplayType prevDisplayType = Instance._currentDisplayType;
		Instance._currentDisplayType = _DISPLAY_MAP.First(e => e.Value == scene.name).Key;
		// ディスプレイ切り替え処理の開始
		StartCoroutine(SwitchDisplayScene(prevDisplayType, scene));
		Instance._async = null;
	}

	private void SceneUnloaded(Scene scene)
	{
		SceneManager.sceneLoaded -= SceneLoaded;
		SceneManager.sceneUnloaded -= SceneUnloaded;
	}

	/// <summary>
	/// 別シーンのディスプレイに遷移
	/// </summary>
	private IEnumerator SwitchDisplayScene(DisplayType deleteDisplayType, Scene scene)
	{
		// 解放するディスプレイシーンのアニメーション再生
		Instance._currentdisplay.OnSwitchFadeOut();

		// アニメーション終了待ち

		// ディスプレイシーンの整理(このタイミングで_currentdisplay変更)
		yield return StartCoroutine(LoadDisplayScene(scene));

		// ディスプレイの初期化
		Instance._currentdisplay.OnAwake(Instance._currentSceneCache);

		AsyncOperation asyncOp;
		
		// 過去のディスプレイシーン解放
		asyncOp = SceneManager.UnloadSceneAsync(_DISPLAY_MAP[deleteDisplayType]);

		// 過去のディスプレイシーン解放待ち
		if (asyncOp.progress < 0.9f)
		{
			Debug.Log(asyncOp.progress.ToString());
			yield return null;
		}

		// ディスプレイ開始アニメーションの再生
		Instance._currentdisplay.OnSwitchFadeIn();

		// アニメーション終了待ち
	}

	/// <summary>
	/// ディスプレイシーン内の不要なオブジェクトを全て消去し、ディスプレイクラスを取得する
	/// </summary>
	private IEnumerator LoadDisplayScene(Scene scene)
	{
		// ルートオブジェクト取得
		GameObject[] goList = scene.GetRootGameObjects();
		if (goList == null)
		{
			yield break;
		}
		if (goList.Length == 0)
		{
			yield break;
		}

		DisplayBase display;
		
		// ディスプレイオブジェクト取得処理
		foreach (var go in goList)
		{
			display = go.GetComponentInChildren<DisplayBase>();
			
			// displayを含んでいる場合(goがCanvas)
			if (display != null)
			{
				// ディスプレイオブジェクトの取得
				Instance._currentdisplay = display;

				// Canvas内のディスプレイオブジェクト以外の消去
				foreach (Transform child in go.transform)
				{
					if (child != display.transform)
					{
						Destroy(child.gameObject);
					}
				}
			}
			else
			{
				// ディスプレイオブジェクトと関係無いオブジェクトの消去
				Destroy(go);
			}
		}
		yield return null;
	}
}
