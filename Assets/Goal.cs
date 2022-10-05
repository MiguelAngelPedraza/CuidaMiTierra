using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    bool liebre, lobo, oso;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(liebre && oso && lobo)EndGame();
    }
    public void EndGame()
    {
        
        Debug.Log("WIN");
    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name=="Liebre")liebre=true;
        if(other.gameObject.name=="Lobo")lobo=true;
        if(other.gameObject.name=="OsoLabrador")oso=true;
    }
}
