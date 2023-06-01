using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTxtManager : MonoBehaviour
{
    [HideInInspector]
    public float diamondScore;

    [HideInInspector]
    public float bonusMultiplier;
    public static ScoreTxtManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("DiamonScore: "+diamondScore.ToString() + " Bonus Multiplier: " + bonusMultiplier.ToString());
    }
}
