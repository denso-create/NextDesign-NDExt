# Next Design Extension Utility Tool
Next Designのエクステンションを開発するツールです。

- [1. 必要環境](#1-必要環境)
- [2. インストール方法](#2-インストール方法)
- [3. 利用方法](#3-利用方法)
- [4. ドキュメント](#4-ドキュメント)

## 1. 必要環境
* このプログラムを動作させるには [.NET8のSdk](https://dotnet.microsoft.com/ja-jp/download/dotnet/8.0)およびnuget.exeのインストールが必要です。
* nuget.exe は[公式サイト](https://www.nuget.org/downloads)からダウンロードし、適切なフォルダーに保存して、そのフォルダーを PATH 環境変数に追加してください（パスの設定が通っていないと正しく動作しません）。

## 2. インストール方法
Next Designのエクステンション開発支援コマンドラインツールをグローバルツールとして[nuget.orgに公開](https://www.nuget.org/packages/NDExt/)しています。コマンドプロンプトから次のように実行してインストールします。

```
> dotnet tool install --global NDExt 
```

* インストール後は下記のコマンドを実行しておきます。
```
> ndext install
```

## 3. 利用方法
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
> ndext pack -c Release -v 3.0 
```

`pack`コマンドの実行に成功すると`ndpackages`フォルダにnupkgファイルが作成されます。

## 4. ドキュメント
詳しい利用方法は[NDExtのドキュメント](https://docs.nextdesign.app/extension/docs/tools/ndext/intro)を参照して下さい。

---

# Next Design Extension Utility Tool
This is a tool for developing extensions for Next Design.

- [1. Required environment](#1-required-environment)
- [2. How to install](#2-how-to-install)
- [3. How to use](#3-how-to-use)
- [4. Documentation](#4-documentation)

## 1. Required environment
* To run this program, you need to install [.NET8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) and nuget.exe.
* Download nuget.exe from the [official website](https://www.nuget.org/downloads), save it in an appropriate folder, and add that folder to the PATH environment variable (it will not work properly if the path is not set).

## 2. How to install
Next Design's extension development support command line tool is [published on nuget.org](https://www.nuget.org/packages/NDExt/) as a global tool. Run the following from the command prompt to install it.

```
> dotnet tool install --global NDExt
```

* After installation, run the following command.
```
> ndext install
```

## 3. How to use
Execute from the command prompt. Check the available commands by executing the following.

```
> ndext --help
```

* You can check as follows.
```
NDExt:
A utility that allows you to create Next Design extensions.

Usage:
NDExt [options] [command]

Options:
--version Display version information

Commands:
  install            Installs the project template. Run this first.
  new <name>         Creates a Next Design extension project in the current folder.
  new-extp <name>    Creates an extension project using the ExtensionPoints library in the current folder.
  pack               Packages the extension.
  uninstall          Uninstalls the project template.
```

* Creates a .NET Core project for the Next Design extension in the current directory.
```
> ndext new Ext1
```

* Create an extension project using [NextDesign.Desktop.ExtensionPoints](https://www.nuget.org/packages/NextDesign.Desktop.ExtensionPoints/) in the current directory.
```
> ndext new-extp Ext2
```

* To package an extension, execute as follows.

```
> ndext pack -c Release -v 3.0
```

If the `pack` command is executed successfully, a nupkg file will be created in the `ndpackages` folder.

## 4. Documentation
For detailed usage, please refer to [NDExt documentation](https://docs.nextdesign.app/extension/en/docs/tools/ndext/intro).