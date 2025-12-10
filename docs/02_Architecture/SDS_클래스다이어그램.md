## 📂 3.2.1 Core 관련 클래스

### 📦AudioManager

> **Description:**
> 게임의 모든 사운드를 관리하는 매니저 클래스

**🟢Attributes (속성)**

| Name            | Description              | Type                            | Visibility      |
|:----------------|:-------------------------|:--------------------------------|:----------------|
| `Instance`      | `AudioManager`의 싱글톤 인스턴스 | `AudioManager`                  | `Public Static` |
| `bgmSource`     | 배경 음악 재생에 사용되는 컴포넌트      | `AudioSource`                   | `Private`       |
| `sfxSource`     | 효과음 재생에 사용되는 컴포넌트        | `AudioSource`                   | `Private`       |
| `bgmClips`      | 인스펙터에 할당된 BGM 클립 배열      | `AudioClip[]`                   | `Private`       |
| `sfxClips`      | 인스펙터에 할당된 SFX 클립 배열      | `AudioClip[]`                   | `Private`       |
| `bgmDictionary` | BGM 클립 이름으로 검색하기 위한 딕셔너리 | `Dictionary<string, AudioClip>` | `Private`       |
| `sfxDictionary` | SFX 클립 이름으로 검색하기 위한 딕셔너리 | `Dictionary<string, AudioClip>` | `Private`       |
| `masterVolume`  | 전체 마스터 볼륨 레벨             | `float`                         | `Private`       |
| `bgmVolume`     | BGM 개별 볼륨 레벨             | `float`                         | `Private`       |

**🔷Operations (메서드)**

| Name                           | Description                    | Type (Return) | Visibility |
|:-------------------------------|:-------------------------------|:--------------|:-----------|
| `InitializeAudioDictionary()`  | 배열의 내용을 클립을 이름으로 초기화하는 메서드     | `void`        | `Private`  |
| `PlayBGM(string clipName)`     | 지정된 이름의 BGM 재생하는 메서드           | `void`        | `Public`   |
| `PlaySfx(string clipName)`     | 지정된 이름의 SFX 클립을 재생하는 메서드       | `void`        | `Public`   |
| `StopBGM()`                    | BGM을 끄는 메서드                    | `void`        | `Public`   |
| `SetMasterVolume(float level)` | 마스터 볼륨을 설정하고, 이 값을 반영하는 메서드    | `void`        | `Public`   |
| `SetBgmVolume(float level)`    | BGM 개별 볼륨을 설정하고, 이 값을 반영하는 메서드 | `void`        | `Public`   |
| `SetSfxVolume(float level)`    | SFX 개별 볼륨을 설정하고, 이 값을 반영하는 메서드 | `void`        | `Public`   |

### 📦GameManager

> **Description:**
> Manager 클래스들을 종합 관리하는 마스터 클래스

**🟢Attributes (속성)**

| Name                  | Description                     | Type                      | Visibility      |
|:----------------------|:--------------------------------|:--------------------------|:----------------|
| `Instance`            | `GameManager`의 씬을 넘나드는 싱글톤 인스턴스 | `GameManager`             | `Public Static` |
| `OnTimeChanged`       | 게임 시간이 변경될 때 발생하는 이벤트           | `event Action<float>`     | `Public`        |
| `OnGameStateChanged`  | 게임 상태가 변경될 때 발생하는 이벤트           | `event Action<GameState>` | `Public`        |
| `IsTimerStopped`      | 타이머만 멈출지 여부를 설정하는 플래그           | `bool`                    | `Public`        |
| `_currentState`       | 현재 게임 상태를 저장하는 백킹 필드            | `GameState`               | `Private`       |
| `_gameTime`           | 현재 플레이 시간을 저장하는 백킹 필드           | `float`                   | `Private`       |
| `_playerManager`      | `PlayerManager` 인스턴스 참조         | `PlayerManager`           | `Private`       |
| `_rewardManager`      | `RewardManager` 인스턴스 참조         | `RewardManager`           | `Private`       |
| `_inGamePanelManager` | `InGamePanelManager` 인스턴스 참조    | `InGamePanelManager`      | `Private`       |
| `_inputManager`       | `InputManager` 인스턴스 참조          | `InputManager`            | `Private`       |

**🔷Operations (메서드)**

| Name                                             | Description                                          | Type (Return) | Visibility |
|:-------------------------------------------------|:-----------------------------------------------------|:--------------|:-----------|
| `PauseGame()`                                    | 게임을 일시정지하고, 게임시간을 멈추고, 일시정지 패널을 표시하는 메서드             | `void`        | `Public`   |
| `ResumeGame()`                                   | 게임을 재개하고, 게임 시간을 흐르게 하고, 일시정지 패널을 닫는 메서드             | `void`        | `Public`   |
| `HandlePauseInput()`                             | `Playing` 상태와 `Paused` 상태를 토글하는 메서드                  | `void`        | `Private`  |
| `GameOver()`                                     | 게임 오버 처리 메서드                                         | `void`        | `Public`   |
| `GameClear()`                                    | 게임 클리어 처리 메서드                                        | `void`        | `Public`   |
| `StartGame()`                                    | 상태를 초기화하고  새 게임을 시작하는 메서드                            | `void`        | `Public`   |
| `GoToMainMenu()`                                 | 상태 초기화 후 메인 메뉴 씬을 로드하는 메서드                           | `void`        | `Public`   |
| `RestartGame()`                                  | 게임을 다시 시작하는 메서드                                      | `void`        | `Public`   |
| `Shutdown()`                                     | 애플리케이션을 종료하는 메서드                                     | `void`        | `Public`   |
| `HandlePlayerLeveledUp()`                        | 플레이어 레벨업 또는 보물상자 획득 시 호출되며, 보상 시스템을 시작, 게임을 멈추는 메서드  | `void`        | `Private`  |
| `HandleRewardFinished()`                         | 보상을 받고나서, 보상 패널을 닫고 게임 재개하는 메서드                      | `void`        | `Private`  |
| `OnSceneLoaded(Scene scene, LoadSceneMode mode)` | 씬 로드 시마다 호출되어 이전 씬 이벤트 구독을 해제하고, 인게임 씬인 경우 초기화하는 메서드 | `void`        | `Private`  |
| `InitializeInGameManagers()`                     | 인게임 씬 로드 후 매니저들을 찾아 연결하고 필요한 이벤트를 구독하는 메서드           | `IEnumerator` | `Private`  |
| `UnsubscribeInGameEvents()`                      | 씬 전환 또는 파괴 시 인게임 매니저들의 이벤트 구독을 안전하게 해제하는 메서드         | `void`        | `Private`  |

### 🏷️InputManager

> **Description:**
> 사용자의 입력을 관리하는 매니저 클래스

**🟢Attributes (속성)**

| Name                         | Description                     | Type                    | Visibility |
|:-----------------------------|:--------------------------------|:------------------------|:-----------|
| `OnMovementInput`            | 이동 입력이 변경될 때마다 호출되는 이벤트         | `event Action<Vector2>` | `Public`   |
| `OnPausePressed`             | 일시정지 키(ESC)가 눌렸을 때 호출되는 이벤트     | `event Action`          | `Public`   |
| `GetItemUseInput`            | 아이템 슬롯 키가 눌렸을 때 호출되는 이벤트        | `event Action<int>`     | `Public`   |
| `horizontalInput`            | 현재 수평 입력 값                      | `float`                 | `Private ` |
| `verticalInput`              | 현재 수직 입력 값                      | `float`                 | `Private ` |
| `mouseXInput`                | 현재 마우스 X축 입력 값                  | `float`                 | `Private ` |
| `mouseYInput`                | 현재 마우스 Y축 입력 값                  | `float`                 | `Private ` |
| `jumpInput`                  | 점프 입력 상태 (프레임당 `GetButtonDown`) | `bool`                  | `Private`  |
| `pauseInput`                 | 일시정지 입력 상태 (ESC 키)              | `bool`                  | `Private`  |
| `dashInput`                  | 대시 입력 상태 (Space 키)              | `bool`                  | `Private`  |
| `useItemInput`               | 사용하려는 아이템 슬롯 번호                 | `int`                   | `Private`  |

**🔷Operations (메서드)**

| Name                               | Description                                        | Type (Return) | Visibility |
|:-----------------------------------|:---------------------------------------------------|:--------------|:-----------|
| `Init()`                           | 모든 입력 값을 초기화하는 메서드                                 | `void`        | `Public`   |
| `ProcessInput()`                   | 매 프레임 입력 상태를 받아와 필드에 저장하고, 유효한 입력에 대해 이벤트 방송하는 메서드 | `void`        | `Public`   |
| `IsKeyPressed(KeyCode keyCode)`    | 특정 키가 눌리고 있는지 확인하는 메서드                             | `bool`        | `Public`   |
| `IsKeyDown(KeyCode keyCode)`       | 특정 키가 눌렸는지 확인하는 메서드                                | `bool`        | `Public`   |
| `GetMouseCoord()`                  | 현재 마우스 커서의 씬 좌표를 반환하는 메서드                          | `Vector2`     | `Public`   |
| `IsMouseButtonPressed(int button)` | 특정 마우스 버튼을 누르고 있는지 확인하는 메서드                        | `bool`        | `Public`   |
| `IsMouseButtonDown(int button)`    | 특정 마우스 버튼이 눌렸는지 확인하는 메서드                           | `bool`        | `Public`   |

### 🏷️PoolManager

> **Description:**
> 오브젝트 풀링 시스템을 구현한 클래스

**🟢Attributes (속성)**

| Name          | Description                        | Type                                 | Visibility      |
|:--------------|:-----------------------------------|:-------------------------------------|:----------------|
| `Instance`    | `PoolManager`의 싱글톤 인스턴스            | `PoolManager`                        | `Public Static` |
| `_pools`      | Instance ID를 통해 풀 관리용 딕셔너리         | `Dictionary<int, Queue<GameObject>>` | `Private`       |
| `_containers` | Hierarchy 정리를 위한, 풀별 부모를 관리하는 딕셔너리 | `Dictionary<int, Transform>`         | `Private`       |

**🔷Operations (메서드)**

| Name                                                            | Description                             | Type (Return) | Visibility |
|:----------------------------------------------------------------|:----------------------------------------|:--------------|:-----------|
| `Get(GameObject prefab, Vector3 position, Quaternion rotation)` | 풀에서 오브젝트를 가져와 활성화하고 위치/회전을 설정하는 메서드     | `GameObject`  | `Public`   |
| `ReturnToPool(GameObject obj, GameObject prefab)`               | 사용이 끝난 오브젝트를 비활성화하고 해당 프리팹의 풀에 반환하는 메서드 | `void`        | `Public`   |
| `Preload(GameObject prefab, int count)`                         | 특정 프리팹에 대해 지정된 개수만큼 오브젝트를 미리 생성하는 메서드   | `void`        | `Public`   |
| `InitPool(GameObject prefab)`                                   | 풀이 들어갈 부모를 초기화 하는 메서드                   | `void`        | `Private`  |

### 📦SaveManager

> **Description:**
> 게임 내용을 저장하고 불러오는 클래스

**🟢Attributes (속성)**

| Name                     | Description                             | Type           | Visibility |
|:-------------------------|:----------------------------------------|:---------------|:-----------|
| `KEY_GOLD`               | 골드 저장 키 상수                              | `const string` | `Private`  |
| `KEY_MASTER_VOLUME`      | 마스터 볼륨 설정 저장 키 상수                       | `const string` | `Private`  |
| `KEY_BGM_VOLUME`         | BGM 볼륨 설정 저장 키 상수                       | `const string` | `Private`  |
| `KEY_SFX_VOLUME`         | SFX 볼륨 설정 저장 키 상수                       | `const string` | `Private`  |
| `KEY_UPGRADE_PREFIX`     | 능력치 강화 레벨 저장 키 접두사 상수 (`"Upgrade_"`)    | `const string` | `Private`  |
| `KEY_UNLOCKED_MONSTERS`  | 몬스터 도감 언락 목록 저장 키 상수                    | `const string` | `Private`  |
| `KEY_UNLOCKED_EQUIPMENT` | 장비 도감 언락 목록 저장 키 상수                     | `const string` | `Private`  |
| `KEY_UNLOCKED_ITEMS`     | 아이템 도감 언락 목록 저장 키                       | `const string` | `Private`  |
| `UnlockData`             | `HashSet<string>`을 JSON 직렬화하기 위한 래퍼 클래스 | `class`        | `Private`  |

**🔷Operations (메서드)**

| Name                                                       | Description                                | Type (Return)     | Visibility       |
|:-----------------------------------------------------------|:-------------------------------------------|:------------------|:-----------------|
| `Save()`                                                   | `PlayerPrefs`에 임시 저장된 모든 데이터를 영구 저장하는 메서드  | `void`            | `Public Static`  |
| `DeleteAll()`                                              | `PlayerPrefs`에 저장된 데이터 삭제하는 메서드            | `void`            | `Public Static`  |
| `HasKey(string key)`                                       | 지정된 키에 해당하는 데이터가 있는지 확인하는 메서드              | `bool`            | `Public Static`  |
| `SaveGold(int amount)`                                     | 현재 골드 저장하는 메서드                             | `void`            | `Public Static`  |
| `LoadGold()`                                               | 저장된 골드를 불러오는 메서드                           | `int`             | `Public Static`  |
| `SaveUpgradeLevel(UpgradeType upgradeType, int level)`     | 특정 능력치의 강화 레벨을 저장하는 메서드                    | `void`            | `Public Static`  |
| `LoadUpgradeLevel(UpgradeType upgradeType)`                | 특정 능력치의 강화 레벨을 불러오는 메서드                    | `int`             | `Public Static`  |
| `GetUpgradeKey(UpgradeType upgradeType)`                   | `UpgradeType`을 기반으로 고유한 저장 키 문자열을 생성하는 메서드 | `string`          | `Private Static` |
| `SaveUnlockedMonsters(HashSet<string> unlockedIds)`        | 몬스터 언락 ID 목록을 저장하는 메서드                     | `void`            | `Public Static`  |
| `LoadUnlockedMonsters()`                                   | 몬스터 언락 ID 목록을 불러오는 메서드                     | `HashSet<string>` | `Public Static`  |
| `SaveUnlockedEquipment(HashSet<string> unlockedIds)`       | 장비 언락 ID 목록을 저장하는 메서드                      | `void`            | `Public Static`  |
| `LoadUnlockedEquipment()`                                  | 장비 언락 ID 목록을 불러오는 메서드                      | `HashSet<string>` | `Public Static`  |
| `SaveUnlockedItems(HashSet<string> unlockedIds)`           | 아이템 언락 ID 목록을 저장하는 메서드                     | `void`            | `Public Static`  |
| `LoadUnlockedItems()`                                      | 아이템 언락 ID 목록을 불러오는 메서드                     | `HashSet<string>` | `Public Static`  |
| `SaveVolume(string volumeType, float value)`               | 마스터, BGM, SFX 볼륨 값을 저장하는 메서드               | `void`            | `Public Static`  |
| `LoadVolume(string volumeType, float defaultValue = 1.0f)` | 지정된 볼륨 타입의 값을 불러오는 메서드                     | `float`           | `Public Static`  |

### 📦SettingManager

> **Description:**
> 게임 해상도 설정하는 클래스

**🟢Attributes (속성)**

| Name                 | Description               | Type               | Visibility |
|:---------------------|:--------------------------|:-------------------|:-----------|
| `resolutionDropdown` | 해상도 목록을 표시하는 UI 드롭다운 컴포넌트 | `TMP_Dropdown`     | `Private`  |
| `fullScreenToggle`   | 전체화면 여부를 설정하는 UI 토글 컴포넌트  | `Toggle`           | `Private`  |
| `masterSlider`       | 마스터 볼륨 설정용 UI 슬라이더 컴포넌트   | `Slider`           | `Private`  |
| `bgmSlider`          | BGM 볼륨 설정용 UI 슬라이더 컴포넌트   | `Slider`           | `Private`  |
| `sfxSlider`          | SFX 볼륨 설정용 UI 슬라이더 컴포넌트   | `Slider`           | `Private`  |
| `resolutionIndex`    | 선택된 해상도 번호                | `int`              | `Private`  |
| `isFullScreen`       | 전체화면 여부 설정                | `bool`             | `Private`  |
| `targetResolution`   | Unity에서 지원하는 해상도 목록       | `List<Resolution>` | `Private`  |

**🔷Operations (메서드)**

| Name                          | Description                           | Type (Return) | Visibility |
|:------------------------------|:--------------------------------------|:--------------|:-----------|
| `SetResolution(int index)`    | UI 드롭다운에서 선택된 해상도 번호를 임시 변수에 저장하는 메서드 | `void`        | `Public`   |
| `PickFullScreen(bool isFull)` | UI 토글에서 선택된 전체화면 여부를 임시 변수에 저장하는 메서드  | `void`        | `Public`   |
| `ApplyResolution()`           | 선택된 해상도 옵션을 적용하는 메서드                  | `void`        | `Public`   |
| `Init_Resolution()`           | 시스템에서 지원하는 해상도 목록을 가져와 ui에 반영하는 메서드   | `void`        | `Private`  |
| `Init_VolumeSettings()`       | 저장된 사운드 세팅을 가져와서 ui를 초기화 하는 메서드       | `void`        | `Private`  |

### 📦UpgradeManager

> **Description:**
> 플레이어 능력치 강화하는 클래스

**🟢Attributes (속성)**

| Name                | Description                    | Type                             | Visibility      |
|:--------------------|:-------------------------------|:---------------------------------|:----------------|
| `Instance`          | `UpgradeManager`의 싱글톤 인스턴스     | `UpgradeManager`                 | `Public Static` |
| `OnGoldChanged`     | 현재 골드가 변경될 때 발생하는 이벤트          | `event Action<int>`              | `Public`        |
| `OnUpgradeChanged`  | 특정 업그레이드의 레벨이 변경될 때 발생하는 이벤트   | `event Action<UpgradeType, int>` | `Public`        |
| `AvailableUpgrades` | 게임 내에서 사용 가능한 모든 업그레이드 데이터 리스트 | `List<UpgradeData>`              | `Public`        |
| `availableUpgrades` | 업그레이드 데이터 리스트                  | `List<UpgradeData>`              | `Private`       |
| `_currentGold`      | 현재 플레이어가 보유한 골드 양              | `int`                            | `Private`       |
| `_upgradeLevels`    | 각 업그레이드의 레벨을 저장하는 딕셔너리         | `Dictionary<UpgradeType, int>`   | `Private`       |

**🔷Operations (메서드)**

| Name                                | Description                             | Type (Return) | Visibility |
|:------------------------------------|:----------------------------------------|:--------------|:-----------|
| `GetUpgradeLevel(UpgradeType type)` | 특정 업그레이드 타입의 현재 레벨을 반환하는 메서드            | `int`         | `Public`   |
| `GetStatBonus(UpgradeType type)`    | 특정 업그레이드 타입의 스텟 보너스를 반환하는 메서드           | `float`       | `Public`   |
| `Purchase(UpgradeData data)`        | 업그레이드의 조건을 만족하면 구매하고 이벤트를 방송 하는 메서드     | `bool`        | `Public`   |
| `Refund(UpgradeData data)`          | 조건을 만족하면 업그레이드 구매를 환불 해주고 이벤트를 방송하는 메서드 | `bool`        | `Public`   |
| `LoadData()`                        | 저장된 강화 레벨과 골드를 가지고와 UI에 반영하는 메서드        | `void`        | `Private`  |

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
> 플레이어가 획득할 수 있는 오브젝트의 기본 클래스

**🟢Attributes (속성)**

| Name                | Description        | Type            | Visibility  |
|:--------------------|:-------------------|:----------------|:------------|
| `Position`          | 오브젝트 자신의 위치        | `Vector2`       | `Public`    |
| `moveSpeed`         | 플레이어에게 끌려갈 때의 속도   | `float`         | `Public`    |
| `currentTarget`     | `PlayerMager` 참조   | `PlayerManager` | `Protected` |
| `_isMovingToPlayer` | 플레이어에게 끌려가는 중인지 여부 | `bool`          | `Private`   |

**🔷Operations (메서드)**

| Name                                 | Description                      | Type (Return)   | Visibility |
|:-------------------------------------|:---------------------------------|:----------------|:-----------|
| `StartMoveTo(PlayerManager target)`  | 플레이어 쪽으로 이동하는 메서드                | `void`          | `Public`   |
| `StopMove()`                         | 이동을 멈추는 메서드                      | `void`          | `Public`   |
| `MoveToPlayer(PlayerManager target)` | 플레이어에게 이동한 다음 가까워지면 획득 처리 하는 메서드 | `void`          | `Public`   |
| `OnAcquire(PlayerManager player)`    | 획득 시 실제로 발생하는 효과를 정의하는 추상 메서드    | `abstract void` | `Public`   |

### 📦EventManager

> **Description:**
> 게임이 진행되는 동안 발생하는 이벤트를 관리하는 클래스

**🟢Attributes (속성)**

| Name               | Description               | Type                   | Visibility      |
|:-------------------|:--------------------------|:-----------------------|:----------------|
| `Instance`         | `EventManager`의 싱글톤 인스턴스  | `EventManager`         | `Public Static` |
| `playerManager`    | `PlayerManager` 참조        | `PlayerManager`        | `Private`       |
| `possibleEvents`   | 발생 가능한 모든 게임 이벤트 데이터 리스트  | `List<GameEventData>`  | `Private`       |
| `minEventInterval` | 이벤트 발생 최소 주기              | `float`                | `Private`       |
| `maxEventInterval` | 이벤트 발생 최대 주기              | `float`                | `Private`       |
| `OnToggleEvent`    | 이벤트 시작/종료 시 구독자에게 알리는 이벤트 | `event Action<string>` | `Public`        |
| `_timer`           | 현재 이벤트 주기를 측정하는 타이머       | `float`                | `Private`       |
| `_nextEventTime`   | 다음 이벤트가 발생해야 할 시간         | `float`                | `Private`       |
| `_currentEvent`    | 현재 활성화된 이벤트 데이터           | `GameEventData`        | `Private`       |

**🔷Operations (메서드)**

| Name                                           | Description                                       | Type (Return) | Visibility |
|:-----------------------------------------------|:--------------------------------------------------|:--------------|:-----------|
| `SetNextEventTime()`                           | 다음 이벤트 발생시간을 설정하고 타이머를 초기화하는 메서드                  | `void`        | `Private`  |
| `TriggerRandomEvent()`                         | 이벤트 리스트에서 무작위로 하나의 이벤트를 선택하는 메서드                  | `void`        | `Public`   |
| `StartEvent(GameEventData eventData)`          | 선택된 이벤트를 실행하는 메서드                                 | `void`        | `Public`   |
| `ProcessEventRoutine(GameEventData eventData)` | 이벤트 시작부터 끝날때까지 모든 단계를 순차적으로 처리하는 코루틴 메서드          | `IEnumerator` | `Private`  |
| `EndEvent(GameEventData eventData)`            | 이벤트를 종료시, 활성화 된 모든 이벤트의 효과를 해제하고 다음 이벤트를 준비하는 메서드 | `void`        | `Private`  |

### 📦GameEventData

> **Description:**
> 게임 이벤트에 대한 데이터 구조를 담는 클래스

**🟢Attributes (속성)**

| Name                  | Description                      | Type                 | Visibility |
|:----------------------|:---------------------------------|:---------------------|:-----------|
| `eventName`           | 이벤트의 이름                          | `string`             | `Public`   |
| `description`         | 이벤트에 대한 상세 설명                    | `string`             | `Public`   |
| `notificationMessage` | 이벤트 시작/종료 시 UI에 표시될 메시지          | `string`             | `Public`   |
| `duration`            | 이벤트가 지속될 시간                      | `float`              | `Public`   |
| `statModifiers`       | 수정할 능력치 종류와 수치 값을 가진 구조체를 담는 리스트 | `List<StatModifier>` | `Public`   |



### 📦Reposition

> **Description:**
> 청크를 재배치함으로써 무한맵처럼 보이게 하는 클래스

**🟢Attributes (속성)**

| Name        | Description | Type    | Visibility |
|:------------|:------------|:--------|:-----------|
| `chunkSize` | 맵 청크 하나의 크기 | `float` | `Private`  |


**🔷Operations (메서드)**

| Name                                    | Description                        | Type (Return) | Visibility |
|:----------------------------------------|:-----------------------------------|:--------------|:-----------|
| `RepositionMapChucnk(Vector3 distance)` | 플레이어와 청크 간의 거리를 기반으로 청크를 재배치하는 메서드 | `void`        | `Private`  |



### 📦RewardManager

> **Description:**
> 레벨업시 제공되는 보상을 관리하는 클래스

**🟢Attributes (속성)**

| Name                      | Description             | Type                                   | Visibility |
|:--------------------------|:------------------------|:---------------------------------------|:-----------|
| `OnRewardProcessFinished` | 보상 선택/스킵 완료 시 발생하는 이벤트  | `event Action`                         | `Public`   |
| `OnRewardTextUIChanged`   | 보상 패널의 텍스트 정보 갱신 이벤트    | `event Action<int,int,float>`          | `Public`   |
| `OnRewardUIChanged`       | 보상 카드 목록 갱신 이벤트         | `event Action<List<ScriptableObject>>` | `Public`   |
| `playerManager`           | `PlayerManager` 참조      | `PlayerManager`                        | `Private`  |
| `lootDataBase`            | `LootDataBase` 참조       | `LootDataBase`                         | `Private`  |
| `inventoryManager`        | `InventoryManager` 참조   | `InventoryManager`                     | `Private`  |
| `_maxRerollCount`         | 최대 리롤 횟수                | `int`                                  | `Private`  |
| `_rerollCount`            | 현재 남은 리롤 횟수             | `int`                                  | `Private`  |
| `_baseRerollPrice`        | 기본 리롤 비용                | `int`                                  | `Private`  |
| `_rerollPrice`            | 현재 리롤에 필요한 골드 비용        | `int`                                  | `Private`  |
| `_skipExpRatio`           | 보상 스킵 시 얻는 최대 경험치 대비 비율 | `float`                                | `Private`  |

**🔷Operations (메서드)**

 Name                                      | Description                  | Type (Return) | Visibility |
|:------------------------------------------|:-----------------------------|:--------------|:-----------|
| `GenerateRewards()`                       | 3개의 무작위 보상 생성하는 메서드          | `void`        | `Public`   |
| `OnRewardSelected(ScriptableObject data)` | 보상을 선택하면 선택 장비/아이템을 추가하는 메서드 | `void`        | `Public`   |
| `OnRerollPressed()`                       | 리롤버튼을 누르면 새로운 보상을 생성하는 메서드   | `void`        | `Public`   |
| `OnSkipPressed()`                         | 스킵버튼을 누르면 경험치를 지급하는 메서드      | `void`        | `Public`   |


### 📦UpgradeData

> **Description:**
> 업그레이드 데이터를 담는 클래스

**🟢Attributes (속성)**

| Name            | Description       | Type          | Visibility |
|:----------------|:------------------|:--------------|:-----------|
| `upgradeName`   | 업그레이드의 이름         | `string`      | `Private`  |
| `description`   | 업그레이드에 대한 상세 설명   | `string`      | `Private`  |
| `upgradeType`   | 업그레이드하는 스텟 종류     | `UpgradeType` | `Private`  |
| `baseCost`      | 업그레이드의 기본 비용      | `int`         | `Private`  |
| `maxLevel`      | 도달 가능한 최대 레벨      | `int`         | `Private`  |
| `valuePerLevel` | 레벨당 획득하는 스탯 보너스 값 | `float`       | `Private`  |

**🔷Operations (메서드)**

| Name                                | Description                         | Type (Return) | Visibility |
|:------------------------------------|:------------------------------------|:--------------|:-----------|
| `GetCostForLevel(int currentLevel)` | 레벨당 비용 증가시키는 메서드                    | `int`         | `Public`   |
| `GetTotalBonus(int currentLevel)`   | 현재 레벨까지 누적된 총 스텟 보너스를 계산해서 반환하는 메서드 | `float`       | `Public`   |

## 📂 3.2.4 Loot-Abstract 관련 클래스

### 📦EquipmentBase

> **Description:**
> 모든 장비(Weapon, Passive)가 상속받는 추상 클래스

**🟢Attributes (속성)**

| Name      | Description                    | Type            | Visibility  |
|:----------|:-------------------------------|:----------------|:------------|
| `_data`   | 장비의 Scriptable Object를 할당하는 필드 | `EquipmentData` | `protected` |
| `_level`  | 장비의 레벨을 저장하는 필드                | `int`           | `protected` |
| `_player` | 플레이어 매니저 인스턴스 참조               | `PlayerManager` | `protected` |

**🔷Operations (메서드)**

| Name                                                     | Description          | Type (Return) | Visibility |
|:---------------------------------------------------------|:---------------------|:--------------|:-----------|
| `LevelUp()`                                              | 장비의 레벨을 증가시키는 가상 메서드 | `void`        | `public`   |

### 📦Item

> **Description:**
> 모든 아이템이 상속받는 추상 클래스

**🟢Attributes (속성)**

| Name              | Description                     | Type            | Visibility |
|:------------------|:--------------------------------|:----------------|:-----------|
| `data`            | 아이템의 Scriptable Object를 할당하는 필드 | `ItemData`      | `private`  |
| `_player`         | 플레이어 매니저 인스턴스 참조                | `PlayerManager` | `private`  |
| `durability`      | 아이템을 사용할 수 있는 횟수                | `int`           | `private`  |
| `currentCooldown` | 아이템의 남은 재사용 가능 시간을 저장하는 필드      | `float`         | `private`  |

**🔷Operations (메서드)**

| Name                               | Description           | Type (Return) | Visibility |
|:-----------------------------------|:----------------------|:--------------|:-----------|
| `Activate()`                       | 아이템의 사용을 처리하는 가상 메서드  | `bool`        | `public`   |
| `UpdateCooldown(deltaTime: float)` | 아이템의 쿨다운 시간을 갱신하는 메서드 | `void`        | `public`   |

### 📦Passive
> **Description:**
> 모든 패시브 장비가 상속 받는 추상 클래스

**🔷Operations (메서드)**

| Name                                                     | Description                 | Type (Return) | Visibility |
|:---------------------------------------------------------|:----------------------------|:--------------|:-----------|
| `LevelUp()`                                              | 장비의 레벨을 증가시키는 오버라이드 메서드     | `void`        | `public`   |
| `ApplyStatBonus()`                                       | 장비의 효과를 플레이어 캐릭터에게 적용하는 메서드 | `void`        | `private`  |

### 📦Projectile
> **Description:**
> 플레이어의 무기가 지원하는 모든 투사체의 추상 클래스

**🟢Attributes (속성)**

| Name           | Description                      | Type    | Visibility  |
|:---------------|:---------------------------------|:--------|:------------|
| `_speed`       | 투사체의 속도를 정의하는 필드                 | `float` | `protected` |
| `_damage`      | 투사체의 데미지를 정의하는 필드                | `float` | `protected` |
| `_penetration` | 투사체가 적을 관통할 수 있는 횟수의 -1을 정의하는 필드 | `int`   | `protected` |

**🔷Operations (메서드)**

| Name                                                            | Description             | Type (Return) | Visibility  |
|:----------------------------------------------------------------|:------------------------|:--------------|:------------|
| `UpdateMovement()`                                              | 투사체의 이동 로직을 구현하는 가상 메서드 | `void`        | `protected` |
| `InitializeBase(speed: float, damage: float, penetration: int)` | 투사체의 기본 속성을 초기화하는 메서드   | `void`        | `protected` |

---

### 📦Weapon

> **Description:**
> 모든 무기가 상속 받는 추상 클래스

**🟢Attributes (속성)**

| Name               | Description              | Type    | Visibility  |
|:-------------------|:-------------------------|:--------|:------------|
| `_currentCooldown` | 무기의 남은 재사용 대기시간을 저장하는 필드 | `float` | `protected` |

**🔷Operations (메서드)**

| Name                                                       | Description               | Type (Return) | Visibility  |
|:-----------------------------------------------------------|:--------------------------|:--------------|:------------|
| `UpdateCooldown(deltaTime: float)`                         | 무기의 재사용 대기시간을 갱신하는 가상 메서드 | `void`        | `public`    |
| `CalculateDamage(baseDamage: float, isCritical: out bool)` | 무기의 최종 데미지를 계산하는 메서드      | `float`       | `protected` |
| `CalculateCooldown()`                                      | 무기의 최종 재사용 대기시간을 계산하는 메서드 | `float`       | `protected` |
| `PerformAttack()`                                          | 실제 공격 로직을 구현하는 가상 메서드     | `void`        | `protected` |

## 📂 3.2.5 Loot-Data 관련 클래스

### 📦EquipmentData

> **Description:**
> 모든 장비의 정보를 정의하는 데이터 컨테이너 클래스 (ScriptableObject)

**🟢Attributes (속성)**

| Name             | Description            | Type     | Visibility |
|:-----------------|:-----------------------|:---------|:-----------|
| `_equipmentName` | 장비의 이름을 저장하는 필드        | `string` | `private`  |
| `_description`   | 장비의 설명을 저장하는 필드        | `string` | `private`  |
| `_icon`          | 장비의 아이콘 스프라이트를 저장하는 필드 | `Sprite` | `private`  |
| `_maxLevel`      | 장비의 최대 레벨을 정의하는 필드     | `int`    | `private`  |
| `unlocked`       | 장비의 획득 이력을 나타내는 필드     | `bool`   | `private`  |

### 📦EquipmentInfo

> **Description:**
> 도감의 장비 부문 데이터베이스 관리용 클래스

**🟢Attributes (속성)**

| Name         | Description                    | Type            | Visibility |
|:-------------|:-------------------------------|:----------------|:-----------|
| `Id`         | 장비의 고유 Id를 저장하는 필드             | `string`        | `public`   |
| `Data`       | 장비의 Scriptable Object를 저장하는 필드 | `EquipmentData` | `public`   |
| `IsUnlocked` | 장비의 획득 이력을 나타내는 필드             | `bool`          | `public`   |

### 📄 ItemData
> **Description:**
> 아이템의 정보를 정의하는 데이터 컨테이너 클래스 (ScriptableObject)

**🟢Attributes (속성)**

| Name             | Description               | Type         | Visibility |
|:-----------------|:--------------------------|:-------------|:-----------|
| `_itemName`      | 아이템의 이름을 저장하는 필드          | `string`     | `private`  |
| `_description`   | 아이템의 설명을 저장하는 필드          | `string`     | `private`  |
| `_icon`          | 아이템의 아이콘 스프라이트를 저장하는 필드   | `Sprite`     | `private`  |
| `_prefab`        | 구현된 아이템의 프리팹을 저장하는 필드     | `GameObject` | `private`  |
| `unlocked`       | 아이템의 획득 이력을 나타내는 필드       | `bool`       | `private`  |
| `_cooldown`      | 아이템의 재사용 대기시간을 정의하는 필드    | `float`      | `private`  |
| `_maxDurability` | 아이템의 최대 사용 가능 횟수를 정의하는 필드 | `int`        | `private`  |

### 📦ItemInfo

> **Description:**
> 도감의 아이템 부문 데이터베이스 관리용 클래스

**🟢Attributes (속성)**

| Name         | Description                     | Type       | Visibility |
|:-------------|:--------------------------------|:-----------|:-----------|
| `Id`         | 아이템의 고유 Id를 저장하는 필드             | `string`   | `public`   |
| `Data`       | 아이템의 Scriptable Object를 저장하는 필드 | `ItemData` | `public`   |
| `IsUnlocked` | 아이템의 획득 이력을 나타내는 필드             | `bool`     | `public`   |

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
> 플레이어가 획득한 무기, 패시브 장비, 소모성 아이템 관리하는 클래스

**🟢Attributes (속성)**

| Name                 | Description                     | Type            | Visibility |
|:---------------------|:--------------------------------|:----------------|:-----------|
| `playerManager`      | `PlayerManager` 참조              | `PlayerManager` | `Private`  |
| `weaponParent`       | 무기 및 패시브 오브젝트가 생성될 부모           | `Transform`     | `Private`  |
| `maxWeaponSlots`     | 보유 가능한 최대 무기 슬롯 개수              | `int`           | `Private`  |
| `maxPassiveSlots`    | 보유 가능한 최대 패시브 슬롯 개수             | `int`           | `Private`  |
| `maxItemSlots`       | 보유 가능한 최대 소모성 아이템 슬롯 개수         | `int`           | `Private`  |
| `OnInventoryChanged` | 인벤토리 내용 변경 시 UI 갱신을 위해 호출되는 이벤트 | `event Action`  | `Public`   |
| `_weapons`           | 현재 플레이어가 보유한 `Weapon` 인스턴스 리스트  | `List<Weapon>`  | `Private`  |
| `_passives`          | 현재 플레이어가 보유한 `Passive` 인스턴스 리스트 | `List<Passive>` | `Private`  |
| `_consumables`       | 현재 플레이어가 보유한 `Item` 인스턴스 리스트    | `List<Item>`    | `Private`  |

**🔷Operations (메서드)**

| Name                               | Description                  | Type (Return)   | Visibility |
|:-----------------------------------|:-----------------------------|:----------------|:-----------|
| `Initialize(PlayerManager player)` | 플레이어 매니저 초기화 메서드             | `void`          | `Public`   |
| `Add(EquipmentData data)`          | 장비를 추가하거나 보유 중이면 레벨 업시키는 메서드 | `void`          | `Public`   |
| `Add(ItemData data)`               | 소모성 아이템을 추가하는 메서드            | `void`          | `Public`   |
| `FindItem(EquipmentData data)`     | 할성화된 무기와 패시브의 데이터를 반환하는 메서드  | `EquipmentBase` | `Public`   |
| `UseItem(int slotIndex)`           | 아이템을 사용 메서드                  | `void`          | `Public`   |
| `AddWeapon(WeaponData data)`       | 무기를 추가하는 메서드                 | `void`          | `Private`  |
| `AddPassive(PassiveData data)`     | 인벤토리에 패시브 아이템을 추가하는 메서드      | `void`          | `Private`  |
| `AddConsumable(ItemData data)`     | 아이템을 추가하는 메서드                | `void`          | `Private`  |

### 📦PlayerMagnet

> **Description:**
> 플레이어 자석 기능 클래스

**🟢Attributes (속성)**

| Name                 | Description                  | Type            | Visibility |
|:---------------------|:-----------------------------|:----------------|:-----------|
| `orbLayer`           | 감지 대상이 되는 경험치의 레이어 마스크       | `LayerMask`     | `Private`  |
| `maxTargetsPerFrame` | 한 번의 감지로 처리할 수 있는 최대 오브젝트 수  | `int`           | `Private`  |
| `_playerManager`     | 플레이어의 능력치와 위치 정보를 가져오기 위한 참조 | `PlayerManager` | `Private`  |
| `_results`           | 주위 획득 가능 오브젝트 저장 배열          | `Collider2D[]`  | `Private`  |

**🔷Operations (메서드)**

| Name       | Description           | Type (Return) | Visibility |
|:-----------|:----------------------|:--------------|:-----------|
| `magnet()` | 획득가능한 오브젝트를 끌어당기는 메서드 | `void`        | `private`  |

### 🏷️PlayerManager

> **Description:**
> 플레이어 객체를 관리하는 매니저 클래스

**🟢Attributes (속성)**

| Name                    | Description                     | Type                         | Visibility |
|:------------------------|:--------------------------------|:-----------------------------|:-----------|
| `OnHpChanged`           | HP 변경 시 호출되는 이벤트                | `event Action<float, float>` | `Public`   |
| `OnExpChanged`          | 경험치 변경 시 호출되는 이벤트               | `event Action<float, float>` | `Public`   |
| `OnGoldChanged`         | 골드 변경 시 호출되는 이벤트                | `event Action<int>`          | `Public`   |
| `OnKillCountChanged`    | 킬 카운트 변경 시 호출되는 이벤트             | `event Action<int>`          | `Public`   |
| `OnPlayerLeveledUp`     | 레벨 업 시 호출되는 이벤트                 | `event Action`               | `Public`   |
| `OnPlayerGetTreasure`   | 보물 상자 획득 시 호출되는 이벤트             | `event Action`               | `Public`   |
| `FacingDirection`       | 플레이어가 현재 바라보는 방향                | `Vector2`                    | `Public`   |
| `inputManager`          | `InputManager` 참조               | `InputManager`               | `Private`  |
| `UpgradeManager`        | `UpgradeManager` 참조             | `UpgradeManager`             | `Private`  |
| `inventoryManager`      | `InventoryManager` 참조           | `InventoryManager`           | `Private`  |
| `startingWeapon`        | 게임 시작 시 지급될 기본 무기 데이터           | `WeaponData`                 | `Private`  |
| `stats`                 | 플레이어 능력치 데이터                    | `PlayerStats`                | `Private`  |
| `contactDamageCooldown` | 피격 후 무적시간                       | `float`                      | `Private`  |
| `dashDistance`          | 대시 시 이동할 거리                     | `float`                      | `Private`  |
| `dashDuration`          | 대시가 지속되는 시간                     | `float`                      | `Private`  |
| `dashCooldown`          | 대시 후 재사용까지의 쿨다운 시간              | `float`                      | `Private`  |
| `dashDamage`            | 대시 데미지                          | `float`                      | `Private`  |
| `dashDamageRadius`      | 대시 데미지 범위                       | `float`                      | `Private`  |
| `lightningEffectPrefab` | 대시 번개 이펙트 프리펩                   | `Gameobject`                 | `private`  |
| `floatingTextOffPrefab` | 대시 쿨타임 알림창 프리펩                  | `Gameobject`                 | `private`  |
| `floatingTextOffset`    | 대시 알림 시작 위치 offset              | `Vector3`                    | `private`  |
| `_currentHp`            | 현재 HP                           | `float`                      | `Private`  |
| `_level`                | 현재 레벨                           | `int`                        | `Private`  |
| `_currentExp`           | 현재 경험치                          | `int`                        | `Private`  |
| `_maxExp`               | 다음 레벨에 필요한 최대 경험치               | `int`                        | `Private`  |
| `_gold`                 | 현재 보유 골드                        | `int`                        | `Private`  |
| `_killCount`            | 현재 킬 카운트                        | `int`                        | `Private`  |
| `_contactDamageTimer`   | 충돌 무적 시간 타이머                    | `float`                      | `Private`  |
| `_isDashing`            | 현재 대시 중인지 여부                    | `bool`                       | `Private`  |
| `_dashCooldownTimer`    | 대시 재사용 쿨다운 타이머                  | `float`                      | `Private`  |
| `_lastMoveDirection`    | 플레이어가 마지막으로 이동했던 방향             | `Vector2`                    | `Private`  |
| `_originalLayer`        | 대시 충돌 무시를 위해 저장해 둔 플레이어의 원래 레이어 | `int`                        | `Private`  |

**🔷Operations (메서드)**

| Name                                                                     | Description                      | Type (Return) | Visibility |
|:-------------------------------------------------------------------------|:---------------------------------|:--------------|:-----------|
| `HandleItemUseInput(int slotNumber)`                                     | 아이템 사용 메서드                       | `void`        | `Private`  |
| `TakeDamage(float amount)`                                               | 몬스터 공격으로 인한 데미지를 받는 메서드          | `void`        | `Public`   |
| `Heal(float amount)`                                                     | 플레이의 HP를 회복 시키는 메서드              | `void`        | `Public`   |
| `TakeDamage(float amount, bool isContactDamage)`                         | 몬스터 충돌로 인한 데미지를 받는 메서드           | `void`        | `Public`   |
| `GainExp(int amount)`                                                    | 경험치를 획득하는 메서드                    | `void`        | `Public`   |
| `GainGold(int amount)`                                                   | 골드 획득하는 메서드                      | `void`        | `Public`   |
| `SpendGold(int amount)`                                                  | 골드 소비하는 메서드                      | `bool`        | `Public`   |
| `GainTreasure()`                                                         | 보물 상자 획득 메서드                     | `void`        | `Public`   |
| `GainKillCount(int amount)`                                              | 킬 카운트를 증가시키는 메서드                 | `void`        | `Public`   |
| `AddEquipment(EquipmentData data)`                                       | 장비를 획득하는 메서드                     | `void`        | `Public`   |
| `AddItem(ItemData data)`                                                 | 아이템을 획득하는 메서드                    | `void`        | `Public`   |
| `AddPassiveBonus(UpgradeType type, object source, float value)`          | 패시브 아이템 등에 의한 스탯 보너스를 적용하는 메서드   | `void`        | `Public`   |
| `ApplyEventModifiers(object eventSource, List<StatModifier> modifiers)`  | 이벤트 발생시 플레이어 능력치를 오르게 하는 메서드     | `void`        | `Public`   |
| `RemoveEventModifiers(object eventSource, List<StatModifier> modifiers)` | 이벤트 종료시 증가된 능력치를 제거하는 메서드        | `void`        | `Public`   |
| `RemovePassiveBonus(UpgradeType type, object source)`                    | 패시브 아이템  의한 스탯 보너스 능력치를 제거하는 메서드 | `void`        | `Public`   |
| `EquipStartingWeapon()`                                                  | 기본무기 지급 메서드                      | `void`        | `Private`  |
| `Move(Vector2 direction)`                                                | 플레이어 이동시키는 메서드                   | `void`        | `Private`  |
| `Die()`                                                                  | 플레이어 사망을 처리하는 메서드                | `void`        | `Private`  |
| `Player_Animation()`                                                     | 플레이어 애니메이션 동작 메서드                | `void`        | `Private`  |
| `LevelUp()`                                                              | 플레이어 레벨 업 시키는 메서드                | `void`        | `Private`  |
| `ApplyUpgradeBonuses()`                                                  | 플레이어 스텟을 강화하는 메서드                | `void`        | `Private`  |
| `TryDash()`                                                              | 플레이어를 대시시키는 메서드                  | `void`        | `Private`  |
| `DashCoroutine(Vector2 direction)`                                       | 대시 행동 로작 정의 메서드                  | `IEnumerator` | `Private`  |
| `DealDashDamage(HashSet<Monster> damagedMonsters)`                       | 주변 적에게 대시 피해를 입히는 메서드            | `void`        | `Private`  |
| `SpawnLightningEffect(Vector2 startPos, Vector2 endPos)`                 | 대시 경로에 번개 이펙트를 생성하는 메서드          | `void`        | `Private`  |
| `InvincibilityFlashCoroutine()`                                          | 무적 시간동안 플레이어를 깜빡이는 메서드           | `IEnumerator` | `Private`  |
| `ShowDashCooldownText()`                                                 | 대시 쿨다운을 알려주는 텍스트를 띄워주는 메서드       | `void`        | `Private`  |

### 📦PlayerStats

> **Description:**
> 플레이어의 능력치를 정의하는 클래스

**🟢Attributes (속성)**

| Name                  | Description           | Type                                                 | Visibility |
|:----------------------|:----------------------|:-----------------------------------------------------|:-----------|
| `maxHp`               | 기본 최대 HP              | `float`                                              | `Private`  |
| `speed`               | 기본 이동 속도              | `float`                                              | `Private`  |
| `attackDamageMult`    | 기본 공격 피해 배율           | `float`                                              | `Private`  |
| `attackSpeedMult`     | 기본 공격 속도 배율           | `float`                                              | `Private`  |
| `cooldownMult`        | 기본 쿨다운 감소 배율          | `float`                                              | `Private`  |
| `magnetRange`         | 기본 아이템 획득 범위          | `float`                                              | `Private`  |
| `critChance`          | 기본 치명타 확률             | `float`                                              | `Private`  |
| `critDamageMult`      | 기본 치명타 피해 배율          | `float`                                              | `Private`  |
| `expMult`             | 기본 경험치 획득 배율          | `float`                                              | `Private`  |
| `goldMult`            | 기본 골드 획득 배율           | `float`                                              | `Private`  |
| `damageReductionMult` | 기본 피해 감소율             | `float`                                              | `Private`  |
| `_permanentBonuses`   | 업그레이드 전용 능력치 보너스      | `Dictionary<UpgradeType, float>`                     | `Private`  |
| `_passiveBonuses`     | 패시브 장비 전용 능력치 보너스     | `Dictionary<UpgradeType, Dictionary<object, float>>` | `Private`  |
| `_eventBonuses`       | 이벤트 버프/디버프 전용 능력치 보너스 | `Dictionary<UpgradeType, Dictionary<object, float>>` | `Private`  |

**🔷Operations (메서드)**

| Name                                                            | Description                                            | Type (Return) | Visibility |
|:----------------------------------------------------------------|:-------------------------------------------------------|:--------------|:-----------|
| `SetPermanentBonus(UpgradeType type, float value)`              | 업그레이드에 의한 능력치 보너스를 설정하는 메서드                            | `void`        | `Public`   |
| `SetPassiveBonus(UpgradeType type, object source, float value)` | 패시브 장비에 의한 능력치 보너스를 설정하는 메서드                           | `void`        | `Public`   |
| `RemovePassiveBonus(UpgradeType type, object source)`           | 패시브 장비에 의한능력치 보너스를 제거하는 메서드                            | `void`        | `Public`   |
| `GetBonus(UpgradeType type)`                                    | 영구 업그레이드, 패시브 장비, 이벤트에 의해 적용된 능력치 보너스를 합산한 값을 반환하는 메서드 | `float`       | `Public`   |
| `ClearBonuses()`                                                | 영구, 패시브 보너스 목록을 모두 초기화 하는 메서드                          | `void`        | `Public`   |
| `AddEventBonus(UpgradeType type, object source, float value)`   | 이벤트에 의한 능력치 보너스를 적용하는 메서드                              | `void`        | `Public`   |
| `RemoveEventBonus(UpgradeType type, object source)`             | 이벤트 능력치 보너스를 제거하는 메서드                                  | `void`        | `Public`   |

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
