using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventWithDelay : MonoBehaviour
{
    [SerializeField] UnityEvent thisEvents;
    [SerializeField] float timeDelay;
    [SerializeField] bool action;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(action==false)TimeCount();
        else{thisEvents.Invoke();}
        

    }
    void TimeCount()
    {
        timeDelay -= Time.deltaTime;
        if(timeDelay<= 0){action=true;}

    }
}
