# Next Design Extension Utility Tool
Next Designのエクステンションを開発するツールです。

## インストール方法
* 事前条件：このプログラムを動作させるには [.NET Core 3.1のSdk](https://dotnet.microsoft.com/download/dotnet/3.1)のインストールが必要です。

* Next Designのエクステンション開発支援コマンドラインツールをグローバルツールとして[nuget.orgに公開](https://www.nuget.org/packages/NDExt/)しています。
 * コマンドプロンプトから次のように実行してインストールします。
  
```
> dotnet tool install --global NDExt 
```

* インストール後は下記のコマンドを実行しておきます。
```
> ndext install
```

## 利用方法
コマンドプロンプトから実行します。利用できるコマンドは下記を実行して確認して下さい。

```
> ndext --help
```

* 次のように確認できます。
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

* Next Designのエクステンションの .NET Core プロジェクトをカレントディレクトリに作成します。
```
> ndext new Ext1
```

* [NextDesign.Desktop.ExtensionPoints](https://www.nuget.org/packages/NextDesign.Desktop.ExtensionPoints/)を利用したエクステンションのプロジェクトをカレントディレクトリに作成します。
```
> ndext new-extp Ext2
```

* エクステンションをパッケージ化するには次のように実行します。

```
> ndext pack -c Release -v 2.0.0 
```
