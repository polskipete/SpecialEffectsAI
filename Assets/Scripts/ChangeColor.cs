using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
    public GameObject head;
    private ColorGen otherScripts;

    private float hSliderValueR;
    private float hSliderValueG;
    private float hSliderValueB;
    private float hSliderValueA;

    


    public ParticleSystem pEffect;
    // Use this for initialization
    void Start () {

        pEffect= GetComponent<ParticleSystem>();

        otherScripts = head.GetComponent<ColorGen>();
        
        


    }
	
	// Update is called once per frame
	void Update () {
       
        var main = pEffect.main;
        hSliderValueR = otherScripts.hSliderValueR;
        hSliderValueG = otherScripts.hSliderValueG;
        hSliderValueB = otherScripts.hSliderValueB;
        hSliderValueA = otherScripts.hSliderValueA;
        //Debug.Log(hSliderValueG);
        main.startColor = new Color(hSliderValueR, hSliderValueG, hSliderValueB, hSliderValueA+.5f);
    }
    void OnGUI() {
        
    }

}
