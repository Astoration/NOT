﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
	float time = 0.1f;
	public Text Dialog;
    public AudioClip typing;    //사운드 파일을 가진다
    public static DialogManager instance;//사운드매니저의 위치를 담는다
	public bool nowTyping = false;
	public int i = 0;
	public string[] texts = new string[100];
	public bool isBreaking = false;
    AudioSource audio;
<<<<<<< HEAD
	IEnumerator textReading(string text,bool option){
=======

    IEnumerator textReading(string text){
>>>>>>> 6bf2bddec1c36280bc54a96bc3aed1e136e7b41e
		nowTyping = true;
		string stringStack = "";
		isBreaking = false;
		for (int i = 0; i < text.Length+1; i++) {
			if (isBreaking)
				i = text.Length;
			stringStack = text.Substring (0, i);
			Dialog.text = stringStack;
            audio.PlayOneShot(typing);
			yield return new WaitForSeconds (0.1f);
		}
		isBreaking = false;
		nowTyping = false;
		if (option) {
			Days.instance.date += 1;
			Application.LoadLevel ("HouseScene");
		}
	}
    void Awake()
    {
        if (DialogManager.instance == null)
        {// 인스턴스가 비어있으면
            DialogManager.instance = this;   //이것의 인스턴스를 집어넣는다.
        }
    }
    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();// 오디오 컴퍼넌스를 담는다.
	}

	public void SetText(TextAsset asset){
		texts = asset.text.Split('\n');
		 StartCoroutine (textReading (texts [i++],false));
	}

	public void CallBackText(string message){
		StartCoroutine(textReading(message,true));
	}
	// Update is called once per frame
	void Update () {
		if (!nowTyping && Input.GetKeyDown (KeyCode.Return) && i < texts.Length)
			StartCoroutine (textReading (texts [i++],false));
		else if (Input.GetKeyDown (KeyCode.Return))
			isBreaking = true;
	}
}
