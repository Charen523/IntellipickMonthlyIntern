using System;
using UnityEngine;

[Serializable]
public class PlayerAnimData
{
    [SerializeField] private string atkParam = "IsAtk";
    public int AtkParamHash { get; private set; }

    public void Initialize()
    {
        AtkParamHash = Animator.StringToHash(atkParam);
    }
}

public class Player : MonoBehaviour
{
    public PlayerAnimData AnimData { get; private set; }
    public PlayerData data { get; private set; }

    public Animator animator;
    private PlayerFSM fsm;

    public Transform arrowPos;

    public LayerMask targetLayer;
    public Collider2D target;
    public Transform searchPos1;
    public Transform searchPos2;

    private void Awake()
    {
        AnimData = new PlayerAnimData();
        data = new PlayerData();
        AnimData.Initialize();
        fsm = new PlayerFSM(this);

        GameManager.Instance.OnMonsterDead += ResetTarget;
    }

    private void Update()
    {
        fsm.Update();
    }

    private void ResetTarget()
    {
        target = null;
    }

    public void ArrowStart()
    {
        if (target != null)
        {
            Arrow arrow = ObjectPool.Instance.Get<Arrow>(GameManager.Instance.arrowTag);
            arrow.GetAttackSign(arrowPos.position, data.baseDmg);
        }
    }

    public void AtkAnimEnd()
    {
        fsm.ChangeState(fsm.IdleState);
    }
}
