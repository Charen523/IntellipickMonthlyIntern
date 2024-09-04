using UnityEngine;

public class PlayerFSM
{
    public Player Player { get; set; }

    #region States
    private IState curState;
    public PlayerIdleState IdleState { get; set; }
    public PlayerAtkState AtkState { get; set; }
    #endregion

    #region Attack Timing
    private readonly float atkSpd;
    private float elapseTime;
    #endregion

    public PlayerFSM(Player player)
    {
        Player = player;
        
        IdleState = new PlayerIdleState(this);
        AtkState = new PlayerAtkState(this);

        atkSpd = player.data.baseAtkSpd;
    }

    public void ChangeState(IState state)
    {
        curState?.Exit();
        curState = state;
        curState?.Enter();
    }

    public void Update()
    {
        if (elapseTime <= 0 && Player.target != null)
        {
            elapseTime = atkSpd;
            ChangeState(AtkState);
        }
        elapseTime -= Time.deltaTime;

        curState?.Update();
    }
}
