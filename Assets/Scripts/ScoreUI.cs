using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {
	
	private GameObject guiTextSaveScore;   // SaveScore Text
	
	// テキストボックスで入力される文字列を格納
	public string name;
	public string score_string;
	public int score;
	public InputField nameInput;
	public Text scoreText;
	void Start () {

		// ゲームオブジェクトを検索し取得する
		guiTextSaveScore  = GameObject.Find ("GUITextSaveScore");
		score = PlayerPrefs.GetInt ("Score", 1);
		scoreText.text = score.ToString();
	}

	public void submitButton(){
		name = nameInput.text;
		Debug.Log (name);
		FindObjectOfType<SaveScore> ().save (name, score);
		Application.LoadLevel ("Stage");
	}
}
