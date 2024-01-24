using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFone : MonoBehaviour
{
    private void Start()
    {
        var height = Camera.main.orthographicSize * 5f;
        var width = height * Screen.width / Screen.height * 2;

        transform.localScale = new Vector3(width, height, 0);
    }
}
