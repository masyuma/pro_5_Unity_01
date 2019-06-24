using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour {

    #region フェードレベルと色に合わせて更新

    [SerializeField, Range(0.0f,1.0f)]
    float fadeLevel = 0.0f;
    Image fadeImage = null;

    void UpdateFade(float level)
    {
        enabled = true;
        fadeLevel = Mathf.Clamp(level,0.0f,1.0f);

        if(fadeImage == null)
        {
            fadeImage = GetComponent<Image>();
        }

        var col = fadeImage.color;
        col.a = level;
        fadeImage.color = col;

        if(level <= 0.0f)
        {
            enabled = false;
        }
    }

    public void SetFadeLevel(float level)
    {
        UpdateFade(level);
    }

    public void SetFadeColor(Color color)
    {
        fadeImage.color = color;
        UpdateFade(fadeLevel);
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        UpdateFade(fadeLevel);
    }
#endif

    #region　扱いやすくするためのシングルトン(ただ1つのオブジェクト)へ

    static SceneFade s_instance = null;
    public static SceneFade Instance
    {
        get { return s_instance; }
    }

    void Awake()
    {
        if(s_instance == null)
        {
            s_instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    #endregion

    #region　時間とともにフェードイン・アウトを行う

    bool is_end = false;

    public IEnumerator YieldFadeIn(float fadeTime = 1.0f)
    {

        if(fadeTime == 0.0f)
        {
            UpdateFade(0.0f);
        }
        else
        {
            is_end = false;
            float time = 0.0f;
            while (time < fadeTime)
            {
                UpdateFade(1.0f - time / fadeTime);
                time += Time.deltaTime;
                yield return null;
            }
            UpdateFade(0.0f);
        }
        is_end = true;
        yield return null;
    }

    public IEnumerator YieldFadeOut(float fadeTime = 1.0f)
    {

        if (fadeTime == 0.0f)
        {
            UpdateFade(1.0f);
        }
        else
        {
            is_end = false;
            float time = 0.0f;
            while (time < fadeTime)
            {
                UpdateFade(time / fadeTime);
                time += Time.deltaTime;
                yield return null;
            }
            UpdateFade(1.0f);
        }
        is_end = true;
        yield return null;
    }

    static public bool IsEnd
    {
        get { return s_instance.is_end; }
    }

    static public Coroutine FadeIn(float fadeTime = 1.0f)
    {
        return s_instance.StartCoroutine(s_instance.YieldFadeIn(fadeTime));
    }

    static public Coroutine FadeOut(float fadeTime = 1.0f)
    {
        return s_instance.StartCoroutine(s_instance.YieldFadeOut(fadeTime));
    }

    #endregion

    #region シーン切り替え

    public IEnumerator YieldSwitchScene(string sceneName, float fadeTime = 1.0f)
    {

        yield return YieldFadeOut(fadeTime);

        SceneManager.LoadScene(sceneName);

        yield return YieldFadeIn(fadeTime);
    }

    static public Coroutine SwitchScene(string sceneName, float fadeTime = 1.0f)
    {
        return s_instance.StartCoroutine(s_instance.YieldSwitchScene(sceneName, fadeTime));
    }

    #endregion

}

#endregion
