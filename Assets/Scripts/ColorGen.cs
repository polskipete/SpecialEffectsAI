using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGen : MonoBehaviour {
    public  ParticleSystem head;
    private bool mutate = false;
    private float random;
    private int addOrminus;

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

        mutate = GUILayout.Toggle(mutate, "Allow Mutation");


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
            AI();

        }

    }
    void AI()
    {
        if (mutate == true)
        {
            mutation();
        }
        else
        {


        }

    }

    void mutation()
    {
        random = Random.Range(1, 101);
        //Debug.Log("Mute Func::" +random);
        if (random <= 15)
         
        {

            if (hSliderValueR <= 0)
            {
                hSliderValueR = Random.Range(.05f, 1.0f);
            }
            if (hSliderValueG <= 0)
            {
                hSliderValueG = Random.Range(.05f, 1.0f);
            }
            if (hSliderValueB <= 0)
            {
                hSliderValueB = Random.Range(.05f, 1.0f);
            }
            if (hSliderValueA <= 0)
            {
                hSliderValueA = Random.Range(.05f, 1.0f);
            }


            // Debug.Log("Rando True");
            random = Random.Range(1,9);
            Debug.Log("Random::"+random);
            if (random == 1)
            {
                random = Random.Range(0.05f, .1f);
                addOrminus = Random.Range(1,101);
                //Debug.Log("Add or Minus::"+addOrminus);

                if (addOrminus <= 50 && hSliderValueR != 0)
                {
                    hSliderValueR = hSliderValueR - random;
                   // Debug.Log("M:Red:::"+random);
                }
                else if (addOrminus >= 50 && hSliderValueR != 1)
                {
                    hSliderValueR = hSliderValueR + random;
                    //Debug.Log("A:Red:::"+random);
                }
                return;
            }
            else if (random == 2)
            {
                random = Random.Range(0.05f, .1f);
                addOrminus = Random.Range(1, 101);
               // Debug.Log("Add or Minus::"+addOrminus);

                if (addOrminus <= 50)
                {
                    hSliderValueG = hSliderValueG - random;
                   // Debug.Log("M:Green:::"+random);
                }
                else if (addOrminus >= 50)
                {
                    hSliderValueG = hSliderValueR + random;
                   // Debug.Log("A:Green:::"+random);
                }
                return;
            }
            else if (random == 3)
            {
                random = Random.Range(0.05f, .1f);
                addOrminus = Random.Range(1, 101);

                if (addOrminus <= 50 )
                {
                    hSliderValueB = hSliderValueB - random;
                  //  Debug.Log("M:Blue:::" + random);
                }
                else if (addOrminus >= 50)
                {
                    hSliderValueB = hSliderValueB + random;
                   // Debug.Log("A:Blue:::" + random);
                }
                return;
            }
            else if (random == 4)
            {
                random = Random.Range(0.01f, .3f);
                addOrminus = Random.Range(1, 101);

                if (addOrminus <= 50)
                {
                    hSliderValueA = hSliderValueA - random;
                   
                }
                else if (addOrminus >= 50)
                {
                    hSliderValueA = hSliderValueA + random;
                    
                }
                return;
            }
            else if (random == 5)
            {
                random = Random.Range(0.01f, .3f);
                addOrminus = Random.Range(0, 1);

                if (addOrminus <= 50)
                {
                    hSliderValueR = hSliderValueR - random;
                    hSliderValueB = hSliderValueB - random;
                }
                else
                {
                    hSliderValueR = hSliderValueR + random;
                    hSliderValueB = hSliderValueB + random;
                }
                return;
            }
            else if (random == 6)
            {
                random = Random.Range(0.01f, .3f);
                addOrminus = Random.Range(0, 1);

                if (addOrminus <= 50)
                {
                    hSliderValueR = hSliderValueR - random;
                    hSliderValueG = hSliderValueG - random;
                }
                else
                {
                    hSliderValueR = hSliderValueR + random;
                    hSliderValueG = hSliderValueG + random;
                }
                return;
            }
            else if (random == 7)
            {
                addOrminus = Random.Range(0, 1);

                if (addOrminus <= 50)
                {
                    hSliderValueR = hSliderValueR - random;
                    hSliderValueA = hSliderValueA - random;
                }
                else
                {
                    hSliderValueR = hSliderValueR + random;
                    hSliderValueA = hSliderValueA + random;
                }
                return;
            }
            else if (random == 8)
            {
                random = Random.Range(0.01f, .3f);
                hSliderValueB = hSliderValueR - random;
                hSliderValueG = hSliderValueR - random;
                return;
            }
            
        }
    }
}
    

