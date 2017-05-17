# 【おまけ】ゴースト機能を実装しよう！
## ゴースト機能概要
名前とスコアに加えて、操作ログを保存します。保存されたスコアの中で最も高い操作ログをゴーストとして表示します。

![ghost0](/readme-img/ghost0.png)

## 作業手順

![mBaaS](/readme-img/mBaaS.png)

* 今まで遊んだデータを一度削除します
* データすべてにチェックを入れると削除ボタンが活性化されますので、クリックすると消去されます

![ans2-1](/readme-img/ans2-1.png)

![Unity](/readme-img/Unity.png)

* 【問題１】でデータの保存を行った場所（「SaveScore.cs」ファイル）を以下のように編集します

```cs
// **********【問題１】名前とスコアを保存しよう！**********
// 保存先クラスを作成
NCMBObject obj = new NCMBObject ("GameScore");
// 値を設定
obj ["name"] = name;
obj ["score"] = score;
/* ゴースト */
obj ["Log"] = Player.posList; // ←追記
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
```

※追加は「`obj ["Log"] = Player.posList;`」の部分です。

![Unity](/readme-img/Unity.png)

* 「`Scripts`」＞「`Manager.cs`」ファイルを編集します
* 「`Update()`」メソッド内のコメントアウトを外します

![ghost1](/readme-img/ghost1.png)

※ 上図の３行の「`//`」を外してください。

## 動作確認

![Unity](/readme-img/Unity.png)

* 再生ボタンをクリックして、ゲームを始めます
* まずは普通に１回遊んで、スコアを保存してください
* １度遊ぶと「スタート画面」に「Ghost」ボタンが表示されます
 * このボタンをクリックするとゴースト機能を使用して遊ぶことができます。

![mBaaS](/readme-img/mBaaS.png)

* 操作ログは下図のように保存されます

![ghost2](/readme-img/ghost2.png)
