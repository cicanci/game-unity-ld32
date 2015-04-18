using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LetterManager : MonoBehaviour {

	public static LetterManager Instance;
	public GameObject LetterPrefab;
	public float DefaultSpeed = 100;
	public float FastSpeed = 1000;

	// We can hardcode the alphabet, I don't believe that it will change soon...
	private string[] mLetters = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
	private GameObject[] mButtons;
	private float Speed;
	private Canvas mGameCanvas;
	private Text mTempText;
	private float mButtonWidth;
	private float mCanvasWidth;
	
	void Start() {
		Instance = this;

		Speed = DefaultSpeed;

		mGameCanvas = gameObject.GetComponent<Canvas>();
		mTempText = GameObject.Find("TempText").GetComponent<Text>();//TODO:this is a temp test

		mButtonWidth = LetterPrefab.GetComponent<RectTransform>().rect.width;
		mCanvasWidth = mGameCanvas.GetComponent<RectTransform>().rect.width;

		// Init the array with all 26 letters
		mButtons = new GameObject[mLetters.Length];
		// Store the start position in order to place all buttons in the right position
		Vector2 startPosition = LetterPrefab.GetComponent<RectTransform>().anchoredPosition;

		// Create all buttons at runtime
		for (int i = 0; i < mLetters.Length; i++) {
			// First create the prefab instance as GameObject
			GameObject letter = Instantiate<GameObject>(LetterPrefab);
			// And then add to the canvas
			letter.transform.SetParent(mGameCanvas.transform, false);
			// Set the start position of the letter object
			letter.GetComponent<RectTransform>().anchoredPosition = new Vector2(startPosition.x + (mButtonWidth * i), startPosition.y);
			// Set the button text based on the letter array
			letter.GetComponentInChildren<Text>().text = mLetters[i];
			// This is the Letter.cs script, need to know what is the letter for each button
			letter.GetComponent<Letter>().LetterValue = mLetters[i];
			// Add the letter object to the array
			mButtons[i] = letter;
		}
	}

	void Update() {
		// Just to avoid null errors at runtime
		if (mButtons != null) {
			// 
			for (int i = 0; i < mButtons.Length; i++) {
				Vector2 oldPosition = mButtons[i].GetComponent<RectTransform>().localPosition ;
				Vector2 newPosition = new Vector2(oldPosition.x - (Time.fixedDeltaTime * Speed), oldPosition.y);

				if (oldPosition.x < -(mCanvasWidth + mButtonWidth) / 2) {
					newPosition = new Vector2(oldPosition.x + (mButtons.Length * mButtonWidth), oldPosition.y);
				}

				mButtons[i].GetComponent<RectTransform>().localPosition = newPosition;
			}
		}
	}

	public void PrintLetter(string pLetter) {
		mTempText.text += pLetter;
	}

	public void ClearCurrentText() {
		mTempText.text = string.Empty;
	}

	public void SendCurrentText() {
		WordManager.Instance.CheckWord(mTempText.text);
		mTempText.text = string.Empty;
	}

	public void MoveToRight() {
		Speed = DefaultSpeed;
	}

	public void MoveToRightFast() {
		Speed = FastSpeed;
	}
}
