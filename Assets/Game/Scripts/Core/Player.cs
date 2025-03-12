using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;

    public void Move(StoreLevel storeLevel)
    {
        if (GameManager.Instance.IsDone == true)
        {
            var pos = new Vector3(storeLevel.MainPos.position.x, storeLevel.MainPos.position.y);

            float distance = Vector3.Distance(transform.position, storeLevel.MainPos.position);
            float jumpPower = distance / 50;

            float woodY = transform.position.y;
            float posY = storeLevel.MainPos.position.y;
            float dis = posY - woodY;

            GameManager.Instance.IsDone = false;
            scrollRect.enabled = false;

            if (dis >= 0.1f)
            {
                woodY = posY;

                transform.DOMove(new Vector2(transform.position.x, woodY), 0.11f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    transform.DOJump(new Vector2(storeLevel.MainPos.position.x, woodY), jumpPower, 1, 0.3f)
                    .SetEase(Ease.Linear).OnComplete(() =>
                    {
                        transform.DOMove(pos, 0.3f).SetEase(Ease.Linear).OnComplete(() =>
                        {
                            GameManager.Instance.IsDone = true;
                            scrollRect.enabled = true;
                        });
                    });
                });
            }
            else
            {
                transform.DOJump(new Vector2(storeLevel.MainPos.position.x, transform.position.y), jumpPower, 1, 0.35f)
                .SetEase(Ease.Linear).OnComplete(() =>
                {
                    transform.DOMove(pos, 0.15f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        GameManager.Instance.IsDone = true;
                        scrollRect.enabled = true;
                    });
                });
            }
        }
        else
        {
            return;
        }
    }
}
