
public class PlayerAtkState : PlayerBaseState
{
    public PlayerAtkState(PlayerFSM stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        if (fsm.Player.target == null) fsm.ChangeState(fsm.IdleState);
        fsm.Player.animator.SetTrigger(fsm.Player.AnimData.AtkParamHash);
    }
}
