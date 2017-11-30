using UnityEngine;

/// <summary>
/// (サンプル)メニューディスプレイのデバッグ用イベント呼び出しクラス
/// </summary>
public class MenuDisplayDebugEvent : DisplayDebugEventBase 
{
	[SerializeField]
	private MenuDisplay _menuDisplay;

	public override void OnAwake()
	{
		debugEvents
			.eventList
			.Add(
			new DisplayDebugger.DebugEvents.Element(
				_menuDisplay._events.onCallEvent,
				nameof(_menuDisplay._events.onCallEvent)));
	}
}