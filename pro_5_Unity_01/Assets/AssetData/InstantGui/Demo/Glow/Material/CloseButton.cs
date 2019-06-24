using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour {


    Animator animCanvas;
    public static bool isStart = false;


    // Use this for initialization
    void Start () {
        animCanvas = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // ボタンが押されたら！
    public void ClickButton()
    {
        isStart = true;
        animCanvas.SetBool("win_close", true);
    }
}
