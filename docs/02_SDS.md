# [로그라이크 프로젝트]

## 💻 팀원 목록

| 학번 | 이름 | 이메일 |
| :--- | :--- | :--- |
| 22012139 | 김도경 | kjkkjs5252@gmail.com |
| 22012140 | 김병규 | rlaqudrbabcd@gmail.com |
| 22112089 | 백승헌 | hun4758@gmail.com |
| 22213499 | 정태현 | ghgh036034@gmail.com |
| 22311884 | 유민서 | winteryu21@gmail.com |
| 22313530 | 배원일 | dnjsdlf325@gmail.com |

## 📜 Revision history

| Revision date | Version # | Description | Author |
| :--- | :--- | :--- | :--- |
| 10/29/2025 | 1.00 | Use Case Diagram 및 Description 작성 | 유민서 |
| 11/04/2025 | 1.10 | (예시)Class Diagram 초안 작성 | OOO |
| 11/05/2025 | 1.20 | (예시)Class Diagram 상세 명세 양식 반영 | OOO |

## = Contents =

* [1. Introduction](#1-introduction)
* [2. Use case analysis](#2-use-case-analysis)
* [3. Class diagram](#3-class-diagram)
* [4. Sequence diagram](#4-sequence-diagram)
* [5. State machine diagram](#5-state-machine-diagram)
* [6. User interface prototype](#6-user-interface-prototype)
* [7. Implementation requirements](#7-implementation-requirements)
* [8. Glossary](#8-glossary)
* [9. References](#9-references)

---

## 1. Introduction

> * Summarize the contents of this document.
> * Describe the important points of your design.

대충 내용

---

## 2. Use case analysis

> * Build a use case diagram.
> * Make detailed description for each use case (Use case description).

### 2.1 Use Case Diagram

![Use Case Diagram](UseCaseDiagram1.png)

다이어그램에 대한 설명

### 2.2 Use Case Descriptions

**(유스케이스 템플릿 - 이 템플릿을 복사해서 유스케이스별로 작성!)**

#### Use case #[Number] : [Use Case Name]

| **GENERAL CHARACTERISTICS** | |
| :--- | :--- |
| **Summary** | (기능 요약) |
| **Scope** | (시스템 범위, 예: 로그라이크 게임) |
| **Level** | User level |
| **Author** | (작성자 이름) |
| **Last Update** | (작성일) |
| **Status** | Analysis |
| **Primary Actor** | (주 행위자, 예: 플레이어) |
| **Preconditions** | (선행 조건) |
| **Trigger** | (유스케이스 시작 계기) |
| **Success Post Condition** | (성공 시 결과) |
| **Failed Post Condition** | (실패 시 결과) |


| **MAIN SUCCESS SCENARIO** | |
| :--- | :--- |
| **Step** | **Action** |
| S | (시나리오 시작) |
| 1 | (행위자 행동) |
| 2 | (시스템 응답) |
| 3 | ... |
| 4 | (시나리오 종료) |

| **EXTENSION SCENARIOS** | |
| :--- | :--- |
| **Step** | **Branching Action** |
| 2 | 2a. (예외 상황) <br> ...2a1. (시스템 응답) |

| **RELATED INFORMATION** | |
| :--- | :--- |
| **Performance** | (성능 요구사항) |
| **Frequency** | (발생 빈도) |
| **Concurrency** | (동시성) |
| **Due Date** | (개발 마감일) |

#### Use case #[1] : 게임을 시작한다

| **GENERAL CHARACTERISTICS** | |
| :--- | :--- |
| **Summary** | 플레이어가 메인 화면에서 '게임 시작' 버튼을 눌러 인게임 씬으로 진입하는 기능 |
| **Scope** | 메인 화면 |
| **Level** | User level |
| **Author** | 유민서 |
| **Last Update** | 2025. 10. 29 |
| **Status** | Analysis |
| **Primary Actor** | 플레이어 |
| **Preconditions** | 플레이어가 '메인화면' 씬에 있어야 한다. |
| **Trigger** | 플레이어가 '게임 시작' 버튼을 클릭했을 때 |
| **Success Post Condition** | 현재 씬이 '인게임'으로 전환된다. |
| **Failed Post Condition** | 실패 조건 없음 |

| **MAIN SUCCESS SCENARIO** | |
| :--- | :--- |
| **Step** | **Action** |
| S | 플레이어가 게임을 시작한다. |
| 1 | 이 Use case는 플레이어가 메인 화면에서 '게임 시작' 버튼을 누를 때 시작된다. |
| 2 | 시스템은 씬을 '메인 화면'에서 '인게임'으로 전환한다. |
| 3 | 시스템은 인게임 시스템(타이머, 몬스터 스폰 등)을 초기화하고 동작시킨다. |
| 4 | 이 Use case는 인게임 씬이 성공적으로 로드되면 종료된다. |

| **RELATED INFORMATION** | |
| :--- | :--- |
| **Performance** | 씬 로딩 시간 ≤ 3초 |
| **Frequency** | 세션 당 1회 |
| **Concurrency** | |
| **Due Date** | |

#### Use case #[2] : [Use Case Name]

| **GENERAL CHARACTERISTICS** | |
| :--- | :--- |
| **Summary** | (기능 요약) |
| **Scope** | (시스템 범위, 예: 로그라이크 게임) |
| **Level** | User level |
| **Author** | (작성자 이름) |
| **Last Update** | (작성일) |
| **Status** | Analysis |
| **Primary Actor** | (주 행위자, 예: 플레이어) |
| **Preconditions** | (선행 조건) |
| **Trigger** | (유스케이스 시작 계기) |
| **Success Post Condition** | (성공 시 결과) |
| **Failed Post Condition** | (실패 시 결과) |

| **MAIN SUCCESS SCENARIO** | |
| :--- | :--- |
| **Step** | **Action** |
| S | (시나리오 시작) |
| 1 | (행위자 행동) |
| 2 | (시스템 응답) |
| 3 | ... |
| 4 | (시나리오 종료) |

| **EXTENSION SCENARIOS** | |
| :--- | :--- |
| **Step** | **Branching Action** |
| 2 | 2a. (예외 상황) <br> ...2a1. (시스템 응답) |

| **RELATED INFORMATION** | |
| :--- | :--- |
| **Performance** | (성능 요구사항) |
| **Frequency** | (발생 빈도) |
| **<Concurrency>** | (동시성) |
| **Due Date** | (개발 마감일) |

---

## 3. Class diagram

> * Draw class diagrams.
> * Describe each class in detail (attributes, methods, others) (table type).

### 3.1 Class Diagram

![Class Diagram](ClassDiagram4.png)

설명

### 3.2 Class Descriptions

**(클래스 템플릿 - 이 템플릿을 복사해서 클래스별로 작성!)**

#### Class: [ClassName]
* **Description:** (클래스에 대한 상세 설명, 예: 예약 정보 DB)

**Attributes (속성)**
| Name | Description | Type | Visibility |
| :--- | :--- | :--- | :--- |
| `[FieldName]` | (필드에 대한 설명, 예: 고유 식별자) | `[FieldType]` | `Private/Public` |
| `currentState` | 현재 게임 상태 | `GameState` | `Private` |
| `currentTime` | 현재 플레이 시간 | `float` | `Private` |
| `playerManager` | 플레이어 매니저 참조 | `PlayerManager` | `Private` |
| `...` | | | |

**Operations (메서드)**
| Name | Description | Type (Return) | Visibility |
| :--- | :--- | :--- | :--- |
| `[MethodName]([param]: [Type])` | (메서드에 대한 설명, 예: 게임 일시정지) | `[ReturnType]` | `Public/Private` |
| `PauseGame()` | 게임을 일시정지 상태로 변경 | `void` | `Public` |
| `UpdateGameState(deltaTime: float)` | 게임 상태를 매 프레임 갱신 | `void` | `Public` |
| `...` | | | |

---

## 4. Sequence diagram

> * Draw sequence diagrams for the whole functions of your system.
> * Explain each sequence diagram.

**(시퀀스 다이어그램 템플릿 - 주요 유스케이스/기능별로 작성하세요)**

### 4.1 [시나리오 1: 예) 플레이어 레벨 업]

`![Sequence Diagram 1](images/sequence_diagram_levelup.png)`

* **Explanation:** (해당 시퀀스 다이어그램에 대한 상세 설명)
    1. `PlayerManager`가 경험치를 획득하여 `LevelUp()` 메서드를 호출합니다.
    2. `PlayerManager`는 `GameManager`의 `PauseGame()`을 호출하여 게임을 일시 정지시킵니다.
    3. `GameManager`는 `InGamePanelManager`의 `ShowRewardPanel()`을 호출합니다.
    4. ...

---

## 5. State machine diagram

> * Draw state machine diagrams for the client and the server system.
> * Explain each state machine diagram.

### 5.1 GameManager State Machine

`![GameManager State Machine](images/state_machine_gamemanager.png)`

* **Explanation:** (GameManager의 상태도 설명)
    * **MainMenu:** 메인 메뉴 씬의 상태입니다.
    * **Playing:** '게임 시작' 시 Playing 상태로 전환되며, `UpdateGameState`가 동작합니다.
    * **Paused:** 'ESC' 입력 시 Paused 상태로 전환됩니다.
    * ...

---

## 6. User interface prototype

> * Design user interface for your software system.
> * It will be easy if you just think that you make a preliminary user manual of your system based on your user interface.

(Figma, PowerPoint 등에서 작업한 UI 프로토타입 스크린샷을 삽입하고 설명합니다.)

### 6.1 메인 화면 (Main Menu)

`![UI Main Menu](images/ui_main_menu.png)`

* (1) **게임 시작:** `InGame` 씬으로 전환합니다.
* (2) **능력치 강화:** 영구 능력치 업그레이드 패널(`UpgradePanel`)을 엽니다.
* ...

---

## 7. Implementation requirements

> * Describe operating environments to implement your system.

* **개발 환경 (Development Environment):**
    * **Engine:** Unity 2022.3.x
    * **IDE:** Visual Studio 2022
    * **Language:** C# 11 (.NET 7)
    * **Version Control:** Git, GitHub
* **실행 환경 (Operating Environment):**
    * **OS:** Windows 10 / Windows 11
    * **CPU:** (예: Intel Core i5 이상)
    * **RAM:** (예: 8GB 이상)

---

## 8. Glossary

> * Specifically describe all of the terms used in this documents.

* **SRP (Single Responsibility Principle):** 단일 책임 원칙. 클래스는 하나의 책임만을 가져야 한다는 설계 원칙.
* **HUD (Heads-Up Display):** 게임 플레이 중 화면에 상시 표시되는 UI (체력 바, 타이머 등).
* **Prefab:** Unity 엔진에서 사용되는, 미리 구성된 게임 오브젝트의 원본 템플릿.

---

## 9. References

> * Describe all of your references (book, paper, technical report etc).

* (예: [게임 디자인 패턴] - Robert Nystrom)
* (예: Unity 공식 문서 - https://docs.unity3d.com/)