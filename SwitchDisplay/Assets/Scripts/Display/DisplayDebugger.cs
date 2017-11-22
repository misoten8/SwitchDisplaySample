using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

/// <summary>
/// ディスプレイ単体駆動補助クラス
/// ディスプレイシーン単体でのテストはこのクラスを使用してください
/// 製作者：実川
/// </summary>
public class DisplayDebugger : MonoBehaviour
{
	/// <summary>
	/// 呼び出し対象ディスプレイ
	/// </summary>
	[SerializeField]
	private DisplayBase _display;

	/// <summary>
	/// 引き渡し用シーンキャッシュ
	/// </summary>
	[SerializeField]
	private SceneCacheBase _sceneCache;

	private Events[] _events;

	private void Start()
	{
		// ディスプレイ初期化処理呼び出し
		_display.OnAwake(_sceneCache);

		// リフレクションを使用する(重いけど、デバッグ用でStart呼び出しだから多少はね？)

		// 型を取得
		Type type = _display.DisplayEvents.GetType();

		// 型のフィールドを取得
		MemberInfo[] members = type.GetMembers();

		// TODO:リフレクションで取得したフィールドをデリゲートに変換する
		// イベントを取得
		//_events = members
		//		.Where(e => e.ReflectedType != typeof(Action) ? true : false)
		//		.Select(e => 
		//		{
		//			var t = e.MemberType.GetType();
		//			var method = t.GetMethod(t.Name);
		//			var instance = Activator.CreateInstance(t);
		//			var methodDelegate = (Action)Action.CreateDelegate(typeof(Action), t, method);
		//			return new Events(methodDelegate, e.Name);
		//		})
		//		.ToArray();
	}

	private void OnGUI()
	{
		if (_events == null)
			return;

		int counter = 0;
		foreach(Events element in _events)
		{
			if(GUI.Button(new Rect(new Vector2(0, counter * 20), new Vector2(150, 20)), element.name))
			{
				// イベント実行
				element.displayEvent?.Invoke();
			}
			counter++;
		}
	}

	/// <summary>
	/// デバッグでのみ使用するイベントクラス
	/// </summary>
	internal class Events
	{
		/// <summary>
		/// ディスプレイイベント
		/// </summary>
		public Action displayEvent;

		/// <summary>
		/// イベント名
		/// </summary>
		public String name;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Events(Action DisplayEvent, String Name)
		{
			displayEvent = DisplayEvent;
			name = Name;
		}
	}
}