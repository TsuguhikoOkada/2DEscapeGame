using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>メインゲーム全体を管理するスクリプト</summary>

public class GameManager  : MonoBehaviour
{
    

    /// <summary>タイムテキストのメンバ変数</summary>
    [SerializeField,Header("タイムテキスト")] TextMeshProUGUI _timeText;

    /// <summary>タイマー(分)を表すメンバ変数</summary>
    [SerializeField, Header("分")] int _countdownMinutes;

    /// <summary>タイマーが0になった時に移動するシーン名のメンバ変数</summary>
    [SerializeField, Header("遷移シーン名")] string _sceneName;

    /// <summary>タイマー(秒)を表すメンバ変数</summary>
    float _countdownSeconds;

    /// <summary>WaitforSecondsのメンバ変数</summary>
    WaitForSeconds _lag;

    /// <summary>WaitforSecondsでの待機時間のメンバ変数</summary>
    [SerializeField, Header("シーン切り換え待機時間")] float _lagSecond;

    /// <summary>タイマーを記録するメンバ変数</summary>
    public static TimeSpan _span;

    /// <summary>再生した時にWaitforSecondsをキャッシュさせるためのAwakeメソッド</summary>
    void Awake()
    {
        _lag = new WaitForSeconds(_lagSecond);

        
    }

    /// <summary>
    /// カウントダウンのセット
    /// </summary>
    void Start()
    {
        _countdownSeconds = _countdownMinutes * 60;
    }

    /// <summary>
    ///  テキスト更新や0秒になった時の処理
    /// </summary>
    void Update()
    {
        _countdownSeconds -= Time.deltaTime;

        _span = new TimeSpan(0, 0, (int)_countdownSeconds);

        _timeText.text = _span.ToString(@"mm\:ss");

        // タイムが0になったら
        if (_countdownSeconds <= 0)
        {
            StartCoroutine(TimeUp());
        }
    }

    IEnumerator TimeUp()
    {
        yield return _lag;

        SceneManager.LoadScene(_sceneName);
    }
}
