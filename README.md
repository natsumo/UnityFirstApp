# 【Unity問題集】『オンラインランキング機能を作ってみよう！「シューティングゲーム」』

![RendaGame](/readme-img/RendaGame.png)

## コンテンツ概要

* [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)の機能『データストア』を学習するための問題集です。
* [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)の利用登録（無料）が必要です。
* 問題用プロジェクトにはオンラインランキング機能が実装されていない状態の「シューティングゲーム」です。
* 既に実装済みの[ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)を利用するための準備（SDK導入など）方法の詳細は[こちら](http://mb.cloud.nifty.com/doc/current/introduction/quickstart_unity.html)をご覧ください。

## 問題について

* 問題は２問あります
* ２問クリアすると「シューティングゲーム」にオンラインランキング機能を実装したアプリが完成します。
* 問題を取り組む上で必要な開発環境は以下です。
   - Unity 3Dが動作するWindows PC もしくはMac PC
   - Unity5.3以降のインストーラ（無料です）

## 問題に取り組む前の準備

### プロジェクトのダウンロード

▼問題用プロジェクト▼

[__「シューティングゲーム」__](https://github.com/natsumo/UnityFirstApp/archive/master.zip)

1. 上記リンクをクリックしてzipファイルをローカルに保存し、zipファイルを解凍します。
2. Unityエディタを起動します。
3. プロジェクトダイアログが表示されると、既存プロジェクトをインポートするので右上の「OPEN」を選択します。
4. zipファイルを解凍した場所のフォルダーを選択します。
5. しばらくするとインポートが終了し、Unityプロジェクトが開きます。
6. Unityから「再生」をクリックすると、【ゲーム(Game)ビュー】でゲームがプレイ出来ます。

#### 「シューティングゲーム」の操作方法

1. 【ゲーム(Game)ビュー】から初期画面(Tap To Start)をタッチします。
2. 矢印で方向を変えながら、弾丸やレーザーなどの飛び道具を利用して敵機を撃ち落とす、単純なゲームです。
3. GameOverになるとゲームプレイヤーの名前を入力するアラートが表示されますので、名前を入力し「Submit」をクリックします。
4. ゲームプレイヤーの名前とスコアが保存され、初期画面に戻ります。

※__注意__：問題に取り組む前の状態では「LeaderBoard」(ランキングを見る)ボタンをタップしてもランキングは表示されません。

### アプリの新規作成とAPIキーの設定

![mBaaS](/readme-img/mBaaS.png)

*  [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)にログインしアプリの新規作成を行います。
* アプリ名はわかりやすいものにしましょう。例）「UnityShootGame」
* アプリが作成されるとAPIキーが２種類（アプリケーションキーとクライアントキー）発行されます。
* 次で使用します。

![Unity](/readme-img/Unity.png)

* 【ヒエラルキー(Hierarchy)ビュー】から`NCMBSettings`を編集します。
* 先程[ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)のダッシュボード上で確認したAPIキーを入力します。

![問題0-1](/readme-img/0-1.png)

* 【インスペクター(Inspector)ビュー】から「NCMB Settings」欄のApplication KeyとClient Keyの入力部分に各APIキーを入力します。

## __【問題１】__：名前とスコアの保存をしてみよう！
`/Assets/Scripts/saveScore.cs`を開きます。下図の__`saveScore`__メソッドを編集し、引数の__`name`__（アラートで入力した名前）と__`score`__（シューティングゲームのスコア）の値をmBaaSに保存する処理をコーディングしてください。

![問題1-1](/readme-img/1-1.png)

* データストアに保存先クラスを作成します。
* クラス名は「`GameScore`」としてください。
* `name`を保存するフィールドを「`name`」、`score`を保存するフィールドを「`score`」として保存してください。

### ヒント
* [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)のUnityドキュメントをご参考ください。
 * [データストア（Unity）基本的な使い方](http://mb.cloud.nifty.com/doc/current/datastore/basic_usage_unity.html)

### コーディング後の作業
問題１のコーディングが完了したら、下記の作業を行います。

__【作業1-1】__それぞれ該当する箇所に以下の処理を追記して、再生時にUnity Console上にログを表示できるようにします。

* 保存に失敗した場合の処理を行う箇所に追記

```csharp
// 保存に失敗した場合の処理
Debug.Log("保存に失敗しました。エラーコード:"+e.ErrorCode);
```

* 保存に成功した場合の処理を行う箇所に追記

```csharp
// 保存に成功した場合の処理
Debug.Log("保存に成功しました。objectId:"+ obj.ObjectId);
```

__【作業1-2】__ Unityから「再生」をクリックすると、【ゲーム(Game)ビュー】でゲームがプレイ出来ます。

* 名前を入力し、「OK」がクリックされると【問題１】で作成した`saveScore`メソッドが呼ばれ、データが保存されます。
* このとき下記のいずれかのログが出力されます。

* 「`保存に成功しました。objectId:************`」の場合は保存成功です
* 「`保存に失敗しました。エラーコード:************`」の場合は保存失敗です

※エラーコードが出た場合は[こちら](http://mb.cloud.nifty.com/doc/current/rest/common/error.html#REST%20API%E3%81%AE%E3%82%A8%E3%83%A9%E3%83%BC%E3%82%B3%E3%83%BC%E3%83%89%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6)で確認できます。

### 答え合わせ

▼答えはこちら▼

[__【問題１】解答__](https://github.com/natsumo/UnityFirstApp/blob/AnswerProject/Answer1.md)


## __【問題２】__：ランキングを表示しよう！
`/Assets/Scripts/LeaderBoard.cs`を開きます。下図の`fetchTopRankers`メソッドを編集し、データストアの`GameScore`クラスに保存した`name`と`score`のデータを`score`の降順（スコアの高い順）で検索・取得する処理をコーディングしてください。

![問題2-1](/readme-img/2-1.png)

* 検索データ件数は５件とします。

### ヒント
* [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)のUnityドキュメントをご参考ください。
 * [データストア（Unity）ランキングを作る](http://mb.cloud.nifty.com/doc/current/datastore/ranking_unity.html)

### コーディング後の作業
問題２のコーディングが完了したら、下記の作業を行います。

__【作業2-1】__該当する箇所に以下の処理を追記して、再生時にUnity Console上にログを表示できるようにします。

* 検索に失敗した場合の処理を行う箇所に追記

```csharp
// 検索に失敗した場合の処理
Debug.Log("検索に失敗しました。エラーコード:"+e.ErrorCode);
```

* 検索に成功した場合の処理を行う箇所に追記

```csharp
// 検索に成功した場合の処理
Debug.Log("検索に成功しました。")
```

__【作業2-2】__ Unityから「再生」し、「LeaderBoard」(ランキングを見る)ボタンをタップします。
* 画面起動後、`fetchTopRankers`メソッドが呼ばれ、【問題１】で保存されたデータが検索・取得されます。
* このとき下記のいずれかのログが出力されます。

* 「`検索に成功しました。`」が表示された場合は検索成功です
* 「`検索に失敗しました。エラーコード:************`」が表示された場合は検索失敗です

※エラーコードが出た場合は[こちら](http://mb.cloud.nifty.com/doc/current/rest/common/error.html#REST%20API%E3%81%AE%E3%82%A8%E3%83%A9%E3%83%BC%E3%82%B3%E3%83%BC%E3%83%89%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6)で確認できます。

* 検索の状態（成功・失敗）に関係なく、「LeaderBoard」(ランキングを見る)ボタンをタップしても、まだランキングは表示されません。

__【作業2-3】__検索に成功したら、該当する箇所に以下の処理を追記して、取得した値から必要なデータを取り出し、ランキング画面へ反映させます。

* 検索に成功した場合の処理を行う箇所に追記

```csharp
//検索成功時の処理
Debug.Log("検索に成功しました。");

List<NCMB.Rankers> list = new List<NCMB.Rankers>();
// 取得したレコードをscoreクラスとして保存
foreach (NCMBObject obj in objList) {
	int    s = System.Convert.ToInt32(obj["score"]);
	string n = System.Convert.ToString(obj["name"]);
	list.Add( new Rankers( s, n ) );
}
topRankers = list;
```

__【作業2-4】__ Unityから「再生」し、「LeaderBoard」(ランキングを見る)ボタンをタップします。

* 先ほどのスコアが表示されれば完成です！おめでとうございます★

### 答え合わせ

▼答えはこちら▼

[__【問題２】解答__](https://github.com/natsumo/UnityFirstApp/blob/AnswerProject/Answer2.md)

## 参考

* 問題の回答を実装した完全なプロジェクトをご用意しています

▼完成版プロジェクト▼

[__「【完成版】シューティングゲーム」__](https://github.com/natsumo/UnityFirstApp/archive/AnswerProject.zip)

* APIキーを設定してご利用ください
