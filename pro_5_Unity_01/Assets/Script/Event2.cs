using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Event2 : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public RectTransform Character;
    public Animator animator,mkm,gt,final;
    public TextController2 textCtrl2;
    public NameController nameCtrl;
    public SpriteRenderer backGround;
    public GameObject FinalWeapon;
    public AudioSource audioSource;
    public AudioClip bgm1,bgm2, bgm3;
    float a;
    public static bool isWait2 = false;
    bool one = true;
    bool setumei = true;
    bool tatakai = true;
    bool heiki = true;
    bool climax = true;
    bool push = true;
    bool finalgt = true;
    bool zikai = true;

    void Start()
    {
        Event.isWait = false;
        isWait2 = true;
        Debug.Log(Event.isWait);
        Debug.Log(isWait2);
        one = true;
        setumei = true;
        tatakai = true;
        heiki = true;
        climax = true;
        push = true;
        finalgt = true;
        zikai = true;
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
                audioSource.clip = bgm1;
                audioSource.Play();
                one = false;
            }
        }

        if (TextController2.textNum1 == 31)
        {
            if (setumei)
            {
                Debug.Log("せつめい");
                animator.SetBool("Close", true);
                mkm.SetBool("mkmClose", false);
                setumei = false;
            }
        }

        if (TextController2.textNum1 == 33)
        {
            if (tatakai)
            {
                Debug.Log("たたかい");
                gt.SetBool("gtClose", false);
                mkm.SetBool("mkmRight", false);
                tatakai = false;
            }
        }

        if (TextController2.textNum1 == 40)
        {
            if (heiki)
            {
                Debug.Log("へいき");
                gt.SetBool("gtClose", true);
                mkm.SetBool("mkmRight", true);
                heiki = false;
            }
        }

        if (TextController2.textNum1 == 43)
        {
            if (climax)
            {
                Debug.Log("クライマックス");
                Instantiate(FinalWeapon);
                climax = false;
            }
        }

        if (CloseButton.isStart)
        {
            audioSource.clip = bgm2;
            audioSource.Play();
            NameController.textNum1 = 44;
            nameCtrl.SetNextLine();
            TextController2.textNum1 = 44;
            textCtrl2.SetNextLine();
            CloseButton.isStart = false;
        }

        if (TextController2.textNum1 == 45)
        {
            if (push)
            {
                Debug.Log("押しちゃった");
                mkm.SetBool("mkmClose", true);
                push = false;
            }
        }

        if (TextController2.textNum1 == 48)
        {
            if (finalgt)
            {
                Debug.Log("最終兵器後藤先生");
                final.SetBool("gtClose", false);
                finalgt = false;
            }
        }

        if (TextController2.textNum1 == 53)
        {
            if (zikai)
            {
                Debug.Log("次回予告");
                audioSource.clip = bgm3;
                audioSource.pitch = 1.2f;
                audioSource.Play();
                zikai = false;
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
}