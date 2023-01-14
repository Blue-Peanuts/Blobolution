using System;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private BaseState[] states;
    
    private int _currentStateId = 0;

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
        states[_currentStateId].enabled = false;
        _currentStateId = id;
        states[_currentStateId].enabled = true;
    }

    private void Update()
    {
        TryStateChange();
    }

    private void TryStateChange()
    {
        //call ChangeState if needs to
        //read MyGene to get transition info
    }
}