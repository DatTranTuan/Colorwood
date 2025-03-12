using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreLevel : MonoBehaviour
{
    [SerializeField] private GameObject checkMark;
    [SerializeField] private int levelNumber;
    [SerializeField] private Player player;
    [SerializeField] private Transform mainPos;

    [SerializeField] private Button thisBtn;

    public Transform MainPos { get => mainPos; set => mainPos = value; }
    public GameObject CheckMark { get => checkMark; set => checkMark = value; }
    public Button ThisBtn { get => thisBtn; set => thisBtn = value; }

    private void Start()
    {
        ThisBtn.onClick.AddListener(Click);
    }

    private void Click()
    {
        player.Move(this);
        DataManager2.Instance.LevelIndex = levelNumber;
        UIManager.Instance.UpdateText(levelNumber);
    }
}
