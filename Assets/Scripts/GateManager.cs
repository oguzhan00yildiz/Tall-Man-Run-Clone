using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    [SerializeField] private bool height;
    [SerializeField] private bool increase;
    public float ScaleMultiplier;

    public static GateManager instance;
    
    void Start()
    {
        instance=this;
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            if (increase)
            {
            if (height)
            {
                ScaleControl.instance.TriggerIncreaseHeight=true;
            }
            else
            {
                ScaleControl.instance.TriggerIncrease=true;
            }
            }
            else
            {
                if (height)
                {
                    ScaleControl.instance.TriggerDecreaseHeight=true;
                }
                else
                {
                    ScaleControl.instance.TriggerDecrease=true;
                }
                
            }
        }
    }
}
