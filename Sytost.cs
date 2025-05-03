using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sytost : MonoBehaviour
{
    public int num;
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (PlayerController.hungry < num)
        {
            image.enabled = false;
        }
    }
}
