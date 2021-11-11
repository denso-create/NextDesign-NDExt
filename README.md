# NDExt 
Next Designのエクステンションの開発を支援するコマンドラインツールです。


> **Notice:**
> 本ツールはNext Design V2が対象のプレビュー公開です。
> Next Design V1.Xでは利用できません。

- [Website](#website)
- [インストール方法](#インストール方法)
- [利用方法](#利用方法)
- [リリースノート](#リリースノート)
- [パッケージの公開方法](#パッケージの公開方法)
  - [ローカル環境からの公開](#ローカル環境からの公開)
  - [Github Actionsによる公開](#github-actionsによる公開)
- [Website](#website-1)
- [参照](#参照)

## Website
https://denso-create.github.io/NextDesign-NDExt/


## インストール方法
* Next Designのエクステンション開発支援コマンドラインツールをグローバルツールとして[nuget.orgに公開](https://www.nuget.org/packages/NDExt/)しています。
* コマンドプロンプトから次のように実行してインストールします。
```
> dotnet tool install --global NDExt 
```

* なお、このプログラムを動作させるには [.NET Core 3.1のSdk](https://dotnet.microsoft.com/download/dotnet/3.1)のインストールが必要です。
  

## 利用方法

* 利用方法の詳細は[こちらのWebsite](https://denso-create.github.io/NextDesign-NDExt/)を参照して下さい。


## リリースノート
* 各バージョンごとの変更点は[リリースノート](https://denso-create.github.io/NextDesign-NDExt/releasenote)を参照して下さい。


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


## Website
静的サイトジェネレータ[Docusaurus](https://docusaurus.io/)を用いています。
`gh-pages`ブランチにビルドした結果をプッシュするには、 [こちらの記事](https://docusaurus.io/docs/deployment#deploy)を参照して下さい。

1. 事前準備
   * `website`の下が https://denso-create.github.io/NextDesign-NDExt の`docusaurus` の環境です。[websiteフォルダのreadme.md](website/README.md)を参照して下さい。
   * 環境変数で `GIT_USER` で本リポジトリに自身のユーザ名を設定してください（本リポジトリへの書き込み権限が必要です）。

2. 公開方法
   * ローカルの環境で以下を実行することで`gh-pages`ブランチに公開できます。

  ```
  publish-website.cmd
  ```

## 参照
* プロジェクトテンプレート
  * インストール・作成するプロジェクトテンプレートは `NextDesign.Extension.ProjectTemplates` のプロジェクトテンプレートを用いています。
  * [Githubリポジトリ](https://github.com/denso-create/NextDesign-Extension-ProjectTemplates)
  * [Nuget.org](https://www.nuget.org/packages/NextDesign.Extension.ProjectTemplates/)
*  関連パッケージもnuget.orgにて[プレビュー公開](https://www.nuget.org/profiles/densocreate)しています。


