using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScene : MonoBehaviour {

	public static MenuScene Instance;

	public GameObject FirstPanel;
	public GameObject SecondPanel;
	public GameObject ThirdPanel;
	public GameObject TutorialPanel;
	public int SlideSpeed;
	public float TutorialTimer;

	private bool mSlideFirstPanel;
	private bool mSlideSecondPanel;
	private bool mSlideThirdPanel;
	private bool mSlideTutorialPanel;
	private float mTutorialPanelTimer;

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

		if (mSlideTutorialPanel) {
			Vector2 oldPosition = TutorialPanel.GetComponent<RectTransform>().localPosition;
			Vector2 newPosition = new Vector2(oldPosition.x - Time.deltaTime * SlideSpeed, oldPosition.y);
			if (newPosition.x < 0) {
				newPosition = new Vector2(0, oldPosition.y);
			}
			TutorialPanel.GetComponent<RectTransform>().localPosition = newPosition;

			if (mTutorialPanelTimer < 0) {
				mSlideTutorialPanel = false;
				Application.LoadLevel("Game");
			}
			else {
				mTutorialPanelTimer -= Time.deltaTime;
			}
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

	public void ShowMenuTutorialPanel() {
		mTutorialPanelTimer = TutorialTimer;
		mSlideTutorialPanel = true;
	}
}
