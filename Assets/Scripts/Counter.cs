using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private float _delay = 0.5f;
    private int _counter = 0;
    private bool _isActive = false;

    private Coroutine _coroutine;

    private void Start()
    {
        _text.text = string.Empty;
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
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
    }

    private IEnumerator CounterRoutine(float delay)
    {
        while (_isActive)
        {
            yield return new WaitForSeconds(delay);
            _counter++;
            DisplayCounter(_counter);
        }
    }

    private void DisplayCounter(int counter)
    {
        _text.text = counter.ToString();
    }
}