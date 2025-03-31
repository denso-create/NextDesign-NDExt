# NDExt 
Next Designのエクステンションの開発を支援するコマンドラインツールです。

- [必要環境](#必要環境)
- [インストール方法](#インストール方法)
- [利用方法](#利用方法)
- [リリースノート](#リリースノート)
- [パッケージの公開方法](#パッケージの公開方法)
  - [ローカル環境からの公開](#ローカル環境からの公開)
  - [Github Actionsによる公開](#github-actionsによる公開)
- [参照](#参照)
- [ライセンス](#ライセンス)

> **Notice:**
> 本ツールはNext Design V2以降を対象としています。
> Next Design V1.Xでは利用できません。

## 必要環境
* このプログラムを動作させるには [.NET8のSdk](https://dotnet.microsoft.com/ja-jp/download/dotnet/8.0)およびnuget.exeのインストールが必要です。
* nuget.exe は[公式サイト](https://www.nuget.org/downloads)からダウンロードし、適切なフォルダーに保存して、そのフォルダーを PATH 環境変数に追加してください（パスの設定が通っていないと正しく動作しません）。

## インストール方法
Next Designのエクステンション開発支援コマンドラインツールをグローバルツールとして[nuget.orgに公開](https://www.nuget.org/packages/NDExt/)しています。コマンドプロンプトから次のように実行してインストールします。
```
> dotnet tool install --global NDExt 
```  

## 利用方法
Next Design のエクステンション開発を支援するコマンドラインツールです。次のような操作が簡単になります。

* エクステンション開発プロジェクトの作成
* Visual Studioでのプロジェクトテンプレートの登録
* エクステンションのパッケージ化

利用できるコマンドは下記を実行して確認して下さい。

```
NDExt:
  Next Designのエクステンションを作成できるユーティリティです。

Usage:
  NDExt [options] [command]

Options:
  --version    Display version information

Commands:
  install            プロジェクトのテンプレートをインストールします。最初に実行して下さい。
  new <name>         現在のフォルダにNext Designのエクステンションのプロジェクトを作成します。
  new-extp <name>    現在のフォルダにExtensionPointsライブラリを用いたエクステンションのプロジェクトを作成します。
  pack               エクステンションをパッケージ化します。
  uninstall          プロジェクトのテンプレートをアンインストールします。
```

詳しくは[NDExtのドキュメント](https://docs.nextdesign.app/extension/docs/tools/ndext/intro)を参照して下さい。


## リリースノート
* 各バージョンごとの変更点は[リリースノート](https://docs.nextdesign.app/extension/docs/tools/ndext/releasenote)を参照して下さい。


## パッケージの公開方法
nuget.orgへの公開方法を説明します。

### ローカル環境からの公開

> 原則、Github Actinsによる公開をして下さい。

1. 事前準備
   * nuget.orgで `densocreate`の組織に所属するアカウントを登録して下さい。
   * 環境変数 `NUGET_APIKEY` をセットして下さい。

2. 公開方法
   * `publish.cmd`を実行して下さい。

上記方法で公開できない場合は以下手順で公開します。
1. [nuget.org](https://www.nuget.org/)にアクセスし、サインインする
2. [Upload]タブを開く
3. [Browse...]ボタンを押下し、アップロードするnugetパッケージを選択し、アップロードする

### Github Actionsによる公開
* `publish`ブランチにマージすると自動的に https://www.nuget.org/packages/NDExt に公開されます。
  * `main`ブランチから`publish`ブランチにマージするためのプルリクを作成し、管理者にApproveしてもらったのちにマージする。
* [publish to nugetアクション](https://github.com/denso-create/NextDesign-NDExt/actions/workflows/publish.yml)で実行しています。

## 参照
* プロジェクトテンプレート
  * インストール・作成するプロジェクトテンプレートは `NextDesign.Extension.ProjectTemplates` のプロジェクトテンプレートを用いています。
  * [Githubリポジトリ](https://github.com/denso-create/NextDesign-Extension-ProjectTemplates)
  * [Nuget.org](https://www.nuget.org/packages/NextDesign.Extension.ProjectTemplates/)
*  関連パッケージもnuget.orgにて[公開](https://www.nuget.org/profiles/densocreate)しています。


## ライセンス
本ライブラリはMITライセンスです。詳細は[LICENSE](./LICENSE) を確認してください。
