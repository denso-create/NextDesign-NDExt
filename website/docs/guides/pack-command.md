---
sidebar_position: 300
---

# pack コマンド 
エクステンションをパッケージ化します。

## コマンド
```
NDExt pack [options]
```

## オプション

```
Usage:
  NDExt pack [options]

Options:
  p, project <project>    対象プロジェクトのディレクトリを指定します。未指定の場合は現在のディレクトリ以下を探索して実行します。
  v, ndver <ndver>        動作の対象となるNext Designのバージョンです。未指定の場合は `1.3.11` です。
  c, config <config>      ビルド構成を指定します。`Debug`または`Release`を指定して下さい。未指定の場合は`Debug` です。
  o, output <output>      作成したパッケージの格納フォルダを指定します。未指定の場合は `ndpackages` です。
  d, copydir <copydir>    作成したパッケージを指定フォルダにもコピーします。

```

## 例

次のように実行すると、カレントディレクトリ以下にあるすべてのエクステンションのプロジェクト(csproj)を探し、ビルドしてパッケージ化します。
```
c:/myproject\src> ndext pack
```