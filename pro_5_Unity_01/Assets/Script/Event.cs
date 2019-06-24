using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public RectTransform Character;
    public Animator animator,mabuta;
    public TextController2 textCtrl2;
    public NameController nameCtrl;
    public SelectController selectCtrl;
    public SpriteRenderer backGround;
    float a;
    public static bool isWait = true;
    bool one = true;
    bool okiru = true;
    bool sentaku = true;

    void Start()
    {
        isWait = true;
        Event2.isWait2 = false;
        Debug.Log(isWait);
        Debug.Log(Event2.isWait2);
        one = true;
        okiru = true;
        sentaku = true;
    }

    void Update()
    {
        if (Time.time > 5.5f)
        {
            if (one)
            {
                StopCoroutine(FadeinPanel());
                StartCoroutine(FadeoutPanel());
                animator.SetBool("Close", false);
                one = false;
            }
        }


        if (TextController2.textNum1 == 5)
        {
            if (okiru)
            {
                Debug.Log("おきるよ");
                mabuta.SetBool("Getup", false);
                okiru = false;
            }
        }

        if (TextController2.textNum1 == 11)
        {
            if (sentaku)
            {
                Debug.Log("せんたくし");
                StartCoroutine(ScenarioMain());
                sentaku = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            StopCoroutine(FadeinPanel());
            StartCoroutine(FadeoutPanel());
            animator.SetBool("Close", false);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            StopCoroutine(FadeoutPanel());
            StartCoroutine(FadeinPanel());
            animator.SetBool("Close", true);
        }
    }

    //フェードアウト自体は↓の処理
    IEnumerator FadeoutPanel()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += 0.01f;
            yield return null;
        }
    }

    IEnumerator FadeinPanel()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= 0.01f;
            yield return null;
        }
    }

    IEnumerator ScenarioMain()
    {

        yield return WaitSelect(
            "我が友、李徴子ではないか？",
            "君の名前は三葉",
            "Armour Zone"
            );

        switch (selectCtrl.Result)
        {
            case 0:
                NameController.textNum1 = 12;
                nameCtrl.SetNextLine();
                TextController2.textNum1 = 12;
                textCtrl2.SetNextLine();
                break;

            case 1:
                NameController.textNum1 = 16;
                nameCtrl.SetNextLine();
                TextController2.textNum1 = 16;
                textCtrl2.SetNextLine();
                break;

            case 2:
                NameController.textNum1 = 20;
                nameCtrl.SetNextLine();
                TextController2.textNum1 = 20;
                textCtrl2.SetNextLine();
                break;
        }

        yield return ImageFade(backGround, Fade.Out);

        yield return ImageFade(backGround, Fade.In);

    }

    // 選択が終了するまで待つ
    public IEnumerator WaitSelect(params string[] args)
    {
        // 選択肢オープン
        selectCtrl.Select(args);

        // 選択終了まで待つ
        while (selectCtrl.IsEndOfSelected == false)
        {
            yield return null;
        }

        // 選択肢クローズ
        selectCtrl.Close();
        yield return null;
    }

    public enum Fade
    {
        In,
        Out,
    }
    public IEnumerator ImageFade(SpriteRenderer sprite, Fade type, float fadeTime = 0.5f)
    {
        float stVal, edVal;
        Color col;
        if (type == Fade.In)
        {
            stVal = 0.0f;
            edVal = 1.0f;
        }
        else
        {
            stVal = 1.0f;
            edVal = 0.0f;
        }

        if (fadeTime > 0.0f)
        {
            // 段階的に反映
            float time = 0.0f;
            while (time < fadeTime)
            {
                // フェード中のアルファ値を計算
                float val = Mathf.Lerp(stVal, edVal, time / fadeTime);
                // フェード中の値を設定
                col = sprite.color;
                col.a = val;
                sprite.color = col;
                // 時間を計算
                time += Time.deltaTime;
                yield return null;
            }
        }
        // 最終的な値は設定
        col = sprite.color;
        col.a = edVal;
        sprite.color = col;
        yield return null;
    }
}
