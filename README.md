# 3DBarrageMaker
## 簡単に3D弾幕をデザインできる
弾のパラメータ、撃ち方のパラメータ、そしてその組み合わせからなる弾幕をScriptableObjectをベースにInspecter上で作成できるようにしたもの
<br>

## 使い方
- ProjectのCreateの作成用メニューから「BarrageData」「ShotData」「BulletData」を作成する。
- 「BulletData」に弾のパラメータ、「ShotData」に撃ち方のパラメータ、「BarrageData」に組み合わせたいBulletDataとShotDataを設定する。
- Sampleでは「FlyCharacterStatus」にInspecter上からBarrageDataを設定することで、ボタンを押したときにそれが呼ばれるようになっている。
<br>

## Bulletのパラメータ
`標準パラメータ`
- BulletType：弾の種類
  - NormalBullet：通常弾
  - CurveBullet：基準軸を中心に回転しながら進む弾
  - SplitBullet：有効時間を迎えたときに別の弾幕を発動する弾
  - ChaseBullet：追尾弾
  - FunnelBullet：基準軸を中心に一定距離で回転しながら、別の弾幕を発動する弾
- Speed：弾のスピード
- ValidTime：弾の有効時間
- Damage：弾のダメージ量
<br>

`SplitBulelt用のパラメータ`
- SplitData：弾が有効時間を迎えたときに発動する弾幕のデータ
<br>

`CurveBullet / FunnelBullet用のパラメータ`
- AngularSpeed：弾の角速度
-  Axis：弾の回転する軸
<br>

`FunnelBullet用のパラメータ`
- DeploymentDistance：ファンネルが展開する距離
- DeploymentTime：ファンネルが展開するまでの時間
<br>

`ChaseBullet用のパラメータ`
- ChasePower：弾がターゲットを追尾する力
- ChaseEnableTime：弾が追尾を開始するまでの時間
<br>

## Shotのパラメータ
`標準パラメータ`
- ShotType：Shotの種類
  - Normal：照準に対して撃つ弾幕
  - AllRange：全方位に対して撃つ弾幕
  - Gather：自機に対して集まるように撃つ弾幕
- BulletNum：発射する弾数。AllRangeShotShapeで弾数を指定されていないときに適用される
<br>

`NormalShotのパラメータ`
- RandomDiffusion：拡散性がランダムかのFlag
- BulletShake：目標ベクトルからズレる割合
<br>

`AllRangeShotのパラメータ`
- AllRangeShotShape：全方位に放つ弾幕の形
<br>

`GatherShotのパラメータ`
- IsThrough：発射位置を通過してその対称点まで有効にするかのFlag
- Distance;：IsThroughが有効の時、発射位置をどの程度離れて通過するか
<br>

`繰り返しに関するパラメータ`
- Delay：発射までの遅延時間
- Cycle：発射周期
- Count：発射の繰り返し回数
- AngularSpeed：連射時に変化する角速度
- Axis：連射時に変化する基準軸
<br>

## Barrageのパラメータ
一対のBulletDataとShotDataを複数設定できる。
