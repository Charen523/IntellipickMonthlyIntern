
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerFSM stateMachine) : base(stateMachine) { }

    public override void Update()
    {
        if (fsm.Player.target == null)
        {
            Collider2D newTarget = Physics2D.OverlapArea(fsm.Player.searchPos1.position,
                                  fsm.Player.searchPos2.position,
                                  fsm.Player.targetLayer);
            fsm.Player.target = newTarget;
        }
    }
}
