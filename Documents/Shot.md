## Shotのパラメータ
#### 標準パラメータ
- ShotType：Shotの種類
  - Normal：照準に対して撃つ弾幕
  - AllRange：全方位に対して撃つ弾幕
  - Gather：自機に対して集まるように撃つ弾幕
- BulletNum：発射する弾数。AllRangeShotShapeで弾数を指定されていないときに適用される


#### NormalShotのパラメータ
- RandomDiffusion：拡散性がランダムかのFlag（falseの場合、リング状の弾幕が発射される）
- BulletShake：目標ベクトルからズレる割合（0に設定するとすべての弾が重なる）


#### AllRangeShotのパラメータ
- AllRangeShotShape：全方位に放つ弾幕の形
    - Random：完全にランダムに全方位に弾幕を放つ
    - Plane：ある平面に対して均等に放つ
    - Tetrahedron：正四面体の頂点に対して放つ
    - Hexahedran：正六面体の頂点に対して放つ
    - Octahedron：正八面体の頂点に対して放つ
    - Dodecahedron：正十二面体の頂点に対して放つ
    - Icosahedron：正二十面体の頂点に対して放つ
    - High Density：全方位に均等に放つ（密度の違うものを5種類用意）


#### GatherShotのパラメータ
- IsThrough：発射位置を通過してその対称点まで有効にするかのFlag（falseの場合、一点で集約するように弾が消える）
- Distance;：IsThroughが有効の時、発射位置をどの程度離れて通過するか（0の場合、一点で一度集約してその対称点で弾が消える）


#### 繰り返しに関するパラメータ
- Delay：発射までの遅延時間
- Cycle：発射周期
- Count：発射の繰り返し回数
- AngularSpeed：連射時に変化する角速度
- Axis：連射時に変化する基準軸
