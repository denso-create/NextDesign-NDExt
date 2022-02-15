# NDExt 
Next Designのエクステンションの開発を支援するコマンドラインツールです。

- [インストール方法](#インストール方法)
- [利用方法](#利用方法)
- [リリースノート](#リリースノート)
- [パッケージの公開方法](#パッケージの公開方法)
  - [ローカル環境からの公開](#ローカル環境からの公開)
  - [Github Actionsによる公開](#github-actionsによる公開)
- [参照](#参照)
- [ライセンス](#ライセンス)

> **Notice:**
> 本ツールはNext Design V2が対象としています。
> Next Design V1.Xでは利用できません。


## インストール方法
* Next Designのエクステンション開発支援コマンドラインツールをグローバルツールとして[nuget.orgに公開](https://www.nuget.org/packages/NDExt/)しています。
* コマンドプロンプトから次のように実行してインストールします。
```
> dotnet tool install --global NDExt 
```

* なお、このプログラムを動作させるには [.NET Core 3.1のSdk](https://dotnet.microsoft.com/download/dotnet/3.1)のインストールが必要です。
  

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

1. 事前準備
   * nuget.orgで `densocreate`の組織に所属するアカウントを登録して下さい。
   * 環境変数 `NUGET_APIKEY` をセットして下さい。

2. 公開方法
   * `publish.cmd`を実行して下さい。

### Github Actionsによる公開
* [publish to nugetアクション](https://github.com/denso-create/NextDesign-NDExt/actions/workflows/publish.yml)を用いて下さい。


## 参照
* プロジェクトテンプレート
  * インストール・作成するプロジェクトテンプレートは `NextDesign.Extension.ProjectTemplates` のプロジェクトテンプレートを用いています。
  * [Githubリポジトリ](https://github.com/denso-create/NextDesign-Extension-ProjectTemplates)
  * [Nuget.org](https://www.nuget.org/packages/NextDesign.Extension.ProjectTemplates/)
*  関連パッケージもnuget.orgにて[公開](https://www.nuget.org/profiles/densocreate)しています。


## ライセンス
本ライブラリはMITライセンスです。詳細は[LICENSE](./LICENSE) を確認してください。
