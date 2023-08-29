using UnityEngine;
using TMPro;
using System;

public class ListElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Transform _element;
    public Action<Transform> OnElementSelect;

    public void SetElement(Transform element)
    {
        _element = element;
        _text.text = _element.name;
    }

    public void OnClick()
    {
        Debug.Log($"{_element.name} is clicked");
        OnElementSelect?.Invoke(_element);
    }
}
