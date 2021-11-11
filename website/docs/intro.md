---
sidebar_position: 100
id: intro
slug: /
---

# 概要

Next Designのエクステンションを開発するコマンドラインツールです。次のような操作が簡単になります。

* エクステンション開発プロジェクトの作成
* Visual Studioでのプロジェクトテンプレートの登録
* エクステンションのパッケージ化

## インストール
NDExtを利用するには、まず [インストール](installation) を行って下さい。


## コマンドの概要

コマンドプロンプトから実行します。利用できるコマンドは下記を実行して確認して下さい。

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

  

