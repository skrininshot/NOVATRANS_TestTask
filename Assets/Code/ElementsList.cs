using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
[RequireComponent(typeof(ContentSizeFitter))]
public class ElementsList : MonoBehaviour
{
    [SerializeField] private Transform _elementsParent;
    [SerializeField] private ListElement _listElementPrefab;
    private List<ListElement> _listElements = new();

    private void Awake()
    {
        if (_elementsParent != null)
        {
            for (int i = 0; i < _elementsParent.childCount; i++)
            {
                ListElement newElement = Instantiate(_listElementPrefab, transform);
                newElement.SetElement(_elementsParent.GetChild(i));
                _listElements.Add(newElement);
            }
        } 
    }
}
