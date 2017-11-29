using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityScript.Lang;




using UnityEditor;
using UnityEngine;


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
		Menu,
        Move
    }

	private static readonly Dictionary<DisplayType, string> _DISPLAY_MAP = 
		new Dictionary<DisplayType, string>
    {
        { DisplayType.Logo, "LogoDisplay" },
        { DisplayType.Menu, "MenuDisplay" },
        { DisplayType.Move, "MoveDisplay" }
    };

	private AsyncOperation _async = null;

	private void Start()
	{
		// シーン遷移
		Instance._async = SceneManager.LoadSceneAsync(_DISPLAY_MAP[CurrentDisplayType], LoadSceneMode.Additive);
		Instance._currentDisplayType = CurrentDisplayType;
		SceneManager.sceneLoaded += (scene, mode) => Instance._async = null;
	}

	/// <summary>
	/// ディスプレイの切り替え処理
	/// ディスプレイ遷移中に呼び出した場合、処理をスキップする
	/// </summary>
	public static void SwitchDisplay(DisplayType type)
	{
		if (Instance._async != null)
			return;

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

	private void SceneLoaded(Scene scene, LoadSceneMode mode)
	{
		//SceneManager.sceneUnloaded -= SceneUnloaded;
		SceneManager.UnloadSceneAsync(_DISPLAY_MAP[Instance._currentDisplayType]);
		Debug.Log(scene.name + " シーン読み込み完了\nこれより" + Instance._currentDisplayType.ToString() + " シーンの解放を行います");
		Instance._currentDisplayType = _DISPLAY_MAP.First(e => e.Value == scene.name).Key;
		Instance._async = null;
	}

	private void SceneUnloaded(Scene scene)
	{
		//SceneManager.sceneLoaded -= SceneLoaded;
		Debug.Log(scene.name + " シーンの開放が完了しました");
		SceneManager.sceneLoaded -= SceneLoaded;
		SceneManager.sceneUnloaded -= SceneUnloaded;
	}


    //勢力図関係ココカラ///////////////////////////////////////////////////////////////////////////////////////////
    [SerializeField]
    static float Player1Power = 1.0f;
    [SerializeField]
    static float Player2Power = 2.0f;
    [SerializeField]
    static float Player3Power = 3.0f;
    [SerializeField]
    static float Player4Power = 4.0f;
    /// <summary>
    /// 勢力図ゲージの表示計算
    /// </summary>
    /// <param name="No">Noはプレイヤーの番号を入れる</param>
    /// <returns></returns>
    public static float GetPlayerPower( int No )
    {
        float AllPower =   Player1Power + Player2Power + Player3Power + Player4Power;
        float[] Power  = { Player1Power , Player2Power , Player3Power , Player4Power };
        if ( AllPower > 0.0f ) Power[ No - 1 ] = Power[ No - 1 ] / AllPower;
        return Power[No-1];
    }

    //任意のプレイヤーのスコアを増やす
    //public void AddScore(int No, float Value = 0.01f)
    //{
    //    switch (No)
    //    {
    //        case 1:
    //            Player1Power += Value;
    //            break;
    //        case 2:
    //            Player2Power += Value;
    //            break;
    //        case 3:
    //            Player3Power += Value;
    //            break;
    //        default:
    //            Player4Power += Value;
    //            break;
    //    }
    //}

    //Inspector上にボタンを作る
    [CustomEditor(typeof(DisplayManager))]//拡張するクラスを指定
    public class DisplayManagerEditor : Editor
    {

        /// <summary>
        /// InspectorのGUIを更新
        /// </summary>
        public override void OnInspectorGUI()
        {
            //元のInspector部分を表示
            base.OnInspectorGUI();

            //ボタンを表示
            if (GUILayout.Button("Player1PowerUp"))
            {
                Player1Power += 1.0f;
            }
            if (GUILayout.Button("Player2PowerUp"))
            {
                Player2Power += 1.0f;
            }
            if (GUILayout.Button("Player3PowerUp"))
            {
                Player3Power += 1.0f;
            }
            if (GUILayout.Button("Player4PowerUp"))
            {
                Player4Power += 1.0f;
            }

        }
    }
    //勢力図関係ココマデ//////////////////////////////////////////////////////////////////////////////////////////





    //コントローラーの角度関係ココカラ//////////////////////////////////////////////////////////////////////////////////////////
    static float ControllerAngle;

    public static float GetControllerAngle()
    {
        return ControllerAngle;
    }
    //コントローラーの角度関係ココマデ//////////////////////////////////////////////////////////////////////////////////////////




}
