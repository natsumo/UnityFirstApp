using NCMB; //mobile backendのSDKを読み込む
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// 【mBaaS】データの保存
public class SaveScore : MonoBehaviour {
	public void save( string name, int score ) {
		// **********【問題１】名前とスコアを保存しよう！**********
		// 保存先クラスを作成
		NCMBObject obj = new NCMBObject ("GameScore");
		// 値を設定
		obj ["name"] = name;
		obj ["score"] = score;
		// 保存を実施
		obj.SaveAsync ((NCMBException e) => {
			if (e != null)
			{
				// 保存に失敗した場合の処理
				Debug.Log("保存に失敗しました。エラーコード:"+e.ErrorCode);
			}
			else
			{
				// 保存に成功した場合の処理
				Debug.Log("保存に成功しました。objectId:"+ obj.ObjectId);
			}
		});
		// **************************************************
	}
}
