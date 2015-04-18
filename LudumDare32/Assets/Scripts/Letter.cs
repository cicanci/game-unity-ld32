using UnityEngine;
using System.Collections;

public class Letter : MonoBehaviour {

	public string LetterValue;

	public void PrintLetter() {
		LetterManager.Instance.PrintLetter(LetterValue);
	}
}
