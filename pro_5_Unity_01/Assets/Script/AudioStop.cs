using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioStop : MonoBehaviour {

    private AudioSource Attention;

    // Use this for initialization
    void Start () {
        Attention = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit") || Input.GetMouseButton(0) && SceneManager.GetActiveScene().name == "Attention")
        {
            Attention.Stop();
        }
    }
}
