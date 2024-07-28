using UnityEngine;

public class IdleState : State
{
    public override void Enter()
    {
        Debug.Log("Entered Idle state!!!");
        isComplete = false;
    }

    public override void Exit()
    {
        Debug.Log("Exited Idle state. . .");
    }

    public override void PhysicsProcess()
    {
        if(script.input != 0)
        {
            isComplete = true;
        }
    }

    public override void Process()
    {
        
    }
}
