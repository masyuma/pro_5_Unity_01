using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFade : MonoBehaviour
{
    public float fadeTime;
    private float time;
    public Image st, co, es;
    public Text stt, cot, est;
    float b1, b2, b3;

    // Use this for initialization
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        b1 = time / fadeTime;
        var color1 = st.color = stt.color;
        color1.a = b1;
        st.color = stt.color = color1;

        b2 = time / fadeTime;
        var color2 = co.color = cot.color;
        color2.a = b2;
        co.color = cot.color = color2;

        b3 = time / fadeTime;
        var color3 = es.color = est.color;
        color3.a = b3;
        es.color = est.color = color3;
    }
}