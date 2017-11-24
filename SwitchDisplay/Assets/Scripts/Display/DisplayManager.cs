using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using System.Collections;

/// <summary>
/// DisplayManager クラス
/// 製作者：実川
/// </summary>
public class DisplayManager : SingletonMonoBehaviour<DisplayManager>
{
	/// <summary>
	/// 現在選択されているディスプレイの種類
	/// </summary>
	public static DisplayType CurrentDisplayType
	{
		get { return Instance._currentDisplayType; }
	}

	private DisplayType _currentDisplayType = DisplayType.None;

	/// <summary>
	/// ディスプレイの種類
	/// </summary>
	public enum DisplayType
	{
		/// <summary>
		/// ディスプレイなし
		/// </summary>
		None,
		Logo,
		Menu
	}

	/// <summary>
	/// フェードインアニメーション終了時実行イベント
	/// </summary>
	public event Action onFadedIn;

	/// <summary>
	/// フェードアウトアニメーション終了時実行イベント
	/// </summary>
	public event Action onFadedOut;

	/// <summary>
	/// ディスプレイタイプとシーンの紐付けマップ
	/// </summary>
	private static readonly Dictionary<DisplayType, string> _DISPLAY_MAP = 
		new Dictionary<DisplayType, string>
	{
		{ DisplayType.Logo, "LogoDisplay" },
		{ DisplayType.Menu, "MenuDisplay" }
	};

	/// <summary>
	/// 現在表示されているディスプレイ
	/// </summary>
	private IDisplay _currentdisplay;

	/// <summary>
	/// 現在表示されているシーンのキャッシュ
	/// </summary>
	private ISceneCache _currentSceneCache;

	/// <summary>
	/// ディスプレイ切り替え中かどうか
	/// </summary>
	private bool _isSwitching = false;

	private void Start()
	{
		SceneManager.sceneLoaded += (scene, mode) =>
		{
			DisplayType prevDisplayType = Instance._currentDisplayType;
			Instance._currentDisplayType = _DISPLAY_MAP.First(e => e.Value == scene.name).Key;
			// ディスプレイ切り替え処理の開始
			StartCoroutine(SwitchEnd(prevDisplayType, scene));
		};
	}

	/// <summary>
	/// ディスプレイの切り替え処理
	/// ディスプレイ遷移中に呼び出した場合、処理をスキップする
	/// </summary>
	public static void SwitchDisplay(DisplayType type, ISceneCache sceneCache)
	{
		if (Instance._isSwitching)
			return;

		Instance._currentSceneCache = sceneCache;
		Instance._isSwitching = true;

		// シーン遷移
		Instance.StartCoroutine(Instance.SwitchBegin(type));
	}

	/// <summary>
	/// ディスプレイイベント継承クラスを取得する
	/// </summary>
	public static T GetInstanceDisplayEvents<T>() where T : class, IEvents
	{
		T events = Instance._currentdisplay.DisplayEvents as T;

		return events != null ? events : default(T);
	}

	/// <summary>
	/// ディスプレイ切り替え開始処理
	/// </summary>
	private IEnumerator SwitchBegin(DisplayType LoadDisplayType)
	{
		// 解放するディスプレイシーンのアニメーション再生
		if (_currentDisplayType != DisplayType.None)
			yield return StartCoroutine(Instance._currentdisplay?.OnSwitchFadeOut());

		onFadedOut?.Invoke();
		onFadedOut = null;

		SceneManager.LoadSceneAsync(_DISPLAY_MAP[LoadDisplayType], LoadSceneMode.Additive);
		Debug.Log(_DISPLAY_MAP[LoadDisplayType] + " シーン読み込みを開始します");

		// ローディング画面を表示すると良いかも
	}

	/// <summary>
	/// ディスプレイ切り替え終了処理
	/// </summary>
	private IEnumerator SwitchEnd(DisplayType deleteDisplayType, Scene scene)
	{
		// ディスプレイシーンの整理(このタイミングで_currentdisplay変更)
		yield return StartCoroutine(LoadDisplayScene(scene));

		if (deleteDisplayType != DisplayType.None) {
			// 過去のディスプレイシーン解放
			AsyncOperation asyncOp = SceneManager.UnloadSceneAsync (_DISPLAY_MAP [deleteDisplayType]);

			// 過去のディスプレイシーン解放待ち
			while (asyncOp.progress < 0.9f)
				yield return null;
		}

		// ディスプレイの初期化
		Instance._currentdisplay.OnAwake(Instance._currentSceneCache);

		// ディスプレイ開始アニメーションの再生
		yield return StartCoroutine(Instance._currentdisplay.OnSwitchFadeIn());

		onFadedIn?.Invoke();
		onFadedIn = null;

		// ディスプレイ切り替え終了
		Instance._isSwitching = false;
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
				display.gameObject.SetActive(false);

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
