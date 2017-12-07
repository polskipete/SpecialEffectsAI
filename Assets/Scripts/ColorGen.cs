using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ColorGen : MonoBehaviour {
    public  ParticleSystem head;

    private bool mutate = false;
    private float random;
    private int addOrminus;
    public int saveNum;

    public int x;

    public float RangeRMax;
    public float RangeRMin;

    public float RangeBMax;
    public float RangeBMin;

    public float RangeGMax;
    public float RangeGMin;

    public float RangeAMax;
    public float RangeAMin;


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

    public float hSliderValueRSum=0;
    public float hSliderValueGSum=0;
    public float hSliderValueBSum=0;
    public float hSliderValueASum=0;

    public float hSliderValueRBACK;
    public float hSliderValueGBACK;
    public float hSliderValueBBACK;
    public float hSliderValueABACK;

    void Start()
    {
        head = GetComponent<ParticleSystem>();
        x = 1;
        do
        {
            hSliderValueR = Random.Range(.05f, 1.0f);
            hSliderValueG = Random.Range(.05f, 1.0f);
            hSliderValueB = Random.Range(.05f, 1.0f);
            hSliderValueA = Random.Range(.05f, .5f);


            hSliderValueRSum += hSliderValueR;
            hSliderValueGSum += hSliderValueG;
            hSliderValueBSum += hSliderValueB;
            hSliderValueASum += hSliderValueA;

            x++;
        } while (x != 5);

        hSliderValueR = hSliderValueRSum/ (Random.Range(3.5f, 5.5f));
        hSliderValueG = hSliderValueRSum / (Random.Range(3.5f, 5.5f));
        hSliderValueB = hSliderValueRSum / (Random.Range(3.5f, 5.5f));
        hSliderValueA = hSliderValueRSum / 8.5f;


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
        if (GUI.Button(new Rect(60, 300, 65, 30), "Save"))
        {
            saveColor();
        }
        if (GUI.Button(new Rect(60, 255, 65, 30), "Generate"))
            {
            Debug.Log("AI NOT DONE");
            if (mutate == true)
            {
               
                AI();
                mutation();
            }
            else
            {
                AI();

            }
          



        }

    }
    void AI()
    {
     RangeRMax= hSliderValueRMax;
     RangeRMin= hSliderValueRMin;

     RangeBMax= hSliderValueGMax;
     RangeBMin= hSliderValueGMin;

     RangeGMax= hSliderValueBMax;
     RangeGMin= hSliderValueBMin;

     RangeAMax= hSliderValueAMax;
     RangeAMin= hSliderValueAMin;

        //R
        if (hSliderValueR > hSliderValueG)
        {
            if (RangeRMax > RangeRMax +.25f)
            {
                RangeRMax += .25f;
            }
           
                

            if (RangeGMin < RangeGMin - .1f)
            {
                RangeGMin -= .1f;
            }
            if (RangeBMin < RangeBMin - .1f)
            {
                RangeBMin -= .1f;
            }
            if (RangeAMin < RangeAMin - .1f)
            {
                RangeAMin -= .1f;
            }
        }
        if (hSliderValueR > hSliderValueB)
        {
            if (RangeRMax > RangeRMax + .25f)
            {
                RangeRMax += .25f;
            }

            

            if (RangeGMin < RangeGMin - .1f)
            {
                RangeGMin -= .1f;
            }
            if (RangeBMin < RangeBMin - .1f)
            {
                RangeBMin -= .1f;
            }
            if (RangeAMin < RangeAMin - .1f)
            {
                RangeAMin -= .1f;
            }
        }
        if (hSliderValueR > hSliderValueA)
        {
            if (RangeRMax > RangeRMax + .25f)
            {
                RangeRMax += .25f;
            }

            

            if (RangeGMin < RangeGMin - .1f)
            {
                RangeGMin -= .1f;
            }
            if (RangeBMin < RangeBMin - .1f)
            {
                RangeBMin -= .1f;
            }
            if (RangeAMin < RangeAMin - .1f)
            {
                RangeAMin -= .1f;
            }
        }

        //G
        if (hSliderValueG> hSliderValueR)
        {
            if (RangeGMax > RangeGMax + .25f)
            {
                RangeGMax += .25f;
            }

           

            if (RangeRMin < RangeRMin - .1f)
            {
                RangeRMin -= .1f;
            }
            if (RangeBMin < RangeBMin - .1f)
            {
                RangeBMin -= .1f;
            }
            if (RangeAMin < RangeAMin - .1f)
            {
                RangeAMin -= .1f;
            }
        }
        if (hSliderValueG > hSliderValueB)
        {
            if (RangeGMax > RangeGMax + .25f)
            {
                RangeGMax += .25f;
            }

            

            if (RangeRMin < RangeRMin - .1f)
            {
                RangeRMin -= .1f;
            }
            if (RangeBMin < RangeBMin - .1f)
            {
                RangeBMin -= .1f;
            }
            if (RangeAMin < RangeAMin - .1f)
            {
                RangeAMin -= .1f;
            }
        }
        if (hSliderValueG > hSliderValueA)
        {
            if (RangeGMax > RangeGMax + .25f)
            {
                RangeGMax += .25f;
            }

            

            if (RangeRMin < RangeRMin - .1f)
            {
                RangeRMin -= .1f;
            }
            if (RangeBMin < RangeBMin - .1f)
            {
                RangeBMin -= .1f;
            }
            if (RangeAMin < RangeAMin - .1f)
            {
                RangeAMin -= .1f;
            }
        }

        //B
        if (hSliderValueB > hSliderValueR)
        {
            if (RangeBMax > RangeBMax + .25f)
            {
                RangeBMax += .25f;
            }

            

            if (RangeRMin < RangeRMin - .1f)
            {
                RangeRMin -= .1f;
            }
            if (RangeGMin < RangeGMin - .1f)
            {
                RangeGMin -= .1f;
            }
            if (RangeAMin < RangeAMin - .1f)
            {
                RangeAMin -= .1f;
            }
        }
        if (hSliderValueB > hSliderValueG)
        {
            if (RangeBMax > RangeBMax + .25f)
            {
                RangeBMax += .25f;
            }

            

            if (RangeRMin < RangeRMin - .1f)
            {
                RangeRMin -= .1f;
            }
            if (RangeGMin < RangeGMin - .1f)
            {
                RangeGMin -= .1f;
            }
            if (RangeAMin < RangeAMin - .1f)
            {
                RangeAMin -= .1f;
            }
        }
        if (hSliderValueB > hSliderValueA)
        {
            if (RangeBMax > RangeBMax + .25f)
            {
                RangeBMax += .25f;
            }

            

            if (RangeRMin < RangeRMin - .1f)
            {
                RangeRMin -= .1f;
            }
            if (RangeGMin < RangeGMin - .1f)
            {
                RangeGMin -= .1f;
            }
            if (RangeAMin < RangeAMin - .1f)
            {
                RangeAMin -= .1f;
            }
        }

        //A
        if (hSliderValueB > hSliderValueR)
        {
            if (RangeAMax > RangeAMax + .25f)
            {
                RangeAMax += .25f;
            }

            

            if (RangeRMin < RangeRMin - .1f)
            {
                RangeRMin -= .1f;
            }
            if (RangeGMin < RangeGMin - .1f)
            {
                RangeGMin -= .1f;
            }
            if (RangeBMin < RangeBMin - .1f)
            {
                RangeBMin -= .1f;
            }
        }
        if (hSliderValueB > hSliderValueG)
        {
            if (RangeAMax > RangeAMax + .25f)
            {
                RangeAMax += .25f;
            }

            

            if (RangeRMin < RangeRMin - .1f)
            {
                RangeRMin -= .1f;
            }
            if (RangeGMin < RangeGMin - .1f)
            {
                RangeGMin -= .1f;
            }
            if (RangeBMin < RangeBMin - .1f)
            {
                RangeBMin -= .1f;
            }
        }
        if (hSliderValueA > hSliderValueB)
        {
            if (RangeAMax > RangeAMax + .25f)
            {
                RangeAMax += .25f;
            }

            

            if (RangeRMin < RangeRMin - .1f)
            {
                RangeRMin -= .1f;
            }
            if (RangeGMin < RangeGMin - .1f)
            {
                RangeGMin -= .1f;
            }
            if (RangeBMin < RangeBMin - .1f)
            {
                RangeBMin -= .1f;
            }
        }

        
        hSliderValueR = Random.Range(RangeRMin, RangeRMax);
        hSliderValueG = Random.Range(RangeGMin, RangeGMax);
        hSliderValueB = Random.Range(RangeBMin, RangeBMax);
        hSliderValueA = Random.Range(RangeAMin, RangeAMax);


    }

    void mutation()
    {
        
        random = Random.Range(1, 101);
        //Debug.Log("Mute Func::" +random);

        if (random <= 20)
         
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


    
   void saveColor()
    {
        string path = "Assets/Save/saveColor.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("RED:"+hSliderValueR+"GREEN"+ hSliderValueG+"BLUE"+ hSliderValueB+"ALPHA"+ hSliderValueA);
        writer.Close();

      

        
    }
    void backColor()
    {

    }
}
    

