using System.Collections.Generic;

public class Transition
{
    public int FromStateId;
    public int ToStateId;
    public List<BaseCondition> Conditions;
}