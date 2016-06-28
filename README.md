# 【Unity問題集】『オンラインランキング機能を作ってみよう！「シューティングゲーム」』

![RendaGame](/readme-img/RendaGame.png)

## コンテンツ概要

* [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)の機能『データストア』を学習するための問題集です
* [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)の利用登録（無料）が必要です。
* 問題用プロジェクトにはオンラインランキング機能が実装されていない状態の「連打ゲーム」です
* 既に実装済みの[ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)を利用するための準備（SDK導入など）方法の詳細は[こちら](http://mb.cloud.nifty.com/doc/current/introduction/quickstart_ios.html)をご覧ください。

## 問題について

* 問題は２問あります
* ２問クリアすると「連打ゲーム」にオンラインランキング機能を実装したアプリが完成します
* 問題を取り組む上で必要な開発環境は以下です
* Mac OS X 10.10(Yosemite)以上
* Xcode ver.7 以上

## 問題に取り組む前の準備

### プロジェクトのダウンロード

▼問題用プロジェクト▼

[__「連打ゲーム」__](https://github.com/natsumo/UnityFirstApp/archive/master.zip)

1. 上記リンクをクリックしてzipファイルをローカルに保存します
1. zipファイルを解凍して、`SwiftFirstApp.xcworkspace`をダブルクリックしてXcodeでプロジェクトを開きます
1. アプリを実行し、「連打ゲーム」で遊んでみましょう

#### 「連打ゲーム」の操作方法

1. 「Start」ボタンをタップします
2. 「3」,「2」,「1」とカウントダウンし、「スタート！」から「タイムアップ！」の10秒間「◎」の部分がタップできるようになります
3. 10秒間の間に何回タップできるかを競う単純なゲームです
4. 10秒経つと名前を入力するアラートが表示されますので、入力し「OK」をクリックします
5. 画面に名前とスコアが表示されます

※__注意__：問題に取り組む前の状態では「ランキングを見る」ボタンをタップしてもランキングは表示されません

### アプリの新規作成とAPIキーの設定

![mBaaS](/readme-img/mBaaS.png)

*  [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)にログインしアプリの新規作成を行います
* アプリ名はわかりやすいものにしましょう。例）「renda」
* アプリが作成されるとAPIキーが２種類（アプリケーションキーとクライアントキー）発行されます
* 次で使用します。

![Unity](/readme-img/Unity.png)

* `AppDelegate.swift`を編集します
* 先程[ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)のダッシュボード上で確認したAPIキーを貼り付けます

![問題0-1](/readme-img/0-1.png)

* それぞれ`YOUR_NCMB_APPLICATION_KEY`と`YOUR_NCMB_CLIENT_KEY`の部分を書き換えます
* このとき、ダブルクォーテーション（`"`）を消さないように注意してください！

## __【問題１】__：名前とスコアの保存をしてみよう！
`GameViewController.swift`を開きます。下図の__`saveScore`__メソッドを編集し、引数の__`name`__（アラートで入力した名前）と__`score`__（連打ゲームでタップした回数）の値をmBaaSに保存する処理をコーディングしてください

![問題1-1](/readme-img/1-1.png)

* データストアに保存先クラスを作成します
* クラス名は「`GameScore`」としてください
* `name`を保存するフィールドを「`name`」、`score`を保存するフィールドを「`score`」として保存してください

### ヒント
* [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)のiOSドキュメントはObjective-Cで書かれていますので、Swiftに書き換えたものを用意しました
* [Swiftでデータベースを使おう！①（保存・取得・更新・削除）](http://qiita.com/natsumo/items/c00cf7a48e0f8cd8d236)

### コーディング後の作業
問題１のコーディングが完了したら、下記の作業を行います

__【作業1-1】__それぞれ該当する箇所に以下の処理を追記して、実行時にXcode上にログを表示できるようにします

* 保存に失敗した場合の処理を行う箇所に追記

```swift
// 保存に失敗した場合の処理
print("エラーが発生しました。エラーコード:\(error.code)")
```

* 保存に成功した場合の処理を行う箇所に追記

```swift
// 保存に成功した場合の処理
print("保存に成功しました。objectId:\(obj.objectId)")
```

__【作業1-2】__シュミレーターで実行、「Start」ボタンを押してゲームを遊びます

* 名前を入力し、「OK」がクリックされると【問題１】で作成した`saveScore`メソッドが呼ばれ、データが保存されます
* このとき下記のいずれかのログが出力されます

* 「`保存に成功しました。objectId:************`」の場合は保存成功です
* 「`エラーが発生しました。エラーコード:************`」の場合は保存失敗です

※エラーコードが出た場合は[こちら](http://mb.cloud.nifty.com/doc/current/rest/common/error.html#REST%20API%E3%81%AE%E3%82%A8%E3%83%A9%E3%83%BC%E3%82%B3%E3%83%BC%E3%83%89%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6)で確認できます

### 答え合わせ

▼答えはこちら▼

[__【問題１】解答__](https://github.com/natsumo/UnityFirstApp/blob/AnswerProject/Answer1.md)


## __【問題２】__：ランキングを表示しよう！
`RankingViewController.swift`を開きます。下図の`checkRanking`メソッドを編集し、データストアの`GameScore`クラスに保存した`name`と`score`のデータを`score`の降順（スコアの高い順）で検索・取得する処理をコーディングしてください

![問題2-1](/readme-img/2-1.png)

* 検索データ件数は５件とします
* ただし、この値は「`rankingNumber`」としてフィールドに設定しているため、「`5`」の代わりに「`Int32(rankingNumber)`」を使用して設定してください

### ヒント
* [ニフティクラウドmobile backend](http://mb.cloud.nifty.com/)のiOSドキュメントはObjective-Cで書かれていますので、Swiftに書き換えたものを用意しました
* [Swiftでデータベースを使おう！③（ランキングを作る・アクセス権限）](http://qiita.com/natsumo/items/25074fa1ce209033e98e)

### コーディング後の作業
問題２のコーディングが完了したら、下記の作業を行います

__【作業2-1】__該当する箇所に以下の処理を追記して、実行時にXcode上にログを表示できるようにします

* 検索に失敗した場合の処理を行う箇所に追記

```swift
// 検索に失敗した場合の処理
print("検索に失敗しました。エラーコード:\(error.code)")
```

* 検索に成功した場合の処理を行う箇所に追記

```swift
// 検索に成功した場合の処理
print("検索に成功しました。")
```

__【作業2-2】__シュミレーターで実行し、「ランキングを見る」ボタンをタップします
* 画面起動後、`checkRanking`メソッドが呼ばれ、【問題１】で保存されたデータが検索・取得されます
* このとき下記のいずれかのログが出力されます

* 「`検索に成功しました。`」が表示された場合は検索成功です
* 「`検索に失敗しました。エラーコード:************`」が表示された場合は検索失敗です

※エラーコードが出た場合は[こちら](http://mb.cloud.nifty.com/doc/current/rest/common/error.html#REST%20API%E3%81%AE%E3%82%A8%E3%83%A9%E3%83%BC%E3%82%B3%E3%83%BC%E3%83%89%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6)で確認できます

* 検索の状態（成功・失敗）に関係なく、「ランキングを見る」ボタンをタップしても、まだランキングは表示されません

__【作業2-3】__検索に成功したら、該当する箇所に以下の処理を追記して、取得した値から必要なデータを取り出し、ランキング画面へ反映させます

* 検索に成功した場合の処理を行う箇所に追記

```swift
// 取得したデータを格納
self.rankingArray = objects as! Array
// テーブルビューをリロード
self.rankingTableView.reloadData()
```

__【作業2-4】__シュミレーターで実行、「ランキングを見る」ボタンを押します

* 先ほどのスコアが表示されれば完成です！おめでとうございます★

### 答え合わせ

▼答えはこちら▼

[__【問題２】解答__](https://github.com/natsumo/UnityFirstApp/blob/AnswerProject/Answer2.md)

## 参考

* 問題の回答を実装した完全なプロジェクトをご用意しています

▼完成版プロジェクト▼

[__「【完成版】連打ゲーム」__](https://github.com/natsumo/UnityFirstApp/archive/AnswerProject.zip)

* APIキーを設定してご利用ください
