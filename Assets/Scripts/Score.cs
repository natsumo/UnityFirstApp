using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public Text scoreText;

	public Text saveScoreText;

	// スコア
	private int score;
	private string ScoreKey = "Score";

	void Start ()
	{
		Initialize ();
	}
	
	void Update ()
	{
		// スコア・ハイスコアを表示する
		scoreText.text = "Score: " + score.ToString ();

	}
	
	// ゲーム開始前の状態に戻す
	private void Initialize ()
	{
		// スコアを0に戻す
		score = 0;
		Debug.Log (score.ToString ());

	}
	
	// ポイントの追加
	public void AddPoint (int point)
	{
		score = score + point;
	}
	
	// ハイスコアの保存
	public void Save ()
	{
		// ハイスコアを保存する
		PlayerPrefs.SetInt (ScoreKey, score);
		PlayerPrefs.Save ();

		// ゲーム開始前の状態に戻す
		Initialize ();
	}
	
}