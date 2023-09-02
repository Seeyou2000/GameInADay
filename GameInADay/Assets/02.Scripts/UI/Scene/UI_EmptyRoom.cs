using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EmptyRoom : MonoBehaviour
{
    private Image _image;

    void Start()
    {
        _image = GetComponent<Image>();
        _image.color = new(0.016f, 0.459f, 0.937f);
    }
}
