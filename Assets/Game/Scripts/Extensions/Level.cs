using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(nameof(DelayfixScale));
    }

    public IEnumerator DelayfixScale() {
        yield return new WaitForSeconds(0.05f);
        ObjectScaler objectScaler = transform.AddComponent<ObjectScaler>();
        objectScaler.SetScalerWithScreen();
    }
}
