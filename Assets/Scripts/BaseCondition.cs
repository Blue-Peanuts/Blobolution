using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseCondition
{
    public enum ConditionType
    {
        MoreThan, LessThan
    }
    protected abstract float MaxValue
    {
        get;
    }

    protected abstract float MinValue
    {
        get;
    }

    protected abstract float Value(StateMachine machine);
    public ConditionType Type;
    public float Threshold;
    
    public bool Fullfilled(StateMachine machine)
    {
        if (Type == ConditionType.LessThan)
        {
            return Value(machine) < Threshold;
        }

        return Value(machine) > Threshold;
    }
    public void Mutate()
    {
        Threshold += Random.Range(1, -1) * (MaxValue - MinValue) / 5f;
        Threshold = Mathf.Clamp(Threshold, MinValue, MaxValue);
    }

    public static BaseCondition NewRandomCondition()
    {
        int roll = Random.Range(0, 6);
        BaseCondition[] conditions =
        {
            new ConditionTimeFromBirth(),
            new ConditionTimeFromStateChange(),
            new ConditionClosestFood(),
            new ConditionClosestEnemy(),
            new ConditionClosestFriend(),
            new ConditionEnergy(),
        };
        BaseCondition pickedCondition = conditions[roll];
        pickedCondition.Threshold = (pickedCondition.MaxValue + pickedCondition.MinValue) / 2;
        pickedCondition.Mutate();
        return pickedCondition;
    }
}