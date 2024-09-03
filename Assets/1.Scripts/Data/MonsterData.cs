using System;
using UnityEngine;

public interface IData
{
    public string Id { get; }
}

[Serializable]
public class MonsterData : IData
{
    public string Name;
    public string Grade;
    public float Speed;
    public int Health;

    public string Id => Name;
}
