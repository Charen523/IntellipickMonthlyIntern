using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public event Action OnMonsterDead;

    public readonly string arrowTag = "Arrow";
    public readonly string monsterTag = "Monster";

    public Monster curMonster;
    public MonsterInfoPopup MonsterInfo;

    private void Start()
    {
        SpawnMonster();
    }

    public void SpawnMonster()
    {
        curMonster = ObjectPool.Instance.Get<Monster>(monsterTag);
    }

    public void MonsterDeadEvent()
    {
        OnMonsterDead?.Invoke();
    }
}