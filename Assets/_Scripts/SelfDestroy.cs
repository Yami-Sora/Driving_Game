using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SelfDestroy : MonoBehaviour
{
    void Start()
    {
    Invoke("Destroy", 12f);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

}
