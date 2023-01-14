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

    private Dictionary<int, List<(List<BaseCondition>, int)>> _mappedTransitions = null;

    public Dictionary<int, List<(List<BaseCondition>, int)>> MappedTransitions
    {
        get
        {
            if (_mappedTransitions == null)
                _mappedTransitions = GetMappedTransitions(Transitions);
            return _mappedTransitions;
        }
    }
    private Dictionary<int, List<(List<BaseCondition>, int)>> GetMappedTransitions(List<Transition> transitions)
    {
        Dictionary<int, List<(List<BaseCondition>, int)>> dict = new Dictionary<int, List<(List<BaseCondition>, int)>>();
        
        foreach (var transition in transitions)
        {
            if (!dict.ContainsKey(transition.FromStateId))
            {
                List<(List<BaseCondition>, int)> lst = new List<(List<BaseCondition>, int)>();
                lst.Add((transition.Conditions, transition.ToStateId));
                dict.Add(transition.FromStateId, lst);
            }
            else
            {
                dict[transition.FromStateId].Add((transition.Conditions, transition.ToStateId));
            }
        }

        return null;
    }
    
    public bool IsFriendsWith(Gene targetGene)
    {
        return false;
    }

    public static Gene RandomGene(GameObject blob)
    {
        Gene gene = blob.AddComponent<Gene>();
        gene._redPigment = Random.Range(0f, 1f);
        gene._greenPigment = Random.Range(0f, 1f);
        gene._bluePigment = Random.Range(0f, 1f);
        gene.Transitions.Add(Transition.RandomTransition());

        return gene;
    }

    public Gene Mutate(GameObject blob)
    {
        Gene newGene = blob.AddComponent<Gene>();
        
        newGene._redPigment = Random.Range(0f, 1f);
        newGene._greenPigment = Random.Range(0f, 1f);
        newGene._bluePigment = Random.Range(0f, 1f);
        
        newGene.Transitions = new List<Transition>();
        foreach (var tr in Transitions)
        {
            newGene.Transitions.Add(tr.Mutate());
        }

        return newGene;
    }
}