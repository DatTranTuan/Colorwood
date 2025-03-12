using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undoo : MonoBehaviour
{
    private void OnMouseDown()
    {
        SoundManager.Instance.Play("Undo");
        StartCoroutine(GameManager.Instance.Undo());
    }
}
