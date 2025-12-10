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
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description                      | Type                      | Visibility |
| :------------------- | :------------------------------- | :------------------------ | :--------- |
| `bgmClips`           | 배경 음악 리스트                 | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                         | Description                           | Type (Return) | Visibility |
| :--------------------------- | :------------------------------------ | :------------ | :--------- |
| `SetSfxVolume(level: float)` | 설정 파일을 읽어와서 효과음 불륨 적용 | `void`        | `public`   |

### 📦EnemyReposition

> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description                      | Type                      | Visibility |
| :------------------- | :------------------------------- | :------------------------ | :--------- |
| `bgmClips`           | 배경 음악 리스트                 | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                         | Description                           | Type (Return) | Visibility |
| :--------------------------- | :------------------------------------ | :------------ | :--------- |
| `SetSfxVolume(level: float)` | 설정 파일을 읽어와서 효과음 불륨 적용 | `void`        | `public`   |

### 📦Monster

> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description                      | Type                      | Visibility |
| :------------------- | :------------------------------- | :------------------------ | :--------- |
| `bgmClips`           | 배경 음악 리스트                 | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                         | Description                           | Type (Return) | Visibility |
| :--------------------------- | :------------------------------------ | :------------ | :--------- |
| `SetSfxVolume(level: float)` | 설정 파일을 읽어와서 효과음 불륨 적용 | `void`        | `public`   |

### 🏷️NormalMonster

> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description                      | Type                      | Visibility |
| :------------------- | :------------------------------- | :------------------------ | :--------- |
| `bgmClips`           | 배경 음악 리스트                 | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                         | Description                           | Type (Return) | Visibility |
| :--------------------------- | :------------------------------------ | :------------ | :--------- |
| `SetSfxVolume(level: float)` | 설정 파일을 읽어와서 효과음 불륨 적용 | `void`        | `public`   |

### 🏷️Projectile2

> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description                      | Type                      | Visibility |
| :------------------- | :------------------------------- | :------------------------ | :--------- |
| `bgmClips`           | 배경 음악 리스트                 | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                         | Description                           | Type (Return) | Visibility |
| :--------------------------- | :------------------------------------ | :------------ | :--------- |
| `SetSfxVolume(level: float)` | 설정 파일을 읽어와서 효과음 불륨 적용 | `void`        | `public`   |

### 📦SpawnManager

> **Description:**
> 몬스터 생성을 관리하는 매니저 클래스

**🟢Attributes (속성)**

| Name                 | Description                        | Type                                  | Visibility |
|:---------------------|:-----------------------------------|:--------------------------------------|:-----------|
| `OnBossSpawned`      | 보스 스폰 또는 처치를 알리는 이벤트               | `event Action<bool,BossMonster>`      | `Public`   |
| `playerTransform`    | 플레이어의 위치 참조                        | `Transform`                           | `Private`  |
| `waves`              | 시간 순서대로 정의된 웨이브 데이터 리스트            | `List<WaveData>`                      | `Private`  |
| `bossPrefab`         | 보스 몬스터 프리팹                         | `BossMonster`                         | `Private`  |
| `spawnRadius`        | 몬스터 스폰 위치를 계산할 때 사용하는 플레이어 주변 범위   | `float`                               | `Private`  |
| `bossSpawnCycle`     | 보스가 스폰되는 시간 주기                     | `float`                               | `Private`  |
| `initialPerTypeSize` | PoolManager에 타입별로 미리 로드할 초기 몬스터 수량 | `int`                                 | `Private`  |
| `_currentWave`       | 현재 활성화된 `WaveData` 참조              | `WaveData`                            | `Private`  |
| `_bossLevel`         | 현재 스폰해야 할 보스의 레벨                   | `int`                                 | `Private`  |
| `_isBossActive`      | 현재 필드에 보스가 활성화 여부                  | `bool`                                | `Private`  |
| `_activeMonsters`    | 현재 필드에 활성화된 몬스터 리스트                | `List<Monster>`                       | `Private`  |
| `_spawnTimers`       | 각 몬스터 타입별 스폰 간격을 조절하는 타이머          | `Dictionary<MonsterSpawnInfo, float>` | `Private`  |

**🔷Operations (메서드)**

| Name                                             | Description                                              | Type (Return) | Visibility |
|:-------------------------------------------------|:---------------------------------------------------------|:--------------|:-----------|
| `UpdateWaveData(float time)`                     | 현재 시간을 기반으로 몬스터의 스폰 패턴을 정의하는 메서드                         | `void`        | `Private`  |
| `ProcessWaveSpawning()`                          | 현제 웨이브 데이터에 따라 몬스터 소환하는 메서드                              | `void`        | `Private`  |
| `SpawnBoss()`                                    | 보스를 소환하고 이벤트 방송하는 메서드                                    | `void`        | `Private`  |
| `OnBossDied(Monster boss)`                       | 보스 사망시 이벤트 방송하는 메서드                                      | `void`        | `Private`  |
| `SpawnMonster(Monster prefab, Vector2 position)` | 몬스터 오브젝트를 가져와 초기화하고 스폰 리스트에 추가하는 메서드                     | `void`        | `Public`   |
| `ReturnToPool(Monster monster, Monster prefab)`  | 몬스터 사망 시  `PoolManager`에게 오브젝트 반환 하는 메서드                 | `void`        | `Public`   |
| `PreloadAllWaveMonsters()`                       | 리스트를 순회하며 모든 몬스터 프리팹을 `PoolManager`에 등록하고 초기 생성 요청하는 메서드 | `void`        | `Private`  |
| `CalculateSpawnPosition()`                       | 플레이어 주변 범위 내의 랜덤한 위치를 계산하여 반환하는 메서드                      | `Vector2`     | `Public`   |

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

| Name                 | Description                      | Type                      | Visibility |
| :------------------- | :------------------------------- | :------------------------ | :--------- |
| `bgmClips`           | 배경 음악 리스트                 | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                         | Description                           | Type (Return) | Visibility |
| :--------------------------- | :------------------------------------ | :------------ | :--------- |
| `SetSfxVolume(level: float)` | 설정 파일을 읽어와서 효과음 불륨 적용 | `void`        | `public`   |

### 🏷️MonsterInfo

> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description                      | Type                      | Visibility |
| :------------------- | :------------------------------- | :------------------------ | :--------- |
| `bgmClips`           | 배경 음악 리스트                 | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                         | Description                           | Type (Return) | Visibility |
| :--------------------------- | :------------------------------------ | :------------ | :--------- |
| `SetSfxVolume(level: float)` | 설정 파일을 읽어와서 효과음 불륨 적용 | `void`        | `public`   |

### 📦PassiveData

> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description                      | Type                      | Visibility |
| :------------------- | :------------------------------- | :------------------------ | :--------- |
| `bgmClips`           | 배경 음악 리스트                 | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                         | Description                           | Type (Return) | Visibility |
| :--------------------------- | :------------------------------------ | :------------ | :--------- |
| `SetSfxVolume(level: float)` | 설정 파일을 읽어와서 효과음 불륨 적용 | `void`        | `public`   |

### 📦WeaponData

> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description                      | Type                      | Visibility |
| :------------------- | :------------------------------- | :------------------------ | :--------- |
| `bgmClips`           | 배경 음악 리스트                 | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                         | Description                           | Type (Return) | Visibility |
| :--------------------------- | :------------------------------------ | :------------ | :--------- |
| `SetSfxVolume(level: float)` | 설정 파일을 읽어와서 효과음 불륨 적용 | `void`        | `public`   |

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

> **Description:**ㄴ
> 몬스터/장비/아이템 도감 UI 전체를 관리하는 매니저 클래스  
> 각 도감 탭(몬스터, 장비, 아이템) 패널을 전환하고, `LootDataBase` 정보를 기반으로 `CodexSlot`을 동적 생성하여  
> 스크롤 뷰에 배치하며, 선택된 슬롯의 상세 정보를 `DescriptionPanel`에 표시하도록 연결하는 역할을 담당한다.

**🟢Attributes (속성)**

| Name               | Description                                              | Type               | Visibility |
| :----------------- | :------------------------------------------------------- | :----------------- | :--------- |
| `allCodexPanels`   | 몬스터/장비/아이템 도감 탭에 해당하는 모든 패널 배열     | `GameObject[]`     | `Private`  |
| `monsterContent`   | 몬스터 도감 슬롯이 배치될 ScrollView의 Content Transform | `Transform`        | `Private`  |
| `equipmentContent` | 장비(무기/패시브) 도감 슬롯이 배치될 Content Transform   | `Transform`        | `Private`  |
| `itemContent`      | 아이템 도감 슬롯이 배치될 Content Transform              | `Transform`        | `Private`  |
| `slotPrefab`       | 도감 슬롯 UI 프리팹(`CodexSlot` 컴포넌트 포함)           | `GameObject`       | `Private`  |
| `descriptionPanel` | 선택된 도감 슬롯의 상세 정보를 출력하는 설명 패널        | `DescriptionPanel` | `Private`  |

**🔷Operations (메서드)**

| Name                                 | Description                                                                                                                                      | Type (Return) | Visibility |
| :----------------------------------- | :----------------------------------------------------------------------------------------------------------------------------------------------- | :------------ | :--------- |
| `OpenPanel(targetPanel: GameObject)` | 전달받은 패널만 활성화하고 나머지 도감 패널은 비활성화하여 탭 전환을 처리하고, 선택 효과음을 재생하는 메서드                                     | `void`        | `Public`   |
| `RefreshCodex()`                     | 기존 도감 슬롯을 모두 제거한 뒤, `LootDataBase`에서 몬스터/장비/아이템 정보를 조회하여 슬롯을 동적 생성하고 `DescriptionPanel`과 연결하는 메서드 | `void`        | `Public`   |
| `ClearContent(content: Transform)`   | 전달받은 Content Transform의 모든 자식 슬롯 오브젝트를 제거하여 도감 UI를 초기화하는 유틸리티 메서드                                             | `void`        | `Private`  |

### 🏷️CodexSlot

> **Description:**
> 도감 UI 그리드 안에서 각 칸(슬롯)을 표현하는 컴포넌트.  
> 몬스터 / 아이템 / 장비 타입에 따라 아이콘을 설정하고, 슬롯 클릭 시 `DescriptionPanel`에 상세 정보를 띄우도록 버튼 이벤트를 연결하는 역할을 한다.

**🟢Attributes (속성)**

| Name                | Description                                              | Type               | Visibility |
| :------------------ | :------------------------------------------------------- | :----------------- | :--------- |
| `slot`              | 슬롯 전체를 클릭하기 위한 버튼 컴포넌트                  | `Button`           | `Private`  |
| `slotIcon`          | 도감 슬롯에 표시되는 아이콘 이미지                       | `Image`            | `Private`  |
| `slotSilhouette`    | 미해금 상태일 때 사용되는 실루엣(잠금) 아이콘 스프라이트 | `Sprite`           | `Private`  |
| `_descriptionPanel` | 슬롯이 클릭되었을 때 상세 정보를 표시할 대상 패널 참조   | `DescriptionPanel` | `Private`  |

**🔷Operations (메서드)**
| Name | Description | Type (Return) | Visibility |
| :---------------------------------------- | :--------------------------------------------------------------------------------------------------- | :------------ | :--------- |
| `SetMonster(data: Monster, unlocked: bool)` | 몬스터 도감 슬롯을 설정. 해금 여부에 따라 실제 아이콘 또는 실루엣을 설정하고, 클릭 시 몬스터 상세 정보를 보여주도록 버튼 이벤트를 등록한다. | `void` | `Public` |
| `SetItem(data: ItemData, unlocked: bool)` | 아이템 도감 슬롯을 설정. 해금 여부에 따라 아이콘/실루엣을 설정하고, 클릭 시 아이템 상세 정보 표시 이벤트를 등록한다. | `void` | `Public` |
| `SetEquip(data: EquipmentData, unlocked: bool)` | 장비 도감 슬롯을 설정. 해금 여부에 따라 아이콘/실루엣을 설정하고, 클릭 시 장비 상세 정보 표시 이벤트를 등록한다. | `void` | `Public` |
| `SetDescriptionPanel(panel: DescriptionPanel)` | 이 슬롯이 참조할 `DescriptionPanel`을 주입하여, 클릭 시 해당 패널을 통해 상세 정보를 출력할 수 있도록 연결하는 초기화 메서드 | `void` | `Public` |

### 🏷️DescriptionPanel

> **Description:**
> 도감에서 선택된 슬롯의 상세 정보를 화면에 표시하는 패널 UI 컴포넌트.  
> 몬스터 / 아이템 / 장비 타입에 따라 아이콘, 이름, 설명 텍스트를 갱신하며,  
> 해금 여부에 따라 실제 정보 또는 실루엣·잠금 문구를 보여준다. 필요 시 패널을 숨기는 기능도 제공한다.

**🟢Attributes (속성)**

| Name                    | Description                                               | Type              | Visibility |
| :---------------------- | :-------------------------------------------------------- | :---------------- | :--------- |
| `descriptionIcon`       | 상세 정보에 표시될 아이콘 이미지(몬스터/아이템/장비 공용) | `Image`           | `Private`  |
| `descriptionNameText`   | 상세 정보 상단에 표시되는 이름 텍스트                     | `TextMeshProUGUI` | `Private`  |
| `descriptionText`       | 상세 설명(효과, 설정 등)을 출력하는 본문 텍스트           | `TextMeshProUGUI` | `Private`  |
| `descriptionSilhouette` | 미해금 상태일 때 사용되는 공통 실루엣(잠금) 스프라이트    | `Sprite`          | `Private`  |

**🔷Operations (메서드)**

| Name                                             | Description                                                                                                                    | Type (Return) | Visibility |
| :----------------------------------------------- | :----------------------------------------------------------------------------------------------------------------------------- | :------------ | :--------- |
| `ShowMonster(data: Monster, unlocked: bool)`     | 몬스터 상세 정보를 패널에 표시. 해금 여부에 따라 아이콘/이름/설명을 실제 데이터 또는 잠금 표현으로 설정하고 패널을 활성화한다. | `void`        | `Public`   |
| `ShowItem(data: ItemData, unlocked: bool)`       | 아이템 상세 정보를 패널에 표시. 해금 여부에 따라 아이콘/이름/설명을 설정하고 패널을 활성화한다.                                | `void`        | `Public`   |
| `ShowEquip(data: EquipmentData, unlocked: bool)` | 장비 상세 정보를 패널에 표시. 해금 여부에 따라 아이콘/이름/설명을 설정하고 패널을 활성화한다.                                  | `void`        | `Public`   |
| `Hide()`                                         | 상세 정보 패널 전체를 비활성화하여 화면에서 숨기는 메서드                                                                      | `void`        | `Public`   |

### 🏷️FloatingText

> **Description:**
> 플레이어 머리 위 등에 잠깐 떠올랐다가 사라지는 연출용 텍스트를 담당하는 컴포넌트.  
> 시작 위치에서 위로 천천히 상승(rise)하면서, 일정 시간 동안 페이드인 → 유지 → 페이드아웃 애니메이션을 수행하고 애니메이션이 끝나면 스스로 `Destroy` 되는 일회성 UI 오브젝트 역할을 한다.

**🟢Attributes (속성)**

| Name             | Description                                         | Type          | Visibility |
| :--------------- | :-------------------------------------------------- | :------------ | :--------- |
| `riseDuration`   | 텍스트가 화면에 존재하는 총 지속 시간               | `float`       | `Private`  |
| `riseSpeed`      | 텍스트가 위로 상승하는 속도                         | `float`       | `Private`  |
| `fadeInDuration` | 생성 후 완전히 보이기까지 걸리는 페이드인 구간 시간 | `float`       | `Private`  |
| `fadeOutStart`   | 전체 진행도(0~1) 중 페이드아웃을 시작할 지점 비율   | `float`       | `Private`  |
| `_textMesh`      | 실제 텍스트를 표시하는 `TextMeshPro` 컴포넌트 참조  | `TextMeshPro` | `Private`  |
| `_elapsedTime`   | 생성 이후 누적 경과 시간                            | `float`       | `Private`  |
| `_originalColor` | 텍스트의 원래 색상(알파 변경 전 기본 색상)          | `Color`       | `Private`  |
| `_startPosition` | 텍스트가 떠오르기 시작하는 월드 좌표 시작 위치      | `Vector3`     | `Private`  |

**🔷Operations (메서드)**

| Name                                               | Description                                                                                                                                                            | Type (Return) | Visibility |
| :------------------------------------------------- | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------- | :------------ | :--------- |
| `Initialize(text: string, startPosition: Vector3)` | 표시할 텍스트와 시작 위치를 설정하고, 초기 색상을 완전 투명(알파 0)으로 만든 뒤 애니메이션을 시작할 준비를 하는 초기화 메서드                                          | `void`        | `Public`   |
| `FloatingAnimation()`                              | 경과 시간에 따라 텍스트의 상승 위치와 알파 값을 계산하여 페이드인/유지/페이드아웃 애니메이션을 적용하고, 지정 시간이 지나면 오브젝트를 삭제하는 내부 애니메이션 메서드 | `void`        | `Private`  |

### 📦HUDManager

> **Description:**
> 게임 플레이 중 화면에 표시되는 HUD(UI)를 총괄 관리하는 매니저 컴포넌트.  
> HP/EXP 바, 타이머, 골드/처치 수, 장비·아이템 슬롯, 보스 체력바, 퀘스트 패널 등  
> 다양한 UI 요소를 `PlayerManager`, `GameManager`, `InventoryManager`, `SpawnManager`, `EventManager`의 이벤트에 따라 갱신·표시한다.

**🟢Attributes (속성)**

| Name               | Description                                                      | Type               | Visibility |
| :----------------- | :--------------------------------------------------------------- | :----------------- | :--------- |
| `playerManager`    | 플레이어 현재 HP/EXP/골드/킬 수 등의 정보를 제공하는 매니저 참조 | `PlayerManager`    | `Private`  |
| `inventoryManager` | 장비 및 소비 아이템 정보를 관리하는 인벤토리 매니저 참조         | `InventoryManager` | `Private`  |
| `spawnManager`     | 보스 스폰 이벤트를 발생시키는 스폰 매니저 참조                   | `SpawnManager`     | `Private`  |
| `eventManager`     | 퀘스트 알림 등 커스텀 이벤트를 방송하는 이벤트 매니저            | `EventManager`     | `Private`  |
| `hpSlider`         | 플레이어 HP를 표시하는 슬라이더                                  | `Slider`           | `Private`  |
| `expSlider`        | 플레이어 경험치를 표시하는 슬라이더                              | `Slider`           | `Private`  |
| `timerText`        | 생존 시간(타이머)을 “MM:SS” 형식으로 표시하는 텍스트             | `TextMeshProUGUI`  | `Private`  |
| `goldText`         | 현재 보유 골드를 표시하는 텍스트                                 | `TextMeshProUGUI`  | `Private`  |
| `killCountText`    | 누적 처치 수를 표시하는 텍스트                                   | `TextMeshProUGUI`  | `Private`  |
| `weaponSlots`      | 공격형 장비(무기) 아이콘을 표시하는 이미지 슬롯 배열 (최대 6개)  | `Image[]`          | `Private`  |
| `passiveSlots`     | 패시브 장비 아이콘을 표시하는 이미지 슬롯 배열 (최대 6개)        | `Image[]`          | `Private`  |
| `itemSlots`        | 소비 아이템 아이콘을 표시하는 이미지 슬롯 배열 (최대 3개)        | `Image[]`          | `Private`  |
| `bossHpBarPanel`   | 보스 등장 시 표시되는 보스 HP 바 패널 오브젝트                   | `GameObject`       | `Private`  |
| `bossNameText`     | 현재 보스 이름을 표시하는 텍스트                                 | `TextMeshProUGUI`  | `Private`  |
| `bossHpBarSlider`  | 보스 체력을 비율로 표시하는 슬라이더                             | `Slider`           | `Private`  |
| `questInfo`        | 퀘스트 안내/알림을 보여주는 퀘스트 패널 오브젝트                 | `GameObject`       | `Private`  |
| `questInfoText`    | 현재 퀘스트 또는 알림 내용을 출력하는 텍스트                     | `TextMeshProUGUI`  | `Private`  |

**🔷Operations (메서드)**

| Name                                                | Description                                                                                                                                   | Type (Return) | Visibility |
| :-------------------------------------------------- | :-------------------------------------------------------------------------------------------------------------------------------------------- | :------------ | :--------- |
| `UpdateHpBar(currentHp: float, maxHp: float)`       | `PlayerManager.OnHpChanged` 이벤트를 받아 HP 슬라이더 값을 `currentHp / maxHp` 비율로 갱신한다.                                               | `void`        | `Private`  |
| `UpdateExpBar(currentExp: float, maxExp: float)`    | `PlayerManager.OnExpChanged` 이벤트를 받아 EXP 슬라이더 값을 `currentExp / maxExp` 비율로 갱신한다.                                           | `void`        | `Private`  |
| `UpdateTimerText(time: float)`                      | `GameManager.OnTimeChanged` 이벤트를 받아 경과 시간을 초 단위로 입력받아 “MM:SS” 포맷으로 변환 후 타이머 텍스트를 갱신한다.                   | `void`        | `Private`  |
| `UpdateGoldText(amount: int)`                       | `PlayerManager.OnGoldChanged` 이벤트를 받아 골드 텍스트를 현재 값으로 갱신한다.                                                               | `void`        | `Private`  |
| `UpdateKillCountText(amount: int)`                  | `PlayerManager.OnKillCountChanged` 이벤트를 받아 처치 수 텍스트를 현재 값으로 갱신한다.                                                       | `void`        | `Private`  |
| `InitHUD()`                                         | 게임 시작 시 HP/EXP/타이머/골드/킬 수의 초기값을 설정하고, 보스 HP 바 패널과 퀘스트 패널을 비활성화하며, 인벤토리 UI를 초기 갱신한다.         | `void`        | `Private`  |
| `UpdateInventoryUI()`                               | `InventoryManager.OnInventoryChanged` 이벤트를 받아 무기, 패시브, 아이템 슬롯을 각각 현재 인벤토리 상태에 맞게 아이콘/활성화 여부를 갱신한다. | `void`        | `Private`  |
| `UpdateSlots(slots: Image[], icons: List<Sprite>)`  | 주어진 슬롯 배열과 아이콘 리스트를 기반으로, 각 슬롯에 아이콘을 매칭하거나 비활성화하는 헬퍼 메서드(남는 슬롯은 숨김 처리).                   | `void`        | `Private`  |
| `ShowBossHpBarPanel(show: bool, boss: BossMonster)` | 보스 등장/퇴장 시 호출되어 보스 HP 바 패널을 보이거나 숨기고, 보스 이름과 HP 바를 초기 설정하며, 보스 HP 변경 이벤트에 구독/해제한다.         | `void`        | `Private`  |
| `UpdateBossHpBar(currentHp: float, maxHp: float)`   | `BossMonster.OnBossHpChanged` 이벤트를 받아 보스 HP 바 슬라이더 값을 `currentHp / maxHp` 비율로 갱신한다.                                     | `void`        | `Private`  |
| `ToggleQuestInfo(notificationMessage: string)`      | `EventManager.OnToggleEvent` 이벤트를 받아 퀘스트 패널의 활성/비활성 상태를 토글하고, 전달된 메시지로 퀘스트 텍스트를 갱신한다.               | `void`        | `Private`  |

### 🏷️InGamePanelManager

> **Description:**
> 인게임 동안 표시되는 일시정지 패널, 보상 선택 패널, 게임오버 패널을 관리하는 UI 매니저 컴포넌트.  
> `GameManager`가 호출하는 공개 메서드를 통해 각 패널의 표시/숨김을 제어하고,  
> `RewardManager`, `InventoryManager`, `GameManager`에서 제공하는 데이터로 패널 내부 텍스트와 아이콘을 갱신한다.

**🟢Attributes (속성)**

| Name                    | Description                                                  | Type               | Visibility |
| :---------------------- | :----------------------------------------------------------- | :----------------- | :--------- |
| `rewardManager`         | 보상 UI 상태 및 선택 이벤트를 제공하는 `RewardManager` 참조  | `RewardManager`    | `Private`  |
| `inventoryManager`      | 무기/패시브 인벤토리 정보를 제공하는 `InventoryManager` 참조 | `InventoryManager` | `Private`  |
| `playerImage`           | 일시정지/게임오버 패널에서 표시할 플레이어 이미지 스프라이트 | `Sprite`           | `Private`  |
| `pausePanel`            | 일시정지(UI) 전체 패널 오브젝트                              | `GameObject`       | `Private`  |
| `pausePlayerImage`      | 일시정지 패널에 표시되는 플레이어 이미지                     | `Image`            | `Private`  |
| `pauseTimerText`        | 일시정지 패널의 타이머 텍스트(플레이 시간)                   | `TextMeshProUGUI`  | `Private`  |
| `pauseWeaponSlots`      | 일시정지 패널의 공격형 장비 슬롯 이미지 배열 (최대 6개)      | `Image[]`          | `Private`  |
| `pausePassiveSlots`     | 일시정지 패널의 패시브 장비 슬롯 이미지 배열 (최대 6개)      | `Image[]`          | `Private`  |
| `rewardPanel`           | 보상 선택 패널 오브젝트                                      | `GameObject`       | `Private`  |
| `rewardSlots`           | 각 보상 카드를 선택하기 위한 버튼 슬롯 배열                  | `Button[]`         | `Private`  |
| `rewardsIcon`           | 보상 카드에 표시되는 아이콘 이미지 배열                      | `Image[]`          | `Private`  |
| `rewardsDescription`    | 각 보상의 설명 텍스트(UI Text) 배열                          | `Text[]`           | `Private`  |
| `rerollCostText`        | 리롤 비용을 표시하는 텍스트                                  | `TextMeshProUGUI`  | `Private`  |
| `rerollCountText`       | 남은 리롤 횟수를 표시하는 텍스트                             | `TextMeshProUGUI`  | `Private`  |
| `skipExpRatio`          | 스킵 시 획득할 경험치 비율을 표시하는 텍스트                 | `TextMeshProUGUI`  | `Private`  |
| `gameOverPanel`         | 게임오버 패널 오브젝트                                       | `GameObject`       | `Private`  |
| `gameOverPlayerImage`   | 게임오버 패널에 표시되는 플레이어 이미지                     | `Image`            | `Private`  |
| `gameOverTitleText`     | 게임오버 패널의 제목 텍스트(클리어/사망 등)                  | `TextMeshProUGUI`  | `Private`  |
| `gameOverTimerText`     | 게임오버 시점까지의 플레이 시간을 표시하는 타이머 텍스트     | `TextMeshProUGUI`  | `Private`  |
| `gameOverGoldText`      | 게임오버 시 보유 골드를 표시하는 텍스트                      | `TextMeshProUGUI`  | `Private`  |
| `gameOverKillCountText` | 게임오버 시 총 킬 수를 표시하는 텍스트                       | `TextMeshProUGUI`  | `Private`  |
| `gameOverWeaponSlots`   | 게임오버 패널의 공격형 장비 슬롯 이미지 배열                 | `Image[]`          | `Private`  |
| `gameOverPassiveSlots`  | 게임오버 패널의 패시브 장비 슬롯 이미지 배열                 | `Image[]`          | `Private`  |

**🔷Operations (메서드)**

| Name                                                      | Description                                                                                                                                              | Type (Return) | Visibility |
| :-------------------------------------------------------- | :------------------------------------------------------------------------------------------------------------------------------------------------------- | :------------ | :--------- |
| `ShowPausePanel(show: bool)`                              | `GameManager`가 호출하는 인터페이스. 일시정지 패널을 열거나 닫으며, 열릴 때 `UpdatePausePanel()`을 호출해 타이머·인벤토리·이미지를 최신 상태로 갱신한다. | `void`        | `Public`   |
| `ShowRewardPanel(show: bool)`                             | 보상 패널의 활성/비활성 상태를 제어하는 메서드. `RewardManager`에서 내용이 셋업된 패널을 표시하거나 숨긴다.                                              | `void`        | `Public`   |
| `ShowGameOverPanel(show: bool, clear: bool)`              | 게임오버 또는 클리어 시 호출되며, `clear` 여부에 따라 제목/내용을 설정하기 위해 `UpdateGameOverPanel(clear)`을 호출한 뒤 게임오버 패널을 표시/숨긴다.    | `void`        | `Public`   |
| `OnClickMainMenu()`                                       | 게임오버/일시정지 패널 내 ‘메인메뉴’ 버튼 클릭 시 호출되어 `GameManager.Instance.GoToMainMenu()`를 실행한다.                                             | `void`        | `Public`   |
| `OnClickRestart()`                                        | ‘다시하기’ 버튼 클릭 시 호출되어 `GameManager.Instance.RestartGame()`을 실행한다.                                                                        | `void`        | `Public`   |
| `OnClickResume()`                                         | ‘계속하기’ 버튼 클릭 시 호출되어 `GameManager.Instance.ResumeGame()`을 실행, 일시정지를 해제한다.                                                        | `void`        | `Public`   |
| `UpdateRewardTextUI(cost: int, count: int, ratio: float)` | 리롤 비용/횟수/스킵 경험치 비율을 UI에 반영하고, 비용 부족·리롤 불가 상태일 때는 텍스트 색상을 빨간색으로 표시하는 내부 콜백 메서드.                     | `void`        | `Private`  |
| `UpdateRewardUI(rewards: List<ScriptableObject>)`         | 전달된 보상 리스트(ItemData/EquipmentData)에 따라 아이콘과 설명 텍스트를 설정하고, 각 보상 버튼에 `rewardManager.OnRewardSelected()` 리스너를 등록한다.  | `void`        | `Private`  |
| `UpdatePausePanel()`                                      | 일시정지 패널의 플레이어 이미지, 현재까지의 게임 시간, 인벤토리(무기/패시브 슬롯)를 최신 상태로 갱신하는 헬퍼 메서드.                                    | `void`        | `Private`  |
| `UpdateGameOverPanel(clear: bool)`                        | 게임오버 패널의 제목(클리어/사망), 플레이 시간, 골드, 킬 수, 인벤토리 슬롯 이미지를 설정하는 메서드.                                                     | `void`        | `Private`  |
| `UpdateInventoryUI(weapons: Image[], passives: Image[])`  | 현재 `InventoryManager`의 무기/패시브 리스트를 읽어 전달된 슬롯 배열에 아이콘을 채우고, 남는 슬롯은 비활성화하는 인벤토리 UI 갱신 메서드.                | `void`        | `Private`  |
| `UpdateSlots(slots: Image[], icons: List<Sprite>)`        | 슬롯 배열과 아이콘 리스트를 순회하며 슬롯에 스프라이트를 설정하거나 비활성화하는 공용 헬퍼 함수.                                                         | `void`        | `Private`  |

### 📦MainMenuPanelManager

> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description                      | Type                      | Visibility |
| :------------------- | :------------------------------- | :------------------------ | :--------- |
| `bgmClips`           | 배경 음악 리스트                 | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                         | Description                           | Type (Return) | Visibility |
| :--------------------------- | :------------------------------------ | :------------ | :--------- |
| `SetSfxVolume(level: float)` | 설정 파일을 읽어와서 효과음 불륨 적용 | `void`        | `public`   |

### 📦TooltipController

> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description                      | Type                      | Visibility |
| :------------------- | :------------------------------- | :------------------------ | :--------- |
| `bgmClips`           | 배경 음악 리스트                 | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                         | Description                           | Type (Return) | Visibility |
| :--------------------------- | :------------------------------------ | :------------ | :--------- |
| `SetSfxVolume(level: float)` | 설정 파일을 읽어와서 효과음 불륨 적용 | `void`        | `public`   |

### 📦UpgradeSlot

> **Description:**
> 여기에 클래스 설명 작성

**🟢Attributes (속성)**

| Name                 | Description                      | Type                      | Visibility |
| :------------------- | :------------------------------- | :------------------------ | :--------- |
| `bgmClips`           | 배경 음악 리스트                 | `AudioClip[0..*]`         | `private`  |
| `OnGameStateChanged` | 게임 상태의 변경을 알리는 이벤트 | `event Action<GameState>` | `public`   |

**🔷Operations (메서드)**

| Name                         | Description                           | Type (Return) | Visibility |
| :--------------------------- | :------------------------------------ | :------------ | :--------- |
| `SetSfxVolume(level: float)` | 설정 파일을 읽어와서 효과음 불륨 적용 | `void`        | `public`   |
