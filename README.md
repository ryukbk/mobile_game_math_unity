# ゲームアプリの数学 サンプルコード

本gitレポジトリーは『[ゲームアプリの数学 Unityで学ぶ基礎からシェーダーまで](http://amzn.to/1UR7vmm) 』(久富木 隆一 著/SBクリエイティブ 刊)のためのサンプルコードならびに著者により更新されるサポート情報を保持します。

上記書籍は、本サンプルコードへの必要十分な注釈を含んでいます。書籍を手元に置いて参照しつつ、Unityで本サンプルコードを動かしたり、あるいは自由に改変したりして、動作結果を視覚的に確認することにより、書籍の内容を直感的に理解し応用につなげることができます。

本ページと合わせ、正誤表他の情報が記載されたSBクリエイティブ社[サポートページ](http://www.sbcr.jp/products/4797384260.html)も参照ください。

## 動作環境

* **Unity 5.2.4 f1** 以降
	- Microsoft Windows 7 以降
	- Mac OS X 10.10 以降
* Unityは、Unity Technologies社のwebサイトから無料のPersonal Editionを選択してダウンロードし、インストールしてください。
	- [最新バージョン](https://unity3d.com/jp/get-unity/download)
	- [過去のバージョン](https://unity3d.com/jp/get-unity/download/archive)
	- [最新バージョン以降のパッチリリース](https://unity3d.com/jp/unity/qa/patch-releases)
* 本サンプルコードは上記バージョンのUnityでの実行を前提としているため、それ以前のバージョンのUnityを同一マシン上で利用しなければならない場合は、[異なるバージョンの同時インストール](http://docs.unity3d.com/ja/current/Manual/InstallingUnity.html)の項目に従いUnity複数バージョンの共存環境を作成してください。

## ダウンロード

最新のサンプルコードは本レポジトリーのmasterブランチに収録されています。

以下のいずれかの方法でサンプルコードを取得してください。

* 本レポジトリーのメニュー内の"Download ZIP"ボタンから一括ダウンロード
* gitクライアントでローカルPCへ本レポジトリーをclone
* githubアカウント所持者であれば、本レポジトリーを自己レポジトリーへfork

## ファイル構成

* sampleフォルダー内にサンプルコードのUnityプロジェクトが存在し、中のAssetsフォルダーにプロジェクトを構成するファイル群が含まれます。
	- Editor: Unity Editor拡張
	- Meshes: インポート元3Dメッシュ
	- Resources: マテリアル
	- Scenes: Unityシーン
	- Scripts: C#スクリプトコンポーネント
	- Shader: GLSLシェーダープログラム

## 実行方法

Unityで、Unityプロジェクトとしてsampleフォルダーを開き、シーン再生ボタンを押下してください。

## 正誤表

書籍出版後に判明した本文中の誤記とその訂正は、SBクリエイティブ社[サポートページ正誤情報](http://www.sbcr.jp/support/12645.html)に掲載しておりますので、お問い合わせ前にご確認ください。

## 補遺

* 前書き
	- 代表的なDCCツールとしてAutodesk Mayaを挙げていますが、他に、無料でオープンソースの3Dモデリングツールとして[Blender](https://www.blender.org/)が有名です。
* 第6章
	- 単位クォータニオンの逆数を与えて回転すると、元のクォータニオンによる回転の逆回転となります。サンプルコード中のQuaternion.Inverseは、引数として与えた単位クォータニオンの逆数を返します。
* 第8章
	- TBDRのメリット/デメリットについては、同じ章で後に存在するグラフィックスパイプライン解説の読後に再度読んでみてください。
	- 遅延シェーディングは、第9章で触れているマルチパスレンダリングを行っており、Gバッファーの作成までがpass 1、Gバッファーを用いて行われる(pass 1ではあえて行わずに次のpassまで遅延された)照明計算がpass 2です。
* 第9章
	- 4次元ベクトルを表す型vec4はx、y、z、wの4つのメンバー変数を持つ構造体であり、packednormalはビットマップの1ピクセルを表すvec4で、RGBA各チャンネルを各メンバー変数に格納しています。つまりpackednormal.wにA(アルファ)が、packednormal.yにG(緑)が入っているので、スウィズル演算子wyを使い、wとyをvec2として抜き出して展開します。
	- サンプルコードのChapter09シーンに以下2点の仕様を追加
		1. シーン再生時に光源を回転
		1. [有名な3Dモデル](https://en.wikipedia.org/wiki/List_of_common_3D_test_models)である、[Utar teapot](https://ja.wikipedia.org/wiki/Utah_teapot)と、スタンフォード大学の[Happy Buddha](http://graphics.stanford.edu/data/3Dscanrep/)を、Blenderにインポート。Blender上で以下改変を適用して[Wavefront objフォーマット](https://en.wikipedia.org/wiki/Wavefront_.obj_file)でエクスポートし、Unityのシーン内に配置
			- オリジナルのマテリアルを削除
			- サブメッシュをjoin
			- メッシュ内の三角形の数が16ビットで表現できない数値(65535)以上であるとUnityでのインポート時にサブメッシュに分割されるため、Decimate ModifierでFace Countを65534以下に削減

## FAQ

* 随時更新

## 著作権表示/ライセンス

(C) 2015 Ryuichi KUBUKI (久富木 隆一)

本サンプルコードは[CC BY-NC-SA/Creative Commons Attribution Non-Commercial Share-Alike 4.0](https://creativecommons.org/licenses/by-nc-sa/4.0/legalcode.ja)でライセンスされています。

The contents of this repository are licensed under [CC BY-NC-SA/Creative Commons Attribution Non-Commercial Share-Alike 4.0](https://creativecommons.org/licenses/by-nc-sa/4.0/legalcode).

## 著者連絡先

* [Twitter](https://twitter.com/ryukbk)
* [blog](http://ryukbk.blogspot.jp/)

## 更新履歴

* 2015-12-18 Unity 5.2.4f1
* 2015-09-29 補遺追加
* 2015-09-26 補遺追加
* 2015-09-22 補遺追加
* 2015-09-19 初版



