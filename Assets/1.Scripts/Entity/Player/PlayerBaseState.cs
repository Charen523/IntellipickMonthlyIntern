using UnityEngine;

public interface IState
{
    public void Enter();
    public void Update();
    public void Exit();
}

public class PlayerBaseState : IState
{
    protected PlayerFSM fsm;

    public PlayerBaseState(PlayerFSM stateMachine)
    {
        this.fsm = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}