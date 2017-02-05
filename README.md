# ゲームアプリの数学 サンプルコード

本gitレポジトリーは『[ゲームアプリの数学 Unityで学ぶ基礎からシェーダーまで](http://amzn.to/1UR7vmm) 』(久富木 隆一 著/SBクリエイティブ 刊)のためのサンプルコードならびに著者により更新されるサポート情報を保持します。

上記書籍は、本サンプルコードへの必要十分な注釈を含んでいます。書籍を手元に置いて参照しつつ、Unityで本サンプルコードを動かしたり、あるいは自由に改変したりして、動作結果を視覚的に確認することにより、書籍の内容を直感的に理解し応用につなげることができます。

本ページと合わせ、正誤表他の情報が記載されたSBクリエイティブ社[サポートページ](http://www.sbcr.jp/products/4797384260.html)も参照ください。

## 更新履歴

* 2017-01-22 第5章サンプルコードDirect3D11向け修正。第5章、第7章補遺追加
* 2017-01-07 Unity 5.5/5.4サポート(Unity 5.5.0f3)、_Object2World、varyingについて補遺追加
* 2015-12-18 著者講演資料追加
* 2015-12-18 Unity 5.3サポート(Unity 5.3.0f4)
* 2015-12-18 Unity 5.2向けブランチ追加(Unity_5.2)(Unity 5.2.4f1)
* 2015-09-29 補遺追加
* 2015-09-26 補遺追加
* 2015-09-22 補遺追加
* 2015-09-19 初版

## 動作環境

* **Unity 5.5.0 f3** 以降
	- Unity 5.3.4以前でサンプルを実行したい場合は[Unity_5.3.4ブランチ](https://github.com/ryukbk/mobile_game_math_unity/tree/Unity_5.3.4)を取得して下さい。
	- Unity 5.2.x以前でサンプルを実行したい場合は[Unity_5.2ブランチ](https://github.com/ryukbk/mobile_game_math_unity/tree/Unity_5.2)を取得してください。
	- Microsoft Windows 7 以降
	- Mac OS X 10.10 以降
* Unityは、Unity Technologies社のwebサイトから無料のPersonal Editionを選択してダウンロードし、インストールしてください。
	- [最新バージョン](https://unity3d.com/jp/get-unity/download)
	- [過去のバージョン](https://unity3d.com/jp/get-unity/download/archive)
	- [最新バージョン以降のパッチリリース](https://unity3d.com/jp/unity/qa/patch-releases)
* 本サンプルコードは上記バージョンのUnityでの実行を前提としているため、それ以前のバージョンのUnityを同一マシン上で利用しなければならない場合は、[異なるバージョンの同時インストール](http://docs.unity3d.com/ja/current/Manual/InstallingUnity.html)の項目に従いUnity複数バージョンの共存環境を作成してください。

## ダウンロード

最新のサンプルコードは本gitレポジトリーのmasterブランチに収録されています。

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
* 第5章
	- サンプルコードのプロジェクトでは、Unity EditorメニューのFile | Build Settings | Player Settings | Graphics API for Windowsの設定は、デフォルトではOpenGL系レンダラーであるOpenGLES3が最上位で最優先と設定されているため、Windows上でもOpenGL系のプロジェクション変換行列となります。Direct3D9レンダラーを最上位に設定すると、本文133ページのプロジェクション変換行列となります。
	- Unity 5.5からの[変更点(Shaders: Z-buffer float inverted)](https://docs.unity3d.com/550/Documentation/Manual/UpgradeGuide55.html)として、Graphics API for Windows設定でDirect3D11レンダラーを最上位に設定した場合、従来のDirect3D9レンダラーと異なり、プロジェクション変換行列Pのz軸範囲が[1, 0]に写像されるようになります。これに伴い、本文133ページのWindows上でのプロジェクション変換行列の3行3列は![](http://latex.codecogs.com/gif.latex?%7B%5Cfrac%7Bn%7D%7Bf-n%7D%7D)、3行4列は![](http://latex.codecogs.com/gif.latex?%7B%5Cfrac%7Bfn%7D%7Bf-n%7D%7D)となります。同様に、144ページでのDirect3D向けのz軸範囲の写像しなおしも、最新サンプルコードはDirect3D11レンダラー上では[1, 0]になるよう処理を行います。

	```
	for (int i = 0; i < 4; i++) {
	    pm[2, i] = pm[2, i] * -0.5f + pm[3, i] * 0.5f;
	}
	```
	
	Unity 5.5でのDirect3D11レンダラーの変更は、本文234ページで触れているデプス(深度)バッファー/Zバッファーの精度を、(Direct3D 9では利用できなかった)浮動小数点精度を用いて向上させるとともに、[reverse-Z](https://developer.nvidia.com/content/depth-precision-visualized)として知られる[1, 0]への写像により遠景部分で精度を向上させるものです。精度向上のためのテクニックとして、他に[対数デプスバッファー(Logarithmic Depth Buffers)](http://qpp.bitbucket.org/translation/maximizing_depth_buffer_range_and/)があります。
* 第6章
	- クォータニオンは`w`、`x`、`y`、`z`の4つの数値の組として表現されますが、回転のために用いる正規化されたクォータニオンであれば、大きさが1であり![](http://latex.codecogs.com/gif.latex?w%5E2+x%5E2+y%5E2+z%5E2%3D1)が成立することを利用して3つの数値があれば残り1つの数値を求められるため、精度を落として`w`の符号をいずれかの数値内のビットに保存するなどの処理を入れれば3つの数値の組としてさらにコンパクトな形式で保存できます。
	- 正規化されたクォータニオンの逆数を与えて回転すると、元のクォータニオンによる回転の逆回転となります。サンプルコード中の`Quaternion.Inverse`は、引数として与えた正規化されたクォータニオンの逆数を返します。
* 第7章
	- 本文181ページの曲線当てはめは、本文168ページで紹介しているスケルタルアニメーションを実現するために、キーフレームアニメーションの元データを[Catmull-Romスプラインのような曲線アルゴリズムで近似することによりデータ量を圧縮する](https://engineering.riotgames.com/news/compressing-skeletal-animation-data)のに利用されることがあります。
* 第8章
	- TBDRのメリット/デメリットについては、同じ章で後に存在するグラフィックスパイプライン解説の読後に再度読んでみてください。
	- 遅延シェーディングは、第9章で触れているマルチパスレンダリングを行っています。Gバッファーの作成までがpass 1、Gバッファーを用いて行われる(pass 1ではあえて行わずに次のpassまで遅延された)照明計算がpass 2です。
* 第9章
	- 4次元ベクトルを表す型`vec4`は`x`、`y`、`z`、`w`の4つのメンバー変数を持つ構造体であり、`packednormal`はビットマップの1ピクセルを表す`vec4`で、RGBA各チャンネルを各メンバー変数に格納しています。つまり`packednormal.w`にA(アルファ)が、`packednormal.y`にG(緑)が入っているので、スウィズル演算子`wy`を使い、`w`と`y`を`vec2`として抜き出して展開します。
	- サンプルコードのChapter09シーンに以下2点の仕様を追加
		1. シーン再生時に光源を回転
		1. [有名な3Dモデル](https://en.wikipedia.org/wiki/List_of_common_3D_test_models)である、[Utar teapot](https://ja.wikipedia.org/wiki/Utah_teapot)と、スタンフォード大学の[Happy Buddha](http://graphics.stanford.edu/data/3Dscanrep/)を、Blenderにインポート。Blender上で以下改変を適用して[Wavefront objフォーマット](https://en.wikipedia.org/wiki/Wavefront_.obj_file)でエクスポートし、Unityのシーン内に配置
			- オリジナルのマテリアルを削除
			- サブメッシュをjoin
			- メッシュ内の三角形の数が16ビットで表現できない数値(65535)以上であるとUnityでのインポート時にサブメッシュに分割されるため、Decimate ModifierでFace Countを65534以下に削減
	- Unity 5.3.5以降では、シェーダープログラム内でのモデル変換行列`_Object2World`の定義が、UnityCG.glslinc内では廃止されていますので、シェーダープログラムを書く際には、代わりに新しく定義された`unity_ObjectToWorld`を使用して下さい。(本レポジトリー内でのサンプルコードでは、`_Object2World`が定義されていない場合は`unity_ObjectToWorld`を用い`_Object2World`を別名として定義するようにしています。)
	- Unity 5.5では、MacでのグラフィックスAPIとしてはPlayer Settingsでの設定ではOpenGLCoreのみ選択できOpenGL2が廃止されています。従って、Mac向けにGLSLシェーダープログラムを動作させるためにはOpenGLCoreがサポートするGLSL 1.30に従って書く必要があります。GLSL 1.30では`varying`変数は廃止されており、代わりに、バーテックスシェーダーで出力する変数は`out`指定してバーテックスシェーダー内に定義し、同名の変数を`in`指定してフラグメントシェーダー内に定義しフラグメントシェーダーへの入力とします。

## FAQ

* 随時更新

## 著者講演資料

* [ゲームアプリの数学@Unity Rendering Wizardの集い](http://www.slideshare.net/ryukbk/unity-rendering-wizard)
	- 2015年10月22日渋谷dots.で開催された[Unity Rendering Wizardの集い](http://eventdots.jp/event/571325)でのLT資料です。 
* [ゲームアプリの数学@プログラマのための数学勉強会](http://www.slideshare.net/ryukbk/ss-55366793)
	- 2015年11月21日渋谷dots.で開催された[第5回 プログラマのための数学勉強会](http://eventdots.jp/event/571642) [#maths4pg](https://twitter.com/hashtag/maths4pg?src=hash)でのLT資料です。
* [ゲームアプリの数学@GREE GameDevelopers' Meetup](http://www.slideshare.net/ryukbk/gree-gamedevelopers-meetup)
	- 2015年12月16日六本木ヒルズのグリー株式会社で開催された[GREE GameDevelopers' Meetup 02](http://greegdm02.peatix.com/) [#greegdm02](https://twitter.com/hashtag/greegdm02?src=hash)での講演資料です。書籍『ゲームアプリの数学 Unityで学ぶ基礎からシェーダーまで』の紹介、番外編(レイトレーシング/レイマーチング/SDFなど、ラスタライズを行わない非ポリゴンベースの3Dグラフィックスの紹介)、ゲーム開発の未来展望(手続き生成、機械学習/ディープラーニング、モバイルVRなど)から成ります。

## 著作権表示/ライセンス

(C) 2015 Ryuichi KUBUKI (久富木 隆一)

本サンプルコードは[CC BY-NC-SA/Creative Commons Attribution Non-Commercial Share-Alike 4.0](https://creativecommons.org/licenses/by-nc-sa/4.0/legalcode.ja)でライセンスされています。

The contents of this repository are licensed under [CC BY-NC-SA/Creative Commons Attribution Non-Commercial Share-Alike 4.0](https://creativecommons.org/licenses/by-nc-sa/4.0/legalcode).

## 著者連絡先

* [Twitter](https://twitter.com/ryukbk)
* [blog](http://ryukbk.blogspot.jp/)


