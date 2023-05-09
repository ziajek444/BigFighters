using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class counterScript : MonoBehaviour
{

    private int counterValue;
    [SerializeField] private Text counterText;
    [SerializeField] private int maxValue = 8;
    [SerializeField] private int minValue = 1;

    void Start()
    {
        counterValue = minValue;
        counterText.text = counterValue.ToString() + "/" + maxValue.ToString();
    }

    public void IncrementingEventCounter()
    {
        if (counterValue < maxValue)
        {
            counterValue++;
            counterText.text = counterValue.ToString() + "/" + maxValue.ToString();
        }
        
    }

    public void DecrementingEventCounter()
    {
        if (counterValue > minValue)
        {
            counterValue--;
            counterText.text = counterValue.ToString() + "/" + maxValue.ToString();
        }
    }

    public int GetCounterValue()
    { return counterValue; }
}
