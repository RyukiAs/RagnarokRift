using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGodOnPrefab : MonoBehaviour
{
    [SerializeField]
    private God godpass;

    public void setGod(God god)
    {
        godpass= god;
    }

    public God getGod() { return godpass; }
}
