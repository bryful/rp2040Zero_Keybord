# RP2040 Zero Keyboard Configurator

RP2040 Zeroベースのカスタムキーボード用のキー割り当て設定ツール
[https://github.com/bryful/rp2040Zero_keyboard_RotaryEncoder](https://github.com/bryful/rp2040Zero_keyboard_RotaryEncoder)


## 概要

このアプリケーションは、RP2040 Zeroマイコンを使用したカスタムキーボードのキー割り当てを視覚的に設定できるWindows向けコンフィギュレーターです。

### 主な機能

- **4×5キーマトリクスの設定**: 20個のキーボタンを自由にカスタマイズ
- **ロータリーエンコーダー対応**: 2つのロータリーエンコーダー（CW/CCW/SW）の設定
- **4レイヤー対応**: 4つの独立したレイヤーで異なるキー配置を保存
- **モディファイアキー**: Ctrl、Shift、Alt、GUIキーの組み合わせに対応
- **マウス操作**: 左/右/中クリック、戻る/進むボタンの設定
- **ファイル保存/読み込み**:
  - JSON形式（人間が読める）
  - バイナリ形式（コンパクト、`.kmp`）
  - C++ヘッダー形式（ファームウェア用、`.h/.cpp`）
- **プリセット対応**: 固定キー、PhotoShop、AfterEffects、カスタム用の4つのプリセット

## 対応環境

- **OS**: Windows 10/11
- **ランタイム**: .NET 10.0
- **ターゲット**: RP2040ベースのカスタムキーボード

## インストール

### ビルド済みバイナリ（予定）

Releasesページから最新版をダウンロードしてください。

### ソースからビルド

**必要な環境:**
- Visual Studio 2026 以降
- .NET 10.0 SDK

## 使い方

### 基本的な操作

1. **アプリケーションの起動**
   - `rp2040Zero_Keybord.exe`を実行

2. **レイヤーの選択**
   - 上部のラジオボタンで0〜3のレイヤーを選択

3. **キーの設定**
   - キーボードマトリクスから設定したいキーをクリック
   - 下部のコンフィギュレーターでキーコード、モディファイア、マウスボタンを設定
   - 「Set」ボタンで適用

4. **ロータリーエンコーダーの設定**
   - CW（時計回り）、CCW（反時計回り）、SW（プッシュ）を個別に設定

5. **保存と読み込み**
   - **自動保存**: アプリ終了時に`keyconfigs.dat`に自動保存
   - **手動保存**: `File > Save`からJSON/バイナリ形式で保存
   - **C++出力**: `File > Export to C++`でファームウェア用のコードを生成

### ファイル形式

#### JSON形式（`.json`）
人間が読める形式。デバッグや共有に便利。

#### バイナリ形式（`.kmp`）
コンパクトな独自形式。高速な読み書き。

#### C++ヘッダー形式（`.h`）
RP2040ファームウェアに直接コピー＆ペースト可能：

### キーコード対応表

- **HIDキーコード**: USB HID準拠（TinyUSB互換）
- **日本語キーボード**: JIS配列の特殊キー（無変換、変換、かな等）に対応
- **ファンクションキー**: F1〜F24
- **メディアキー**: Mute、Volume Up/Down
- **マウスボタン**: Left/Right/Middle/Back/Forward



## ライセンス

MIT License - 詳細は[LICENSE](LICENSE)ファイルを参照してください。

## 作者

[@bryful](https://github.com/bryful)


## 関連リンク

- [RP2040 Zero公式](https://www.waveshare.com/rp2040-zero.htm)
- [TinyUSB HID仕様](https://github.com/hathach/tinyusb)
- [USB HIDキーコード一覧](https://www.usb.org/sites/default/files/documents/hut1_12v2.pdf)

---

**Note**: このツールはキー設定のみを行います。RP2040ファームウェアは別途必要です。