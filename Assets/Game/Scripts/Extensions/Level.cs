using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level : MonoBehaviour
{
    public IEnumerator DelayfixScale() {
        yield return new WaitForSeconds(0.05f);
        ObjectScaler objectScaler = transform.AddComponent<ObjectScaler>();
        objectScaler.SetScalerWithScreen();
        yield return new WaitForSeconds(2f);
        Destroy(objectScaler);
    }
}
