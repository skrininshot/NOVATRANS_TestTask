using UnityEngine;
using TMPro;

public class ListElement : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Transform _element;

    private void OnValidate()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

    public void SetElement(Transform element)
    {
        _element = element;
        _text.text = _element.name;
    }

    public void OnClick()
    {
        Debug.Log($"{_element.name} is clicked");
    }
}
