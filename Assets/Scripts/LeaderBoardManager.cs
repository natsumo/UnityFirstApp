using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class LeaderBoardManager : MonoBehaviour {
	
	private LeaderBoard lBoard;
	public Text[] top = new Text[5];

	bool isRankFetched;
	bool isLeaderBoardFetched;
	
	// ボタンが押されると対応する変数がtrueになる
	private bool backButton;
	
	void Start ()
	{
		lBoard = new LeaderBoard();
		
		// フラグ初期化
		isRankFetched  = false;
		isLeaderBoardFetched = false;

	}
	
	void Update()
	{
		// 現在の順位の取得が完了したら1度だけ実行
		if( !isRankFetched ){
			lBoard.fetchTopRankers();
			isRankFetched = true;
		}
		
		// ランキングの取得が完了したら1度だけ実行
		if( lBoard.topRankers != null && !isLeaderBoardFetched){ 
			
			// 取得したトップ5ランキングを表示
			for( int i = 0; i < lBoard.topRankers.Count; ++i) {
				top[i].text = i+1 + ". " + lBoard.topRankers[i].print();
			}

			isLeaderBoardFetched = true;
		}
	}

	public void BackButton(){
		Application.LoadLevel("Stage");
	} 
}
