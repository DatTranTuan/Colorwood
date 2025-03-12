using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject homePanel;
    [SerializeField] private GameObject playPanel;
    [SerializeField] private GameObject tutorPanel;

    [SerializeField] private GameObject homeSettingPanel;
    [SerializeField] private GameObject playSettingPanel;

    [SerializeField] private Button closeSTPanel;
    [SerializeField] private Button closeSTPanel2;

    [SerializeField] private GameObject undoBtn;
    [SerializeField] private GameObject keyBtn;

    [SerializeField] private Button restartBtn;
    [SerializeField] private Button nextLevelBtn;
    [SerializeField] private Button replayBtn;
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button backHomeBtn;

    [SerializeField] private int moveLeft;
    [SerializeField] private Text moveLeftText;
    [SerializeField] private GameObject moveLeftPanel;


    public Text playText;

    public Button NextLevelBtn { get => nextLevelBtn; set => nextLevelBtn = value; }
    public int MoveLeft { get => moveLeft; set => moveLeft = value; }
    public GameObject MoveLeftPanel { get => moveLeftPanel; set => moveLeftPanel = value; }

    private void Start()
    {
        playText.text = "Level " + DataManager2.Instance.LevelIndex.ToString();

        settingBtn.onClick.AddListener(ClickSettingPanel);
        closeSTPanel.onClick.AddListener(CloseSettingPanel);
        closeSTPanel2.onClick.AddListener(CloseSettingPanel);

        replayBtn.onClick.AddListener(ClickReplay);
        backHomeBtn.onClick.AddListener(ClickBackHomePanel);
    }

    public void TurnOffHomePanel()
    {
        homePanel.SetActive(false);
    }

    public void TurnOnPlayPanel()
    {
        playPanel.SetActive(true);
        undoBtn.SetActive(true);

        if (DataManager2.Instance.LevelIndex <= 2)
        {
            tutorPanel.SetActive(true);
        }
        else
        {
            keyBtn.SetActive(true);
        }
    }

    public void ClickReplay()
    {
        AdManager.Instance.ShowInterstitialAd();

        SoundManager.Instance.Play("Replay");
        DataManager2.Instance.ReplayLevel();
    }

    public void ClickSettingPanel()
    {
        SoundManager.Instance.Play("Tap");

        if (homePanel.activeSelf)
        {
            homeSettingPanel.SetActive(true);
        }
        else if (playPanel.activeSelf)
        {
            playSettingPanel.SetActive(true);
        }
    }

    public void CloseSettingPanel()
    {
        SoundManager.Instance.Play("Tap");

        if (homeSettingPanel.activeSelf)
        {
            homeSettingPanel.SetActive(false);
        }
        else if (playSettingPanel.activeSelf)
        {
            playSettingPanel.SetActive(false);
        }
    }

    public void ClickBackHomePanel()
    {
        SoundManager.Instance.Play("Tap");

        GameManager.Instance.Key.Index = 0;
        GameManager.Instance.UnLockCount = 4;

        DataManager2.Instance.DeleteLevel();

        moveLeftPanel.SetActive(false);
        tutorPanel.SetActive(false);
        playPanel.SetActive(false);
        undoBtn.SetActive(false);
        keyBtn.SetActive(false);
        homePanel.SetActive(true);

        CloseSettingPanel();
    }

    public void UpdateText(int level)
    {
        playText.text = "Level " + level.ToString();
    }

    public void TurnOnMoveLeft(int index)
    {
        MoveLeft = index;
        UpdateMoveLeft();
        MoveLeftPanel.SetActive(true);
    }

    public void CheckMoveLeft()
    {
        if (moveLeft > 0)
        {
            moveLeft--;
            UpdateMoveLeft();

            if (moveLeft == 0)
            {
                LoseWinManager.Instance.ActiveLosePanel();
            }
        }
    }

    public void UpdateMoveLeft()
    {
        moveLeftText.text = "Move left: " + moveLeft;
    }

    public void AllLevelSound()
    {
        SoundManager.Instance.Play("Tap");
    }
}
