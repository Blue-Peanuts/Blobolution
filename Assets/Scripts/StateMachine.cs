using System;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private BaseState[] states;
    
    private int _currentStateId = 0;

    private float _timeAtBirth;
    private float _timeAtStateChange;
    public float LifeTime => Time.time - _timeAtBirth;
    public float StateLifeTime => Time.time - _timeAtStateChange;

    private Gene _gene = null;
    private Gene MyGene {
        get
        {
            if (_gene == null)
                _gene = GetComponent<Gene>();
            return _gene;
        }
    }

    private void ChangeState(int id)
    {
        _timeAtStateChange = Time.time;
        states[_currentStateId].enabled = false;
        _currentStateId = id;
        states[_currentStateId].enabled = true;
    }

    private void Start()
    {
        _timeAtBirth = Time.time;
        _timeAtStateChange = Time.time;
    }

    private void Update()
    {
        TryStateChange();
    }

    private void TryStateChange()
    {
        //call ChangeState if needs to
        //read MyGene to get transition info

        var geneTransitions = MyGene.MappedTransitions;

        foreach (var tuple in geneTransitions[_currentStateId])
        {
            bool change = true;

            foreach (var condition in tuple.Item1)
            {
                if (!condition.Fullfilled())
                {
                    change = false;
                }
            }

            if (change)
            {
                ChangeState(tuple.Item2);
                break;
            }

        }


    }
    
    
}