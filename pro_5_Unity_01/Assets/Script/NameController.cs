using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameController : MonoBehaviour
{
    [SerializeField]
    Text uiText;

    //　読む込むテキストが書き込まれている.txtファイル
    [SerializeField]
    private TextAsset textAsset;
    //　テキストファイルから読み込んだデータ
    private string loadText1;
    //　改行で分割して配列に入れる
    private string[] splitText1;
    //　現在表示中テキスト1番号
    public static int textNum1;

    [SerializeField]
    [Range(0.0001f, 0.3f)]
    float intervalForCharacterDisplay = 0.05f;

    private string currentText = string.Empty;
    private float timeUntilDisplay = 0;
    private float timeElapsed = 1;
    private int lastUpdateCharacter = -1;

    TextController2 script;
    bool iti = true;
    bool niyon = true;

    void Start()
    {
        loadText1 = textAsset.text;
        splitText1 = loadText1.Split(char.Parse("\n"));
        textNum1 = 0;
        script = GetComponent<TextController2>();
    }

    void Update()
    {
        if (Event.isWait)
        {
            if (iti)
            {
                textNum1 = 0;
                iti = false;
            }
        }

        if (Time.time > 8.5f)
        {
            if (Event.isWait)
            {
                textNum1 = 0;
                SetNextLine();
            }
        }

        if (Event2.isWait2)
        {
            if (niyon)
            {
                textNum1 = 24;
                niyon = false;
            }
        }

        if (Time.time > 8.5f)
        {
            if (Event2.isWait2)
            {
                textNum1 = 24;
                SetNextLine();

            }
        }

        // 文字の表示が完了してるならクリック時に次の行を表示する
        if (script.IsCompleteDisplayText)
        {
            if (textNum1 < splitText1.Length && Input.GetMouseButtonDown(0))
            {
                if (0 < textNum1)
                {
                    if (textNum1 < 11)
                    {
                        SetNextLine();
                    }
                }

                if (13 <= textNum1)
                {
                    if (textNum1 <= 15)
                    {
                        SetNextLine();
                    }
                }

                if (17 <= textNum1)
                {
                    if (textNum1 <= 19)
                    {
                        SetNextLine();
                    }
                }

                if (21 <= textNum1)
                {
                    if (textNum1 <= 23)
                    {
                        SetNextLine();
                    }
                }

                if (24 < textNum1)
                {
                    if (textNum1 < 43)
                    {
                        SetNextLine();
                    }
                }

                if (45 <= textNum1)
                {
                    if (textNum1 <= 59)
                    {
                        SetNextLine();
                    }
                }
            }
        }
        else
        {
            // 完了してないなら文字をすべて表示する
            if (Input.GetMouseButtonDown(0))
            {
                timeUntilDisplay = 0;
            }
        }

        int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
        if (displayCharacterCount != lastUpdateCharacter)
        {
            uiText.text = currentText.Substring(0, displayCharacterCount);
            lastUpdateCharacter = displayCharacterCount;
        }
    }


    public void SetNextLine()
    {
        currentText = splitText1[textNum1];
        timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
        timeElapsed = Time.time;
        textNum1++;
        lastUpdateCharacter = -1;
        Debug.Log("名前" + textNum1);
    }
}
