using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : Singleton<TutorialManager>
{
    [SerializeField] private Hand handTut;

    [SerializeField] private Sprite[] markArray;

    [SerializeField] private List<WoodStore> listWS = new List<WoodStore>();

    public List<WoodStore> ListWS { get => listWS; set => listWS = value; }
    public Hand HandTut { get => handTut; set => handTut = value; }

    public void Check(WoodStore ws)
    {
        for (int i = 0; i < ListWS.Count; i++)
        {
            if (ListWS[i] != ws)
            {
                if (listWS[i].ListWoodBlock.Count < 1 || ListWS[i].ListWoodBlock[ListWS[i].ListWoodBlock.Count - 1].WoodType == ws.ListWoodBlock[ws.ListWoodBlock.Count -1].WoodType)
                {
                    ListWS[i].Mark.gameObject.SetActive(true);
                    ListWS[i].Mark.SpriteRenderer.sprite = markArray[0];
                }
                else
                {
                    ListWS[i].Mark.gameObject.SetActive(true);
                    ListWS[i].Mark.SpriteRenderer.sprite = markArray[1];
                }
            }
        }
    }

    public void SetFalse()
    {
        for (int i = 0; i < ListWS.Count; i++)
        {
            ListWS[i].Mark.gameObject.SetActive(false);
        }
    }
}
