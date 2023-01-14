public abstract class BaseCondition
{
    public enum ConditionType
    {
        MoreThan, LessThan
    }

    protected abstract float Value { get; }
    public ConditionType type;
    public float threshold;
    
    public bool Fullfilled()
    {
        if (type == ConditionType.LessThan)
        {
            return Value < threshold;
        }

        return Value > threshold;
    }
}