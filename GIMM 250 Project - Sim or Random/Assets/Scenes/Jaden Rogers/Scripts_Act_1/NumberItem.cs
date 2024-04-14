using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberItem : Item
{
    public float numberValue;
    [SerializeField] private TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp.text = numberValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
