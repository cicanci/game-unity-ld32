using UnityEngine;
using System.Collections;

public class WordManager : MonoBehaviour {

	public static WordManager Instance;
	public GameObject GameCanvas;
	public string[] ValidWords = {"BALL", "GUN", "MUG"};
	public string CurrentWord;

	void Start() {
		Instance = this;
	}

	public void CheckWord(string pWord) {
		Debug.Log(IsValidWord(pWord));
	}

	public void PrintLetter(string pWord) {
		CurrentWord += pWord;
		Debug.Log(pWord);
	}

	public void SendCurrentText() {
		Debug.Log(IsValidWord(CurrentWord));
		CurrentWord = string.Empty;
	}

	public void ClearCurrentText() {
		CurrentWord = string.Empty;
	}

	private bool IsValidWord(string pWord) {
		foreach (string word in ValidWords) {
			if (word == pWord) {
				return true;
			}
		}
		return false;
	}
}
