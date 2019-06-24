using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadText : MonoBehaviour
{

    //　読み込んだテキストを出力するUIテキスト
    [SerializeField]
    private Text dataText;
    //　読む込むテキストが書き込まれている.txtファイル
    [SerializeField]
    private TextAsset textAsset;
    //　テキストファイルから読み込んだデータ
    private string loadText1;
    //　改行で分割して配列に入れる
    private string[] splitText1;
    //　現在表示中テキスト1番号
    private int textNum1;

    void Start()
    {
        loadText1 = textAsset.text;
        splitText1 = loadText1.Split(char.Parse("\n"));
        textNum1 = 0;
    }

    void Update()
    {
        //　読み込んだテキストファイルの内容を表示
        if (Input.GetButtonDown("Fire1"))
        {
            if (splitText1[textNum1] != "")
            {
                dataText.text = splitText1[textNum1];
                textNum1++;
                if (textNum1 >= splitText1.Length)
                {
                    textNum1 = 0;
                }
            }
            else
            {
                dataText.text = "";
                textNum1++;
            }
        }
    }
}