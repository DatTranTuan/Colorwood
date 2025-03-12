using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float moveDistance = 0.5f; // Khoảng cách di chuyển
    public float moveDuration = 1f; // Thời gian di chuyển
    public float angle = 30f; // Góc di chuyển (30 độ)
    public Ease moveEase = Ease.InOutSine; // Kiểu easing (làm mượt chuyển động)

    private Vector3 direction; // Hướng di chuyển

    private Tween tween;

    public Tween Tween { get => tween; set => tween = value; }

    private void Start()
    {
        // Tính toán hướng di chuyển theo góc 30 độ
        float radians = angle * Mathf.Deg2Rad;
        direction = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
        MoveObject();
    }

    public void MoveObject()
    {
        Vector3 targetPosition = transform.position + direction * moveDistance;

        tween = transform.DOMove(targetPosition, moveDuration)
            .SetEase(moveEase) // Áp dụng easing cho chuyển động mượt
            .SetLoops(-1, LoopType.Yoyo); // Lặp vô hạn, đi lên rồi xuống
    }
}
