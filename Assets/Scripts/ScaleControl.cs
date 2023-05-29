using UnityEngine;
﻿using System.Collections;
using System.Collections.Generic;

public class ScaleControl : MonoBehaviour
{
    public List<GameObject> thicknespieces=new List<GameObject>();

    [SerializeField] private GameObject root;

    private void Start()
    {
        Thicknes(1f);
    }

    public void Thicknes(float value)
    {
        foreach (GameObject item in thicknespieces)
        {
            item.transform.localScale += new Vector3(value, 0, value);
        }

        //root.transform.localScale += new Vector3(value, value * 0.5f, value);
    }
}
