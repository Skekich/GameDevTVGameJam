using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DisableOnExit : MonoBehaviour
{
    public void DestoryObjectOnExtit()
    {
        Destroy(gameObject);
    }
}
