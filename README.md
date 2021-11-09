# Next Design Extension Utility Tool
Next Designのエクステンションを開発するツールです。

## インストール方法
* 事前条件：このプログラムを動作させるには [.NET Core 3.1のSdk](https://dotnet.microsoft.com/download/dotnet/3.1)のインストールが必要です。

* Next Designのエクステンション開発支援コマンドラインツールをグローバルツールとして[nuget.orgに公開](https://www.nuget.org/packages/NDExt/)しています。
 * コマンドプロンプトから次のように実行してインストールします。
  

## 利用方法
* [こちらのreadme](.\src\NDExt\docs\readme.md)を参照して下さい。

## リリースノート
* [こちらのリリースノート](releasenotes.md)を参照して下さい。


## nuget.orgへのパッケージの公開方法

### 事前準備
* nuget.orgで `densocreate`の組織に所属するアカウントを登録して下さい。
* 環境変数 `NUGET_APIKEY` をセットして下さい。

### 公開方法
* `publish.cmd`を実行して下さい。

## 関連パッケージ
関連パッケージもnuget.orgにて[プレビュー公開](https://www.nuget.org/profiles/densocreate)しています。

## TODO
* Visual Studioでのダイアログでの対応
  * テンプレートをNuget.orgにpublishしておく。
  * NDExtはそのパッケージをインストールするようにする。
    * https://github.com/dotnet/iot/issues/1173

