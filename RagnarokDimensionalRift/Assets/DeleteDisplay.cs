using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDisplay : MonoBehaviour
{
    private void OnDisable()
    {
        Transform parentTransform = this.transform;

        foreach (Transform child in parentTransform)
        {
            Destroy(child.gameObject);
        }
    }
}
