using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct StatModifier
{
    public UpgradeType statType; // StatType -> UpgradeType으로 변경
    [Tooltip("더할 값 (예: Speed 2.0은 속도 +2, AttackDamageMult 0.5는 공격력 +0.5)")]
    public float value;
}

[CreateAssetMenu(fileName = "GameEventData", menuName = "Scriptable Objects/GameEventData")]
public class GameEventData : ScriptableObject
{
    [Header("Event Info")]
    public string eventName;
    [TextArea] public string description;
    public string notificationMessage; // 예: "피의 비가 내립니다! (공격력 증가, 방어력 감소)"
    
    [Header("Settings")]
    public float duration = 10f; // 이벤트 지속 시간

    [Header("Effects")] public List<StatModifier> statModifiers = new List<StatModifier>();
}
