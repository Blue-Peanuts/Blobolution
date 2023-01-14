using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionTimeFromBirth : BaseCondition
{
    protected override float MaxValue => 10;
    protected override float MinValue => 1;

    protected override float Value(StateMachine machine)
    {
        return machine.LifeTime;
    }

}
public class ConditionTimeFromStateChange : BaseCondition
{
    protected override float MaxValue => 10;
    protected override float MinValue => 1;

    protected override float Value(StateMachine machine)
    {
        return machine.StateLifeTime;
    }

}
public class ConditionClosestFood : BaseCondition
{
    protected override float MaxValue => 20;
    protected override float MinValue => 1;

    protected override float Value(StateMachine machine)
    {
        return 
            machine.GetComponent<Blob>().GetDistanceToNearestOfGroup(machine.GetComponent<Blob>().
                FindAllNearTaggedObject("Food", 20), 20);
    }

}
public class ConditionClosestEnemy : BaseCondition
{
    protected override float MaxValue => 20;
    protected override float MinValue => 1;

    protected override float Value(StateMachine machine)
    {
        return machine.GetComponent<Blob>().GetDistanceToNearestOfGroup(machine.GetComponent<Blob>().
            GetAllNearEnemies(20), 20);
    }
        

}
public class ConditionClosestFriend : BaseCondition
{
    protected override float MaxValue => 20;
    protected override float MinValue => 1;

    protected override float Value(StateMachine machine)
    {
        return machine.GetComponent<Blob>().GetDistanceToNearestOfGroup(machine.GetComponent<Blob>().
            GetAllNearFriends(20), 20);
    }

}

public class ConditionEnergy : BaseCondition
{
    protected override float MaxValue => 100;
    protected override float MinValue => 0;

    protected override float Value(StateMachine machine)
    {
        return machine.GetComponent<Energy>().energyLevel;
    }

}