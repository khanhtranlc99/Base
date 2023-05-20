using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayPanel : UIPanelBase
{
	public static PlayPanel _Instance;

	public Transform _Left;

	public Transform _Right;

	public Transform _Top;

	public Transform _Bottom;

	public Transform _BorderTEx;

	public Transform[] _LvPointAns;

	[SerializeField]
	public RectTransform _LeftCollider;

	[SerializeField]
	public RectTransform _RightCollider;

	[SerializeField]
	public RectTransform _TopCollider;

	[SerializeField]
	public RectTransform _BottomCollider;

	[SerializeField]
	private RectTransform topContent;

	[SerializeField]
	private RectTransform playContent;

	[SerializeField]
	private RectTransform bottomContent;

	[SerializeField]
	private RectTransform bottomTipRoot;

	[SerializeField]
	private Button menuBtn;

	[SerializeField]
	private Button listBtn;

	[SerializeField]
	private Button shopBtn;

	[SerializeField]
	private Transform _LevelParent;

	[SerializeField]
	private Image layerCheckImg;

	[SerializeField]
	private Image botTipImg;

	public Transform _levelTextPos;

	[SerializeField]
	private TextMeshProUGUI _LevelText;

	[SerializeField]
	private Text bulbTipText;

	[SerializeField]
	private GameObject mask;

	[SerializeField]
	private GameObject redMark;

	public GameObject _maskImg;

	public float canvaScale;

	private int currentLevel;

	private string currentLevelName;

	private Vector2 playConOffMin;

	private Vector2 playConOffMax;

	private static float tempTop;

	private static float tempBottom;

	private Vector2 tempPCMin;

	private Vector2 tempPCMax;

	private Vector2 topOriPos;

	private Vector2 bottomOriPos;

	private Vector2 pcOffMax;

	private Vector2 pcOffMin;

	private bool changeRect;

	public static bool isFirstShow;

	private float timmer;

	private float bubbleTimmer;

	private bool beginTipGuide;

	private bool bulbLight;

	private bool pause;

	private bool bubbleBeginT;

	[SerializeField]
	private Animator bulbAni;

	[SerializeField]
	private float tipConScaleRate;

	[SerializeField]
	private float tipConScaleSp;

	//private TipHighLightConfig TipHighLight;

	[SerializeField]
	private Button bottomBulbTipBtn;

	[SerializeField]
	private Button botBulbResBtn;

	[SerializeField]
	private Button botBulbSkipBtn;

	//[SerializeField]
	//private BubbleBtn BubbleBtn;

	//[SerializeField]
	//private DailyBubble DailyBubble;

	[SerializeField]
	private Transform[] dailyBuAns;

	private int bubbleReward;

	private bool isRes;

	private bool flag;

	private string tempCurN;

	private void InitTipGuide()
	{
	}

	public void HideBubbltBtn()
	{
	}

	public void UpdateBulbStates()
	{
	}

	private void Update()
	{
	}

	public void ControlMask(bool va)
	{
	}

	private void Awake()
	{
		_Instance = this;
		mask.SetActive(false);
		GameManager._Instance.isLevelClear = false;
		UpdateTips();
		AudioManager._Instance.PlayMusic("main_music_1");
	}

	private void Start()
	{
		UpdatePanel();
	}

	public void UpdateRedMark(bool value)
	{
	}

	public void DailyBubbleCheckShow()
	{
	}

	public void ShopBtnClick()
	{
		if (GameManager._Instance.isLevelClear)
			return;
		UIPanelManager._Insance.ShowPanel("ShopPanel");
		AudioManager._Instance.PlaySound("gameplay_button_click");
	}

	public override void Escape()
	{
	}

	private void RepaireBorder()
	{
	}

	public void SkipBtnClick()
	{
		if (GameManager._Instance.isLevelClear)
			return;
		UIPanelManager._Insance.ShowPanel("SkipPanel");
		AudioManager._Instance.PlaySound("gameplay_button_click");
	}

	public void CheckCurLayer(bool hide = false)
	{
	}

	public void MenuBtnClick()
	{
		if (GameManager._Instance.isLevelClear)
			return;
		UIPanelManager._Insance.ShowPanel("MenuPanel");
		AudioManager._Instance.PlaySound("gameplay_button_click");
	}

	public void LevelBtnClick()
	{
		if (GameManager._Instance.isLevelClear)
			return;
		UIPanelManager._Insance.ShowPanel("LevelPanel");
		AudioManager._Instance.PlaySound("gameplay_button_click");
	}


	public void ShowGuidePanel()
	{
		if (GameManager._Instance.isLevelClear)
			return;

		if (PlayerPrefs.GetInt("Unlock_Tip_" + LevelManager._Instance.currentLevel) == 1)
		  UIPanelManager._Insance.ShowPanel("GuidePanel");
		else
        {
			if(GameManager._Instance._Tips >= 1)
            {
				GameManager._Instance._Tips -= 1;
				PlayerPrefs.SetInt("Tips", GameManager._Instance._Tips);
				PlayerPrefs.SetInt("Unlock_Tip_" + LevelManager._Instance.currentLevel, 1);
				UIPanelManager._Insance.ShowPanel("GuidePanel");
			}
			else
				UIPanelManager._Insance.ShowPanel("ShopPanel");
		}

		UpdateTips();
	}
	public void Replay()
	{
		if (GameManager._Instance.isLevelClear)
			return;

		LevelManager._Instance.LoadLevel();
	}

	private void TipBtnClick()
	{
	}

	public override void Show()
	{
	}

	private void UpdatePlayContentWithShareRect()
	{
	}

	protected override void UpdateShareRect()
	{
	}

	public override void Show(object para)
	{
	}

	public override void Hide()
	{
	}

	public override void UpdatePanel()
	{
		UpdateLvName();
	}

	private void UpdateLvName()
	{
		_LevelText.text = "LVL." + LevelManager._Instance.currentLevel;
	}

	public void UpdatePlayContent(float height = 0f)
	{
	}

	public override void UpdateTips()
	{
		bulbTipText.text = GameManager._Instance._Tips.ToString();
	}

	public void UpdateTips(string str)
	{
	}
}
