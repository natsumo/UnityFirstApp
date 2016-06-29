## 【問題２】答え合わせ

### ランキング画面の確認

* ランキング画面を確認しましょう
 * 「LeaderBoard」(ランキングを見る)ボタンをタップすると以下のようにランキングが表示されます。

![ans2-1](/readme-img/ans2-1.png)

* 上図はランキングが表示されることを確認しましょう！

### コードの答え合わせ

* 模範解答は以下です

```csharp
// **********【問題２】ランキングを表示しよう！**********
// GameScoreクラスを検索するクエリを作成
NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("GameScore");
// Scoreを降順でデータを取得するように設定
query.OrderByDescending ("score");
// 検索件数を設定
query.Limit = 5;
// データストアを検索
query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
	if (e != null) {
		//検索に失敗した場合の処理
		Debug.Log("検索に失敗しました。エラーコード：" + e.ErrorCode);
	} else {
		//検索に成功した場合の処理
		Debug.Log("検索に成功しました。");
		// 取得したデータをリストに設定
		List<NCMB.Rankers> list = new List<NCMB.Rankers>();
		foreach (NCMBObject obj in objList) {
			int    s = System.Convert.ToInt32(obj["score"]);
			string n = System.Convert.ToString(obj["name"]);
			list.Add( new Rankers( s, n ) );
		}
		topRankers = list;
	}
// **************************************************
```
