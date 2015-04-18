using UnityEngine;
using System.Collections;

public class WordManager : MonoBehaviour {

	public static WordManager Instance;

	private string[] mValidWords = {"BALL", "GUN", "MUG"};

	void Start() {
		Instance = this;
	}

	public void CheckWord(string pWord) {
		Debug.Log(IsValidWord(pWord));
	}

	private bool IsValidWord(string pWord) {
		foreach (string word in mValidWords) {
			if (word == pWord) {
				return true;
			}
		}
		return false;
	}
}
