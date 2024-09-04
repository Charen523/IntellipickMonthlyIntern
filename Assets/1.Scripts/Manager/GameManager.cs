using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public event Action MonsterDead;

    public readonly string arrowTag = "Arrow";
    public readonly string monsterTag = "Monster";

    public Monster curMonster;
    public MonsterInfoPopup MonsterInfo;

    private void Start()
    {
        MonsterDead += SpawnMonster;
        SpawnMonster();
    }

    private void SpawnMonster()
    {
        curMonster = ObjectPool.Instance.Get<Monster>(monsterTag);
    }

    public void OnMonsterDead()
    {
        MonsterDead?.Invoke();
    }
}