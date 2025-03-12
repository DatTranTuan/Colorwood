using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Key key;

    [SerializeField] private List<WoodStore> listWS = new List<WoodStore>();

    [SerializeField] private List<Sprite> listSprite = new List<Sprite>();

    [SerializeField] private int winCountData;

    private Stack<UndoClass> wSStack = new Stack<UndoClass>();

    private WoodStore lastWS;
    private WoodStore newWS;

    private int winCount = 0;
    private int unLockCount = 4;
    private int saveIndex;

    private bool isDone = true;
    private bool isntSameWoodType => newWS.ListWoodBlock.Count >0 && lastWS.ListWoodBlock[lastWS.ListWoodBlock.Count - 1].WoodType != newWS.ListWoodBlock[newWS.ListWoodBlock.Count - 1].WoodType;

    public WoodStore LastWS { get => lastWS; set => lastWS = value; }
    public WoodStore NewWS { get => newWS; set => newWS = value; }
    public bool IsDone { get => isDone; set => isDone = value; }
    public int LockCount { get => UnLockCount; set => UnLockCount = value; }
    public Stack<UndoClass> WSStack { get => wSStack; set => wSStack = value; }
    public List<WoodStore> ListWS { get => listWS; set => listWS = value; }
    public Key Key { get => key; set => key = value; }
    public int UnLockCount { get => unLockCount; set => unLockCount = value; }
    public int WinCountData { get => winCountData; set => winCountData = value; }
    public List<Sprite> ListSprite { get => listSprite; set => listSprite = value; }
    public int WinCount { get => winCount; set => winCount = value; }
    public int SaveIndex { get => saveIndex; set => saveIndex = value; }

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        ToggleManager.Instance.LoadStatus("Music", ToggleManager.Instance.MusicToggle, ToggleManager.Instance.MusicToggle2);
        ToggleManager.Instance.LoadStatus("Sound", ToggleManager.Instance.SoundToggle, ToggleManager.Instance.SoundToggle2);
        ToggleManager.Instance.LoadStatus("Haptic", ToggleManager.Instance.HapticToggle, ToggleManager.Instance.HapticToggle2);

        if (ToggleManager.Instance.MusicToggle.isOn)
        {
            SoundManager.Instance.Play("BG");
        }

        if (ToggleManager.Instance.SoundToggle.isOn)
        {
            SoundManager.Instance.TurnOnVolume();
        }
        else
        {
            SoundManager.Instance.TurnOffVolume();
        }

        AndroidVibrationController.EnableVibration(ToggleManager.Instance.HapticToggle.isOn);
    }

    public IEnumerator ChangeElementList()
    {
        if (newWS.ListWoodBlock.Count == 4 || isntSameWoodType)
        {
            lastWS.ResetWoodBlock();

            lastWS = newWS;
            newWS = null;

            lastWS.ClickOn(true);
            lastWS.IsClicked = true;
        }
        else
        {
            int woodBlockCount = 4 - newWS.ListWoodBlock.Count;

            if (newWS.IsLock && newWS.BoxCollider2D.enabled && UnLockCount >= 0 && newWS.BoxCollider2D.isTrigger)
            {
                woodBlockCount = (4 - UnLockCount) - newWS.ListWoodBlock.Count;
                //undoCount = woodBlockCount - 1;

                newWS.BoxCollider2D.isTrigger = false;
            }
            else if (UnLockCount < 0 && newWS.IsLock)
            {
                woodBlockCount = UnLockCount;
            }

            if (woodBlockCount > lastWS.SelectedNumber)
            {
                saveIndex = lastWS.SelectedNumber;
            }
            else
            {
                saveIndex = woodBlockCount;
            }

            SaveUndoStack(lastWS, newWS, saveIndex);

            for (int i = 0; i < woodBlockCount; i++)
            {
                if (i < lastWS.SelectedNumber)
                {
                    WoodBlock item = lastWS.ListWoodBlock[lastWS.ListWoodBlock.Count - 1];
                    item.transform.SetParent(newWS.transform);

                    newWS.ListWoodBlock.Add(item);
                    newWS.SetWoodBlockPos(item);

                    if (newWS.ListWoodBlock.Count == 4)
                    {
                        item.ChangeCutSprite();
                    }
                    else
                    {
                        item.CheckColor();
                    }

                    lastWS.ListWoodBlock.RemoveAt(lastWS.ListWoodBlock.Count - 1);

                    CheckLiquid(lastWS);

                    yield return new WaitForSeconds(0.1f);
                }
                else
                {
                    break;
                }
            }

            if (DataManager2.Instance.LevelIndex == 10 || DataManager2.Instance.LevelIndex == 15)
            {
                UIManager.Instance.CheckMoveLeft();
            }

            if (lastWS.SelectedNumber > 1 && woodBlockCount < lastWS.SelectedNumber)
            {
                lastWS.ClickOn(false);
            }

            lastWS.SelectedNumber = 0;
            newWS.SelectedNumber = 0;

            if (newWS.IsLock)
            {
                newWS.BoxCollider2D.isTrigger = true;
            }

            StartCoroutine(CheckDoneAndWin(newWS));

            lastWS.IsClicked = false;
            lastWS = null;
            newWS = null;
        }
    }

    public void SaveUndoStack(WoodStore from, WoodStore to, int blockCount)
    {
        UndoClass undoClass = new UndoClass(from, to, blockCount);
        wSStack.Push(undoClass);
    }

    public IEnumerator Undo()
    {
        if (wSStack.Count > 0)
        {
            if (wSStack.Count > 2)
            {
                AdManager.Instance.ShowRewardedAd();
            }

            if (DataManager2.Instance.LevelIndex == 10 || DataManager2.Instance.LevelIndex == 15)
            {
                UIManager.Instance.MoveLeft++;
                UIManager.Instance.UpdateMoveLeft();
            }

            if (lastWS != null)
            {
                lastWS.ClickOn(false);
                lastWS.IsClicked = false;
                lastWS = null;
            }

            UndoClass lastAction = wSStack.Peek();

            for (int i = 0; i < lastAction.blockCount; i++)
            {
                WoodBlock item = lastAction.toWS.ListWoodBlock[lastAction.toWS.ListWoodBlock.Count - 1];
                item.transform.SetParent(lastAction.fromWS.transform);

                lastAction.fromWS.ListWoodBlock.Add(item);
                lastAction.fromWS.SetWoodBlockPos(item);

                if (lastAction.fromWS.ListWoodBlock.Count == 4)
                {
                    item.ChangeCutSprite();
                }
                else
                {
                    item.CheckColor();
                }

                lastAction.toWS.ListWoodBlock.RemoveAt(lastAction.toWS.ListWoodBlock.Count - 1);

                yield return new WaitForSeconds(0.1f);
            }

            wSStack.Pop();
        }
    }

    public void CheckLiquid(WoodStore ws)
    {
        if (ws.ListWoodBlock.Count > 0)
        {
            if (ws.ListWoodBlock[ws.ListWoodBlock.Count - 1].IsLiquid)
            {
                ws.ListWoodBlock[ws.ListWoodBlock.Count - 1].IsLiquid = false;
                ws.ListWoodBlock[ws.ListWoodBlock.Count - 1].CheckColor();

                if (ws.ListWoodBlock.Count > 1)
                {
                    for (int i = ws.ListWoodBlock.Count - 2; i >= 0; i--)
                    {
                        if (ws.ListWoodBlock[i].IsLiquid && ws.ListWoodBlock[i].WoodType == ws.ListWoodBlock[ws.ListWoodBlock.Count - 1].WoodType)
                        {
                            ws.ListWoodBlock[i].IsLiquid = false;
                            ws.ListWoodBlock[i].CheckColor();
                        }
                        else
                        {
                            break;
                        }
                    }
                } 
            }
        }
    }

    public IEnumerator CheckDoneAndWin(WoodStore woodStore)
    {
        var woodType = woodStore.ListWoodBlock[0].WoodType;
        int index = 0;

        if (woodStore.ListWoodBlock.Count == 4)
        {
            for (int i = 0; i < woodStore.ListWoodBlock.Count; i++)
            {
                if (woodStore.ListWoodBlock[i].WoodType == woodType)
                {
                    index++;
                    if (index == 3)
                    {
                        wSStack.Clear();
                        Debug.Log("+++++1");

                        //woodStore.gameObject.SetActive(false);
                        woodStore.BoxCollider2D.enabled = false;

                        WinCount++;

                        yield return new WaitForSeconds(0.45f);
                        AndroidVibrationController.VibratePattern(new long[] { 0, 50 }, -1, 11);

                        for (int y = 0; y < woodStore.ListWoodBlock.Count; y++)
                        {
                            woodStore.ListWoodBlock[y].ChangeAllWin();
                            yield return new WaitForSeconds(0.11f);
                        }

                        SoundManager.Instance.Play("Complete");
                        woodStore.ActiveParticel();

                        if (WinCount == winCountData)
                        {
                            Debug.LogError("Winnnn");

                            SoundManager.Instance.Play("Win");

                            DataManager2.Instance.SaveLevel();

                            //DataManager2.Instance.NextLevelBtn.gameObject.SetActive(true);

                            yield return new WaitForSeconds(1f);
                            LoseWinManager.Instance.ActiveWinPanel();
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
