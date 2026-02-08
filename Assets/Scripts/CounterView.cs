using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;   

    private void OnEnable()
    {
        _counter.CounterChanged += DisplayCounter;
    }

    private void Start()
    {
        _text.text = string.Empty;
    }

    private void OnDisable()
    {
        _counter.CounterChanged -= DisplayCounter;
    }

    private void DisplayCounter(int counter)
    {
        _text.text = counter.ToString();
    }
}
