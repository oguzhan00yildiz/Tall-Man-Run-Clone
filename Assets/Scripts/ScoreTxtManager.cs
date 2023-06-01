using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTxtManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreTXT;
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
        scoreTXT.text = ((int) diamondScore).ToString();
        Debug.Log("DiamonScore: "+diamondScore.ToString() + " Bonus Multiplier: " + bonusMultiplier.ToString());
    }
}
