using DG.Tweening;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBlock : MonoBehaviour
{
    [SerializeField] private ParticleSystem particel;

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
    public ParticleSystem Particel { get => particel; set => particel = value; }

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

            CheckParticelColor();
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

    public void CheckParticelColor()
    {
        if ((int)woodType == 1)
        {
            ParticleSystem.MainModule mainModule = Particel.main;
            mainModule.startColor = Color.red;

            ParticleSystem.ColorOverLifetimeModule colorModule = Particel.colorOverLifetime;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] {
                new GradientColorKey(Color.red, 0.0f), 
                new GradientColorKey(Color.red, 1.0f)   
                },
                new GradientAlphaKey[] {
                new GradientAlphaKey(1.0f, 0.0f),
                new GradientAlphaKey(0.0f, 1.0f)
                }
            );
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 2)
        {
            ParticleSystem.MainModule mainModule = Particel.main;
            mainModule.startColor = Color.green;

            ParticleSystem.ColorOverLifetimeModule colorModule = Particel.colorOverLifetime;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] {
                new GradientColorKey(Color.green, 0.0f),
                new GradientColorKey(Color.green, 1.0f)
                },
                new GradientAlphaKey[] {
                new GradientAlphaKey(1.0f, 0.0f),
                new GradientAlphaKey(0.0f, 1.0f)
                }
            );
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 3)
        {
            ParticleSystem.MainModule mainModule = Particel.main;
            mainModule.startColor = new Color(0.75f, 0.58f, 0.89f);

            ParticleSystem.ColorOverLifetimeModule colorModule = Particel.colorOverLifetime;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
               new GradientColorKey[] {
                new GradientColorKey(new Color(0.75f, 0.58f, 0.89f), 0.0f),
                new GradientColorKey(new Color(0.75f, 0.58f, 0.89f), 1.0f)
                },
                new GradientAlphaKey[] {
                new GradientAlphaKey(1.0f, 0.0f),
                new GradientAlphaKey(0.0f, 1.0f)
                }
            );
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 4)
        {
            ParticleSystem.MainModule mainModule = Particel.main;
            mainModule.startColor = new Color(1.0f, 0.71f, 0.76f);

            ParticleSystem.ColorOverLifetimeModule colorModule = Particel.colorOverLifetime;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] {
                new GradientColorKey(new Color(1.0f, 0.71f, 0.76f), 0.0f),
                new GradientColorKey(new Color(1.0f, 0.71f, 0.76f), 1.0f)
                },
                new GradientAlphaKey[] {
                new GradientAlphaKey(1.0f, 0.0f),
                new GradientAlphaKey(0.0f, 1.0f)
                }
            );
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 5)
        {
            ParticleSystem.MainModule mainModule = Particel.main;
            mainModule.startColor = Color.yellow;

            ParticleSystem.ColorOverLifetimeModule colorModule = Particel.colorOverLifetime;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] {
                new GradientColorKey(Color.yellow, 0.0f),
                new GradientColorKey(Color.yellow, 1.0f)
                },
                new GradientAlphaKey[] {
                new GradientAlphaKey(1.0f, 0.0f),
                new GradientAlphaKey(0.0f, 1.0f)
                }
            );
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 6)
        {
            ParticleSystem.MainModule mainModule = Particel.main;
            mainModule.startColor = Color.cyan;

            ParticleSystem.ColorOverLifetimeModule colorModule = Particel.colorOverLifetime;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] {
                new GradientColorKey(Color.cyan, 0.0f),
                new GradientColorKey(Color.cyan, 1.0f)
                },
                new GradientAlphaKey[] {
                new GradientAlphaKey(1.0f, 0.0f),
                new GradientAlphaKey(0.0f, 1.0f)
                }
            );
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 7)
        {
            ParticleSystem.MainModule mainModule = Particel.main;
            mainModule.startColor = new Color(1.0f, 0.75f, 0.5f);

            ParticleSystem.ColorOverLifetimeModule colorModule = Particel.colorOverLifetime;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
               new GradientColorKey[] {
                new GradientColorKey(new Color(1.0f, 0.75f, 0.5f), 0.0f),
                new GradientColorKey(new Color(1.0f, 0.75f, 0.5f), 1.0f)
                },
                new GradientAlphaKey[] {
                new GradientAlphaKey(1.0f, 0.0f),
                new GradientAlphaKey(0.0f, 1.0f)
                }
            );
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else
        {
            spriteRenderer.color = Color.black;
        }
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
