using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionTimeFromBirth : BaseCondition
{
    protected override float MaxValue => 10;
    protected override float MinValue => 1;
    protected override float Value => Machine.LifeTime;

    public ConditionTimeFromBirth(StateMachine machine) : base(machine)
    {
    }
}
public class ConditionTimeFromStateChange : BaseCondition
{
    protected override float MaxValue => 10;
    protected override float MinValue => 1;
    protected override float Value => Machine.StateLifeTime;

    public ConditionTimeFromStateChange(StateMachine machine) : base(machine)
    {
    }
}
public class ConditionClosestFood : BaseCondition
{
    protected override float MaxValue => 20;
    protected override float MinValue => 1;
    protected override float Value => 
        Machine.GetComponent<Blob>().GetDistanceToNearestOfGroup(Machine.GetComponent<Blob>().
            FindAllNearTaggedObject("Food", 20), 20);

    public ConditionClosestFood(StateMachine machine) : base(machine)
    {
    }
}
public class ConditionClosestEnemy : BaseCondition
{
    protected override float MaxValue => 20;
    protected override float MinValue => 1;
    protected override float Value => 
        Machine.GetComponent<Blob>().GetDistanceToNearestOfGroup(Machine.GetComponent<Blob>().
            GetAllNearEnemies(20), 20);

    public ConditionClosestEnemy(StateMachine machine) : base(machine)
    {
    }
}
public class ConditionClosestFriend : BaseCondition
{
    protected override float MaxValue => 20;
    protected override float MinValue => 1;
    protected override float Value => 
        Machine.GetComponent<Blob>().GetDistanceToNearestOfGroup(Machine.GetComponent<Blob>().
            GetAllNearFriends(20), 20);

    public ConditionClosestFriend(StateMachine machine) : base(machine)
    {
    }
}

public class ConditionEnergy : BaseCondition
{
    protected override float MaxValue => 100;
    protected override float MinValue => 0;
    protected override float Value => Machine.GetComponent<Energy>().energyLevel;

    public ConditionEnergy(StateMachine machine) : base(machine)
    {
    }
}