using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGen : MonoBehaviour {
    public  ParticleSystem head;
    public float hSliderValueR ;
    public float hSliderValueG ;
    public float hSliderValueB ;
    public float hSliderValueA ;

    public float hSliderValueRMax;
    public float hSliderValueGMax;
    public float hSliderValueBMax;
    public float hSliderValueAMax;

    public float hSliderValueRMin;
    public float hSliderValueGMin;
    public float hSliderValueBMin;
    public float hSliderValueAMin;

    void Start()
    {
        head = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        
        var main = head.main;
        main.startColor = new Color(hSliderValueR, hSliderValueG, hSliderValueB, hSliderValueA);
            }

    void OnGUI()
    {
        GUI.Label(new Rect(25, 40, 100, 30), "Red");
        GUI.Label(new Rect(25, 70, 100, 30), "Green");
        GUI.Label(new Rect(25, 100, 100, 30), "Blue");
        GUI.Label(new Rect(25, 130, 100, 30), "Alpha");

        hSliderValueR = GUI.HorizontalSlider(new Rect(95, 45, 100, 30), hSliderValueR, 0.0F, 1.0F);
        hSliderValueG = GUI.HorizontalSlider(new Rect(95, 75, 100, 30), hSliderValueG, 0.0F, 1.0F);
        hSliderValueB = GUI.HorizontalSlider(new Rect(95, 105, 100, 30), hSliderValueB, 0.0F, 1.0F);
        hSliderValueA = GUI.HorizontalSlider(new Rect(95, 135, 100, 30), hSliderValueA, 0.0F, 1.0F);


        if (GUI.Button(new Rect(20, 205, 50, 30), "Min"))
            {
                hSliderValueRMin= GUI.HorizontalSlider(new Rect(95, 45, 100, 30), hSliderValueR, 0.0F, 1.0F);
                hSliderValueGMin = GUI.HorizontalSlider(new Rect(95, 75, 100, 30), hSliderValueG, 0.0F, 1.0F);
                hSliderValueBMin = GUI.HorizontalSlider(new Rect(95, 105, 100, 30), hSliderValueB, 0.0F, 1.0F);
                hSliderValueAMin = GUI.HorizontalSlider(new Rect(95, 135, 100, 30), hSliderValueA, 0.0F, 1.0F);
                Debug.Log(hSliderValueRMin);
                Debug.Log(hSliderValueBMin);
            }
        if (GUI.Button(new Rect(120, 205, 50, 30), "Max"))
            {
                hSliderValueRMin = GUI.HorizontalSlider(new Rect(95, 45, 100, 30), hSliderValueR, 0.0F, 1.0F);
                hSliderValueGMin = GUI.HorizontalSlider(new Rect(95, 75, 100, 30), hSliderValueG, 0.0F, 1.0F);
                hSliderValueBMin = GUI.HorizontalSlider(new Rect(95, 105, 100, 30), hSliderValueB, 0.0F, 1.0F);
                hSliderValueAMin = GUI.HorizontalSlider(new Rect(95, 135, 100, 30), hSliderValueA, 0.0F, 1.0F);
            }
        if (GUI.Button(new Rect(60, 255, 65, 30), "Generate"))
            {
            Debug.Log("AI NOT DONE");

        }

    }
}
    

