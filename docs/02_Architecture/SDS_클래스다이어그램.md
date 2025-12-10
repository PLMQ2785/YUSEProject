## 📂 3.2.1 Core 관련 클래스

### 📦AudioManager
> **Description:**
> 게임의 모든 사운드를 관리하는 매니저 클래스


**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `Instance` | `AudioManager`의 싱글톤 인스턴스 | `AudioManager` | `Public Static` |
| `bgmSource` | 배경 음악 재생에 사용되는 컴포넌트 | `AudioSource` | `Private` |
| `sfxSource` | 효과음 재생에 사용되는 컴포넌트 | `AudioSource` | `Private` |
| `bgmClips` | 인스펙터에 할당된 BGM 클립 배열 | `AudioClip[]` | `Private` |
| `sfxClips` | 인스펙터에 할당된 SFX 클립 배열 | `AudioClip[]` | `Private` |
| `bgmDictionary` | BGM 클립 이름으로 검색하기 위한 딕셔너리 | `Dictionary<string, AudioClip>` | `Private` |
| `sfxDictionary` | SFX 클립 이름으로 검색하기 위한 딕셔너리 | `Dictionary<string, AudioClip>` | `Private` |
| `masterVolume` | 전체 마스터 볼륨 레벨 | `float` | `Private` |
| `bgmVolume` | BGM 개별 볼륨 레벨| `float` | `Private` |

**🔷Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `InitializeAudioDictionary()` | 배열의 내용을 클립을 이름으로 초기화하는 메서드 | `void` | `Private` |
| `PlayBGM(string clipName)` | 지정된 이름의 BGM 재생하는 메서드 | `void` | `Public` |
| `PlaySfx(string clipName)` | 지정된 이름의 SFX 클립을 재생하는 메서드 | `void` | `Public` |
| `StopBGM()` | BGM을 끄는 메서드 | `void` | `Public` |
| `SetMasterVolume(float level)` | 마스터 볼륨을 설정하고, 이 값을 반영하는 메서드 | `void` | `Public` |
| `SetBgmVolume(float level)` | BGM 개별 볼륨을 설정하고, 이 값을 반영하는 메서드 | `void` | `Public` |
| `SetSfxVolume(float level)` | SFX 개별 볼륨을 설정하고, 이 값을 반영하는 메서드 | `void` | `Public` |

### 📦GameManager
> **Description:**
> Manager 클래스들을 종합 관리하는 마스터 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `Instance` | `GameManager`의 씬을 넘나드는 싱글톤 인스턴스 | `GameManager` | `Public Static` |
| `OnTimeChanged` | 게임 시간이 변경될 때 발생하는 이벤트 | `event Action<float>` | `Public` |
| `OnGameStateChanged` | 게임 상태가 변경될 때 발생하는 이벤트 | `event Action<GameState>` | `Public` |
| `IsTimerStopped` | 타이머만 멈출지 여부를 설정하는 플래그  | `bool` | `Public` |
| `_currentState` | 현재 게임 상태를 저장하는 백킹 필드 | `GameState` | `Private` |
| `_gameTime` | 현재 플레이 시간을 저장하는 백킹 필드 | `float` | `Private` |
| `_playerManager` |  `PlayerManager` 인스턴스 참조  | `PlayerManager` | `Private` |
| `_rewardManager` |  `RewardManager` 인스턴스 참조 | `RewardManager` | `Private` |
| `_inGamePanelManager` |  `InGamePanelManager` 인스턴스 참조 | `InGamePanelManager` | `Private` |
| `_inputManager` |  `InputManager` 인스턴스 참조 | `InputManager` | `Private` |
| `MAIN_MENU_SCENE` | 메인 메뉴 씬 이름 상수  | `const string` | `Private` |
| `IN_GAME_SCENE` | 인게임 씬 이름 상수  | `const string` | `Private` |

**🔷Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `PauseGame()` | 게임을 일시정지하고, 게임시간을 멈추고, 일시정지 패널을 표시하는 메서드 | `void` | `Public` |
| `ResumeGame()` | 게임을 재개하고, 게임 시간을 흐르게 하고, 일시정지 패널을 닫는 메서드 | `void` | `Public` |
| `HandlePauseInput()` | `Playing` 상태와 `Paused` 상태를 토글하는 메서드  | `void` | `Private` |
| `GameOver()` | 게임 오버 처리 메서드 | `void` | `Public` |
| `GameClear()` | 게임 클리어 처리 메서드 | `void` | `Public` |
| `StartGame()` | 상태를 초기화하고  새 게임을 시작하는 메서드 | `void` | `Public` |
| `GoToMainMenu()` | 상태 초기화 후 메인 메뉴 씬을 로드하는 메서드| `void` | `Public` |
| `RestartGame()` | 게임을 다시 시작하는 메서드 | `void` | `Public` |
| `Shutdown()` | 애플리케이션을 종료하는 메서드| `void` | `Public` |
| `HandlePlayerLeveledUp()` | 플레이어 레벨업 또는 보물상자 획득 시 호출되며, 보상 시스템을 시작, 게임을 멈추는 메서드 | `void` | `Private` |
| `HandleRewardFinished()` | 보상을 받고나서, 보상 패널을 닫고 게임 재개하는 메서드  | `void` | `Private` |
| `OnSceneLoaded(Scene scene, LoadSceneMode mode)` | 씬 로드 시마다 호출되어 이전 씬 이벤트 구독을 해제하고, 인게임 씬인 경우 초기화하는 메서드| `void` | `Private` |
| `InitializeInGameManagers()` | 인게임 씬 로드 후 매니저들을 찾아 연결하고 필요한 이벤트를 구독하는 메서드 | `IEnumerator` | `Private` |
| `UnsubscribeInGameEvents()` | 씬 전환 또는 파괴 시 인게임 매니저들의 이벤트 구독을 안전하게 해제하는 메서드 | `void` | `Private` |

### 🏷️InputManager
> **Description:**
> 사용자의 입력을 관리하는 매니저 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `OnMovementInput` | 이동 입력이 변경될 때마다 호출되는 이벤트 | `event Action<Vector2>` | `Public` |
| `OnPausePressed` | 일시정지 키(ESC)가 눌렸을 때 호출되는 이벤트  | `event Action` | `Public` |
| `GetItemUseInput` | 아이템 슬롯 키가 눌렸을 때 호출되는 이벤트 | `event Action<int>` | `Public` |
| `HORIZONTAL` | 수평 이동 축 이름 상수 | `const string` | `Private` |
| `VERTICAL` |  수직 이동 축 이름 상수 | `const string` | `Private` |
| `JUMP`, `MOUSE_X`, `MOUSE_Y` | 입력 축 이름 상수 | `const string` | `Private` |
| `horizontalInput` | 현재 수평 입력 값 | `float` | `Private ` |
| `verticalInput` | 현재 수직 입력 값 | `float` | `Private ` |
| `mouseXInput` | 현재 마우스 X축 입력 값 | `float` | `Private ` |
| `mouseYInput` | 현재 마우스 Y축 입력 값 | `float` | `Private ` |
| `jumpInput` | 점프 입력 상태 (프레임당 `GetButtonDown`) | `bool` | `Private` |
| `pauseInput` | 일시정지 입력 상태 (ESC 키) | `bool` | `Private` |
| `dashInput` | 대시 입력 상태 (Space 키) | `bool` | `Private` |
| `useItemInput` | 사용하려는 아이템 슬롯 번호 | `int` | `Private` |

**🔷Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `Init()` | 모든 입력 값을 초기화하는 메서드 | `void` | `Public` |
| `ProcessInput()` | 매 프레임 입력 상태를 받아와 필드에 저장하고, 유효한 입력에 대해 이벤트 방송하는 메서드| `void` | `Public` |
| `IsKeyPressed(KeyCode keyCode)` | 특정 키가 눌리고 있는지 확인하는 메서드| `bool` | `Public` |
| `IsKeyDown(KeyCode keyCode)` | 특정 키가 눌렸는지 확인하는 메서드| `bool` | `Public` |
| `GetMouseCoord()` | 현재 마우스 커서의 씬 좌표를 반환하는 메서드| `Vector2` | `Public` |
| `IsMouseButtonPressed(int button)` | 특정 마우스 버튼을 누르고 있는지 확인하는 메서드 | `bool` | `Public` |
| `IsMouseButtonDown(int button)` | 특정 마우스 버튼이 눌렸는지 확인하는 메서드 | `bool` | `Public` |

### 🏷️PoolManager
> **Description:**
> 오브젝트 풀링 시스템을 구현한 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `Instance` | `PoolManager`의 싱글톤 인스턴스 | `PoolManager` | `Public Static` |
| `_pools` | Instance ID를 통해 풀 관리용 딕셔너리 | `Dictionary<int, Queue<GameObject>>` | `Private` |
| `_containers` | Hierarchy 정리를 위한, 풀별 부모를 관리하는 딕셔너리 | `Dictionary<int, Transform>` | `Private` |

**🔷Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `Get(GameObject prefab, Vector3 position, Quaternion rotation)` | 풀에서 오브젝트를 가져와 활성화하고 위치/회전을 설정하는 메서드| `GameObject` | `Public` |
| `ReturnToPool(GameObject obj, GameObject prefab)` | 사용이 끝난 오브젝트를 비활성화하고 해당 프리팹의 풀에 반환하는 메서드 | `void` | `Public` |
| `Preload(GameObject prefab, int count)` | 특정 프리팹에 대해 지정된 개수만큼 오브젝트를 미리 생성하는 메서드| `void` | `Public` |
| `InitPool(GameObject prefab)` | 풀이 들어갈 부모를 초기화 하는 메서드 | `void` | `Private`|

### 📦SaveManager
> **Description:**
> 게임 내용을 저장하고 불러오는 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `KEY_GOLD` | 골드 저장 키 상수 | `const string` | `Private` |
| `KEY_MASTER_VOLUME` | 마스터 볼륨 설정 저장 키 상수 | `const string` | `Private` |
| `KEY_BGM_VOLUME` | BGM 볼륨 설정 저장 키 상수 | `const string` | `Private` |
| `KEY_SFX_VOLUME` | SFX 볼륨 설정 저장 키 상수 | `const string` | `Private` |
| `KEY_UPGRADE_PREFIX` | 능력치 강화 레벨 저장 키 접두사 상수 (`"Upgrade_"`) | `const string` | `Private` |
| `KEY_UNLOCKED_MONSTERS` | 몬스터 도감 언락 목록 저장 키 상수| `const string` | `Private` |
| `KEY_UNLOCKED_EQUIPMENT` | 장비 도감 언락 목록 저장 키 상수| `const string` | `Private` |
| `KEY_UNLOCKED_ITEMS` | 아이템 도감 언락 목록 저장 키 | `const string` | `Private` |
| `UnlockData` | `HashSet<string>`을 JSON 직렬화하기 위한 래퍼 클래스 | `class` | `Private` |

**🔷Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `Save()` | `PlayerPrefs`에 임시 저장된 모든 데이터를 영구 저장하는 메서드 | `void` | `Public Static` |
| `DeleteAll()` | `PlayerPrefs`에 저장된 데이터 삭제하는 메서드  | `void` | `Public Static` |
| `HasKey(string key)` | 지정된 키에 해당하는 데이터가 있는지 확인하는 메서드| `bool` | `Public Static` |
| `SaveGold(int amount)` | 현재 골드 저장하는 메서드 | `void` | `Public Static` |
| `LoadGold()` | 저장된 골드를 불러오는 메서드 | `int` | `Public Static` |
| `SaveUpgradeLevel(UpgradeType upgradeType, int level)` | 특정 능력치의 강화 레벨을 저장하는 메서드 | `void` | `Public Static` |
| `LoadUpgradeLevel(UpgradeType upgradeType)` | 특정 능력치의 강화 레벨을 불러오는 메서드 | `int` | `Public Static` |
| `GetUpgradeKey(UpgradeType upgradeType)` | `UpgradeType`을 기반으로 고유한 저장 키 문자열을 생성하는 메서드 | `string` | `Private Static` |
| `SaveUnlockedMonsters(HashSet<string> unlockedIds)` | 몬스터 언락 ID 목록을 저장하는 메서드 | `void` | `Public Static` |
| `LoadUnlockedMonsters()` | 몬스터 언락 ID 목록을 불러오는 메서드 | `HashSet<string>` | `Public Static` |
| `SaveUnlockedEquipment(HashSet<string> unlockedIds)` | 장비 언락 ID 목록을 저장하는 메서드 | `void` | `Public Static` |
| `LoadUnlockedEquipment()` | 장비 언락 ID 목록을 불러오는 메서드 | `HashSet<string>` | `Public Static` |
| `SaveUnlockedItems(HashSet<string> unlockedIds)` | 아이템 언락 ID 목록을 저장하는 메서드 | `void` | `Public Static` |
| `LoadUnlockedItems()` | 아이템 언락 ID 목록을 불러오는 메서드| `HashSet<string>` | `Public Static` |
| `SaveVolume(string volumeType, float value)` | 마스터, BGM, SFX 볼륨 값을 저장하는 메서드| `void` | `Public Static` |
| `LoadVolume(string volumeType, float defaultValue = 1.0f)` | 지정된 볼륨 타입의 값을 불러오는 메서드 | `float` | `Public Static` |

### 📦SettingManager
> **Description:**
> 게임 해상도 설정하는 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `resolutionDropdown` | 해상도 목록을 표시하는 UI 드롭다운 컴포넌트 | `TMP_Dropdown` | `Private` |
| `fullScreenToggle` | 전체화면 여부를 설정하는 UI 토글 컴포넌트 | `Toggle` | `Private` |
| `masterSlider` | 마스터 볼륨 설정용 UI 슬라이더 컴포넌트 | `Slider` | `Private` |
| `bgmSlider` | BGM 볼륨 설정용 UI 슬라이더 컴포넌트 | `Slider` | `Private` |
| `sfxSlider` | SFX 볼륨 설정용 UI 슬라이더 컴포넌트 | `Slider` | `Private` |
| `resolutionIndex` | 선택된 해상도 번호 | `int` | `Private` |
| `isFullScreen` | 전체화면 여부 설정 | `bool` | `Private` |
| `targetResolution` | Unity에서 지원하는 해상도 목록 | `List<Resolution>` | `Private` |

**🔷Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `SetResolution(int index)` | UI 드롭다운에서 선택된 해상도 번호를 임시 변수에 저장하는 메서드| `void` | `Public` |
| `PickFullScreen(bool isFull)` | UI 토글에서 선택된 전체화면 여부를 임시 변수에 저장하는 메서드| `void` | `Public` |
| `ApplyResolution()` | 선택된 해상도 옵션을 적용하는 메서드| `void` | `Public` |
| `Init_Resolution()` | 시스템에서 지원하는 해상도 목록을 가져와 ui에 반영하는 메서드 | `void` | `Private` |
| `Init_VolumeSettings()` | 저장된 사운드 세팅을 가져와서 ui를 초기화 하는 메서드 | `void` | `Private` |

### 📦UpgradeManager
> **Description:**
> 플레이어 능력치 강화하는 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `Instance` | `UpgradeManager`의 싱글톤 인스턴스 | `UpgradeManager` | `Public Static` |
| `OnGoldChanged` | 현재 골드가 변경될 때 발생하는 이벤트 | `event Action<int>` | `Public` |
| `OnUpgradeChanged` | 특정 업그레이드의 레벨이 변경될 때 발생하는 이벤트 | `event Action<UpgradeType, int>` | `Public`|
| `AvailableUpgrades` | 게임 내에서 사용 가능한 모든 업그레이드 데이터 리스트 | `List<UpgradeData>` | `Public` |
| `availableUpgrades` |  업그레이드 데이터 리스트 | `List<UpgradeData>` | `Private` |
| `_currentGold` | 현재 플레이어가 보유한 골드 양 | `int` | `Private` |
| `_upgradeLevels` | 각 업그레이드의 레벨을 저장하는 딕셔너리 | `Dictionary<UpgradeType, int>` | `Private` |

**🔷Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `GetUpgradeLevel(UpgradeType type)` | 특정 업그레이드 타입의 현재 레벨을 반환하는 메서드 | `int` | `Public` |
| `GetStatBonus(UpgradeType type)` | 특정 업그레이드 타입의 스텟 보너스를 반환하는 메서드 | `float` | `Public` |
| `Purchase(UpgradeData data)` | 업그레이드의 조건을 만족하면 구매하고 이벤트를 방송 하는 메서드 | `bool` | `Public` |
| `Refund(UpgradeData data)` | 조건을 만족하면 업그레이드 구매를 환불 해주고 이벤트를 방송하는 메서드 | `bool` | `Public` |
| `LoadData()` | 저장된 강화 레벨과 골드를 가지고와 UI에 반영하는 메서드 | `void` | `Private` |

---

## 📂 3.2.2 Enemies 관련 클래스

### 🏷️BossMonster
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

### 📦EnemyReposition
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

### 📦Monster
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

### 🏷️NormalMonster
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

### 🏷️Projectile2
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

### 📦SpawnManager
> **Description:**
> 몬스터 생성을 관리하는 매니저 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `OnBossSpawned` | 보스 스폰 또는 처치를 알리는 이벤트 | `event Action<bool,BossMonster>` | `Public` |
| `playerTransform` | 플레이어의 위치 참조  | `Transform` | `Private` |
| `waves` | 시간 순서대로 정의된 웨이브 데이터 리스트 | `List<WaveData>` | `Private` |
| `bossPrefab` | 보스 몬스터 프리팹 | `BossMonster` | `Private` |
| `spawnRadius` | 몬스터 스폰 위치를 계산할 때 사용하는 플레이어 주변 범위 | `float` | `Private` |
| `bossSpawnCycle` | 보스가 스폰되는 시간 주기  | `float` | `Private` |
| `initialPerTypeSize` | PoolManager에 타입별로 미리 로드할 초기 몬스터 수량 | `int` | `Private` |
| `_currentWave` | 현재 활성화된 `WaveData` 참조 | `WaveData` | `Private` |
| `_bossLevel` | 현재 스폰해야 할 보스의 레벨 | `int` | `Private` |
| `_isBossActive` | 현재 필드에 보스가 활성화 여부 | `bool` | `Private` |
| `_activeMonsters` | 현재 필드에 활성화된 몬스터 리스트  | `List<Monster>` | `Private` |
| `_spawnTimers` | 각 몬스터 타입별 스폰 간격을 조절하는 타이머 | `Dictionary<MonsterSpawnInfo, float>` | `Private` |


| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `UpdateWaveData(float time)` | 현재 시간을 기반으로 몬스터의 스폰 패턴을 정의하는 메서드 | `void` | `Private` |
| `ProcessWaveSpawning()` | 현제 웨이브 데이터에 따라 몬스터 소환하는 메서드| `void` | `Private` |
| `SpawnBoss()` | 보스를 소환하고 이벤트 방송하는 메서드 | `void` | `Private` |
| `OnBossDied(Monster boss)` | 보스 사망시 이벤트 방송하는 메서드| `void` | `Private` |
| `SpawnMonster(Monster prefab, Vector2 position)` | 몬스터 오브젝트를 가져와 초기화하고 스폰 리스트에 추가하는 메서드| `void` | `Public` |
| `ReturnToPool(Monster monster, Monster prefab)` | 몬스터 사망 시  `PoolManager`에게 오브젝트 반환 하는 메서드 | `void` | `Public` |
| `PreloadAllWaveMonsters()` | 리스트를 순회하며 모든 몬스터 프리팹을 `PoolManager`에 등록하고 초기 생성 요청하는 메서드 | `void` | `Private` |
| `CalculateSpawnPosition()` | 플레이어 주변 범위 내의 랜덤한 위치를 계산하여 반환하는 메서드 | `Vector2` | `Public` |

## 📂 3.2.3 Gameplay 관련 클래스

### 📦AcquireableObject
> **Description:**
> 플레이어가 획득할 수 있는 오브젝트의 기본 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `Position` | 오브젝트 자신의 위치  | `Vector2` | `Public` |
| `moveSpeed` | 플레이어에게 끌려갈 때의 속도 | `float` | `Public` |
| `currentTarget` | `PlayerMager` 참조 | `PlayerManager` | `Protected` |
| `_isMovingToPlayer` | 플레이어에게 끌려가는 중인지 여부 | `bool` | `Private` |

**🔷Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `StartMoveTo(PlayerManager target)` | 플레이어 쪽으로 이동하는 메서드 | `void` | `Public` |
| `StopMove()` | 이동을 멈추는 메서드| `void` | `Public` |
| `MoveToPlayer(PlayerManager target)` | 플레이어에게 이동한 다음 가까워지면 획득 처리 하는 메서드| `void` | `Public` |
| `OnAcquire(PlayerManager player)` | 획득 시 실제로 발생하는 효과를 정의하는 추상 메서드 | `abstract void` | `Public` |

### 📦EventManager
> **Description:**
> 게임이 진행되는 동안 발생하는 이벤트를 관리하는 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `Instance` | `EventManager`의 싱글톤 인스턴스 | `EventManager` | `Public Static` |
| `playerManager` | `PlayerManager` 참조 | `PlayerManager` | `Private` |
| `possibleEvents` | 발생 가능한 모든 게임 이벤트 데이터 리스트 | `List<GameEventData>` | `Private` |
| `minEventInterval` | 이벤트 발생 최소 주기 | `float` | `Private` |
| `maxEventInterval` | 이벤트 발생 최대 주기 | `float` | `Private` |
| `OnToggleEvent` | 이벤트 시작/종료 시 구독자에게 알리는 이벤트 | `event Action<string>` | `Public` |
| `_timer` | 현재 이벤트 주기를 측정하는 타이머 | `float` | `Private` |
| `_nextEventTime` | 다음 이벤트가 발생해야 할 시간 | `float` | `Private` |
| `_currentEvent` | 현재 활성화된 이벤트 데이터 | `GameEventData` | `Private` |

**🔷Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `SetNextEventTime()` | 다음 이벤트 발생시간을 설정하고 타이머를 초기화하는 메서드| `void` | `Private` |
| `TriggerRandomEvent()` | 이벤트 리스트에서 무작위로 하나의 이벤트를 선택하는 메서드 | `void` | `Public` |
| `StartEvent(GameEventData eventData)` | 선택된 이벤트를 실행하는 메서드 | `void` | `Public` |
| `ProcessEventRoutine(GameEventData eventData)` | 이벤트 시작부터 끝날때까지 모든 단계를 순차적으로 처리하는 코루틴 메서드 | `IEnumerator` | `Private` |
| `EndEvent(GameEventData eventData)` | 이벤트를 종료시, 활성화 된 모든 이벤트의 효과를 해제하고 다음 이벤트를 준비하는 메서드 | `void` | `Private` |

### 📦GameEventData
> **Description:**
> 게임 이벤트에 대한 데이터 구조를 담는 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `eventName` | 이벤트의 이름 | `string` | `Public` |
| `description` | 이벤트에 대한 상세 설명  | `string` | `Public` |
| `notificationMessage` | 이벤트 시작/종료 시 UI에 표시될 메시지 | `string` | `Public` |
| `duration` | 이벤트가 지속될 시간  | `float` | `Public` |
| `statModifiers` | 수정할 능력치 종류와 수치 값을 가진 구조체를 담는 리스트 | `List<StatModifier>` | `Public` |



### 📦Reposition
> **Description:**
> 청크를 재배치함으로써 무한맵처럼 보이게 하는 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `chunkSize` | 맵 청크 하나의 크기 | `float` | `Private` |


**🔷Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `RepositionMapChucnk(Vector3 distance)` | 플레이어와 청크 간의 거리를 기반으로 청크를 재배치하는 메서드 | `void` | `Private` |



### 📦RewardManager
> **Description:**
> 레벨업시 제공되는 보상을 관리하는 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `OnRewardProcessFinished` | 보상 선택/스킵 완료 시 발생하는 이벤트| `event Action` | `Public` |
| `OnRewardTextUIChanged` | 보상 패널의 텍스트 정보 갱신 이벤트 | `event Action<int,int,float>` | `Public` |
| `OnRewardUIChanged` | 보상 카드 목록 갱신 이벤트 | `event Action<List<ScriptableObject>>` | `Public` |
| `playerManager` | `PlayerManager` 참조 | `PlayerManager` | `Private` |
| `lootDataBase` | `LootDataBase` 참조 | `LootDataBase` | `Private` |
| `inventoryManager` | `InventoryManager` 참조 | `InventoryManager` | `Private` |
| `_maxRerollCount` | 최대 리롤 횟수 | `int` | `Private` |
| `_rerollCount` | 현재 남은 리롤 횟수 | `int` | `Private` |
| `_baseRerollPrice` | 기본 리롤 비용 | `int` | `Private` |
| `_rerollPrice` | 현재 리롤에 필요한 골드 비용 | `int` | `Private` |
| `_skipExpRatio` | 보상 스킵 시 얻는 최대 경험치 대비 비율 | `float` | `Private` |

**🔷Operations (메서드)**

Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `GenerateRewards()` | 3개의 무작위 보상 생성하는 메서드 | `void` | `Public` |
| `OnRewardSelected(ScriptableObject data)` | 보상을 선택하면 선택 장비/아이템을 추가하는 메서드| `void` | `Public` |
| `OnRerollPressed()` | 리롤버튼을 누르면 새로운 보상을 생성하는 메서드  | `void` | `Public` |
| `OnSkipPressed()` | 스킵버튼을 누르면 경험치를 지급하는 메서드| `void` | `Public` |


### 📦UpgradeData
> **Description:**
> 업그레이드 데이터를 담는 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `upgradeName` | 업그레이드의 이름 | `string` | `Private` |
| `description` | 업그레이드에 대한 상세 설명 | `string` | `Private` |
| `upgradeType` | 업그레이드하는 스텟 종류  | `UpgradeType` | `Private` |
| `baseCost` | 업그레이드의 기본 비용 | `int` | `Private` |
| `maxLevel` | 도달 가능한 최대 레벨 | `int` | `Private` |
| `valuePerLevel` | 레벨당 획득하는 스탯 보너스 값 | `float` | `Private` |

**🔷Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `GetCostForLevel(int currentLevel)` | 레벨당 비용 증가시키는 메서드 | `int` | `Public` |
| `GetTotalBonus(int currentLevel)` | 현재 레벨까지 누적된 총 스텟 보너스를 계산해서 반환하는 메서드 | `float` | `Public` |

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
> 플레이어가 획득한 무기, 패시브 장비, 소모성 아이템 관리하는 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `playerManager` | `PlayerManager` 참조 | `PlayerManager` | `Private` |
| `weaponParent` | 무기 및 패시브 오브젝트가 생성될 부모  | `Transform` | `Private` |
| `maxWeaponSlots` | 보유 가능한 최대 무기 슬롯 개수 | `int` | `Private` |
| `maxPassiveSlots` | 보유 가능한 최대 패시브 슬롯 개수 | `int` | `Private` |
| `maxItemSlots` | 보유 가능한 최대 소모성 아이템 슬롯 개수 | `int` | `Private` |
| `OnInventoryChanged` | 인벤토리 내용 변경 시 UI 갱신을 위해 호출되는 이벤트 | `event Action` | `Public` |
| `_weapons` | 현재 플레이어가 보유한 `Weapon` 인스턴스 리스트 | `List<Weapon>` | `Private` |
| `_passives` | 현재 플레이어가 보유한 `Passive` 인스턴스 리스트 | `List<Passive>` | `Private` |
| `_consumables` | 현재 플레이어가 보유한 `Item` 인스턴스 리스트 | `List<Item>` | `Private` |

**🔷Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `Initialize(PlayerManager player)` | 플레이어 매니저 초기화 메서드 | `void` | `Public` |
| `Add(EquipmentData data)` | 장비를 추가하거나 보유 중이면 레벨 업시키는 메서드 | `void` | `Public` |
| `Add(ItemData data)` | 소모성 아이템을 추가하는 메서드 | `void` | `Public` |
| `FindItem(EquipmentData data)` | 할성화된 무기와 패시브의 데이터를 반환하는 메서드 | `EquipmentBase` | `Public` |
| `UseItem(int slotIndex)` | 아이템을 사용 메서드 | `void` | `Public` |
| `AddWeapon(WeaponData data)` | 무기를 추가하는 메서드| `void` | `Private` |
| `AddPassive(PassiveData data)` | 인벤토리에 패시브 아이템을 추가하는 메서드 | `void` | `Private` |
| `AddConsumable(ItemData data)` | 아이템을 추가하는 메서드| `void` | `Private` |

### 📦PlayerMagnet
> **Description:**
> 플레이어 자석 기능 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `orbLayer` | 감지 대상이 되는 경험치의 레이어 마스크 | `LayerMask` | `Private` |
| `maxTargetsPerFrame` | 한 번의 감지로 처리할 수 있는 최대 오브젝트 수 | `int` | `Private` |
| `_playerManager` | 플레이어의 능력치와 위치 정보를 가져오기 위한 참조 | `PlayerManager` | `Private` |
| `_results` | 주위 획득 가능 오브젝트 저장 배열 | `Collider2D[]` | `Private` |

**🔷Operations (메서드)**

| Name                            | Description             | Type (Return) | Visibility |
|:--------------------------------|:------------------------|:--------------|:-----------|
| `magnet()`    | 획득가능한 오브젝트를 끌어당기는 메서드   | `void`        | `private`   |

### 🏷️PlayerManager
> **Description:**
> 플레이어 객체를 관리하는 매니저 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `OnHpChanged` | HP 변경 시 호출되는 이벤트 | `event Action<float, float>` | `Public` |
| `OnExpChanged` | 경험치 변경 시 호출되는 이벤트  | `event Action<float, float>` | `Public` |
| `OnGoldChanged` | 골드 변경 시 호출되는 이벤트 | `event Action<int>` | `Public` |
| `OnKillCountChanged` | 킬 카운트 변경 시 호출되는 이벤트 | `event Action<int>` | `Public` |
| `OnPlayerLeveledUp` | 레벨 업 시 호출되는 이벤트  | `event Action` | `Public` |
| `OnPlayerGetTreasure` | 보물 상자 획득 시 호출되는 이벤트 | `event Action` | `Public` |
| `FacingDirection` | 플레이어가 현재 바라보는 방향  | `Vector2` | `Public` |
| `inputManager` | `InputManager` 참조 | `InputManager` | `Private` |
| `UpgradeManager` | `UpgradeManager` 참조 | `UpgradeManager` | `Private` |
| `inventoryManager` | `InventoryManager` 참조 | `InventoryManager` | `Private` |
| `startingWeapon` | 게임 시작 시 지급될 기본 무기 데이터 | `WeaponData` | `Private` |
| `stats` | 플레이어 능력치 데이터 | `PlayerStats` | `Private` |
| `contactDamageCooldown` | 피격 후 무적시간 | `float` | `Private` |
| `dashDistance` | 대시 시 이동할 거리 | `float` | `Private` |
| `dashDuration` | 대시가 지속되는 시간 | `float` | `Private` |
| `dashCooldown` | 대시 후 재사용까지의 쿨다운 시간 | `float` | `Private` |
| `dashDamage` | 대시 데미지 | `float` | `Private` |
| `dashDamageRadius` | 대시 데미지 범위 | `float` | `Private` |
| `lightningEffectPrefab` | 대시 번개 이펙트 프리펩 | `Gameobject` | `private` |
| `floatingTextOffPrefab` | 대시 쿨타임 알림창 프리펩| `Gameobject` | `private` |
| `floatingTextOffset` | 대시 알림 시작 위치 offset | `Vector3`| `private`|
| `_currentHp` | 현재 HP | `float` | `Private` |
| `_level` | 현재 레벨  | `int` | `Private` |
| `_currentExp` | 현재 경험치 | `int` | `Private` |
| `_maxExp` | 다음 레벨에 필요한 최대 경험치  | `int` | `Private` |
| `_gold` | 현재 보유 골드 | `int` | `Private` |
| `_killCount` | 현재 킬 카운트 | `int` | `Private` |
| `_contactDamageTimer` | 충돌 무적 시간 타이머 | `float` | `Private` |
| `_isDashing` | 현재 대시 중인지 여부 | `bool` | `Private` |
| `_dashCooldownTimer` | 대시 재사용 쿨다운 타이머 | `float` | `Private` |
| `_lastMoveDirection` | 플레이어가 마지막으로 이동했던 방향 | `Vector2` | `Private` |
| `_originalLayer` | 대시 충돌 무시를 위해 저장해 둔 플레이어의 원래 레이어 | `int` | `Private` |

**🔷Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `HandleItemUseInput(int slotNumber)` | 아이템 사용 메서드 | `void` | `Private` |
| `TakeDamage(float amount)` | 몬스터 공격으로 인한 데미지를 받는 메서드 | `void` | `Public` |
| `Heal(float amount)` | 플레이의 HP를 회복 시키는 메서드 | `void` | `Public` |
| `TakeDamage(float amount, bool isContactDamage)` | 몬스터 충돌로 인한 데미지를 받는 메서드| `void` | `Public` |
| `GainExp(int amount)` | 경험치를 획득하는 메서드 | `void` | `Public` |
| `GainGold(int amount)` | 골드 획득하는 메서드 | `void` | `Public` |
| `SpendGold(int amount)` | 골드 소비하는 메서드 | `bool` | `Public` |
| `GainTreasure()` | 보물 상자 획득 메서드 | `void` | `Public` |
| `GainKillCount(int amount)` | 킬 카운트를 증가시키는 메서드 | `void` | `Public` |
| `AddEquipment(EquipmentData data)` | 장비를 획득하는 메서드 | `void` | `Public` |
| `AddItem(ItemData data)` | 아이템을 획득하는 메서드 | `void` | `Public` |
| `AddPassiveBonus(UpgradeType type, object source, float value)` | 패시브 아이템 등에 의한 스탯 보너스를 적용하는 메서드 | `void` | `Public` |
| `ApplyEventModifiers(object eventSource, List<StatModifier> modifiers)` | 이벤트 발생시 플레이어 능력치를 오르게 하는 메서드 | `void` | `Public` |
| `RemoveEventModifiers(object eventSource, List<StatModifier> modifiers)` | 이벤트 종료시 증가된 능력치를 제거하는 메서드 | `void` | `Public` |
| `RemovePassiveBonus(UpgradeType type, object source)` | 패시브 아이템  의한 스탯 보너스 능력치를 제거하는 메서드 | `void` | `Public` |
| `EquipStartingWeapon()` | 기본무기 지급 메서드 | `void` | `Private` |
| `Move(Vector2 direction)` | 플레이어 이동시키는 메서드 | `void` | `Private` |
| `Die()` | 플레이어 사망을 처리하는 메서드 | `void` | `Private` |
| `Player_Animation()` | 플레이어 애니메이션 동작 메서드 | `void` | `Private` |
| `LevelUp()` | 플레이어 레벨 업 시키는 메서드  | `void` | `Private` |
| `ApplyUpgradeBonuses()` | 플레이어 스텟을 강화하는 메서드 | `void` | `Private` |
| `TryDash()` | 플레이어를 대시시키는 메서드 | `void` | `Private` |
| `DashCoroutine(Vector2 direction)` | 대시 행동 로작 정의 메서드 | `IEnumerator` | `Private` |
| `DealDashDamage(HashSet<Monster> damagedMonsters)` | 주변 적에게 대시 피해를 입히는 메서드 | `void` | `Private` |
| `SpawnLightningEffect(Vector2 startPos, Vector2 endPos)` | 대시 경로에 번개 이펙트를 생성하는 메서드 | `void` | `Private` |
| `InvincibilityFlashCoroutine()` | 무적 시간동안 플레이어를 깜빡이는 메서드 | `IEnumerator` | `Private` |
| `ShowDashCooldownText()` | 대시 쿨다운을 알려주는 텍스트를 띄워주는 메서드 | `void` | `Private` |

### 📦PlayerStats
> **Description:**
> 플레이어의 능력치를 정의하는 클래스

**🟢Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `maxHp` | 기본 최대 HP | `float` | `Private` |
| `speed` | 기본 이동 속도 | `float` | `Private` |
| `attackDamageMult` | 기본 공격 피해 배율 | `float` | `Private` |
| `attackSpeedMult` | 기본 공격 속도 배율 | `float` | `Private` |
| `cooldownMult` | 기본 쿨다운 감소 배율 | `float` | `Private` |
| `magnetRange` | 기본 아이템 획득 범위 | `float` | `Private` |
| `critChance` | 기본 치명타 확률 | `float` | `Private` |
| `critDamageMult` | 기본 치명타 피해 배율 | `float` | `Private` |
| `expMult` | 기본 경험치 획득 배율 | `float` | `Private` |
| `goldMult` | 기본 골드 획득 배율 | `float` | `Private` |
| `damageReductionMult` | 기본 피해 감소율 | `float` | `Private` |
| `_permanentBonuses` |  업그레이드 전용 능력치 보너스 | `Dictionary<UpgradeType, float>` | `Private` |
| `_passiveBonuses` | 패시브 장비 전용 능력치 보너스  | `Dictionary<UpgradeType, Dictionary<object, float>>` | `Private` |
| `_eventBonuses` | 이벤트 버프/디버프 전용 능력치 보너스  | `Dictionary<UpgradeType, Dictionary<object, float>>` | `Private` |

**🔷Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `SetPermanentBonus(UpgradeType type, float value)` |업그레이드에 의한 능력치 보너스를 설정하는 메서드 | `void` | `Public` |
| `SetPassiveBonus(UpgradeType type, object source, float value)` | 패시브 장비에 의한 능력치 보너스를 설정하는 메서드| `void` | `Public` |
| `RemovePassiveBonus(UpgradeType type, object source)` | 패시브 장비에 의한능력치 보너스를 제거하는 메서드 | `void` | `Public` |
| `GetBonus(UpgradeType type)` | 영구 업그레이드, 패시브 장비, 이벤트에 의해 적용된 능력치 보너스를 합산한 값을 반환하는 메서드 | `float` | `Public` |
| `ClearBonuses()` | 영구, 패시브 보너스 목록을 모두 초기화 하는 메서드 | `void` | `Public` |
| `AddEventBonus(UpgradeType type, object source, float value)` | 이벤트에 의한 능력치 보너스를 적용하는 메서드| `void` | `Public` |
| `RemoveEventBonus(UpgradeType type, object source)` | 이벤트 능력치 보너스를 제거하는 메서드 | `void` | `Public` |

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
