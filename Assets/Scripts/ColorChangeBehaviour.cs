using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangeBehaviour : MonoBehaviour
{
    private Material _material;

    // Start is called before the first frame update
    void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    private void ChangeColor(Button button)
    {
        _material.color = new Color(Random.Range(0.0f, 1), Random.Range(0.0f, 1), Random.Range(0.0f, 1), Random.Range(0.0f, 1));
    }

    public void ChangeColor(Color color)
    {
        _material.color = color;
    }
}
