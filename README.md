# NDExt 
Next Designのエクステンションの開発を支援するコマンドラインツールです。

> **Notice:**
> 本ツールはNext Design V2が対象のプレビュー公開です。
> Next Design V1.Xでは利用できません。

- [インストール方法](#インストール方法)
- [利用方法](#利用方法)
- [リリースノート](#リリースノート)
- [パッケージの公開方法](#パッケージの公開方法)
  - [ローカル環境からの公開](#ローカル環境からの公開)
  - [Github Actionsによる公開](#github-actionsによる公開)
- [参照](#参照)

## インストール方法
* Next Designのエクステンション開発支援コマンドラインツールをグローバルツールとして[nuget.orgに公開](https://www.nuget.org/packages/NDExt/)しています。
* コマンドプロンプトから次のように実行してインストールします。
```
> dotnet tool install --global NDExt 
```

* なお、このプログラムを動作させるには [.NET Core 3.1のSdk](https://dotnet.microsoft.com/download/dotnet/3.1)のインストールが必要です。
  

## 利用方法
* 利用方法の詳細は[こちらのreadme](src/NDExt/docs/readme.md)を参照して下さい。

## リリースノート
* 各バージョンごとの変更点は[こちらのリリースノート](releasenotes.md)を参照して下さい。

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
*  関連パッケージもnuget.orgにて[プレビュー公開](https://www.nuget.org/profiles/densocreate)しています。


