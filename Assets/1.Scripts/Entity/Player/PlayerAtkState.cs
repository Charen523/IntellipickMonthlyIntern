
public class PlayerAtkState : PlayerBaseState
{
    public PlayerAtkState(PlayerFSM stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        fsm.Player.animator.SetTrigger(fsm.Player.AnimData.AtkParamHash);
    }
}
