using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シングルトン実装クラス
/// 製作者：実川
/// 使用時の注意点
/// シングルトン継承クラスにAwakeを実装すると、継承先の方が先に呼ばれるためAwakeを使用しないでください。
/// また、シングルトン継承クラス内で呼び出し順を設定する必要がある場合、Unityのインスペクターから直接Awakeの呼び出し順を設定してください
/// </summary>
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    static protected T instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static T Instance
    {
        get
        {
            return instance;
        }
    }
}