using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem instance;

    public delegate void DelegateAction();
    public event DelegateAction sampleAction;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void OnSampleAction()
    {
        if (sampleAction != null)
        {
            sampleAction();
        }
    }
    
}
