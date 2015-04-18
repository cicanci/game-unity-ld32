using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	public void ClearCurrentText() {
		WordManager.Instance.ClearCurrentText();
	}

	public void SendCurrentText() {
		WordManager.Instance.SendCurrentText();
	}
}
