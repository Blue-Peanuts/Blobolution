using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Transition
{
    private const int StateCount = 6;
    public int FromStateId;
    public int ToStateId;
    public List<BaseCondition> Conditions;

    public static Transition RandomTransition()
    {
        Transition transition = new Transition();
        transition.FromStateId = Random.Range(0, StateCount);
        transition.ToStateId = Random.Range(0, StateCount);
        transition.Conditions = new List<BaseCondition>();
        transition.Conditions.Add(BaseCondition.NewRandomCondition());

        return transition;
    }
    public Transition Mutate()
    {
        Transition newTransition = new Transition();
        newTransition.Conditions = new List<BaseCondition>();
        foreach (var condition in Conditions)
        {
            BaseCondition newCondition = (BaseCondition)Activator.CreateInstance(condition.GetType());
            newCondition.Threshold = condition.Threshold;
            if(Random.Range(0, 9) == 0)
                newCondition.Mutate();
            if(Random.Range(0, 9) != 0)
                newTransition.Conditions.Add(newCondition);
        }

        if (Random.Range(0, 9) == 0)
            newTransition.Conditions.Add(BaseCondition.NewRandomCondition());
        return newTransition;
    }
}