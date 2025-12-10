## 6. 캐릭터 요구사항 (CHA) 테스트 명세

| ID | 업무명 (기능) | 요약 | 세부요구사항 설명 | 입력변수 | 정상 입력값 | 예외 입력값 | 추적성 | 우선순위 |
|:---|:-------------|:----:|:------------------|:--------:|:-----------:|:-----------:|:------:|:--------:|
| 6 | 캐릭터 | 캐릭터 시스템 | - | - | - | - | - | - |
| 6.1 | 캐릭터 행동 | 기본 조작 | - | - | - | - | - | - |
| 6.1.1 | 이동 (Move) | 2D 이동 조작 | InputManager를 통해 입력받은 수평(Horizontal), 수직(Vertical) 축 값을 기반으로 캐릭터를 이동시킨다.입력 방향에 따라 스프라이트(FlipX)와 애니메이션(IsWalk)을 갱신한다. | InputManager | Axis (-1.0 ~ 1.0) | - | PlayerManager.Move | High |
| 6.1.2 | 대시 (Dash) | 회피 및 돌진 | Space 키 입력 시, 현재 이동 방향으로 빠르게 돌진한다.대시 중에는 무적 상태가 되며, 경로상의 적에게 DashDamage를 입힌다. | InputManager, DashCooldown | Cooldown <= 0 | Cooldown > 0 | PlayerManager.TryDash | Medium |
| 6.1.3 | 공격 (Attack) | 자동 공격 | InventoryManager에 등록된 무기(Weapon)들이 각자의 쿨타임과 로직에 따라 자동으로 공격을 수행한다.무기 슬롯은 최대 6개로 제한된다. | InventoryManager | Weapons List | 슬롯 초과 | InventoryManager | High |
| 6.1.4 | 아이템 사용 | 소모품 사용 | 숫자 키 1, 2, 3을 입력하여 해당 슬롯의 아이템을 사용한다.사용 시 효과가 즉시 발동되며, 내구도가 소진되면 인벤토리에서 제거된다. | InputManager, Consumables | Index 0~2 | 빈 슬롯 호출 | PlayerManager.HandleItemUseInput | Low |
| 6.2 | 캐릭터 능력치 | 스탯 시스템 | - | - | - | - | - | - |
| 6.2.1 | 스탯 구성 | 스탯 정의 | 캐릭터는 다음 스탯을 보유하며 PlayerStats 클래스에서 관리된다.• 생존: MaxHp, DamageReductionMult, CooldownMult• 이동: Speed• 공격: AttackDamageMult, AttackSpeedMult, CritChance, CritDamageMult• 성장: ExpMult, GoldMult, MagnetRange | UpgradeType | Enum 정의 값 | 정의되지 않은 타입 | PlayerStats | High |
| 6.2.2 | 스탯 연산 | 보너스 합산 | 최종 스탯 값은 다음 공식에 따라 실시간으로 계산된다.Final = Base + PermanentBonus + PassiveBonus + EventBonus | Dictionary<Source, Value> | - | - | PlayerStats.GetBonus | High |
| 6.3 | 상태 변화 | 생명력 관리 | - | - | - | - | - | - |
| 6.3.1 | 피격 (Damage) | 데미지 처리 | 적과 충돌하거나 공격받으면 데미지 공식 Amount * (1 - DamageReduction)에 따라 체력이 감소한다.피격 시 일시적인 **무적 시간(깜빡임 효과)**이 적용된다. | TakeDamage(amount) | CurrentHp > 0 | 대시 중, 무적 중 | PlayerManager.TakeDamage | High |
| 6.3.2 | 회복 (Heal) | 체력 회복 | 아이템이나 레벨업 효과로 체력을 회복한다. 회복량은 MaxHp를 초과할 수 없다. | Heal(amount) | CurrentHp < MaxHp | - | PlayerManager.Heal | Medium |
| 6.3.3 | 사망 (Die) | 게임 오버 | CurrentHp가 0 이하가 되면 캐릭터는 비활성화(SetActive(false))되며, GameManager.GameOver()를 호출하여 게임을 종료한다. | CurrentHp <= 0 | - | - | PlayerManager.Die | High |
| 6.3.4 | 레벨업 | 성장 이벤트 | 경험치가 MaxExp에 도달하면 레벨이 상승한다.레벨업 시 MaxHp의 20%를 회복하고, 필요 경험치가 10% 증가한다. | CurrentExp | Current >= Max | - | PlayerManager.LevelUp | High |
| 6.4 | 상호작용 | 오브젝트 획득 | - | - | - | - | - | - |
| 6.4.1 | 자석 (Magnet) | 아이템 끌어당기기 | AcquireableObject는 캐릭터와의 거리가 MagnetRange 이내일 때 캐릭터 방향으로 이동한다. | Distance, MagnetRange | Dist < Range | - | AcquireableObject | Medium |
| 6.4.2 | 획득 (Acquire) | 아이템 수집 | 대상 오브젝트와의 거리가 0.5f 미만이 되면 획득 처리(OnAcquire)된다.종류에 따라 경험치, 골드, 아이템 등이 캐릭터에게 지급된다. | Distance | Dist < 0.5f | - | AcquireableObject | High |


