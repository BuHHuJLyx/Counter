using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Counter : MonoBehaviour
{
    public event Action<int> CounterChanged;

    [SerializeField] private InputReader _inputReader;

    private float _delay = 0.5f;
    private int _counter = 0;
    private bool _isActive = false;

    private Coroutine _coroutine;


    private void OnEnable()
    {
        _inputReader.MouseClicked += SwitchState;
    }

    private void OnDisable()
    {
        _inputReader.MouseClicked += SwitchState;
    }

    private void SwitchState()
    {
        if (_isActive)
        {
            _isActive = false;
            StopCoroutine(_coroutine);
        }
        else
        {
            _isActive = true;
            _coroutine = StartCoroutine(CounterRoutine(_delay));
        }
    }

    private IEnumerator CounterRoutine(float delay)
    {
        while (_isActive)
        {
            yield return new WaitForSeconds(delay);
            _counter++;
            CounterChanged?.Invoke(_counter);
        }
    }
}