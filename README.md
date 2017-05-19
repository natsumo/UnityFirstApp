# 【Unity問題集】<br>オンラインランキング機能を作ってみよう！<br>「シューティングゲーム」
_2017/05/17作成 (2017/05/19修正)_

![RendaGame](/readme-img/RendaGame.png)

GitHub<br>
**https://goo.gl/H3Gxbi**

<div style="page-break-before:always"></div>

## コンテンツ概要

* ニフティクラウド mobile backend の機能『データストア』を学習するための問題集です
* ニフティクラウド mobile backend の利用登録（無料）が必要です
* 問題用プロジェクトにはオンラインランキング機能が実装されていない状態の「シューティングゲーム」です
* 既に実装済みのニフティクラウド mobile backend を利用するための準備（SDK導入など）方法の詳細はこちらをご覧ください<br>http://mb.cloud.nifty.com/doc/current/introduction/quickstart_unity.html

## 問題について

* 問題は２問あります
* ２問クリアすると「シューティングゲーム」にオンラインランキング機能を実装したアプリが完成します
* 問題を取り組む上で必要な開発環境は以下です
   - Unity 3Dが動作するWindows PC もしくはMac PC
   - Unity5.3以降

<div style="page-break-before:always"></div>

## 問題に取り組む前の準備
### プロジェクトのダウンロード

▼問題用プロジェクト▼<br>**https://github.com/natsumo/UnityFirstApp/archive/Question.zip**

1. 上記リンクからzipファイル取得します
1. ローカルに保存し、解凍します

#### 「シューティングゲーム」の操作方法

1. 【ゲーム(Game)ビュー】から初期画面(Tap To Start)をタッチします
2. 矢印で方向を変えながら、弾丸やレーザーなどの飛び道具を利用して敵機を撃ち落とす、単純なゲームです
3. GameOverになるとゲームプレイヤーの名前を入力するアラートが表示されますので、名前を入力し「Submit」をクリックします
4. ゲームプレイヤーの名前とスコアが保存され、初期画面に戻ります

※ __注意__：問題に取り組む前の状態では「LeaderBoard」(ランキングを見る)ボタンをタップしてもランキングは表示されません

<div style="page-break-before:always"></div>

### アプリの新規作成とAPIキーの設定

![mBaaS](/readme-img/mBaaS.png)

*  ニフティクラウド mobile backend にログインしアプリの新規作成を行います
* アプリ名はわかりやすいものにしましょう　例）「UnityShootGame」
* アプリが作成されるとAPIキーが２種類（アプリケーションキーとクライアントキー）発行されます
* 次で使用します

![Unity](/readme-img/Unity.png)

* 【ヒエラルキー(Hierarchy)ビュー】から`NCMBSettings`を編集します
* 先程ニフティクラウド mobile backend のダッシュボード上で確認したAPIキーを入力します

![問題0-1](/readme-img/0-1.png)

* 【インスペクター(Inspector)ビュー】から「NCMB Settings」欄のApplication KeyとClient Keyの入力部分に各APIキーを入力します

<div style="page-break-before:always"></div>

## 【問題１】<br>名前とスコアの保存をしてみよう！
`/Assets/Scripts/saveScore.cs`を開きます。下図の__`saveScore`__ メソッドを編集し、引数の__`name`__ （アラートで入力した名前）と__`score`__ （シューティングゲームのスコア）の値をニフティクラウド mobile backend に保存する処理をコーディングしてください。

![問題1-1](/readme-img/1-1.png)

* データストアに保存先クラスを作成します
* クラス名は「`GameScore`」としてください
* `name`を保存するフィールドを「`name`」、`score`を保存するフィールドを「`score`」として保存してください

### ヒント
* ニフティクラウド mobile backend のUnityドキュメントをご参考ください<br>http://mb.cloud.nifty.com/doc/current/datastore/basic_usage_unity.html

<div style="page-break-before:always"></div>

### コーディング後の作業
問題１のコーディングが完了したら、下記の作業を行います

#### 【作業1-1】
それぞれ該当する箇所に以下の処理を追記して、再生時にUnity Console上にログを表示できるようにします

* 保存に失敗した場合の処理を行う箇所に追記

 ![code1](/readme-img/code1.png)

* 保存に成功した場合の処理を行う箇所に追記

 ![code2](/readme-img/code2.png)

#### 【作業1-2】
「再生」をクリックし、ゲームをします

* ゲームオーバーになったら名前を入力し、「OK」がクリックされると【問題１】で作成した`saveScore`メソッドが呼ばれ、データが保存されます
* このとき下記のいずれかのログが出力されます
 * 保存成功時：「`保存に成功しました。objectId:*********`」
 * 保存失敗時：「`保存に失敗しました。エラーコード:******`」

※ エラーコードが出た場合はこちらで確認できます<br>http://mb.cloud.nifty.com/doc/current/rest/common/error.html#REST_APIのエラーコードについて

<div style="page-break-before:always"></div>

### 【問題１】答え合わせ
#### ニフティクラウドmobile backend上での確認
![mBaaS](/readme-img/mBaaS.png)

* 保存されたデータを確認しましょう
 * 「データストア」をクリックすると、「`GameScore`」クラスにデータが登録されていることが確認できます。

 ![ans1-1](/readme-img/ans1-1.png)

<div style="page-break-before:always"></div>

#### コードの答え合わせ

* 模範解答は以下です

 ![Answer1](/readme-img/Answer1.png)

<div style="page-break-before:always"></div>

## 【問題２】<br>ランキングを表示しよう！
`/Assets/Scripts/LeaderBoard.cs`を開きます。下図の`fetchTopRankers`メソッドを編集し、データストアの`GameScore`クラスに保存した`name`と`score`のデータを`score`の降順（スコアの高い順）で検索・取得する処理をコーディングしてください。

![問題2-1](/readme-img/2-1.png)

* 検索データ件数は５件とします

### ヒント
* ニフティクラウド mobile backend のUnityドキュメントをご参考ください<br>http://mb.cloud.nifty.com/doc/current/datastore/ranking_unity.html

<div style="page-break-before:always"></div>

### コーディング後の作業
問題２のコーディングが完了したら、下記の作業を行います。

#### 【作業2-1】
該当する箇所に以下の処理を追記して、再生時にUnity Console上にログを表示できるようにします

* 検索に失敗した場合の処理を行う箇所に追記

 ![code3](/readme-img/code3.png)

* 検索に成功した場合の処理を行う箇所に追記

 ![code4](/readme-img/code4.png)

#### 【作業2-2】
Unityから「再生」し、「LeaderBoard」(ランキングを見る)ボタンをタップします
* 画面起動後、`fetchTopRankers`メソッドが呼ばれ、【問題１】で保存されたデータが検索・取得されます
* このとき下記のいずれかのログが出力されます
 * 検索成功時：「`検索に成功しました。`」
 * 検索失敗時：「`検索に失敗しました。エラーコード：******`」

※ エラーコードが出た場合はこちらで確認できます<br>http://mb.cloud.nifty.com/doc/current/rest/common/error.html#REST_APIのエラーコードについて

<div style="page-break-before:always"></div>

#### 【作業2-3】
検索に成功したら、該当する箇所に以下の処理を追記して、取得した値から必要なデータを取り出し、ランキング画面へ反映させます

* 検索に成功した場合の処理を行う箇所に追記

 ![code5](/readme-img/code5.png)

#### 【作業2-4】
Unityから「再生」し、「LeaderBoard」(ランキングを見る)ボタンをタップします

* 先ほどのスコアが表示されれば完成です！おめでとうございます★

<div style="page-break-before:always"></div>

### 【問題２】答え合わせ
#### ランキング画面の確認

* ランキング画面を確認しましょう
 * 「LeaderBoard」(ランキングを見る)ボタンをタップすると以下のようにランキングが表示されます。

 ![ans2-1](/readme-img/ans2-1.png)

* 上図はランキングが表示されることを確認しましょう！

<div style="page-break-before:always"></div>

#### コードの答え合わせ

* 模範解答は以下です

 ![Answer2](/readme-img/Answer2.png)

<div style="page-break-before:always"></div>

## 参考

* 問題の回答を実装した完全なプロジェクトをご用意しています

▼完成版プロジェクト▼<br>**https://github.com/natsumo/UnityFirstApp/archive/AnswerProject.zip**

* APIキーを設定してご利用ください

### おまけ

* ニフティクラウド mobile backend を使って、シューティングゲームに「__ゴースト機能__」を実装することができます！

 ![ghost0](/readme-img/ghost0.png)

* 興味がある方はこちらをご覧ください<br>https://github.com/natsumo/UnityFirstApp/blob/master/Ghost.md
