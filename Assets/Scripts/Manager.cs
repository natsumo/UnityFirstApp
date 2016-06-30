using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
	// Playerプレハブ
	public GameObject player;
	public GameObject ghost;
	// タイトル
	private GameObject title;
	private GameObject ghostButton;

	 void Start ()
	{
		// Titleゲームオブジェクトを検索し取得する
		title = GameObject.Find ("Title");
		ghostButton = GameObject.Find ("GhostButton");
	}
	
	void Update ()
	{
		// ゲーム中ではなく、タッチまたはマウスクリック直後であればtrueを返す。
		if (!IsPlaying()) {
			/* ゴースト機能 */
//			if (Bg_ghost.readyGhost == true)
//				ghostButton.gameObject.SetActive (true);
//			else
				ghostButton.gameObject.SetActive (false);
		}
	}

	void GameStart (bool withGhost)
	{
		// ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
		title.gameObject.SetActive(false);
		//------------------------------------------------------------------------------
		if (withGhost == true) {
			// ゴーストボタンを押下したらゴーストを表示する
			Instantiate (ghost, ghost.transform.position, ghost.transform.rotation);
			Instantiate (player, player.transform.position, player.transform.rotation);
		} else {
			// 画面を押下したらゴーストを表示しないでゲームを開始する
			Instantiate (player, player.transform.position, player.transform.rotation);
		}
		//------------------------------------------------------------------------------
	}
	
	public void GameOver ()
	{
		FindObjectOfType<Score> ().Save ();
		Application.LoadLevel ("SaveScore");
		// ゲームオーバー時に、タイトルを表示する
	}
	
	public bool IsPlaying ()
	{
		// ゲーム中かどうかはタイトルの表示/非表示で判断する
		return title.activeSelf == false;
	}

	public void tapStart(){
		GameStart (false);
	}

	public void leaderBoardButtonDown(){
		Application.LoadLevel("LeaderBoard");
	}

	public void ghostButtonDown(){
		GameStart (true);
	}
}