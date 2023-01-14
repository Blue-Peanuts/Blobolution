using System.Collections.Generic;
using UnityEngine;

public class Gene : MonoBehaviour
{
    private const int StateCount = 4;
    
    private float _redPigment = 0.5f;
    public float RedPigment
    {
        get => _redPigment;
        set
        {
            _redPigment = value;
            _redPigment = Mathf.Clamp(_redPigment, 0, 1);
        }
    }
    private float _bluePigment = 0.5f;
    public float BluePigment
    {
        get => _bluePigment;
        set
        {
            _bluePigment = value;
            _bluePigment = Mathf.Clamp(_greenPigment, 0, 1);
        }
    }
    private float _greenPigment = 0.5f;
    public float GreenPigment
    {
        get => _greenPigment;
        set
        {
            _greenPigment = value;
            _greenPigment = Mathf.Clamp(_greenPigment, 0, 1);
        }
    }

    public List<Transition> Transitions = null;

    public List<int> inheritance;

    private Dictionary<int, (List<BaseCondition>, int)> _mappedTransitions = null;

    public Dictionary<int, (List<BaseCondition>, int)> MappedTransitions
    {
        get
        {
            if (_mappedTransitions == null)
                _mappedTransitions = GetMappedTransitions(Transitions);
            return _mappedTransitions;
        }
    }

    private Dictionary<int, (List<BaseCondition>, int)> GetMappedTransitions(List<Transition> transitions)
    {
        //Implement mapped transitions here
        return null;
    }
}