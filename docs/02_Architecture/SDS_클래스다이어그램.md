## 📂 3.2.1 Core 관련 클래스

### 📦AudioManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦GameManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 🏷️InputManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 🏷️PoolManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦SaveManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦SettingManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦UpgradeManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

---

## 📂 3.2.2 Enemies 관련 클래스

### 🏷️BossMonster
> **Description:**
> Monster 클래스를 상속받는 보스 몬스터 클래스.   
  보스 전용 체력바 UI 연동을 위한 이벤트와 사망 시 보상 생성 로직을 포함.

**🟢Attributes (속성)**

| Name                 | Description                    | Type                      | Visibility |
|:---------------------|:-------------------------------|:--------------------------|:-----------|
| `OnBossHpChanged`    | 보스 체력 변경 시 발생하는 이벤트   | `Action<float, float>`    | `public`   |
| `BossMaxHp`          | 보스 최대 체력(Read-Only)        | `float`                   | `public`   |
| `BossCurrentHp`      | 보스의 현재 체력 (읽기 전용)       | `float`                   | `public`   |
| `TreasurePrefab`     | 보스 사망 시 드롭할 보물상자 프리팹 | `GameObject`              | `public`   |

**🔷Operations (메서드)**

| Name                            | Description                                                    | Type (Return) | Visibility |
|:--------------------------------|:---------------------------------------------------------------|:--------------|:-----------|
| `Move(targetPosition: Vector2)` | 타겟을 향해 이동하며, 위치에 따라 스프라이트를 좌우 반전               | `void`        | `public`   |
| `TakeDamage(amount: float)`     | 데미지를 입고 피격 효과를 재생하며, OnBossHpChanged 이벤트를 호출     | `void`        | `public`   |
| `Die()`                         | 사망 로그 출력 및 보물상자를 생성한 뒤, 부모의 사망 처리(풀 반환)를 수행 | `void`        | `public`   |

### 📦EnemyReposition
> **Description:**
> 몬스터가 플레이어로부터 일정 거리 이상 멀어지면, 플레이어 진행 방향 앞쪽으로 방향을 설정한다.

**🟢Attributes (속성)**

| Name                    | Description                                | Type          | Visibility |
|:------------------------|:-------------------------------------------|:--------------|:-----------|
| `maxDistanceFromPlayer` | 재배치가 트리거되는 플레이어와의 최대 거리 임계값 | `float`       | `private`  |
| `spawnDistance`         | 재배치 시 설정되는 플레이어로부터의 거리         | `float`      | `private`  |
| `randomOffsetRange`     | 몬스터 간 겹침 방지를 위한 랜덤 위치 오프셋 범위  | `float`      | `private`  |
| `forwardAngleRange`     | 플레이어 진행 방향 기준 재배치 허용 각도(좌우)   | `float`       | `private`  |
| `_maxDistanceSqr`       | 거리 비교 최적화 위해 계산하는 거리의 제곱값     | `float`       | `private`  |
| `_collider`             | 몬스터의 콜라이더 참조(비활성화 확인용)         | `Collider2D`  | `private`  |

**🔷Operations (메서드)**

| Name                               | Description                                                         | Type (Return) | Visibility |
|:-----------------------------------|:--------------------------------------------------------------------|:--------------|:-----------|
| `Reposition(playerPos: Vector3)`   | 플레이어 이동방향 기반으로 전방 부채꼴 범위내 랜덤 위치 계산해서 몬스터 이동   | `void`        | `public`   |

### 📦Monster
> **Description:**
> 몬스터 공통 속성을 정의하는 추상 클래스.

**🟢Attributes (속성)**

| Name                  | Description                  | Type              | Visibility   |
|:----------------------|:-----------------------------|:------------------|:-------------|
| `monsterName`         | 몬스터 이름 (도감 및 식별용)     | `string`          | `protected`  |
| `maxHp`               | 최대 체력                      | `float`           | `protected`  |
| `moveSpeed`           | 이동 속도                      | `float`           | `protected`  |
| `contactDamage`       | 플레이어와 충돌 시 입히는 데미지  | `float`           | `protected`  |
| `expOrbPrefab`        | 사망 시 드롭할 경험치 구슬 프리팹 | `GameObject`      | `public`     |
| `_currentHp`          | 현재 체력                      | `float`           | `protected`  |
| `_target`             | 추적 대상(플레이어)             | `Transform`       | `protected`  |
| `_speedMultiplier`    | 현재 속도 배율 (디버프 등 적용)  | `float`           | `protected`  |
| `_returnToPoolAction` | 몬스터 사망 시 풀로 복귀        | `Action<Monster>` | `protected`  |

**🔷Operations (메서드)**

| Name                                             | Description                                                        | Type (Return) | Visibility  |
|:-------------------------------------------------|:-------------------------------------------------------------------|:--------------|:------------|
| `Init(target, returnCallback)`                   | 스폰 시 타겟 설정, 풀링 콜백 연결, 상태 초기화 수행                      | `void`        | `public`    |
| `Move(targetPosition)`                           | 대상 위치로 이동 (자식 클래스에서 구체적인 이동 로직 구현)                 | `void`        | `public`    |
| `TakeDamage(amount)`                             | 데미지를 입고 피격 효과 실행, 체력이 0 이하가 되면 Die 호출               | `void`        | `public`    |
| `Die()`                                          | 사망 처리, 경험치/재화/킬카운트 반영, 도감 해금 및 오브젝트 풀 반환을 수행   | `void`        | `public`    |
| `ApplySpeedDebuff(source, slowAmount, duration)` | 특정 소스로부터 이동 속도 감소 디버프를 적용(중첩 시 시간 갱신)            | `void`        | `public`    |
| `RemoveSpeedDebuff(source)`                      | 속도 디버프를 제거하고 속도 배율을 재계산                                | `void`        | `public`    |
| `SpawnFadeIn()`                                  | 스폰 시 투명 상태에서 서서히 나타나는 페이드인 연출 수행                   | `IEnumerator` | `protected` |

### 🏷️NormalMonster
> **Description:**
> Monster 클래스를 상속받는 일반 몬스터 클래스   
  플레이어를 향해 단순 이동하며, 이동방향에 따라 스프라이트 방향을 설정한다

**🔷Operations (메서드)**

| Name                            | Description                                                                        | Type          | Visibility |
|:--------------------------------|:-----------------------------------------------------------------------------------|:--------------|:-----------|
| `Move(targetPosition: Vector2)` | CurrentMoveSpeed를 사용하여 타겟 위치로 이동하며, 타겟의 X좌표에 따라 스프라이트를 좌우 반전 | `void`         | `public`   |

### 🏷️Projectile2
> **Description:**
> 적 몬스터가 발사하는 투사체 클래스
  초기화된 방향 또는 타겟을 향해 직선으로 이동하며
  플레이어와 충돌 시 데미지를 입히고 파괴된다

**🟢Attributes (속성)**

| Name             | Description                      | Type        | Visibility |
|:-----------------|:---------------------------------|:------------|:-----------|
| `speed`          | 투사체의 이동 속도                 | `float`      | `private`  |
| `damage`         | 플레이어 충돌 시 입히는 피해량       | `float`     | `private`   |
| `lifetime`       | 투사체가 발사된 후 자동 소멸되는 시간 | `float`     | `private`   |
| `_target`        | 투사체가 날아갈 대상                | `Transform` | `private`   |
| `_moveDirection` | 투사체가 날아갈 방향                | `Transform` | `private`   |

**🔷Operations (메서드)**

| Name                          | Description                                                   | Type (Return) | Visibility |
|:------------------------------|:--------------------------------------------------------------|:--------------|:-----------|
| `Init(target: Transform)`     | 타겟의 위치를 계산하여 이동 방향을 설정하고, 스프라이트 회전을 업데이트 | `void`        | `public`   |
| `Init(direction: Vector2)`    | 지정된 방향 벡터로 이동 방향을 설정하고, 스프라이트 회전을 업데이트     | `void`        | `public`   |
| `SetSize(scale: float)`       | 투사체의 크기 설정                                               | `void`        | `public`   |
| `SetSpeed(newSpeed: float)`   | 투사체의 속도 설정                                               | `void`        | `public`   |
| `SetDamage(newDamage: float)` | 투사체의 데미지 설정                                             | `void`        | `private`   |

### 📦SpawnManager
> **Description:**
> WaveData를 기반으로 몬스터 스폰을 총괄
  시간 흐름에 따라 웨이브를 갱신하고 MonsterSpawnInfo에 설정된 시간에 따라 몬스터를 생성한다
  보스 몬스터의 등장 및 처치 이벤트도 관리하며, PoolManager와 연동하여 몬스터 오브젝트 풀링을 처리

**🟢Attributes (속성)**

| Name                 | Description                                  | Type                                      | Visibility |
|:---------------------|:--------------------------------- -----------|:------------------------------------------|:-----------|
| `playerTransform`    | 플레이어 위치 참조                             | `Transform`                                | `private`  |
| `waves`              | 게임 진행에 따른 웨이브 데이터 리스트             | `List<WaveData>`                           | `private`  |
| `bossPrefab`         | 주기적으로 등장할 보스 몬스터 프리팹              | `BossMonster`                              | `private`  |
| `spawnRadius`        | 플레이어 기준 몬스터 생성 거리                   | `float`                                    | `private`  |
| `bossSpawnCycle`     | 보스 등장 주기                                | `float`                                    | `private`  |
| `initialPerTypeSize` | 몬스터 종류별 초기 풀링 개수                    | `int`                                      | `private`  |
| `OnBossSpawned`      | 보스 등장 및 처치 알림 이벤트                   | `Action<bool, BossMonster>`                | `public`   |
| `_currentWave`       | 현재 진행 중인 웨이브 데이터                    | `WaveData`                                 | `private`  |
| `_activeMonsters`    | 현재 필드에 활성화된 몬스터 리스트(최대 수량 제한) | `List<Monster>`                            | `private`  |
| `_spawnTimers`       | 각 몬스터 종류별 스폰 쿨타임 관리 딕셔너리        | `Dictionary<MonsterSpawnInfo, float>`      | `private`  |

**🔷Operations (메서드)**

| Name                             | Description                                                            | Type (Return) | Visibility |
|:---------------------------------|:-----------------------------------------------------------------------|:--------------|:-----------|
| `UpdateWaveData(time: float)`    | 현재 게임 시간에 맞는 웨이브 데이터를 리스트에서 찾아 현재 웨이브 갱신           | `void`        | `private`  |
| `ProcessWaveSpawning()`          | 현재 웨이브의 모든 MonsterSpawnInfo를 순회하며 각자의 주기에 맞춰 몬스터를 스폰 | `void`        | `private`  |
| `SpawnBoss()`                    | 보스 몬스터를 생성하고 OnBossSpawned 이벤트를 호출하며, 게임 타이머를 일시 정지  | `void`        | `private`  |
| `OnBossDied(boss: Monster)`      | 보스 사망 시 호출되는 콜백. 타이머를 재개하고 보스 처치 이벤트를 방송            | `void`        | `private`  |
| `SpawnMonster(prefab, position)` | PoolManager에 요청하여 몬스터 오브젝트를 가져오고 초기화하여 필드에 배치        | `void`        | `public`   |
| `ReturnToPool(monster, prefab)`  | 몬스터 사망 시 활성 리스트에서 제거하고 PoolManager로 반환 요청               | `void`        | `public`   |
| `PreloadAllWaveMonsters()`       | 게임 시작 시 waves에 등록된 모든 몬스터 프리팹을 PoolManager를 통해 미리 생성  | `void`        | `private`  |
| `CalculateSpawnPosition()`       | 플레이어 위치를 기준으로 spawnRadius 거리의 랜덤한 위치를 계산하여 반환         | `Vector2`     | `public`   |

## 📂 3.2.3 Gameplay 관련 클래스

### 📦AcquireableObject
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦EventManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦GameEventData
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦Reposition
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦RewardManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦UpgradeData
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

## 📂 3.2.4 Loot-Abstract 관련 클래스

### 📦EquipmentBase
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦Item
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 🏷️Passive
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 🏷️Projectile
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦Weapon
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

## 📂 3.2.5 Loot-Data 관련 클래스

### 📦EquipmentData
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦EquipmentInfo
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦ItemData
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦ItemInfo
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 🏷️LootDataBase
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 🏷️MonsterInfo
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦PassiveData
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦WeaponData
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

## 📂 3.2.6 Player 관련 클래스

### 📦InventoryManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦PlayerMagnet
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 🏷️PlayerManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦PlayerStats
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

## 📂 3.2.7 UI 관련 클래스

### 🏷️CodexManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 🏷️CodexSlot
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 🏷️DescriptionPanel
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 🏷️FloatingText
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦HUDManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 🏷️InGamePanelManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦MainMenuPanelManager
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦TooltipController
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |

### 📦UpgradeSlot
> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description        | Type                      | Visibility |
|:---------------------|:-------------------|:--------------------------|:-----------|
| `bgmClips`           | 배경 음악 리스트          | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `SetSfxVolume(level: float)`    | 설정 파일을 읽어와서 효과음 불륨 적용   | `void`        | `public`   |
