using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScene : MonoBehaviour {

	public static MenuScene Instance;

	public GameObject FirstPanel;
	public GameObject SecondPanel;
	public GameObject ThirdPanel;
	public int SlideSpeed;

	private bool mSlideFirstPanel;
	private bool mSlideSecondPanel;
	private bool mSlideThirdPanel;

	void Start() {
		Instance = this;
		mSlideFirstPanel = true;
	}
	
	void Update() {
		if (mSlideFirstPanel) {
			Vector2 oldPosition = FirstPanel.GetComponent<RectTransform>().localPosition;
			Vector2 newPosition = new Vector2(oldPosition.x - Time.deltaTime * SlideSpeed, oldPosition.y);
			if (newPosition.x < 0) {
				mSlideFirstPanel = false;
				newPosition = new Vector2(0, oldPosition.y);
			}
			FirstPanel.GetComponent<RectTransform>().localPosition = newPosition;
		}

		if (mSlideSecondPanel) {
			Vector2 oldPosition = SecondPanel.GetComponent<RectTransform>().localPosition;
			Vector2 newPosition = new Vector2(oldPosition.x - Time.deltaTime * SlideSpeed, oldPosition.y);
			if (newPosition.x < 0) {
				mSlideSecondPanel = false;
				newPosition = new Vector2(0, oldPosition.y);
			}
			SecondPanel.GetComponent<RectTransform>().localPosition = newPosition;
		}

		if (mSlideThirdPanel) {
			Vector2 oldPosition = ThirdPanel.GetComponent<RectTransform>().localPosition;
			Vector2 newPosition = new Vector2(oldPosition.x - Time.deltaTime * SlideSpeed, oldPosition.y);
			if (newPosition.x < 0) {
				mSlideThirdPanel = false;
				newPosition = new Vector2(0, oldPosition.y);
			}
			ThirdPanel.GetComponent<RectTransform>().localPosition = newPosition;
		}
	}

	public void ShowMenuSecondPanel() {
		mSlideSecondPanel = true;
	}
	
	public void ShowMenuThirdPanel(GameDifficult pDifficult) {
		GameData.SelectRandomTheme(pDifficult);
		ThirdPanel.GetComponentInChildren<Text>().text = GameData.Theme;
		mSlideThirdPanel = true;
	}
}
