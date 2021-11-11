---
sidebar_position: 200
---

# new コマンド

NDExtを用いれば、コマンドラインとVisual Studioの両方から Next Designのエクステンション開発用の.NET プロジェクトを作成可能です。

## コマンドプロンプトやシェルからプロジェクトを作成する
Next Designのエクステンションの .NET Core プロジェクトをカレントディレクトリに作成します。


| コマンド名         | プロジェクトの種類  | 
| ----              | ----               | 
|  new              |  シンプルなエクステンションのプロジェクト  
|  new-extp          |  [NextDesign.Desktop.ExtensionPoints](https://www.nuget.org/packages/NextDesign.Desktop.ExtensionPoints/)を利用したエクステンション  

次のように実行します。

```
ndext new Ext1
```

[NextDesign.Desktop.ExtensionPoints](https://www.nuget.org/packages/NextDesign.Desktop.ExtensionPoints/)を利用したエクステンションのプロジェクトをカレントディレクトリに作成します。
```
ndext new-extp Ext2
```

## `new` , `new-extp` コマンド
現在のフォルダにNext Designのエクステンションのプロジェクトを作成します。

```
Usage:
  NDExt new <name>

Arguments:
  <name>    作成プロジェクト名を指定して下さい
```
