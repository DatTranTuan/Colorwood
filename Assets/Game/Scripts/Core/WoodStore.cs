using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodStore : MonoBehaviour
{
    [SerializeField] private Transform[] posArray; 

    [SerializeField] private Mark mark;

    [SerializeField] private GameObject winPaticel;

    [SerializeField] private bool isLock;
    [SerializeField] private GameObject lockPrefab;

    private bool isClicked = false;
    private StoreData data;

    [SerializeField] private List<WoodBlock> listWoodBlock = new List<WoodBlock>();
    [SerializeField] private List<GameObject> listLock = new List<GameObject>();

    [SerializeField] private Transform headPos;
    [SerializeField] private Transform lastPos;

    [SerializeField] private BoxCollider2D boxCollider2D;

    [SerializeField] private int posss;

    private int selectedNumber = 0;

    private bool isUndo = false;
    private bool isUndo2 = false;
    private bool isLoading = false;

    public int SelectedNumber { get => selectedNumber; set => selectedNumber = value; }
    public List<WoodBlock> ListWoodBlock { get => listWoodBlock; set => listWoodBlock = value; }
    public Transform LastPos { get => lastPos; set => lastPos = value; }
    public bool IsClicked { get => isClicked; set => isClicked = value; }
    public BoxCollider2D BoxCollider2D { get => boxCollider2D; set => boxCollider2D = value; }
    public List<GameObject> ListLock { get => listLock; set => listLock = value; }
    public bool IsLock { get => isLock; set => isLock = value; }
    public bool IsUndo { get => isUndo; set => isUndo = value; }
    public Transform HeadPos { get => headPos; set => headPos = value; }
    public int Posss { get => posss; set => posss = value; }
    public bool IsUndo2 { get => isUndo2; set => isUndo2 = value; }
    public Mark Mark { get => mark; set => mark = value; }

    public WoodBlock woodPrefab;

    private void Start()
    {
        Posss = 0;

        AddWoodBlockToList();

    }

    public void SetData(StoreData data) 
    {
        this.data = data;

        if (data != null) 
        {
            SetPos(data.posIndex);

            if (!data.isLock)
            {
                isLoading = true;

                for (int i = 0; i < data.woodDatas.Count; i++)
                {
                    UpdateWood(data.woodDatas[i]);
                }

                isLoading = false;
            }
            else
            {
                isLock = true;
                boxCollider2D.enabled = false;

                GameManager.Instance.Key.LockWoodStore = this;

                int index = 0;

                for (int i = 0; i < 4; i++)
                {
                    var lockSpawn = Instantiate(lockPrefab);
                    listLock.Add(lockSpawn);

                    lockSpawn.transform.SetParent(transform);

                    if (index == 0)
                    {
                        lockSpawn.transform.position = new Vector3(LastPos.position.x + 0.03f, lastPos.position.y);
                    }
                    else
                    {
                        lockSpawn.transform.position = new Vector3(LastPos.position.x + 0.03f, posArray[index].position.y);
                    }

                    index++;
                }
            }
        }
    }

    private void UpdateWood(WoodData woodData)
    {
        if (woodData != null)
        {
            var woodSpawn = Instantiate(woodPrefab);

            //listWoodBlock.Add(woodSpawn);
            woodSpawn.SetData(woodData, this, woodData.isLiquid);

            SetWoodBlockPos(woodSpawn);

            posss++;
        }
    }

    public void SetPos(int index)
    {
        float yPos = -1f;

        if (index >= 0)
        {
            if (index <= 3)
            {
                transform.position = new Vector3(-1.5f + index, 2.23f, 0);
            }
            else
            {
                if (index < 9)
                {
                    if (index == 4)
                    {
                        transform.position = new Vector3(-1.5f, yPos, 0);
                    }
                    else
                    {
                        index -= 4;
                        transform.position = new Vector3(-1.5f + index, yPos, 0);
                    }
                }
                else
                {
                    float xIndex = (index - 15) / 10;

                    if (index == 15)
                    {
                        transform.position = new Vector3(-1f, 2.23f, 0);
                    }
                    else if (index < 45)
                    {
                        transform.position = new Vector3(-1f + xIndex, 2.23f, 0);
                    }
                    else
                    {
                        if (index == 45)
                        {
                            transform.position = new Vector3(-1f, yPos, 0);
                        }
                        else
                        {
                            xIndex = (index - 45) / 10;
                            transform.position = new Vector3(-1f + xIndex, yPos, 0);
                        }
                    }
                }
            }
        }
        else
        {
            if (index == -5)
            {
                transform.position = new Vector3(-2f, 2.23f, 0);
            }
            else if (index == -15)
            {
                transform.position = new Vector3(-2f, yPos, 0);
            }
            else if (index == -45)
            {
                transform.position = new Vector3(-1f + 3, 2.23f, 0);
            }
        }
    }

    private void OnMouseDown()
    {
        if (!GameManager.Instance.IsDone)
        {
            return;
        }
        else
        {
            if (!IsClicked)
            {
                if (GameManager.Instance.LastWS == null)
                {
                    GameManager.Instance.LastWS = this;

                    if (GameManager.Instance.LastWS.ListWoodBlock.Count <= 0)
                    {
                        GameManager.Instance.LastWS = null;
                        return;
                    }
                    else
                    {
                        ClickOn(true);
                        IsClicked = true;

                        if (DataManager2.Instance.ListLevel[0].gameObject.activeSelf || DataManager2.Instance.ListLevel[1].gameObject.activeSelf)
                        {
                            TutorialManager.Instance.Check(this);
                            TutorialManager.Instance.HandTut.Tween.Kill();
                            TutorialManager.Instance.HandTut.gameObject.SetActive(false);
                        }
                    }
                }
                else
                {

                    if (GameManager.Instance.NewWS == null)
                    {
                        GameManager.Instance.NewWS = this;

                        StartCoroutine(GameManager.Instance.ChangeElementList());

                        if (DataManager2.Instance.ListLevel[0].gameObject.activeSelf || DataManager2.Instance.ListLevel[1].gameObject.activeSelf)
                        {
                            TutorialManager.Instance.SetFalse();
                        }
                    }
                }
            }
            else
            {
                ClickOn(false);
                IsClicked = false;
                GameManager.Instance.LastWS = null;
            }
        }
    }

    public void AddWoodBlockToList()
    {
        WoodBlock[] woodBlock = transform.GetComponentsInChildren<WoodBlock>();

        ListWoodBlock.AddRange(woodBlock);
    }

    public void ClickOn(bool select)
    {
        if (listWoodBlock.Count > 0)
        {
            if (!select)
            {
                selectedNumber = 0;
                ListWoodBlock[ListWoodBlock.Count - 1].Select(select);
                AndroidVibrationController.VibratePattern(new long[] { 0, 50 }, -1, 1);

                if (DataManager2.Instance.ListLevel[0].gameObject.activeSelf || DataManager2.Instance.ListLevel[1].gameObject.activeSelf)
                {
                    TutorialManager.Instance.SetFalse();
                }
            }
            else
            {
                ListWoodBlock[ListWoodBlock.Count - 1].Select(select);
                selectedNumber++;
                AndroidVibrationController.VibratePattern(new long[] { 0, 50 }, -1, 8);
            }

            SoundManager.Instance.Play("CubePeek");

            for (int i = ListWoodBlock.Count - 2; i >= 0; i--)
            {
                if (ListWoodBlock[i].WoodType == ListWoodBlock[ListWoodBlock.Count - 1].WoodType && !listWoodBlock[i].IsLiquid)
                {
                    if (select)
                    {
                        ListWoodBlock[i].Select(select);
                        selectedNumber++;
                    }
                    else
                    {
                        ListWoodBlock[i].Select(select);
                        selectedNumber = 0;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        else
        {
            isClicked = false;
            return;
        }
    }

    public void SetWoodBlockPos(WoodBlock woodBlock)
    {
        if (!IsUndo2 && !isLoading)
        {
            Posss = listWoodBlock.Count - 1;
        }

        if (isUndo)
        {
            Posss++;
            isUndo = false;
        }

        if (Posss <= 0)
        {
            woodBlock.Rendere.sortingOrder = 2;
            woodBlock.OrderIndex = 2;
        }
        else
        {
            if (Posss == 0)
            {
                Posss = 1;
            }

            woodBlock.Rendere.sortingOrder = posss + 2;
            woodBlock.OrderIndex = posss + 2;
        }

        var pos = new Vector3(LastPos.position.x, posArray[posss].position.y);

        if (isLoading)
        {
            woodBlock.transform.position = pos;
        }
        else
        {
            //orderIndex++;

            //woodBlock.SpriteRenderer.sortingOrder = orderIndex;

            float distance = Vector3.Distance(transform.position, pos);
            float jumpPower = distance / 2 * 1.5f;

            float woodY = woodBlock.transform.position.y;
            float headPosY = headPos.transform.position.y;
            float dis = headPosY - woodY;

            GameManager.Instance.IsDone = false;

            if (dis >= 0.1f)
            {
                woodY = headPos.transform.position.y;

                woodBlock.Rendere.sortingOrder = 10;
                woodBlock.ParticleColor.ParticleMain.gameObject.SetActive(true);

                woodBlock.transform.DOMove(new Vector2(woodBlock.transform.position.x, woodY), 0.16f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    woodBlock.transform.DOJump(new Vector2(headPos.position.x, woodY), jumpPower, 1, 0.21f)
                    .SetEase(Ease.Linear).OnComplete(() =>
                    {
                        woodBlock.transform.DOMove(pos, 0.11f).SetEase(Ease.Linear).OnComplete(() =>
                        {
                            GameManager.Instance.IsDone = true;
                            woodBlock.Rendere.sortingOrder = woodBlock.OrderIndex;
                            woodBlock.Anim.ClearState();

                            if (GameManager.Instance.SaveIndex > 1)
                            {
                                SoundManager.Instance.Play("7Cube");
                                AndroidVibrationController.VibratePattern(new long[] { 0, 50, 1, 20 }, -1, 8);
                            }
                            else
                            {
                                SoundManager.Instance.Play("1Cube");
                                AndroidVibrationController.VibratePattern(new long[] { 0, 50 }, -1, 10);
                            }

                            //woodBlock.ParticleColor.ParticleMain.gameObject.SetActive(false);

                        });
                    });
                });
            }
            else
            {
                woodBlock.Rendere.sortingOrder = 10;
                woodBlock.ParticleColor.ParticleMain.gameObject.SetActive(true);

                woodBlock.transform.DOJump(new Vector2(headPos.position.x, woodY), jumpPower + 1f, 1, 0.31f)
                .SetEase(Ease.Linear).OnComplete(() =>
                {
                    woodBlock.transform.DOMove(pos, 0.16f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        GameManager.Instance.IsDone = true;
                        woodBlock.Rendere.sortingOrder = woodBlock.OrderIndex;
                        woodBlock.Anim.ClearState();

                        if (GameManager.Instance.SaveIndex > 1)
                        {
                            SoundManager.Instance.Play("7Cube");
                            AndroidVibrationController.VibratePattern(new long[] { 0, 50, 1, 20 }, -1, 8);
                        }
                        else
                        {
                            SoundManager.Instance.Play("1Cube");
                            AndroidVibrationController.VibratePattern(new long[] { 0, 50 }, -1, 10);
                        }

                        //woodBlock.ParticleColor.ParticleMain.gameObject.SetActive(false);
                    });
                });
            }
        }
    }

    public void ResetWoodBlock()
    {
        IsClicked = false;
        ClickOn(false);
    }

    public void ActiveParticel()
    {
        var confetti = Instantiate(winPaticel, transform);
        confetti.transform.SetParent(transform);
        Destroy(confetti.gameObject, 6f);
    }
}

[Serializable]
public class LevelDataD
{
    public int LevelID;
    public List<StoreData> storeDatas;
    public int winCount;

    public LevelDataD(int LevelID,List<StoreData> storeDatas, int winCount) 
    {
        this.LevelID = LevelID;
        this.storeDatas = storeDatas;
        this.winCount = winCount;
    }
}

[Serializable]
public class StoreData
{
    public int posIndex; // so thu tu tren man hinh
    public List<WoodData> woodDatas;
    public bool isLock;

    public StoreData(int posIndex, List<WoodData> woodDatas, bool isLock) 
    {
        this.posIndex = posIndex;
        this.woodDatas = woodDatas;
        this.isLock = isLock;
    }
}

[Serializable]
public class WoodData 
{
    public WoodType woodType;
    public int index;
    public bool isLiquid;

    public WoodData(WoodType woodType,int index, bool isLiquid) 
    {
        this.woodType = woodType;
        this.index = index;
        this.isLiquid = isLiquid;
    }
}
