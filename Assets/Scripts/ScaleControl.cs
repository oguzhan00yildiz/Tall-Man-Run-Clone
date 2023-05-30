using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScaleControl : MonoBehaviour
{
    private Transform originalParent;
    private Vector3 originalScale;
    public Transform Target;
    public Transform HipSpine;
    public Transform ShoulderSpine;
    public Transform NeckSpine;
    public float firstY;
    public float value;
    public float ScaleRate;
    public bool TriggerIncrease;

    public List<GameObject> Spines=new List<GameObject>();
    public List<GameObject> SpinesVertical=new List<GameObject>();


    private void Update()
    {
        if (TriggerIncrease)
        {
            IncreaseScale();
            TriggerIncrease=false;
        }
    }

    private void Start()
    {

        
    }

    
    private void IncreaseScale()
    {
        HipSpine.transform.localScale+=new Vector3(ScaleRate/2,ScaleRate/2,ScaleRate/5);

        ShoulderSpine.transform.localScale+=new Vector3(ScaleRate/1.5f,ScaleRate/1.5f,ScaleRate/10);

        NeckSpine.transform.localScale+=new Vector3(ScaleRate/2,0,ScaleRate/2);

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        foreach (var item in Spines)
        {
             originalParent = item.transform.parent;

            // Objeyi unparent yap
            item.transform.SetParent(null,true);

            item.transform.localScale +=new Vector3(ScaleRate,ScaleRate,ScaleRate);

            item.transform.SetParent(originalParent,true);

        }

        foreach (var item in SpinesVertical)
        {
            originalParent = item.transform.parent;

            // Objeyi unparent yap
            item.transform.SetParent(null,true);

            item.transform.localScale +=new Vector3(ScaleRate,0,ScaleRate);

            item.transform.SetParent(originalParent,true);
        }


    }
}
