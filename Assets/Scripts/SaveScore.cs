using NCMB; //mobile backendのSDKを読み込む
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// 【mBaaS】データの保存
public class SaveScore : MonoBehaviour {
	// **********【問題１】名前とスコアを保存しよう！**********
	public void save( string name, int score ) {
		NCMBObject obj = new NCMBObject ("GameScore");
		obj ["name"] = name;//オブジェクトに名前とスコアを設定
		obj ["score"] = score;
		/* ゴースト機能 */
//		obj ["Log"] = Player.posList;
		obj.SaveAsync ();
	}
	// **************************************************
}
