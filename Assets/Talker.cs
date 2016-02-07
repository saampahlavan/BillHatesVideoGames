using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Talker : MonoBehaviour {

	private string continueInput = "Fire1";
	private bool _showing = false;
	private bool isTalking = false;
	private string _text;

	private string _windowTargetText = string.Empty;
	private string _windowCurrentText = string.Empty;
	private int _textFrames = int.MaxValue;

	public Canvas dialogueBox;

	// Use this for initialization
	void Start () 
	{
		

		Dialoguer.events.onStarted += onStarted;
		Dialoguer.events.onTextPhase += onTextPhase;
		Dialoguer.events.onEnded += onEnded;
	}

	void onTextPhase (DialoguerTextData data)
	{
		_text = data.text;
		_windowCurrentText = string.Empty;
		_windowTargetText = data.text;
	}

	void onStarted ()
	{
		_showing = true;
		isTalking = true;
	}

	void onEnded()
	{
		_showing = false;
		isTalking = false;
		dialogueBox.GetComponent<CanvasGroup>().alpha = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{
		//dialogueBox.GetComponentInChildren<Text>().text = _windowTargetText;
		dialogueBox.GetComponentInChildren<Text>().text = _windowCurrentText;

		if(isTalking)
		{
			calculateText();
		}



		if(Input.GetButtonDown("Fire1"))
		{
			if (_windowCurrentText == _windowTargetText)
			{
				Dialoguer.ContinueDialogue();
			}
		}
	}


	private void calculateText()
	{
		if (_windowTargetText == string.Empty || _windowCurrentText == _windowTargetText) return;

		int frameSkip = 2;

		if (_textFrames < frameSkip)
		{
			_textFrames += 1;
			return;
		}
		else
		{
			_textFrames = 0;
		}

		int charsPerInterval = 1;
		if (_windowCurrentText != _windowTargetText)
		{
			for (int i = 0; i < charsPerInterval; i += 1)
			{
				if (_windowTargetText.Length <= _windowCurrentText.Length) break;
				_windowCurrentText += _windowTargetText[_windowCurrentText.Length];
			}
		}


	}



	void OnTriggerStay2D(Collider2D thing)
	{
		if(thing.tag == "Player")
		{
			

			if(Input.GetButtonDown("Fire1"))
			{
				print("TALKING");
				dialogueBox.GetComponent<CanvasGroup>().alpha = 1;

				if(isTalking == false)
				Dialoguer.StartDialogue(0);
				_showing = true;
			}
		}
		
	}
}
