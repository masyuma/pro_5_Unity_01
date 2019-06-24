using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndChara : MonoBehaviour {

    public Image Chara1,Chara2,Chara3,Chara4, Chara5, Chara6;
    public GameObject Chara7;
    float a1,a2,a3,a4,a5,a6;
    public float Endcount;
    float upperlimit;
    bool one = true;
    bool two = true;
    bool three = true;
    bool four = true;
    bool five = true;
    bool six = true;
    bool seven = true;
    bool eight = true;
    bool nine = true;
    bool ten = true;
    bool eleven = true;
    bool twelve = true;
    bool thirteen = true;
    bool fourteen = true;
    bool isEnd = true;
    public string Attention;

    void Start()
    {
        a1 = Chara1.GetComponent<Image>().color.a;
        a2 = Chara2.GetComponent<Image>().color.a;
        a3 = Chara3.GetComponent<Image>().color.a;
        a4 = Chara4.GetComponent<Image>().color.a;
        a5 = Chara3.GetComponent<Image>().color.a;
        a6 = Chara4.GetComponent<Image>().color.a;
        upperlimit = 0;
        one = true;
        two = true;
        three = true;
        four = true;
        five = true;
        six = true;
        seven = true;
        eight = true;
        nine = true;
        ten = true;
        eleven = true;
        twelve = true;
        thirteen = true;
        fourteen = true;
        isEnd = true;
    }

    void Update()
    {
        upperlimit += Time.deltaTime;

        if (upperlimit > Endcount)
        {
            if (one)
            {
                StopCoroutine(FadeinPanel1());
                StartCoroutine(FadeoutPanel1());
                one = false;
            }
        }


        if (upperlimit > (Endcount * 2))
        {
            if (two)
            {
                StopCoroutine(FadeoutPanel1());
                StartCoroutine(FadeinPanel1());
                two = false;
            }
        }

        if (upperlimit > (Endcount * 3))
        {
            if (three)
            {
                StopCoroutine(FadeinPanel2());
                StartCoroutine(FadeoutPanel2());
                three = false;
            }
        }

        if (upperlimit > (Endcount * 4))
        {
            if (four)
            {
                StopCoroutine(FadeoutPanel2());
                StartCoroutine(FadeinPanel2());
                four = false;
            }
        }

        if (upperlimit > (Endcount * 5))
        {
            if (five)
            {
                StopCoroutine(FadeinPanel3());
                StartCoroutine(FadeoutPanel3());
                five = false;
            }
        }

        if (upperlimit > (Endcount * 6))
        {
            if (six)
            {
                StopCoroutine(FadeoutPanel3());
                StartCoroutine(FadeinPanel3());
                six = false;
            }
        }

        if (upperlimit > (Endcount * 7))
        {
            if (seven)
            {
                StopCoroutine(FadeinPanel4());
                StartCoroutine(FadeoutPanel4());
                seven = false;
            }
        }

        if (upperlimit > (Endcount * 8))
        {
            if (eight)
            {
                StopCoroutine(FadeoutPanel4());
                StartCoroutine(FadeinPanel4());
                eight = false;
            }
        }

        if (upperlimit > (Endcount * 9))
        {
            if (nine)
            {
                StopCoroutine(FadeinPanel5());
                StartCoroutine(FadeoutPanel5());
                nine = false;
            }
        }

        if (upperlimit > (Endcount * 10))
        {
            if (ten)
            {
                StopCoroutine(FadeoutPanel5());
                StartCoroutine(FadeinPanel5());
                ten = false;
            }
        }

        if (upperlimit > (Endcount * 11))
        {
            if (eleven)
            {
                StopCoroutine(FadeinPanel6());
                StartCoroutine(FadeoutPanel6());
                eleven = false;
            }
        }

        if (upperlimit > (Endcount * 12))
        {
            if (twelve)
            {
                StopCoroutine(FadeoutPanel6());
                StartCoroutine(FadeinPanel6());
                twelve = false;
            }
        }

        if (upperlimit > 106)
        {
            if (thirteen)
            {
                Chara7.SetActive(true);
                thirteen = false;
            }
        }

        if (upperlimit > 113)
        {
            if (fourteen)
            {
                upperlimit = 0;
                Chara7.SetActive(false);
                SceneFade.SwitchScene(Attention);
                fourteen = false;
            }
        }

        if (Input.GetButtonDown("Submit") || Input.GetMouseButton(0) && SceneManager.GetActiveScene().name == "End")
        {
            if (isEnd)
            {
                upperlimit = 0;
                SceneFade.SwitchScene(Attention);
                isEnd = false;
            }
        }
    }

    //フェードアウト自体は↓の処理
    IEnumerator FadeoutPanel1()
    {
        while (a1 < 1)
        {
            Chara1.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
            a1 += 0.01f;
            yield return null;
        }
    }

    IEnumerator FadeinPanel1()
    {
        while (a1 > 0)
        {
            Chara1.GetComponent<Image>().color -= new Color(0, 0, 0, 0.01f);
            a1 -= 0.01f;
            yield return null;
        }
    }

    IEnumerator FadeoutPanel2()
    {
        while (a2 < 1)
        {
            Chara2.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
            a2 += 0.01f;
            yield return null;
        }
    }

    IEnumerator FadeinPanel2()
    {
        while (a2 > 0)
        {
            Chara2.GetComponent<Image>().color -= new Color(0, 0, 0, 0.01f);
            a2 -= 0.01f;
            yield return null;
        }
    }

    IEnumerator FadeoutPanel3()
    {
        while (a3 < 1)
        {
            Chara3.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
            a3 += 0.01f;
            yield return null;
        }
    }

    IEnumerator FadeinPanel3()
    {
        while (a3 > 0)
        {
            Chara3.GetComponent<Image>().color -= new Color(0, 0, 0, 0.01f);
            a3 -= 0.01f;
            yield return null;
        }
    }

    IEnumerator FadeoutPanel4()
    {
        while (a4 < 1)
        {
            Chara4.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
            a4 += 0.01f;
            yield return null;
        }
    }

    IEnumerator FadeinPanel4()
    {
        while (a4 > 0)
        {
            Chara4.GetComponent<Image>().color -= new Color(0, 0, 0, 0.01f);
            a4 -= 0.01f;
            yield return null;
        }
    }

    IEnumerator FadeoutPanel5()
    {
        while (a5 < 1)
        {
            Chara5.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
            a5 += 0.01f;
            yield return null;
        }
    }

    IEnumerator FadeinPanel5()
    {
        while (a5 > 0)
        {
            Chara5.GetComponent<Image>().color -= new Color(0, 0, 0, 0.01f);
            a5 -= 0.01f;
            yield return null;
        }
    }

    IEnumerator FadeoutPanel6()
    {
        while (a6 < 1)
        {
            Chara6.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
            a6 += 0.01f;
            yield return null;
        }
    }

    IEnumerator FadeinPanel6()
    {
        while (a6 > 0)
        {
            Chara6.GetComponent<Image>().color -= new Color(0, 0, 0, 0.01f);
            a6 -= 0.01f;
            yield return null;
        }
    }
}
