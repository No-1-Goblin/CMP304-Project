using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimescaleHandler : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Timescale: " + slider.value.ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Timescale: " + slider.value.ToString("0.00");
        Time.timeScale = slider.value;
    }
}
