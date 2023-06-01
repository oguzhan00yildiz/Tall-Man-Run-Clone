using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScaleControl : MonoBehaviour
{
    private Transform originalParent;
    private Vector3 originalScale;
    public Transform Target;
    public Transform HipSpine;
    public Transform ShoulderSpine;
    public Transform NeckSpine;
    public Transform BackSpine;
    private float ScaleRate;
    public float HeightRate;
    public bool TriggerIncrease;
    public bool TriggerIncreaseHeight;
    public bool TriggerDecrease;
    public bool TriggerDecreaseHeight;
    public GameObject StartPanel;
    public GameObject DeathPanel;
    public GameObject BossPanel;
    public bool BossPanelActivated;

    public List<GameObject> Spines=new List<GameObject>();
    public List<GameObject> SpinesVertical=new List<GameObject>();
    public static ScaleControl instance;


    private void Update()
    {

        if (BossPanelActivated)
            {
                BossPanel.SetActive(true);
            }

        if (HipSpine.transform.localScale.x<0||HipSpine.transform.localScale.y<0||HipSpine.transform.localScale.z<0 )
        {
            DeathPanel.SetActive(true);
            
            Destroy(gameObject);
            //ölme krranı getir
            
            
        }

        if (TriggerIncrease)
        {
            IncreaseScale();
            TriggerIncrease=false;
        }

        if (TriggerIncreaseHeight)
        {
            IncreaseHeight();
            TriggerIncreaseHeight=false;
            
        }
        if (TriggerDecrease)
        {
            DecreaseScale();
            TriggerDecrease=false;
        }

        if (TriggerDecreaseHeight)
        {
            DecreaseHeight();
            TriggerDecreaseHeight =false;
            
        }



        if (Input.GetMouseButtonDown(0))
        {
            StartPanel.SetActive(false);
        }
    }

    private void Start()
    {
        instance=this;
        
        StartPanel.SetActive(true);
    }


    

    private void IncreaseHeight()
    {
        BackSpine.transform.position+=new Vector3(0,HeightRate,0);

    }
    private void DecreaseHeight()
    {
        if (BackSpine.transform.localPosition.y>1f)
        {
            BackSpine.transform.position+=new Vector3(0,-HeightRate,0);
        }
        
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
    private void DecreaseScale()
    {
        
        HipSpine.transform.localScale+=new Vector3(-ScaleRate/2,-ScaleRate/2,-ScaleRate/5);

        ShoulderSpine.transform.localScale+=new Vector3(-ScaleRate/1.5f,-ScaleRate/1.5f,-ScaleRate/10);

        NeckSpine.transform.localScale+=new Vector3(-ScaleRate/2,0,-ScaleRate/2);

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        foreach (var item in Spines)
        {
             originalParent = item.transform.parent;

            // Objeyi unparent yap
            item.transform.SetParent(null,true);

            item.transform.localScale +=new Vector3(-ScaleRate,-ScaleRate,-ScaleRate);

            item.transform.SetParent(originalParent,true);

        }

        foreach (var item in SpinesVertical)
        {
            originalParent = item.transform.parent;

            // Objeyi unparent yap
            item.transform.SetParent(null,true);

            item.transform.localScale +=new Vector3(-ScaleRate,0,-ScaleRate);

            item.transform.SetParent(originalParent,true);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            Debug.Log(other.GetComponent<GateManager>().ScaleMultiplier);
            Debug.Log("scalerate  "+ScaleRate);
            ScaleRate=other.GetComponent<GateManager>().ScaleMultiplier;
        }
        
    }

}
