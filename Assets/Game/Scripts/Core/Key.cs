using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private WoodStore lockWoodStore;
    [SerializeField] private BoxCollider2D boxCollider2D;

    private int index = 0;

    public WoodStore LockWoodStore { get => lockWoodStore; set => lockWoodStore = value; }
    public int Index { get => index; set => index = value; }
    public BoxCollider2D BoxCollider2D { get => boxCollider2D; set => boxCollider2D = value; }

    private void OnMouseDown()
    {
        ClickUnlockKey();
    }

    public void ClickUnlockKey()
    {
        if (Index <= 3)
        {
            if (index == 0)
            {
                AdManager.Instance.ShowRewardedAd();
            }

            SoundManager.Instance.Play("Key");

            LockWoodStore.ListLock[Index].SetActive(false);
            Index++;

            GameManager.Instance.LockCount--;

            if (LockWoodStore.IsLock)
            {
                LockWoodStore.BoxCollider2D.enabled = true;
            }
        }
    }
}
