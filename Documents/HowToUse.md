## 使い方
### 弾幕を作成する。
下図のように、ProjectのCreateの作成用メニューからそれぞれ「BulletData」「ShotData」「BurrageData」を作成する.<br>
![MakeScriptableObject.png](./MakeScriptableObject.png)
- [「BulletData」](./Bullet.md)：弾に関する設定
- [「ShotData」](./Shot.md)：撃ち方に関する設定
- [「BarrageData」](./Barrage.md)：弾と撃ち方の組み合わせに関する設定 <br>
※詳しいパラメータの説明は各種リンク先を参照

***
### ScriptableObjectにパラメータを設定する
作成したScriptableObjectにInspecter上からパラメータを設定する.<br>
#### 例）FunnelBulletのパラメータ <br>
![SetBulletParameter.png](./SetBulletParameter.png)<br>
```
上図の例では、
・初速20m/s（回転による速度は考慮されていない）
・有効時間は5s（FunnelBulletの場合、この項目は放つ弾幕に依存）
・ダメージ量は1
・Barrage Sentryという弾幕を放ちながら進行
・Barrage Sentryは、「Shot Plane Shooting」と「Bullet Normal」によって構成（ここで編集可）
・展開位置は自機から半径20mの位置
・1sの時間をかけて展開位置に到達
・角速度は60deg/s（初速とは依存関係にない）
・回転軸はY軸
```
という設定をしている.<br>

#### 例）AllRangeShotのパラメータ<br>
![SetShotParameter.png](./SetShotParameter.png)<br>
```
上図の例では、
・撃ち方は全方位に対して放つ
・その形はランダム
・一度呼ばれるごとに放つ弾の数は10発
・呼ばれる回数は20回
・呼ばれる周期は0.01s
```
という設定をしている.

#### 例）AllRange Crossのパラメータ<br>
![SetBarrageParameter.png](./SetBarrageParameter.png)<br>
```
上図の例では、
・6つの組み合わせを同時に発射する
・それぞれの弾の動作のみが異なり、別々の回転軸で回転する（それぞれのBullet Curveは異なるパラメータを設定してある）
```
***

### 作成した弾幕のセット
Sampleでは Hierarchyの「Player(親)/Player」にアタッチされている「FlyCharacterStatus」 にInspecter上からBarrageDataを設定することで、ボタンを押したときにそれが呼ばれるようになっている。
![SetBarrageData.png](./SetBarrageData.png)<br>

ちなみに、敵に対しても同様にBarrageDataを設定してあるため、変更することが可能.
