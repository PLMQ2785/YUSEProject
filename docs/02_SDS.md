# [로그라이크 프로젝트]

## 💻 팀원 목록

| 학번       | 이름  | 이메일                    |
|:---------|:----|:-----------------------|
| 22012139 | 김도경 | kjkkjs5252@gmail.com   |
| 22012140 | 김병규 | rlaqudrbabcd@gmail.com |
| 22112089 | 백승헌 | hun4758@gmail.com      |
| 22213499 | 정태현 | ghgh036034@gmail.com   |
| 22311884 | 유민서 | winteryu21@gmail.com   |
| 22313530 | 배원일 | dnjsdlf325@gmail.com   |

## 📜 Revision history

| Revision date | Version # | Description                       | Author |
|:--------------|:----------|:----------------------------------|:-------|
| 10/29/2025    | 1.00      | Use Case Diagram 및 Description 작성 | 유민서    |
| 11/04/2025    | 1.10      | (예시)Class Diagram 초안 작성           | OOO    |
| 11/05/2025    | 1.20      | (예시)Class Diagram 상세 명세 양식 반영     | OOO    |

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

본 문서는 우리 팀이 개발하고자 하는 탑다운 시점 로그라이크 액션 게임 프로젝트의 Software Design Specification(SDS)이다. 게임 개발 과정에서 필요한 기능적 요구사항을 구체화하고, 시스템의 구조적 및 동작적 설계 내용을 명확히 제시하는 것을 목적으로 한다. SDS는 게임의 핵심 시스템과 주요 기능을 정의하여 프로젝트 구성원이 공통된 이해를 바탕으로 일관성 있는 개발을 진행할 수 있도록 지원하며, 향후 유지보수 및 확장 개발 시 표준 참조 문서로 활용된다.
Use Case Analysis는 사용자 관점에서의 주요 기능 및 시나리오를 정의하였고, Class Diagram은 시스템의 구조 및 클래스 간 관계를 나타낸다. Sequence Diagram과 State Machine Diagram은 게임 시스템의 동작 흐름 및 상태 전이 과정을 기술하며, User Interface 설계는 게임의 화면 구성과 사용자 인터페이스 동작을 묘사하였다.
본 SDS 문서에서는 각 다이어그램과 구성 요소 간의 일관성 검토를 중요하게 생각했다. 특히, 메서드 명칭이나 호출 구조의 불일치는 설계 및 구현상의 오류로 이어질 수 있기 때문에 Class Diagram에 정의된 메서드 이름이 Sequence Diagram에서 동일하게 사용되었는지를 검토했다. 또한, UI Prototype의 화면 전환 흐름이 GameManager의 State Machine Diagram과 일치하는지 검토해야 하며, 게임의 상태가 UI 설계와 정확히 대응되어야 한다.
본 프로젝트는 다음과 같은 개발 환경과 도구를 기반으로 진행된다. 게임 엔진은 Unity를 사용하고, 개발 언어는 C#을 사용한다. Unity 엔진을 활용한 개발은 빠른 프로토타이핑과 다양한 플랫폼 지원을 가능하게 한다. GitHub을 통한 형상 관리는 협업 효율성과 버전 추적의 용이성을 제공한다. 

---

## 2. Use case analysis

> * Build a use case diagram.
> * Make detailed description for each use case (Use case description).

### 2.1 Use Case Diagram

![Use Case Diagram](imgs/usecaseDiagram.png)

다이어그램에 대한 설명

### 2.2 Use Case Descriptions

**(유스케이스 템플릿 - 이 템플릿을 복사해서 유스케이스별로 작성!)**

#### Use case #[Number] : [Use Case Name]

| **GENERAL CHARACTERISTICS** |                       |
|:----------------------------|:----------------------|
| **Summary**                 | (기능 요약)               |
| **Scope**                   | (시스템 범위, 예: 로그라이크 게임) |
| **Level**                   | User level            |
| **Author**                  | (작성자 이름)              |
| **Last Update**             | (작성일)                 |
| **Status**                  | Analysis              |
| **Primary Actor**           | (주 행위자, 예: 플레이어)      |
| **Preconditions**           | (선행 조건)               |
| **Trigger**                 | (유스케이스 시작 계기)         |
| **Success Post Condition**  | (성공 시 결과)             |
| **Failed Post Condition**   | (실패 시 결과)             |


| **MAIN SUCCESS SCENARIO** |            |
|:--------------------------|:-----------|
| **Step**                  | **Action** |
| S                         | (시나리오 시작)  |
| 1                         | (행위자 행동)   |
| 2                         | (시스템 응답)   |
| 3                         | ...        |
| 4                         | (시나리오 종료)  |

| **EXTENSION SCENARIOS** |                                   |
|:------------------------|:----------------------------------|
| **Step**                | **Branching Action**              |
| 2                       | 2a. (예외 상황) <br> ...2a1. (시스템 응답) |

| **RELATED INFORMATION** |           |
|:------------------------|:----------|
| **Performance**         | (성능 요구사항) |
| **Frequency**           | (발생 빈도)   |
| **Concurrency**         | (동시성)     |
| **Due Date**            | (개발 마감일)  |

#### Use case #[1] : 게임을 시작한다

| **GENERAL CHARACTERISTICS** |                                             |
|:----------------------------|:--------------------------------------------|
| **Summary**                 | 플레이어가 메인 화면에서 인게임 씬으로 진입하는 기능               |
| **Scope**                   | 메인 화면                                       |
| **Level**                   | User level                                  |
| **Author**                  | 유민서                                         |
| **Last Update**             | 2025. 10. 29                                |
| **Status**                  | Analysis                                    |
| **Primary Actor**           | 플레이어                                        |
| **Preconditions**           | 플레이어가 '메인화면' 씬에 있어야 한다.                     |
| **Trigger**                 | 플레이어가 '게임 시작' 버튼을 클릭했을 때                    |
| **Success Post Condition**  | 현재 씬이 '인게임'으로 전환된다.                         |
| **Failed Post Condition**   | 실패 조건 없음                                    |

| **MAIN SUCCESS SCENARIO** |                                                  |
|:--------------------------|:-------------------------------------------------|
| **Step**                  | **Action**                                       |
| S                         | 플레이어가 게임을 시작한다.                                  |
| 1                         | 이 Use case는 플레이어가 메인 화면에서 '게임 시작' 버튼을 누를 때 시작된다. |
| 2                         | 시스템은 씬을 '메인 화면'에서 '인게임'으로 전환한다.                  |
| 3                         | 시스템은 인게임 시스템(타이머, 몬스터 스폰 등)을 초기화하고 동작시킨다.        |
| 4                         | 이 Use case는 인게임 씬이 성공적으로 로드되면 종료된다.              |

| **RELATED INFORMATION** |              |
|:------------------------|:-------------|
| **Performance**         | 씬 로딩 시간 ≤ 3초 |
| **Frequency**           | 세션 당 1회      |
| **Concurrency**         |              |
| **Due Date**            |              |

#### Use case #[2] : 게임을 일시 정지한다

| **GENERAL CHARACTERISTICS** |                                                 |
|:----------------------------|:------------------------------------------------|
| **Summary**                 | 플레이어가 게임의 모든 동작을 멈추고 일시 정지 화면을 호출하는 기능          |
| **Scope**                   | 인게임                                             |
| **Level**                   | User level                                      |
| **Author**                  | 유민서                                             |
| **Last Update**             | 2025. 11. 06.                                   |
| **Status**                  | Analysis                                        |
| **Primary Actor**           | 플레이어                                            |
| **Preconditions**           | 플레이어가 '인게임' 씬에서 게임을 플레이 중이어야 한다.                |
| **Trigger**                 | 플레이어가 ESC 키를 눌렀을 때                              |
| **Success Post Condition**  | 게임의 모든 인게임 시스템 동작이 일시 중단되고, 일시 정지 화면이 호출된다.     |
| **Failed Post Condition**   | 실패 조건 없음                                        |

| **MAIN SUCCESS SCENARIO** |            |
|:--------------------------|:-----------|
| **Step**                  | **Action** |
| S                         | 플레이어가 게임을 일시 정지한다.  |
| 1                         | 이 Use case는 플레이어가 ESC 키를 누를 때 시작된다.   |
| 2                         | 시스템은 시간 측정, 몬스터 이동 등 모든 인게임 시스템 동작을 중단시킨다.   |
| 3                         | 시스템은 일시 정지 화면을 호출하며, 현재 진행 상황(보유 장비 등)을 요약하여 표시한다.    |
| 4                         | 시스템은 플레이어의 '계속하기' 또는 '게임 종료' 선택을 대기한다.  |

| **EXTENSION SCENARIOS** |                                                                                                                  |
|:------------------------|:-----------------------------------------------------------------------------------------------------------------|
| **Step**                | **Branching Action**                                                                                             |
| 4                       | 4a. 플레이어가 '계속하기' 버튼을 클릭한다. <br/> …4a1. 시스템은 일시 정지 화면을 닫고, 중단되었던 모든 인게임 시스템 동작을 재개한다.<br/>...4a2. Use Case가 종료된다. |
| 4                       | 4b. 플레이어가 '게임 종료' 버튼을 클릭한다. <br/> ...4b1. 시스템은 전체 게임 시스템을 종료한다.                                                  |


| **RELATED INFORMATION** |           |
|:------------------------|:----------|
| **Performance**         | (성능 요구사항) |
| **Frequency**           | (발생 빈도)   |
| **<Concurrency>**       | (동시성)     |
| **Due Date**            | (개발 마감일)  |
=======
=======

| **RELATED INFORMATION** |                 |
|:------------------------|:----------------|
| **Performance**         | 즉시 반응 ≤ 0.1초    |
| **Frequency**           | 플레이어의 판단에 따라 다름 |
| **<Concurrency>**       | 제한 없음           |
| **Due Date**            |        |

=======

#### Use case #[3] : 보상을 선택한다

| **GENERAL CHARACTERISTICS** |                                                 |
|:----------------------------|:------------------------------------------------|
| **Summary**                 | 플레이어가 레벨 업 또는 보스 처치 시 나타나는 3개의 보상 중 하나를 선택하는 기능 |
| **Scope**                   | 인게임                                             |
| **Level**                   | User level                                      |
| **Author**                  | 유민서                                             |
| **Last Update**             | 2025. 10. 29.                                   |
| **Status**                  | Analysis                                        |
| **Primary Actor**           | 플레이어                                            |
| **Preconditions**           | 플레이어의 캐릭터가 레벨 업 하거나, 보스 몬스터를 처치해야 한다.                                   |
| **Trigger**                 | 시스템이 '보상 화면'을 호출했을 때                                  |
| **Success Post Condition**  | 플레이어가 선택한 보상이 캐릭터에 적용되고, 보상 화면이 닫힌 후 게임이 재개된다.                                       |
| **Failed Post Condition**   | 실패 조건 없음                                      |


| **MAIN SUCCESS SCENARIO** |            |
|:--------------------------|:-----------|
| **Step**                  | **Action** |
| S                         | 플레이어가 보상을 선택한다.  |
| 1                         | 이 Use case는 시스템이 보상 화면을 호출할 때 시작된다.   |
| 2                         | 시스템은 3개의 선택 가능한 보상 목록을 표시한다.   |
| 3                         | 플레이어가 3개의 보상 중 하나를 선택하고 클릭한다.       |
| 4                         | 시스템은 선택된 보상('장비 획득' 또는 '기존 장비 강화')을 캐릭터에 적용한다.  |
| 5                         | 시스템은 보상 화면을 닫고 게임을 재개한다.                                                |
| 6                         | 이 Use case는 보상 적용이 완료되면 종료된다.                                                                        |


| **EXTENSION SCENARIOS** |                                                                                                                     |
|:------------------------|:--------------------------------------------------------------------------------------------------------------------|
| **Step**                | **Branching Action**                                                                                                |
| 3                       | 3a. 플레이어가 보상을 선택하는 대신 '보상 목록 새로고침' 버튼을 클릭한다<br/>…3a1. 시스템은 플레이어의 재화를 소모한다.<br/>...3a2. 시스템은 3개의 보상 목록을 새로고침하여 다시 표시한다.<br/>...3a3. 시나리오 3단계(보상 선택)로 돌아간다.|
| 3                       | 3b. 플레이어가 보상을 선택하는 대신 '건너뛰기'를 선택한다.<br/>…3b1. 시스템은 보상 화면을 닫고 플레이어에게 일정량의 경험치를 지급한다.<br/>...3b2. Use case가 종료된다.|

| **RELATED INFORMATION** |                      |
|:------------------------|:---------------------|
| **Performance**         | 즉시 반응 ≤ 0.1초         |
| **Frequency**           | 레벨 업 또는 보스 처치 시마다 발생 |
| **Concurrency**         | 제한 없음                |
| **Due Date**            |              |


#### Use case #[3] : 보상을 선택한다

| **GENERAL CHARACTERISTICS** |                                                 |
|:----------------------------|:------------------------------------------------|
| **Summary**                 | 플레이어가 레벨 업 또는 보스 처치 시 나타나는 3개의 보상 중 하나를 선택하는 기능 |
| **Scope**                   | 인게임                                             |
| **Level**                   | User level                                      |
| **Author**                  | 유민서                                             |
| **Last Update**             | 2025. 10. 29.                                   |
| **Status**                  | Analysis                                        |
| **Primary Actor**           | 플레이어                                            |
| **Preconditions**           | 플레이어의 캐릭터가 레벨 업 하거나, 보스 몬스터를 처치해야 한다.                                   |
| **Trigger**                 | 시스템이 '보상 화면'을 호출했을 때                                  |
| **Success Post Condition**  | 플레이어가 선택한 보상이 캐릭터에 적용되고, 보상 화면이 닫힌 후 게임이 재개된다.                                       |
| **Failed Post Condition**   | 실패 조건 없음                                      |


| **MAIN SUCCESS SCENARIO** |            |
|:--------------------------|:-----------|
| **Step**                  | **Action** |
| S                         | 플레이어가 보상을 선택한다.  |
| 1                         | 이 Use case는 시스템이 보상 화면을 호출할 때 시작된다.   |
| 2                         | 시스템은 3개의 선택 가능한 보상 목록을 표시한다.   |
| 3                         | 플레이어가 3개의 보상 중 하나를 선택하고 클릭한다.       |
| 4                         | 시스템은 선택된 보상('장비 획득' 또는 '기존 장비 강화')을 캐릭터에 적용한다.  |
| 5                         | 시스템은 보상 화면을 닫고 게임을 재개한다.                                                |
| 6                         | 이 Use case는 보상 적용이 완료되면 종료된다.                                                                        |


| **EXTENSION SCENARIOS** |                                                                                                                     |
|:------------------------|:--------------------------------------------------------------------------------------------------------------------|
| **Step**                | **Branching Action**                                                                                                |
| 3                       | 3a. 플레이어가 보상을 선택하는 대신 '보상 목록 새로고침' 버튼을 클릭한다<br/>…3a1. 시스템은 플레이어의 재화를 소모한다.<br/>...3a2. 시스템은 3개의 보상 목록을 새로고침하여 다시 표시한다.<br/>...3a3. 시나리오 3단계(보상 선택)로 돌아간다.|
| 3                       | 3b. 플레이어가 보상을 선택하는 대신 '건너뛰기'를 선택한다.<br/>…3b1. 시스템은 보상 화면을 닫고 플레이어에게 일정량의 경험치를 지급한다.<br/>...3b2. Use case가 종료된다.|

| **RELATED INFORMATION** |                      |
|:------------------------|:---------------------|
| **Performance**         | 즉시 반응 ≤ 0.1초         |
| **Frequency**           | 레벨 업 또는 보스 처치 시마다 발생 |
| **Concurrency**         | 제한 없음                |
| **Due Date**            |              |

#### Use case #[4] : 보상을 새로 고침한다.

| **GENERAL CHARACTERISTICS** |                                                 |
|:----------------------------|:------------------------------------------------|
| **Summary**                 | 보상목록을 재화를 이용하여 새로고침 하는 기능 |
| **Scope**                   | 인게임                                             |
| **Level**                   | User level                                      |
| **Author**                  | 김도경                                            |
| **Last Update**             | 2025. 11. 07.                                   |
| **Status**                  | Analysis                                        |
| **Primary Actor**           | 플레이어                                            |
| **Preconditions**           | 플레이어가 보상목록 화면에 있어야하고, 새로고침 할 재화가 충분해야한다. |
| **Trigger**                 | 플레이어가 '새로고침' 버튼을 눌렀을때                               |
| **Success Post Condition**  | 보상 목록 3개가 전부 다른 것으로 새로고침 된다.                     |
| **Failed Post Condition**   | 재화가 부족할 시 실패한다.                                     |


| **MAIN SUCCESS SCENARIO** |            |
|:--------------------------|:-----------|
| **Step**                  | **Action** |
| S                         | 플레이어가 보상을 '새로고침' 한다.  |
| 1                         | 이 Use case는 플레이어가 '새로고침' 버튼을 눌렀을 때 시작된다.   |
| 2                         | 시스템은 3개의 선택 보상을 다른 보상으로 새로고침 해준다.  |
| 3                         | 이 Use case는 새로운 보상으로 바뀌면 종료된다.     |
                                                                  


| **EXTENSION SCENARIOS** |                                                                                                                     |
|:------------------------|:--------------------------------------------------------------------------------------------------------------------|
| **Step**                |**BranchingAction**                                                                                                |
|

| **RELATED INFORMATION** |                      |
|:------------------------|:---------------------|
| **Performance**         | 새로 고침 시간 ≤ 1초         |
| **Frequency**           | 플레이어가 새로고침 버튼을 누를 때 발생 |
| **Concurrency**         | 제한 없음                |
| **Due Date**            |              |

#### Use case #[5] : 보상을 건너뛴다.

| **GENERAL CHARACTERISTICS** |                                                 |
|:----------------------------|:------------------------------------------------|
| **Summary**                 | 보상목록을 건너뛰는 기능 |
| **Scope**                   | 인게임                                             |
| **Level**                   | User level                                      |
| **Author**                  | 김도경                                            |
| **Last Update**             | 2025. 11. 07.                                   |
| **Status**                  | Analysis                                        |
| **Primary Actor**           | 플레이어                                            |
| **Preconditions**           | 플레이어가 보상목록 화면에 있어야한다. |
| **Trigger**                 | 플레이어가 '건너뛰기' 버튼을 눌렀을 때                           |
| **Success Post Condition**  | 보상 목록이 닫히고 일정량의 경험치를 획득한다.                    |
| **Failed Post Condition**   | 실패 조건 없음                                 |


| **MAIN SUCCESS SCENARIO** |            |
|:--------------------------|:-----------|
| **Step**                  | **Action** |
| S                         | 플레이어가 보상을 '건너뛰기' 한다.  |
| 1                         | 이 Use case는 플레이어가 '건너뛰기' 버튼을 눌렀을 때 시작된다.   |
| 2                         | 시스템은 보상 창을 닫고 플레이어 근처에 경험치 오브를 떨어뜨린다.   |
| 3                         | 이 Use Case는 '건너뛰기'버튼을 누르면 종료된다.     |
                                                                  


| **EXTENSION SCENARIOS** |                                                                                                                     |
|:------------------------|:--------------------------------------------------------------------------------------------------------------------|
| **Step**                |**BranchingAction**                                                                                                |
|

| **RELATED INFORMATION** |                      |
|:------------------------|:---------------------|
| **Performance**         | 건너뛰기 시간 ≤ 1초         |
| **Frequency**           | 플레이어가 '건너뛰기' 버튼을 누를 때 발생 |
| **Concurrency**         | 제한 없음                |
| **Due Date**            |              |





#### Use case #[6] : 캐릭터를 이동한다

| **GENERAL CHARACTERISTICS** |                                                            |
|:----------------------------|:-----------------------------------------------------------|
| **Summary**                 | 플레이어가 키보드를 조작하여 캐릭터를 맵 상에서 8방향으로 자유롭게 이동시키는 기능 |
| **Scope**                   | 인게임                                                        |
| **Level**                   | User level                                                 |
| **Author**                  | 유민서                                                        |
| **Last Update**             | 2025. 11. 06.                                              |
| **Status**                  | Analysis                                                   |
| **Primary Actor**           | 플레이어                                                       |
| **Preconditions**           | 플레이어가 '인게임' 씬에서 게임을 플레이 중이며, 캐릭터가 움직일 수 있는 상태이다.           |
| **Trigger**                 | 플레이어가 W, A, S, D 키 중 하나 이상을 누르고 있을 때                       |
| **Success Post Condition**  | 캐릭터가 플레이어가 입력한 방향으로 이동한다.                                  |
| **Failed Post Condition**   | 실패 조건 없음                                                   |

| **MAIN SUCCESS SCENARIO** |                                                          |
|:--------------------------|:---------------------------------------------------------|
| **Step**                  | **Action**                                               |
| S                         | 플레이어가 캐릭터를 이동한다.                                         |
| 1                         | 이 Use case는 플레이어가 W, A, S, D 중 하나 이상의 키를 누를 때 시작된다.      |
| 2                         | 시스템은 플레이어의 키 입력(상하좌우 또는 대각선)을 감지한다.                      |
| 3                         | 캐릭터는 해당 방향으로 CHA.Stat.1에 정의된 '이동 속도'에 맞춰 이동한다.           |
| 4                         | 이 Use case는 플레이어가 키에서 손을 떼어 이동 입력을 멈출 때 종료된다.                      |

| **EXTENSION SCENARIOS** |                                                                   |
|:------------------------|:------------------------------------------------------------------|
| **Step**                | **Branching Action**                                              |
| 3                       | 3a. 캐릭터가 이동 중 경험치 구슬 범위 내에 접근한다.<br/>…3a1. 경험치 구슬이 캐릭터 방향으로 끌려온다. |
| 3                       | 3b. 캐릭터가 이동 중 아이템 범위 내에 접근한다. <br/>...3b1. 해당 아이템의 갯수를 1개 증가시킨다.  |

| **RELATED INFORMATION** |                     |
|:------------------------|:--------------------|
| **Performance**         | 입력 지연 ≤ 0.05초       |
| **Frequency**           | 인게임 플레이 내내 지속적으로 발생 |
| **Concurrency**         | 제한 없음               |
| **Due Date**            |                     |

#### Use case #[7] : 영구 능력치를 강화한다

| **GENERAL CHARACTERISTICS** |                                                  |
|:----------------------------|:-------------------------------------------------|
| **Summary**                 | 플레이어가 능력치 강화화면에서 캐릭터의 기본 능력치를 올리는 기능             |
| **Scope**                   | 메인 화면                                            |
| **Level**                   | User level                                       |
| **Author**                  | 김병규                                              |
| **Last Update**             | 2025. 11. 06.                                    |
| **Status**                  | Analysis                                         |
| **Primary Actor**           | 플레이어                                             |
| **Preconditions**           | 플레이어가 '캐릭터 강화' 씬에 있으며, 강화에 필요한만큼 이상의 재화가 있어야 한다. |
| **Trigger**                 | 플레이어가 강화하려는 능력치의 버튼을 클릭했을 때                      |
| **Success Post Condition**  | 선택한 능력치가 정해진 수준만큼 증가한다.                          |
| **Failed Post Condition**   | 캐릭터의 능력치에 변화가 없다.                                |


| **MAIN SUCCESS SCENARIO** |                                                          |
|:--------------------------|:---------------------------------------------------------|
| **Step**                  | **Action**                                               |
| S                         | 플레이어가 캐릭터의 능력치를 강화한다.                                    |
| 1                         | 이 Use case는 플레이어가 캐릭터 강화화면에서 강화를 원하는 능력치의 버튼을 누를 때 시작된다. |
| 2                         | 시스템은 플레이어가 선택한 능력치를 정해진 수준만큼 증가시킨다.                      |
| 3                         | 이 Use case는 능력치를 증가시킨 후 종료된다.                            |

| **EXTENSION SCENARIOS** |                                                                                              |
|:------------------------|:---------------------------------------------------------------------------------------------|
| **Step**                | **Branching Action**                                                                         |
| 2                       | 2a. 플레이어가 강화에 필요한 충분한 재화를 가지고 있지 않다. <br/>...2a1. 능력치의 변화는 없으며, 강화에 필요한 재화가 부족함을 시각적으로 표시한다. |
| 2                       | 2b. 플레이어가 선택한 능력치가 이미 최대 강화에 도달했다. <br/>...2b1. 능력치의 변화는 없으며, 해당 능력치 강화 버튼이 비활성화된다.          |

| **RELATED INFORMATION** |                             |
|:------------------------|:----------------------------|
| **Performance**         | 즉시 반응 ≤ 0.1초                |
| **Frequency**           | 플레이어가 능력치 강화 버튼을 클릭 할때마다 발생 |
| **Concurrency**         | 제한 없음                       |
| **Due Date**            |                    |

#### Use case #[8] : 도감을 조회한다.

| **GENERAL CHARACTERISTICS** |                                          |
|:----------------------------|:-----------------------------------------|
| **Summary**                 | 게임에 등장한 오브젝트들(몬스터, 장비, 아이템)의 정보를 조회하는 기능 |
| **Scope**                   | 메인 화면                                    |
| **Level**                   | User level                               |
| **Author**                  | 김병규                                      |
| **Last Update**             | 2025. 11. 06.                            |
| **Status**                  | Analysis                                 |
| **Primary Actor**           | 플레이어                                     |
| **Preconditions**           | 플레이어가 '메인 화면' 씬에 있어야 한다.                 |
| **Trigger**                 | 플레이어가 '도감' 버튼을 클릭했을 때                    |
| **Success Post Condition**  | 현재 씬이 도감 화면으로 전환된다.                      |
| **Failed Post Condition**   | 실패 조건 없음                                 |


| **MAIN SUCCESS SCENARIO** |                                                         |
|:--------------------------|:--------------------------------------------------------|
| **Step**                  | **Action**                                              |
| S                         | 플레이어가 오브젝트의 상세정보를 조회한다.                                 |
| 1                         | 이 Use case는 플레이어가 메인 화면의 '도감' 버튼을 누를 때 시작된다.            |
| 2                         | 시스템은 오브젝트를 종류별(몬스터, 장비, 아이템)로 조회할 수 있는 화면을 제공한다.        |
| 3                         | 플레이어는 오브젝트 종류와 조회할 오브젝트를 선택하여 해당 오브젝트의 그림, 상세 정보를 확인한다. |
| 4                         | 이 Use case는 단계 3을 반복하다가 플레이어가 '뒤로 가기' 버튼을 누르면 종료된다.     |

| **EXTENSION SCENARIOS** |                                                                                                               |
|:------------------------|:--------------------------------------------------------------------------------------------------------------|
| **Step**                | **Branching Action**                                                                                          |
| 3                       | 3a. 플레이어가 게임에서 잡지 못한 몬스터나 획득한 적 없는 장비, 아이템의 정보는 확인할 수 없다. <br/> ...3a1 해당 오브젝트들은 실루엣으로만 표시하고 상세 정보를 표시하지 않는다. |

| **RELATED INFORMATION** |                      |
|:------------------------|:---------------------|
| **Performance**         | 즉시 반응 ≤ 0.1초         |
| **Frequency**           | 플레이어 당 게임 플레이에 평균 2번 |
| **Concurrency**         | 제한 없음                |
| **Due Date**            |                      |

#### Use case #[9] : 설정을 변경한다

| **GENERAL CHARACTERISTICS** |                                                  |
|:----------------------------|:-------------------------------------------------|
| **Summary**                 | 게임의 설정을 플레이어가 본인 환경에 맞게 변경하는 기능                  |
| **Scope**                   | 메인 화면                                            |
| **Level**                   | User level                                       |
| **Author**                  | 김병규                                              |
| **Last Update**             | 2025. 11. 06.                                    |
| **Status**                  | Analysis                                         |
| **Primary Actor**           | 플레이어                                             |
| **Preconditions**           | 플레이어가 플레이어가 메인 화면 혹은 인게임의 일시 정지상태에 있어야한다. |
| **Trigger**                 | 플레이어가 '설정' 버튼을 클릭했을 때                            |
| **Success Post Condition**  | 플레이어가 선택한 설정에 따라 화면크기, 음향 등이 변경된다.               |
| **Failed Post Condition**   | 실패 조건 없음                                         |

| **MAIN SUCCESS SCENARIO** |                                                  |
|:--------------------------|:-------------------------------------------------|
| **Step**                  | **Action**                                       |
| S                         | 플레이어가 게임의 설정을 변경한다.                              |
| 1                         | 이 Use case는 플레이어가 '설정' 버튼을 누르면 시작된다.             |
| 2                         | 시스템은 '설정' 버튼을 눌렀던 화면위에 팝업으로 설정창을 띄운다.            |
| 3                         | 플레이어는 각종 설정(화면 크기, 해상도, 음향)을 본인 환경에 맞게 설정한다.     |
| 4                         | 플레이어가 '적용하기' 버튼을 누르면 입력한 설정으로 환경이 변경된다.          |
| 5                         | 이 Use case는 단계 3~4 반복 중 플레이어가 '닫기' 버튼을 누르면 종료된다. |

| **EXTENSION SCENARIOS** |                                                                               |
|:------------------------|:------------------------------------------------------------------------------|
| **Step**                | **Branching Action**                                                          |
| 3                       | 3a. 설정창에서 '도감 초기화' 버튼을 누른다. <br/> ...3a1 현재 도감의 상태를 해금된 오브젝트가 없는 초기 상태로 되돌린다. |

| **RELATED INFORMATION** |                      |
|:------------------------|:---------------------|
| **Performance**         | 설정 변경 시간 ≤ 1초        |
| **Frequency**           | 플레이어 당 게임 플레이에 평균 1번 |
| **Concurrency**         | 제한 없음                |
| **Due Date**            |                      |

#### Use case #[10] : 도감을 초기화한다.

| **GENERAL CHARACTERISTICS** |                                                  |
|:----------------------------|:-------------------------------------------------|
| **Summary**                 | 플레이어가 모은 도감을 초기화하는 기능              |
| **Scope**                   | 메인 화면                                            |
| **Level**                   | User level                                       |
| **Author**                  | 김도경                                             |
| **Last Update**             | 2025. 11. 07.                                    |
| **Status**                  | Analysis                                         |
| **Primary Actor**           | 플레이어                                             |
| **Preconditions**           | 플레이어가 설정창을 열고 있어야한다. |
| **Trigger**                 | 플레이어가 '도감 초기화' 버튼을 클릭했을 때                            |
| **Success Post Condition**  | 도감이 아무것도 없는 상태로 초기화된다.            |
| **Failed Post Condition**   | 초기화가 제대로 되지않는다.                                        |

| **MAIN SUCCESS SCENARIO** |                                                  |
|:--------------------------|:-------------------------------------------------|
| **Step**                  | **Action**                                       |
| S                         | 플레이어가 도감을 초기화한다.                             |
| 1                         | 이 Use case는 플레이어가 '도감 초기화' 버튼을 눌렀을때 시작된다.            |
| 2                         | 시스템이 도감을 초기화한다.            |
| 3                         |이 Use case는 '도감 초기화' 버튼을 누르면 종료된다.    |


| **EXTENSION SCENARIOS** |                                                                               |
|:------------------------|:------------------------------------------------------------------------------|
| **Step**                | **Branching Action**                                                          |
| -                     | -

| **RELATED INFORMATION** |                      |
|:------------------------|:---------------------|
| **Performance**         | 도감 초기화 시간 ≤ 5초        |
| **Frequency**           | 플레이어 당 평균 1번 |
| **Concurrency**         | 제한 없음                |
| **Due Date**            |                      |


#### Use case #[11] : 아이템을 사용한다.

| **GENERAL CHARACTERISTICS** |                                  |
|:----------------------------|:---------------------------------|
| **Summary**                 | 게임 중 얻은 아이템들을 사용하는 기능            |
| **Scope**                   | 인게임                              |
| **Level**                   | User level                       |
| **Author**                  | 김병규                              |
| **Last Update**             | 2025. 11. 06.                    |
| **Status**                  | Analysis                         |
| **Primary Actor**           | 플레이어                             |
| **Preconditions**           | 플레이어가 '인게임' 씬에서 게임을 플레이 중이어야 한다. |
| **Trigger**                 | 플레이어가 아이템 사용에 할당된 키를 입력했을 때      |
| **Success Post Condition**  | 입력한 키에 따른 아이템을 사용한다.             |
| **Failed Post Condition**   | 아이템이 사용되지 않는다.                   |


| **MAIN SUCCESS SCENARIO** |                                                          |
|:--------------------------|:---------------------------------------------------------|
| **Step**                  | **Action**                                               |
| S                         | 플레이어가 인게임에서 획득한 아이템을 사용한다.                               |
| 1                         | 이 Use case는 플레이어가 아이템 사용 키(숫자키 1,2,3)를 누를 때 시작된다.        |
| 2                         | 시스템은 입력받은 키에 해당하는 아이템의 효과를 게임에 적용하고, 해당 아이템의 개수를 하나 줄인다. |
| 3                         | 이 Use case는 아이템의 효과가 사용되고 나면 종료된다.                       |

| **EXTENSION SCENARIOS** |                                                                  |
|:------------------------|:-----------------------------------------------------------------|
| **Step**                | **Branching Action**                                             |
| 2                       | 2a. 플레이어가 입력한 키에 해당하는 아이템의 개수가 0개이다. <br/> ...2a1 아이템이 사용되지 않는다. |

| **RELATED INFORMATION** |                     |
|:------------------------|:--------------------|
| **Performance**         | 즉시 반응 ≤ 0.1초        |
| **Frequency**           | 플레이어 당 인게임 중 평균 10번 |
| **Concurrency**         | 제한 없음               |
| **Due Date**            |                     |

#### Use case #[12] : 게임을 재시작한다

| **GENERAL CHARACTERISTICS** |                              |
|:----------------------------|:-----------------------------|
| **Summary**                 | 플레이어가 결과 화면에서 게임을 다시 시작하는 기능 |
| **Scope**                   | 인게임                          |
| **Level**                   | User level                   |
| **Author**                  | 김도경                          |
| **Last Update**             | 2025. 11. 06.                |
| **Status**                  | Analysis                     |
| **Primary Actor**           | 플레이어                         |
| **Preconditions**           | 게임 오버나 게임 클리어 결과 화면이어야 한다.   |
| **Trigger**                 | 플레이어가 '재시작' 버튼을 클릭했을 때       |
| **Success Post Condition**  | 게임의 상태가 초기화 되고, 다시 시작된다.     |
| **Failed Post Condition**   | 실패 조건 없음                     |


| **MAIN SUCCESS SCENARIO** |                                              |
|:--------------------------|:---------------------------------------------|
| **Step**                  | **Action**                                   |
| S                         | 플레이어가 게임을 처음부터 다시 시작한다.                      |
| 1                         | 이 Use case는 플레이어가 결과 화면의 '재시작' 버튼을 누르면 시작된다. |
| 2                         | 시스템은 인게임 시스템(타이머, 몬스터 스폰 등)을 초기화하고 다시 동작시킨다. |
| 3                         | 이 Use case는 인게임 시스템이 다시 실행된 후 종료된다.          |

| **RELATED INFORMATION** |              |
|:------------------------|:-------------|
| **Performance**         | 로딩 시간 ≤ 1초   |
| **Frequency**           | 플레이어 당 평균 3번 |
| **Concurrency**         | 제한 없음        |
| **Due Date**            |              |

#### Use case #[13] : 메인 화면으로 이동한다

| **GENERAL CHARACTERISTICS** |                               |
|:----------------------------|:------------------------------|
| **Summary**                 | 플레이어가 결과 화면에서 메인 화면으로 진입하는 기능 |
| **Scope**                   | 인게임                           |
| **Level**                   | User level                    |
| **Author**                  | 김병규                           |
| **Last Update**             | 2025. 11. 06.                 |
| **Status**                  | Analysis                      |
| **Primary Actor**           | 플레이어                          |
| **Preconditions**           | 게임 오버나 게임 클리어 결과 화면이어야 한다.    |
| **Trigger**                 | 플레이어가 '메인 화면으로' 버튼을 클릭했을 때    |
| **Success Post Condition**  | 현재 씬이 '메인 화면'으로 전환된다.         |
| **Failed Post Condition**   | 실패 조건 없음                      |


| **MAIN SUCCESS SCENARIO** |                                                  |
|:--------------------------|:-------------------------------------------------|
| **Step**                  | **Action**                                       |
| S                         | 플레이어가 게임을 끝내고 메인 화면으로 돌아간다.                      |
| 1                         | 이 Use case는 플레이어가 결과 화면의 '메인 화면으로' 버튼을 누르면 시작된다. |
| 2                         | 시스템은 씬을 '인게임'에서 '메인 화면'으로 전환한다.                  |
| 3                         | 이 Use case는 메인 화면 씬이 성공적으로 로드되면 종료된다.            |

| **RELATED INFORMATION** |              |
|:------------------------|:-------------|
| **Performance**         | 씬 로딩 시간 ≤ 3초 |
| **Frequency**           | 세션 당 1회      |
| **Concurrency**         | 제한 없음        |
| **Due Date**            |              |



---

## 3. Class diagram

> * Draw class diagrams.
> * Describe each class in detail (attributes, methods, others) (table type).

### 3.1 Class Diagram

![Class Diagram](imgs/classDiagram.jpg)

설명

### 3.2 Class Descriptions

**(클래스 템플릿 - 이 템플릿을 복사해서 클래스별로 작성!)**

#### Class: [ClassName]
* **Description:** (클래스에 대한 상세 설명, 예: 예약 정보 DB)

**Attributes (속성)**

| Name            | Description            | Type            | Visibility       |
|:----------------|:-----------------------|:----------------|:-----------------|
| `[FieldName]`   | (필드에 대한 설명, 예: 고유 식별자) | `[FieldType]`   | `Private/Public` |
| `currentState`  | 현재 게임 상태               | `GameState`     | `Private`        |
| `currentTime`   | 현재 플레이 시간              | `float`         | `Private`        |
| `playerManager` | 플레이어 매니저 참조            | `PlayerManager` | `Private`        |
| `...`           |                        |                 |                  |

**Operations (메서드)**

| Name                                | Description              | Type (Return)  | Visibility       |
|:------------------------------------|:-------------------------|:---------------|:-----------------|
| `[MethodName]([param]: [Type])`     | (메서드에 대한 설명, 예: 게임 일시정지) | `[ReturnType]` | `Public/Private` |
| `PauseGame()`                       | 게임을 일시정지 상태로 변경          | `void`         | `Public`         |
| `UpdateGameState(deltaTime: float)` | 게임 상태를 매 프레임 갱신          | `void`         | `Public`         |
| `...`                               |                          |                |                  |

### 3.2.1 Core Class

#### Class: [GameManager]
* **Description:** Manager 클래스들을 종합 관리하는 마스터 클래스

**Attributes (속성)**

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

**Operations (메서드)**

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

#### Class: [InputManager]
* **Description:** 사용자의 입력을 관리하는 매니저 클래스

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

**Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `Init()` | 모든 입력 값을 초기화하는 메서드 | `void` | `Public` |
| `ProcessInput()` | 매 프레임 입력 상태를 받아와 필드에 저장하고, 유효한 입력에 대해 이벤트 방송하는 메서드| `void` | `Public` |
| `IsKeyPressed(KeyCode keyCode)` | 특정 키가 눌리고 있는지 확인하는 메서드| `bool` | `Public` |
| `IsKeyDown(KeyCode keyCode)` | 특정 키가 눌렸는지 확인하는 메서드| `bool` | `Public` |
| `GetMouseCoord()` | 현재 마우스 커서의 씬 좌표를 반환하는 메서드| `Vector2` | `Public` |
| `IsMouseButtonPressed(int button)` | 특정 마우스 버튼을 누르고 있는지 확인하는 메서드 | `bool` | `Public` |
| `IsMouseButtonDown(int button)` | 특정 마우스 버튼이 눌렸는지 확인하는 메서드 | `bool` | `Public` |

#### Class: [SpawnManager]
* **Description:** 몬스터 생성을 관리하는 매니저 클래스

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

---
**Operations (메서드)**

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

#### Class: [EventManager]
* **Description:** 게임이 진행되는 동안 무작위 이벤트를 일정 주기로 발생시키는 클래스

**Attributes (속성)**

| Name           | Description | Type        | Visibility |
|:---------------|:------------|:------------|:-----------|
| `currentQuest` | 현재 퀘스트 정보   | `BaseQuest` | `Private`  |

**Operations (메서드)**

| Name                                  | Description   | Type (Return) | Visibility |
|:--------------------------------------|:--------------|:--------------|:-----------|
| `TryStartRandomQuest(gameTime:float)` | 돌발 이벤트 활성화 시도 | `void`        | `Public`   |
| `StartQuest(quest: BaseQuest)`        | 돌발 이벤트 시작     | `void`        | `Public`   |
| `UpdateCurrentQuest()`                | 이벤트 완료 여부 검사  | `void`        | `Public`   |
| `EndQuest()`                          | 이벤트 완료 처리     | `Vector2`     | `Public`   |

#### Class: [AudioManager]
* **Description:** 게임의 모든 사운드를 관리하는 매니저 클래스

**Attributes (속성)**

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

**Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `InitializeAudioDictionary()` | 배열의 내용을 각각 `bgmDictionary`와 `sfxDictionary`로 변환하여 클립을 이름으로 초기화하는 메서드 | `void` | `Private` |
| `PlayBGM(string clipName)` | 지정된 이름의 BGM 재생하는 메서드 | `void` | `Public` |
| `PlaySfx(string clipName)` | 지정된 이름의 SFX 클립을 재생하는 메서드 | `void` | `Public` |
| `StopBGM()` | BGM을 끄는 메서드 | `void` | `Public` |
| `SetMasterVolume(float level)` | 마스터 볼륨을 설정하고, 이 값을 반영하는 메서드 | `void` | `Public` |
| `SetBgmVolume(float level)` | BGM 개별 볼륨을 설정하고, 이 값을 반영하는 메서드 | `void` | `Public` |
| `SetSfxVolume(float level)` | SFX 개별 볼륨을 설정하고, 이 값을 반영하는 메서드 | `void` | `Public` |


#### Class: [PoolManager]
* **Description:** 오브젝트 풀링 시스템을 구현한 클래스

**Attributes (속성)**

| Name | Description | Type | Visibility |
|:---|:---|:---|:---|
| `Instance` | `PoolManager`의 싱글톤 인스턴스 | `PoolManager` | `Public Static` |
| `_pools` | Instance ID를 통해 풀 관리용 딕셔너리 | `Dictionary<int, Queue<GameObject>>` | `Private` |
| `_containers` | Hierarchy 정리를 위한, 풀별 부모를 관리하는 딕셔너리 | `Dictionary<int, Transform>` | `Private` |

**Operations (메서드)**

| Name | Description | Type (Return) | Visibility |
|:---|:---|:---|:---|
| `Get(GameObject prefab, Vector3 position, Quaternion rotation)` | 풀에서 오브젝트를 가져와 활성화하고 위치/회전을 설정하는 메서드| `GameObject` | `Public` |
| `ReturnToPool(GameObject obj, GameObject prefab)` | 사용이 끝난 오브젝트를 비활성화하고 해당 프리팹의 풀에 반환하는 메서드 | `void` | `Public` |
| `Preload(GameObject prefab, int count)` | 특정 프리팹에 대해 지정된 개수만큼 오브젝트를 미리 생성하는 메서드| `void` | `Public` |
| `InitPool(GameObject prefab)` | 풀이 들어갈 부모를 초기화 하는 메서드 | `void` | `Private` |



#### Class: [SaveManager]

* **Description:** 게임 내용을 저장하고 불러오는 클래스

**Attributes (속성)**
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

**Operations (메서드)**

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






### 3.2.2 Player Class

#### Class: [PlayerManager]
* **Description:** 플레이어 객체를 관리하는 매니저 클래스

**Attributes (속성)**

| Name               | Description  | Type               | Visibility |
|:-------------------|:-------------|:-------------------|:-----------|
| `stats`            | 플레이어의 능력치 참조 | `PlayerStats`      | `Private`  |
| `equipmentManager` | 플레이어 장비 참조   | `EquipmentManager` | `Private`  |
| `itemManager`      | 플레이어 아이템 참조  | `itemManager`      | `Private`  |
| `level`            | 플레이어 레벨      | `int`              | `Private`  |
| `currentExp`       | 플레이어의 현재 경험치 | `int`              | `Private`  |
| `maxExp`           | 플레이어의 최대 경험치 | `int`              | `Private`  |
| `killCount`        | 플레이어의 적 처치 수 | `int`              | `Private`  |

**Operations (메서드)**

| Name                                         | Description | Type (Return) | Visibility |
|:---------------------------------------------|:------------|:--------------|:-----------|
| `Move(direction: Vector2)`                   | 플레이어 이동 처리  | `void`        | `Public`   |
| `UseItem(slotIndex: int)`                    | 아이템 사용      | `void`        | `Public`   |
| `TakeDamage(amount: float)`                  | 입은 피해 처리    | `void`        | `Public`   |
| `Heal(amount: float)`                        | Hp 회복 처리    | `void`        | `Public`   |
| `GainExp(amount: int)`                       | 경험치 회복      | `void`        | `Public`   |
| `LevelUp()`                                  | 레벨 증가       | `void`        | `Public`   |
| `Die()`                                      | 플레이어 사망 처리  | `void`        | `Public`   |
| `AddEquipment(equipmentData: EquipmentData)` | 플레이어 장비 추가  | `void`        | `Public`   |

#### Class: [PlayerStats]
* **Description:** 플레이어의 능력치를 관리하는 데이터 클래스

**Attributes (속성)**

| Name                   | Description   | Type    | Visibility |
|:-----------------------|:--------------|:--------|:-----------|
| `Hp`                   | 체력            | `float` | `Private`  |
| `speed`                | 이동 속도         | `float` | `Private`  |
| `magnetRange`          | 드랍 오브젝트 획득 범위 | `float` | `Private`  |
| `reduceDamage`         | 입는 피해 감소      | `float` | `Private`  |
| `damageMult`           | 입히는 피해 배수     | `float` | `Private`  |
| `ciriticalProbability` | 치명타 확률        | `float` | `Private`  |
| `criticalDamageMult`   | 치명타 피해 배율     | `float` | `Private`  |
| `expMult`              | 획득 경험치 배율     | `float` | `Private`  |
| `goldMult`             | 획득 재화 배율      | `float` | `Private`  |
| `reduceCooldownMult`   | 장비 쿨다운 감소 배율  | `float` | `Private`  |
| `projectileSpeedMult`  | 투사체 속도 배율     | `float` | `Private`  |


#### Class: [EquipmentManager]
* **Description:** 플레이어의 장비를 관리하는 매니저 클래스

**Attributes (속성)**

| Name            | Description | Type                    | Visibility |
|:----------------|:------------|:------------------------|:-----------|
| `currentEquips` | 보유 장비 리스트   | `List<Equipment>[0..5]` | `Private`  |

**Operations (메서드)**

| Name                                                  | Description       | Type (Return) | Visibility |
|:------------------------------------------------------|:------------------|:--------------|:-----------|
| `UpdateAllEquipments(deltaTime: float)`               | 장비의 쿨다운, 자동 공격 갱신 | `void`        | `Public`   |
| `AddOrLevelUpEquipment(equipmentData: EquipmentData)` | 장비 획득 처리          | `void`        | `Public`   |

#### Class: [ItemManager]
* **Description:** 플레이어의 아이템을 관리하는 매니저 클래스

**Attributes (속성)**

| Name           | Description | Type               | Visibility |
|:---------------|:------------|:-------------------|:-----------|
| `currentItems` | 보유 장비 리스트   | `List<Item>[0..2]` | `Private`  |

**Operations (메서드)**

| Name                                       | Description | Type (Return) | Visibility |
|:-------------------------------------------|:------------|:--------------|:-----------|
| `ActivateItem(slotIndex: int)`             | 아이템 사용      | `void`        | `Public`   |
| `UpdateAllItemCooldowns(deltaTime: float)` | 아이템 쿨다운 갱신  | `void`        | `Public`   |

### 3.2.3 UI Class

#### Class: [HUDManager]
* **Description:** 인게임 씬의 실시간 정보 인터페이스를 관리하는 클래스

**Attributes (속성)**

| Name             | Description    | Type              | Visibility |
|:-----------------|:---------------|:------------------|:-----------|
| `hpBar`          | 플레이어의 체력 바     | `Slider`          | `Private`  |
| `expBar`         | 플레이어의 경험치 바    | `Slider`          | `Private`  |
| `bossHpBar`      | 보스 몬스터의 체력 바   | `Slider`          | `Private`  |
| `timerText    `  | 게임이 진행된 시간 텍스트 | `TextMeshProUGUI` | `Private`  |
| `goldText`       | 보유 중인 재화 텍스트   | `TextMeshProUGUI` | `Private`  |
| `killCountText`  | 처치한 적의 수 텍스트   | `TextMeshProUGUI` | `Private`  |
| `questInfoPanel` | 돌발 이벤트의 정보 패널  | `GameObject`      | `Private`  |

**Operations (메서드)**

| Name                                               | Description  | Type (Return) | Visibility |
|:---------------------------------------------------|:-------------|:--------------|:-----------|
| `UpdateHpBar(current: float, max: float)`          | 체력 바 갱신      | `void`        | `Public`   |
| `UpdateExpBar(current: float, max: float)`         | 경험치 바 갱신     | `void`        | `Public`   |
| `UpdateTimer(time: float)`                         | 시간 텍스트 갱신    | `void`        | `Public`   |
| `UpdateGold(amount: float)`                        | 보유 재화 텍스트 갱신 | `void`        | `Public`   |
| `ShowBossHpBar(current: float, max: float)`        | 보스 체력 바 표시   | `void`        | `Public`   |
| `ToggleQuestInfo(show: bool, description: string)` | 돌발 이벤트 정보 표시 | `void`        | `Public`   |

#### Class: [InGamePanelManager]
* **Description:** 인게임 씬의 패널 UI를 관리하는 클래스

**Attributes (속성)**

| Name             | Description | Type         | Visibility |
|:-----------------|:------------|:-------------|:-----------|
| `rewardPanel`    | 보상 패널       | `GameObject` | `Private`  |
| `pausePanel`     | 일시 정지 패널    | `GameObject` | `Private`  |
| `gameOverPanel`  | 게임 오버 패널    | `GameObject` | `Private`  |
| `gameClearPanel` | 게임 클리어 패널   | `GameObject` | `Private`  |

**Operations (메서드)**

| Name                             | Description  | Type (Return) | Visibility |
|:---------------------------------|:-------------|:--------------|:-----------|
| `ShowRewardPanel(show: bool)`    | 보상 패널 호출     | `void`        | `Public`   |
| `ShowPausePanel(show: bool)`     | 일시 정지 패널 호출  | `void`        | `Public`   |
| `ShowGameOverPanel(show: bool)`  | 게임 오버 패널 호출  | `void`        | `Public`   |
| `ShowGameClearPanel(show: bool)` | 게임 클리어 패널 호출 | `void`        | `Public`   |

#### Class: [RewardManager]
* **Description:** 보상 시스템을 관리하는 클래스

**Attributes (속성)**

| Name          | Description | Type  | Visibility |
|:--------------|:------------|:------|:-----------|
| `rerollCount` | 현재 새로고침 횟수  | `int` | `Private`  |
| `rerollPrice` | 새로고침 비용     | `int` | `Private`  |

**Operations (메서드)**

| Name                                    | Description | Type (Return) | Visibility |
|:----------------------------------------|:------------|:--------------|:-----------|
| `GenerateRewards()`                     | 보상 선택지 생성   | `void`        | `Public`   |
| `OnRewardSelected(data: EquipmentData)` | 보상 선택       | `void`        | `Public`   |
| `OnRerollPressed()`                     | 보상 선택지 새로고침 | `void`        | `Public`   |
| `OnSkipPressed()`                       | 보상 안 받고 넘기기 | `void`        | `Public`   |

#### Class: [MainMenuPanelManager]
* **Description:** 메인 메뉴 씬의 패널 UI를 관리하는 클래스

**Attributes (속성)**

| Name           | Description  | Type         | Visibility |
|:---------------|:-------------|:-------------|:-----------|
| `upgradePanel` | 캐릭터 영구 강화 패널 | `GameObject` | `Private`  |
| `codexPanel`   | 도감 패널        | `GameObject` | `Private`  |
| `settingPanel` | 설정 화면 패널     | `GameObject` | `Private`  |

**Operations (메서드)**

| Name                            | Description     | Type (Return) | Visibility |
|:--------------------------------|:----------------|:--------------|:-----------|
| `ShowUpgradePanel(show: bool)`  | 캐릭터 영구 강화 패널 호출 | `void`        | `Public`   |
| `ShowCodexPanel(show: bool)`    | 도감 패널 호출        | `void`        | `Public`   |
| `ShowSettingsPanel(show: bool)` | 설정 화면 패널 호출     | `void`        | `Public`   |

#### Class: [UpgradeManager]
* **Description:** 캐릭터 능력치 영구 강화를 관리하는 클래스

**Attributes (속성)**

| Name                         | Description  | Type  | Visibility |
|:-----------------------------|:-------------|:------|:-----------|
| `hpUpgrade`                  | 체력 강화 단계     | `int` | `Private`  |
| `speedUpgrade`               | 이동 속도 강화 단계  | `int` | `Private`  |
| `magnetUpgrade`              | 드롭 획득 범위 증가  | `int` | `Private`  |
| `criticalProbabilityUpgrade` | 치명타 확률 증가    | `int` | `Private`  |
| `criticalDamageMultUpgrade`  | 치명타 피해 배율 증가 | `int` | `Private`  |
| `expMultUpgrade`             | 경험치 획득 배율 증가 | `int` | `Private`  |
| `goldMult`                   | 재화 획득 배율 증가  | `int` | `Private`  |

**Operations (메서드)**

| Name                                      | Description    | Type (Return) | Visibility |
|:------------------------------------------|:---------------|:--------------|:-----------|
| `UpgradeStat(statToUpgrade: StatType)`    | 능력치 강화         | `void`        | `Public`   |
| `GetUpgradeCose(statToUpgrade: StatType)` | 능력치 강화 비용 계산   | `void`        | `Public`   |
| `ApplyAllUpgrades(stats: PlayerStats)`    | 강화된 능력치 인게임 적용 | `void`        | `Public`   |

#### Class: [CodexManager]
* **Description:** 도감 메뉴를 관리하는 클래스

**Attributes (속성)**

| Name            | Description       | Type                        | Visibility |
|:----------------|:------------------|:----------------------------|:-----------|
| `monsterList`   | 조우한 몬스터 리스트       | `List<MonsterData>[0..*]`   | `Private`  |
| `equipmentList` | 획득 이력이 있는 장비 리스트  | `List<EquipmentData>[0..*]` | `Private`  |
| `itemList`      | 획득 이력이 있는 아이템 리스트 | `List<ItemData>[0..*]`      | `Private`  |

#### Class: [SettingManager]
* **Description:** 설정 메뉴를 관리하는 클래스

**Attributes (속성)**

| Name              | Description | Type    | Visibility |
|:------------------|:------------|:--------|:-----------|
| `masterVolume`    | 마스터 불륨      | `float` | `Private`  |
| `resolutionIndex` | 해상도         | `int`   | `Private`  |
| `isFullScreen`    | 전체 화면 여부    | `bool`  | `Private`  |

**Operations (메서드)**

| Name                            | Description | Type (Return) | Visibility |
|:--------------------------------|:------------|:--------------|:-----------|
| `SetMasterVolume(level: float)` | 불륨 설정       | `void`        | `Public`   |
| `ApplyResolution(index: int)`   | 해상도 설정      | `void`        | `Public`   |

### 3.2.4 Data Class

#### Class: [Equipment]
* **Description:** 모든 장비가 상속받는 추상 클래스

**Attributes (속성)**

| Name       | Description | Type    | Visibility |
|:-----------|:------------|:--------|:-----------|
| `level`    | 장비 레벨       | `int`   | `Private`  |
| `cooldown` | 쿨다운         | `float` | `Private`  |

**Operations (메서드)**

| Name                               | Description | Type (Return) | Visibility |
|:-----------------------------------|:------------|:--------------|:-----------|
| `PerformAttack()`                  | 자동 공격       | `void`        | `Public`   |
| `LevelUp()`                        | 장비 레벨 증가    | `void`        | `Public`   |
| `UpdateCooldown(deltaTime: float)` | 쿨다운 갱신      | `void`        | `Public`   |

#### Class: [Item]
* **Description:** 모든 아이템이 상속받는 추상 클래스

**Attributes (속성)**

| Name         | Description | Type    | Visibility |
|:-------------|:------------|:--------|:-----------|
| `durability` | 최대 사용 횟수    | `int`   | `Private`  |
| `cooldown`   | 쿨다운         | `float` | `Private`  |

**Operations (메서드)**

| Name                               | Description | Type (Return) | Visibility |
|:-----------------------------------|:------------|:--------------|:-----------|
| `Activate()`                       | 아이템 사용      | `void`        | `Public`   |
| `UpdateCooldown(deltaTime: float)` | 쿨다운 갱신      | `void`        | `Public`   |

#### Class: [EquipmentData]
* **Description:** 장비의 이름, 설명, 아이콘 정보를 담는 클래스

**Attributes (속성)**

| Name          | Description | Type     | Visibility |
|:--------------|:------------|:---------|:-----------|
| `name`        | 이름          | `string` | `Private`  |
| `description` | 설명          | `string` | `Private`  |
| `icon`        | 장비 스프라이트    | `Sprite` | `Private`  |

#### Class: [ItemData]
* **Description:** 아이템의 이름, 설명, 아이콘 정보를 담는 클래스

**Attributes (속성)**

| Name          | Description | Type     | Visibility |
|:--------------|:------------|:---------|:-----------|
| `name`        | 이름          | `string` | `Private`  |
| `description` | 설명          | `string` | `Private`  |
| `icon`        | 아이템 스프라이트   | `Sprite` | `Private`  |

#### Class: [MonsterData]
* **Description:** 몬스터의 이름, 설명, 외형 정보를 담는 클래스

**Attributes (속성)**

| Name          | Description | Type     | Visibility |
|:--------------|:------------|:---------|:-----------|
| `name`        | 이름          | `string` | `Private`  |
| `description` | 설명          | `string` | `Private`  |
| `icon`        | 몬스터 스프라이트   | `Sprite` | `Private`  |

#### Class: [Projectile]
* **Description:** 투사체의 정보를 담는 클래스

**Attributes (속성)**

| Name      | Description | Type    | Visibility |
|:----------|:------------|:--------|:-----------|
| `genTime` | 객체가 생성된 시간  | `float` | `Private`  |
| `maxTime` | 객체가 소멸하는 시간 | `float` | `Private`  |
| `damage`  | 투사체 피해량     | `float` | `Private`  |

#### Class: [BaseQuest]
* **Description:** 모든 돌발 이벤트가 상속받는 추상 클래스

**Attributes (속성)**

| Name         | Description | Type    | Visibility |
|:-------------|:------------|:--------|:-----------|
| `questTimer` | 이벤트 지속 시간   | `float` | `Private`  |

**Operations (메서드)**

| Name            | Description  | Type (Return) | Visibility |
|:----------------|:-------------|:--------------|:-----------|
| `Start()`       | 이벤트 시작       | `void`        | `Public`   |
| `UpdateQuest()` | 이벤트 완료 여부 갱신 | `void`        | `Public`   |
| `End()`         | 이벤트 종료       | `void`        | `Public`   |

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

> * 5장은 게임 시스템 State machine diagram을 그리고 설명한다. 아래 [그림5-1]은 본 프로젝트에서 제작한 게임 시스템의 State machine diagram이다.

![state machine diagram](imgs/StateDiagram.png)


* 각 State는 게임에서 어떤 Scene을 보여주고 있는지에 대한 상태이고, Game Scene 내에서는 플레이어의 행동에 따라 캐릭터의 상태가 어떻게 바뀌는지 나타낸다.

&ensp;이 프로젝트의 State는 크게 Title Scene, Lobby, Option, Directory, Enhance, Game Scene, Game Over, Game Clear가 있다.
게임을 시작하게 되면 Title Scene에서 시작한다. Title 화면에서 아무키나 누르면 Lobby화면으로 이동한다. Lobby화면에서 Option 버튼을 누르면 옵션으로 그리고 Exit 버튼을 누르면 게임을 종료할 수 있다. Lobby에서는 도감 버튼을 눌러서 플레이어가 게임을 플레이하면서 모은 오브젝트들의 정보를 확인 할 수 있으며, 강화 버튼을 통해 Enhance로 가서 플레이할 캐릭터의 능력치를 플레이어가 원하는 대로 강화할 수 있다. 그리고 게임을 하기 위해서 Start 버튼을 누르면 Game Scene으로 들어간다. 

&ensp;Game Scene에 들어가면 본격적으로 게임을 플레이할 수 있다. 게임 특성상 공격은 자동으로 나가기 때문에 Player는 기본적으로 움직이는 Move 상태, 움직이지 않는 idle 상태, Enemy에게 데미지를 입은 Damaged 상태, 그리고 피가 0 이하면 죽는 Dead 상태가 있다. 시스템 내부적으로 Enemy는 Player의 주변에서 Spawn 된다. Spawn 상태 이후에 Player가 있는 방향으로 이동하는 Chase 상태, Player와 충돌하거나 공격 범위 내에 있을 때 공격하는 Attack 상태, 그리고 Player의 공격에 맞았을 때 데미지를 받는 Damaged 상태가 있다. 이 Enemy의 모든 행동은 Enemy의 hp가 0이 아닐 때 작동하며 hp가 0 이하가 되면 Enemy는 사라진다. 만약 Player가 Dead 상태가 되면 Game Over로 넘어간다. Game Over에서는 재시작 버튼을 눌러 다시 Game Scene으로 돌아가 게임을 할 수 있고 로비 버튼을 통해 Lobby로 돌아갈 수도 있다. 또한 플레이어가 마지막 보스를 쓰러뜨리면 Game Clear로 간다. Game Clear에서도 마찬가지로 Game Scene이나 Lobby로 돌아갈 수 있다. 게임은 Game Clear나 Game Over가 되면 끝난다. 

---

## 6. User interface prototype

> * 6장은 구현할 UI의 구조와 UI 안의 각 구성요소를 설명한다. 프로토타입이기 때문에 UI 디자인은 일부 달라질 수 있지만 내용 및 구성은 거의 동일하다.



### 6.1 타이틀 화면 (Title)

* 아래 [그림 6-1]은 게임을 맨 처음 실행하면 등장하는 타이틀 화면이다.

![Title](imgs/UI_Prototype/Title.png)


 &ensp;게임을 실행하면 처음으로 나타나는 타이틀 화면이다. 아무 키나 누르면 로비 화면으로 넘어간다.
### 6.2 환경설정 화면
* 아래 [그림 6-2]는 타이틀 화면에서 옵션창을 눌렀을 때 나오는 화면이다.

![Option](imgs/UI_Prototype/Option.png)



 &ensp;옵션을 선택하면 설정창을 팝업으로 띄워준다. 화면, 소리, 도감 초기화 부분에서 상세설정을 진행할 수 있다. 화면 부분에선 전체화면을 선택해 모니터 전체에 게임화면을 맞추거나 창모드를 선택해 해상도에 따른 창크기로 표시할 수도 있다. 화면모드, 해상도, 음향 크기를 원하는대로 설정한 후 적용하기 버튼을 누르면 입력한 설정대로 바뀌게 된다. 또한, ‘도감 초기화‘ 버튼을 누르면 플레이어가 해금한 도감의 내용들을 처음 상태로 되돌릴 수 있다. 설정이 끝나면 뒤로가기를 눌러 설정창을 닫을 수 있다.

### 6.3 로비 화면
* 아래 [그림 6-3]은 타이틀 화면에서 시작을 눌렀을 때 나오는 메인로비이다.

![Lobby](imgs/UI_Prototype/Lobby.png)


 &ensp;메인 화면에서는 게임을 진행할 캐릭터의 이미지와 설명을 보여준다. 설명 부분에서는 캐릭터의 고유 능력과 게임을 시작할 때 가지는 기본 장비를 알려준다. ‘캐릭터 강화’ 버튼을 누르면 게임 안에서 획득한 골드를 통해 영구적으로 캐릭터의 스탯을 강화할 수 있다. ‘도감’ 버튼을 눌러 몬스터, 장비, 아이템에 대한 간략한 설명을 볼 수 있으며, ‘시작하기’ 버튼을 눌러 게임을 시작할 수 있다.

### 6.4 도감 화면
* 아래 [그림 6-4]는 메인 로비에서 도감을 선택했을 때 나오는 도감화면이다.
![Compendium](imgs/UI_Prototype/Compendium.png)


 &ensp;도감에서는 게임에 등장하는 오브젝트를 유형별로 구분하여 각 버튼을 선택하면 몬스터, 장비, 아이템들을 모아서 볼 수 있다. 잡거나 획득했던적이 있는 오브젝트들은 클릭하여 오른쪽 화면에서 그림과 함께 상세정보를 확인할 수 있고, 그렇지 않은 오브젝트들은 실루엣으로 표시되어 상세정보를 확인할 수 없다. 좌측상단의 뒤로가기를 눌러 메인 화면으로 돌아갈 수 있다.

### 6.5 특성 선택 화면
* 아래 [그림 6-5]는 메인로비에서 캐릭터 강화를 선택했을 때 나오는 화면이다.
![Enhance](imgs/UI_Prototype/Enhance.png)


 &ensp;캐릭터 강화 화면에선 게임을 통해 획득한 골드를 사용하여 캐릭터의 능력치를 영구적으로 강화할 수 있다. 원하는 능력치에 마우스를 올리면 해당 능력치에 대한 상세 정보를 표시해준다. 좌측상단의 뒤로가기를 눌러 메인 화면으로 돌아갈 수 있다.

### 6.6 특성 설명 화면
* 아래 [그림 6-6]은 캐릭터 강화하면에서 능력치에 마우스를 올려놓았을 때 상세설명을 보여주는 화면이다.
![Enhance_description](imgs/UI_Prototype/Enhance_description.png)


### 6.7 인게임 기본 화면
*아래 [그림 6-7]은 게임을 시작했을 때 나오는 인게임 UI프로토타입이다.

![Ingame_Base](imgs/UI_Prototype/In_Game_Base.png)


 &ensp;인게임 UI 프로토타입을 보여준다. 좌측 상단에는 플레이어의 체력(HP)과 경험치(EXP)를 나타내는 바가 배치되어 있다. 그 하단에는 획득한 장비를 나타내는 6개의 슬롯 과 소모성 아이템을 표시하는 3개의 슬롯이 나란히 정렬되어 있다. 우측 상단에는 타이머가 남은 시간을 표시하며, 그 아래로는 플레이어가 보유한 총 재화와 몬스터 처치 수가 실시간으로 집계되어 나타난다.

### 6.8 인게임 Pause 화면 
* 아래 [그림 6-8]은 인게임 진행중에 ESC를 눌렀을 때 나오는 UI 프로토타입이다.

![Ingame_Pause](imgs/UI_Prototype/In_Game_Pause.png)


 &ensp;ESC 키를 누르면 화면이 어두워지며 게임이 일시 정지되고, 위 그림과 같은 메뉴 창이 나타난다. 좌측에는 '캐릭터 이미지'와 그 하단에 플레이어의 '종합 능력치(스탯)'가 표시된다. 중앙 상단에는 플레이어가 착용한 '장비' 슬롯이 있으며, 각 장비 아이콘에 마우스를 올리면 '장비 설명'란에 상세 정보가 나타난다. 중앙 하단에는 현재 '진행 시간'이 표시된다. 우측에는 게임을 '계속'하거나, '설정' 창을 열거나, 게임을 '종료'하고 시작 화면으로 돌아갈 수 있는 메뉴 버튼이 제공된다.


### 6.9 플레이어 데미지 받는 화면
* 아래 [그림 6-9]은 인게임 진행중 몬스터에게 공격받을 때의 UI 프로토타입이다.

![Damaged](imgs/UI_Prototype/Damaged.png)

    [그림 6-9]-데미지 받는 화면

 &ensp;플레이어의 캐릭터가 몬스터에게 닿거나 공격받으면 일정 수치의 데미지가 캐릭터 위에 표시되고 플레이어의 체력이 데미지 만큼 감소된다. 플레이어의 체력이 0이 되면 캐릭터가 사망하고 게임오버가 된다.


### 6.10 플레이어 공격 화면
* 아래 [그림 6-10]은 인게임 진행중 플레이어가 몬스터를 공격할 때의 UI 프로토타입이다.

![Attack](imgs/UI_Prototype/Attack.png)


 &ensp;몬스터를 공격하면 일정 수치의 데미지가 몬스터 위에 표시되고 몬스터의 체력이 데미지 만큼 감소한다. 몬스터 체력이 0이 되면 몬스터는 사망한다.

### 6.11 적처치 보상 오브젝트 화면
* 아래 [그림 6-11]은 인게임 진행중 플레이어가 몬스터를 처치할 때의 UI 프로토타입이다.

![Experience_Gold](imgs/UI_Prototype/Experience_Gold.png)


 &ensp;몬스터가 사망하면 플레이어가 일정량의 경험치를 획득할 수 있는 구슬이 나타난다. 구슬은 색깔별로 다른 경험치를 제공한다. 아이템과 장비를 획득하는 보물상자와 캐릭터를 강화할 수 있는 골드 또한 일정 확률로 나타난다.

 &ensp;몬스터가 사망하면 플레이어가 일정량의 경험치를 획득할 수 있는 구슬이 나타난다. 구슬은 색깔별로 다른 경험치를 제공한다. 아이템과 장비를 획득하는 보물상자와 캐릭터를 강화할 수 있는 골드 또한 일정 확률로 나타난다.

### 6.12 보스 등장 화면
* 아래 [그림 6-12]은 인게임 진행중 보스 몬스터가 등장할 때의 UI 프로토타입이다.

![Boss](imgs/UI_Prototype/Boss.png)


 &ensp;게임을 진행하다 보면 일정 시간마다 보스 몬스터가 출현한다. 보스 몬스터가 나타나면 화면 중앙에 보스 몬스터 등장 경고가 나타나고, 보스 몬스터 체력을 나타내는 보스 체력바가 화면에 나타난다. 보스 몬스터가 출현하고 있다면 타이머는 정지한다. 플레이어가 보스 몬스터를 처치하면 아이템과 장비를 획득하는 보물상자와 플레이어 레벨을 올려주는 경험치 구슬, 캐릭터 강화에 필요한 골드 등을 획득할 수 있다. 플레이어가 마지막 보스 몬스터를 처치하면 게임이 클리어된다.

 &ensp;게임을 진행하다 보면 일정 시간마다 보스 몬스터가 출현한다. 보스 몬스터가 나타나면 화면 중앙에 보스 몬스터 등장 경고가 나타나고, 보스 몬스터 체력을 나타내는 보스 체력바가 화면에 나타난다. 보스 몬스터가 출현하고 있다면 타이머는 정지한다. 플레이어가 보스 몬스터를 처치하면 아이템과 장비를 획득하는 보물상자와 플레이어 레벨을 올려주는 경험치 구슬, 캐릭터 강화에 필요한 골드 등을 획득할 수 있다. 플레이어가 마지막 보스 몬스터를 처치하면 게임이 클리어된다.

### 6.13 거점 보호 이벤트 발생 화면
* 아래 [그림 6-13]은 인게임 진행중 거점 이벤트가 발생할 때의 UI 프로토타입이다.

![Event](imgs/UI_Prototype/Event.png)


 &ensp;게임 진행 중 일정 확률로 거점 이벤트가 발생한다. 이때 플레이어는 정해진 구역을 몬스터의 공격으로부터 보호해야 하며 그 위치는 캐릭터 주변의 화살표를 통해 표시된다. 거점 이벤트는 5분간 진행되며 몬스터의 공격으로부터 보호 성공 시 아이템과 장비를 획득하는 보물상자를 얻을 수 있다.

 &ensp;게임 진행 중 일정 확률로 거점 이벤트가 발생한다. 이때 플레이어는 정해진 구역을 몬스터의 공격으로부터 보호해야 하며 그 위치는 캐릭터 주변의 화살표를 통해 표시된다. 거점 이벤트는 5분간 진행되며 몬스터의 공격으로부터 보호 성공 시 아이템과 장비를 획득하는 보물상자를 얻을 수 있다.

### 6.14 보상 선택 화면
* 아래 [그림 6-14]은 보상 화면을 나타내는 UI 프로토타입이다.

![Reward](imgs/UI_Prototype/Reward_Select.png)


&ensp;플레이어가 경험치를 획득하여 레벨 업을 하거나 보스 처치 이벤트 성공을 했을 때 나오는 상자를 먹으면 게임 화면이 어두워지며 위의 그림과 같은 창이 나타난다. 
총 3개의 선택할 수 있는 선택지가 제시되며, 각 선택지는 이미지와 설명을 포함한다. 보상의 유형은 ‘소모형 아이템 획득’, ‘신규 장비 획득’ 또는 ‘보유 장비 업그레이드’ 등이 나올 수 있다. 
보상 화면의 좌측 하단의 버튼을 누르면 위의 보상 목록을 변경할 수 있다. 우측 상단의 버튼을 누르면 보상을 포기하는 대신 경험치(EXP)를 획득할 수 있다.

### 6.15 장비/아이템 획득 화면 
*아래 [그림 6-15]은 보상을 획득했을 때 장비나 아이템이 표시되는 화면이다.

![Equip](imgs/UI_Prototype/Equipment_item.png)


 &ensp;필드에 나타나는 보물상자를 통해 얻은 아이템과 장비 등을 착용하게 되면 캐릭터 체력바 밑의 '장비'슬롯에 착용한 장비의 아이콘이 표시된다. 각 장비 아이콘에 마우스를 올리면 '장비 설명'란에 상세 정보가 나타난다.

 &ensp;필드에 나타나는 보물상자를 통해 얻은 아이템과 장비 등을 착용하게 되면 캐릭터 체력바 밑의 '장비'슬롯에 착용한 장비의 아이콘이 표시된다. 각 장비 아이콘에 마우스를 올리면 '장비 설명'란에 상세 정보가 나타난다.

### 6.16 게임 클리어 화면
*아래의 [그림 6-16]은 게임을 클리어 시 나오는 UI 프로토타입이다.

![GameClear](imgs/UI_Prototype/Game_Clear.png)


&ensp;상단 중앙에 클리어 메시지를 출력하여 게임이 끝났다는 것을 알려준다. 좌측에는 플레이한 캐릭터의 이미지와 장착한 장비들을 보여준다. 우측에는 플레이한 시간, 획득한 재화 그리고 처치한 몬스터의 수를 보여준다. 하단의 재시작 버튼을 누르면 게임을 처음부터 다시 시작한다. 메인 화면 버튼을 누르면 메인 화면으로 넘어간다.


### 6.17 게임 오버 화면
*아래 [그림 6-17]은 게임오버 되었을 때 나타나는 UI 프로토타입이다.

![GameOver](imgs/UI_Prototype/GameOver.png)


&ensp;상단 중앙에 ‘플레이어를 죽인 몹에게 죽었습니다.’ 메시지를 출력한다. 나머지는 클리어 UI와 동일하다.


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