using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseCondition
{
    public enum ConditionType
    {
        MoreThan, LessThan
    }

    protected StateMachine Machine;
    protected abstract float MaxValue
    {
        get;
    }

    protected abstract float MinValue
    {
        get;
    }
    
    public BaseCondition(StateMachine machine)
    {
        Machine = machine;
    }

    protected abstract float Value { get; }
    public ConditionType Type;
    public float Threshold;
    
    public bool Fullfilled()
    {
        if (Type == ConditionType.LessThan)
        {
            return Value < Threshold;
        }

        return Value > Threshold;
    }

    public void Mutate()
    {
        Threshold += Random.Range(1, -1) * (MaxValue - MinValue) / 5f;
        Threshold = Mathf.Clamp(Threshold, MinValue, MaxValue);
    }

    public static BaseCondition NewRandomCondition(StateMachine machine)
    {
        int roll = Random.Range(0, 6);
        BaseCondition[] conditions =
        {
            new ConditionTimeFromBirth(machine),
            new ConditionTimeFromStateChange(machine),
            new ConditionClosestFood(machine),
            new ConditionClosestEnemy(machine),
            new ConditionClosestFriend(machine),
            new ConditionEnergy(machine),
        };
        BaseCondition pickedCondition = conditions[roll];
        pickedCondition.Threshold = (pickedCondition.MaxValue + pickedCondition.MinValue) / 2;
        pickedCondition.Mutate();
        return pickedCondition;
    }
}