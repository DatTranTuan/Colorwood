using DG.Tweening;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBlock : MonoBehaviour
{
    [SerializeField] private ParticleColor particleColor;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Renderer rendere;

    [SerializeField] private WoodType woodType;

    [SerializeField] private List<WoodStore> listWS = new List<WoodStore>();

    [SerializeField] private bool isLiquid;

    [SerializeField] private SkeletonAnimation anim;

    private Stack<WoodStore> wtStack = new Stack<WoodStore>();

    private int orderIndex;

    public WoodType WoodType { get => woodType; set => woodType = value; }
    public Stack<WoodStore> WTStack { get => wtStack; set => wtStack = value; }
    public List<WoodStore> ListWS { get => listWS; set => listWS = value; }
    public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
    public bool IsLiquid { get => isLiquid; set => isLiquid = value; }
    public int OrderIndex { get => orderIndex; set => orderIndex = value; }
    public Renderer Rendere { get => rendere; set => rendere = value; }
    public SkeletonAnimation Anim { get => anim; set => anim = value; }
    public ParticleColor ParticleColor { get => particleColor; set => particleColor = value; }

    private void Start()
    {
        Rendere = Anim.GetComponent<Renderer>();
        Anim.timeScale = 0;

    }

    public void Select(bool select)
    {
        GameManager.Instance.IsDone = false;

        if (select)
        {
            Debug.Log("Selected " + gameObject.name);

            //Shake(true);
            ChangeAnimation("animation", true);

            transform.DOMove(new Vector3(transform.position.x, transform.position.y + 0.2f), 0.11f).SetEase(Ease.Linear).OnComplete(() =>
            {
                GameManager.Instance.IsDone = true;
            });
        }
        else
        {
            //Shake(false);

            Debug.Log(" Turn Down " + gameObject.name);
            anim.ClearState();

            transform.DOMove(new Vector3(transform.position.x, transform.position.y - 0.2f), 0.11f).SetEase(Ease.Linear).OnComplete(() =>
            {
                GameManager.Instance.IsDone = true;
            });
        }
    }

    public void UndoBack(WoodStore woodStore)
    {
        SetPos(woodStore);
        transform.SetParent(woodStore.transform);
    }

    public void SetPos(WoodStore woodStore)
    {
        woodStore.SetWoodBlockPos(this);
    }

    public void SetData(WoodData woodData, WoodStore woodStore, bool isLiquid)
    {
        if (woodData != null)
        {
            Rendere.sortingOrder = 1;

            woodType = woodData.woodType;

            transform.SetParent(woodStore.transform);

            if (isLiquid)
            {
                this.isLiquid = true;
            }

            CheckColor();

            if (woodData.index == 3)
            {
                ChangeCutSprite();
            }

            particleColor.CheckParticelMainColor(woodType);
            particleColor.CheckParticel1Color(woodType);
            particleColor.CheckParticel2Color(woodType);
            particleColor.CheckParticel3Color(woodType);
        }
    }

    public void CheckColor ()
    {
        if (isLiquid)
        {
            //spriteRenderer.sprite = GameManager.Instance.ListSprite[0];
            Anim.Skeleton.SetSkin("skin_0");
        }
        else
        {
            if ((int)woodType == 1)
            {
                //spriteRenderer.sprite = GameManager.Instance.ListSprite[1];
                Anim.Skeleton.SetSkin("skin_6");
            }
            else if ((int)woodType == 2)
            {
                //spriteRenderer.sprite = GameManager.Instance.ListSprite[2];
                Anim.Skeleton.SetSkin("skin_2");
            }
            else if ((int)woodType == 3)
            {
                //spriteRenderer.sprite = GameManager.Instance.ListSprite[3];
                Anim.Skeleton.SetSkin("skin_5");
            }
            else if ((int)woodType == 4)
            {
                //spriteRenderer.sprite = GameManager.Instance.ListSprite[4];
                Anim.Skeleton.SetSkin("skin_4");
            }
            else if ((int)woodType == 5)
            {
                //spriteRenderer.sprite = GameManager.Instance.ListSprite[5];
                Anim.Skeleton.SetSkin("skin_7");
            }
            else if ((int)woodType == 6)
            {
                //spriteRenderer.sprite = GameManager.Instance.ListSprite[6];
                Anim.Skeleton.SetSkin("skin_1");
            }
            else if ((int)woodType == 7)
            {
                //spriteRenderer.sprite = GameManager.Instance.ListSprite[7];
                Anim.Skeleton.SetSkin("skin_3");
            }
        }
    }

    public void ChangeCutSprite()
    {
        if ((int)woodType == 1)
        {
            Anim.Skeleton.SetSkin("skin_13");
        }
        else if ((int)woodType == 2)
        {
            Anim.Skeleton.SetSkin("skin_9");
        }
        else if ((int)woodType == 3)
        {
            Anim.Skeleton.SetSkin("skin_12");
        }
        else if ((int)woodType == 4)
        {
            Anim.Skeleton.SetSkin("skin_11");
        }
        else if ((int)woodType == 5)
        {
            Anim.Skeleton.SetSkin("skin_14");
        }
        else if ((int)woodType == 6)
        {
            Anim.Skeleton.SetSkin("skin_8");
        }   
        else if ((int)woodType == 7)
        {
            Anim.Skeleton.SetSkin("skin_10");
        }
        else
        {
            spriteRenderer.color = Color.black;
        }
    }


    public void ChangeAllWin()
    {
        //if ((int)woodType == 1)
        //{
        //    spriteRenderer.sprite = GameManager.Instance.ListSprite[15];
        //}
        //else if ((int)woodType == 2)
        //{
        //    spriteRenderer.sprite = GameManager.Instance.ListSprite[16];
        //}
        //else if ((int)woodType == 3)
        //{
        //    spriteRenderer.sprite = GameManager.Instance.ListSprite[17];
        //}
        //else if ((int)woodType == 4)
        //{
        //    spriteRenderer.sprite = GameManager.Instance.ListSprite[18];
        //}
        //else if ((int)woodType == 5)
        //{
        //    spriteRenderer.sprite = GameManager.Instance.ListSprite[19];
        //}
        //else if ((int)woodType == 6)
        //{
        //    spriteRenderer.sprite = GameManager.Instance.ListSprite[20];
        //}
        //else if ((int)woodType == 7)
        //{
        //    spriteRenderer.sprite = GameManager.Instance.ListSprite[21];
        //}
        //else
        //{
        //    spriteRenderer.color = Color.black;
        //}

        ChangeAnimation("animation_2", false);
    }

    public void ChangeAnimation(string animationName, bool loop = true)
    {
        Anim.timeScale = 1;

        var state = Anim.AnimationState;
       
        if (Anim.Skeleton.Data.FindAnimation(animationName) != null)
        {
            state.SetAnimation(0, animationName, loop);
        }
        else
        {
            Debug.LogError($"Không tìm thấy animation '{animationName}' trong Spine.");
        }
    }
}
