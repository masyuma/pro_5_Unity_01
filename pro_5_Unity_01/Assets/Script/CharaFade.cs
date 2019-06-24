using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaFade : MonoBehaviour {
    public float fadeTime;
    private float time;
    public Image sr1,sr2,sr3,t;
    float a1, a2, a3,t1;

    // Use this for initialization
    void Start () {
        time = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        a1 = time / fadeTime;
        var color1 = sr1.color;
        color1.a = a1;
        sr1.color = color1;

        a2 = time / fadeTime;
        var color2 = sr2.color;
        color2.a = a2;
        sr2.color = color2;

        a3 = time / fadeTime;
        var color3 = sr3.color;
        color3.a = a3;
        sr3.color = color3;

        t1 = time / fadeTime;
        var color4 = t.color;
        color4.a = t1;
        t.color = color4;
    }
}
