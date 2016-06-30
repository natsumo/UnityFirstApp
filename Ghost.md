# 【おまけ】ゴースト機能を実装しよう！

## ゴースト機能概要
保存されたデータの中で最もスコアの高いときの動きをゴーストとして表示できる機能です

![ghost](/readme-img/gost.png)

## 作業手順

* 【問題１】でデータの保存を行った場所を以下のように編集します

```cs
// **********【問題１】名前とスコアを保存しよう！**********
NCMBObject obj = new NCMBObject ("GameScore");
obj ["name"] = name;//オブジェクトに名前とスコアを設定
obj ["score"] = score;
/* ゴースト */
obj ["Log"] = Player.posList; // 追記
obj.SaveAsync ((NCMBException e) => { //この処理でサーバーに書き込む
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

* 「`Scripts`」＞「`Manager.cs`」の「`Update()`」メソッド内のコメントアウトを外します
 * 下図の３行です。

![ghost1](/readme-img/gost1.png)


## 動作確認
実行すると
