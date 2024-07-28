using UnityEngine;

public abstract class State : MonoBehaviour
{
    public bool isComplete { get; protected set; } = false;

    public Paddle script;

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Process();  
    public abstract void PhysicsProcess();
}
