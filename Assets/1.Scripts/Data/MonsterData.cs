using System;

public interface IData
{
    public string Id { get; }
}

[Serializable]
public class MonsterData : IData
{
    public string id;
    public string Name;
    public string Grade;
    public float Speed;
    public int Health;

    public string Id => id.ToString();
}
