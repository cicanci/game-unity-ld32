using UnityEngine;
using System.Collections;

public class LetterControl : MonoBehaviour {

	public void MoveToRight() {
		LetterManager.Instance.MoveToRight();
	}

	public void MoveToRightFast() {
		LetterManager.Instance.MoveToRightFast();
	}

	public void ClearCurrentText() {
		LetterManager.Instance.ClearCurrentText();
	}

	public void SendCurrentText() {
		LetterManager.Instance.SendCurrentText();
	}
}
