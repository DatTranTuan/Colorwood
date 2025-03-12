using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseWinManager : Singleton<LoseWinManager>
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    [SerializeField] private GameObject winImg;
    [SerializeField] private GameObject loseImg;

    public void ActiveWinPanel()
    {
        winPanel.SetActive(true);

        winImg.transform.localScale = Vector3.zero;

        winImg.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            DOVirtual.DelayedCall(0.5f, () => 
            {
                winImg.transform.DOScale(0f, 0.5f).SetEase(Ease.InBack).OnComplete(() =>
                {
                    winPanel.SetActive(false);
                    UIManager.Instance.ClickBackHomePanel();
                    DataManager2.Instance.PlayerMoveToNextLevel();
                });
            });
        });
    }

    public void ActiveLosePanel()
    {
        losePanel.SetActive(true);

        loseImg.transform.localScale = Vector3.zero;

        loseImg.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            DOVirtual.DelayedCall(0.5f, () =>
            {
                loseImg.transform.DOScale(0f, 0.5f).SetEase(Ease.InBack).OnComplete(() =>
                {
                    losePanel.SetActive(false);
                    UIManager.Instance.ClickBackHomePanel();
                });
            });
        });
    }
}
