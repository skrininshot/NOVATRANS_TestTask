using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
[RequireComponent(typeof(ContentSizeFitter))]
public class ElementsList : MonoBehaviour
{
    public Action<Transform> OnElementSelect;

    [SerializeField] private Transform _elementsParent;
    [SerializeField] private ListElement _listElementPrefab;
    private List<ListElement> _elementsList = new();

    private void Awake()
    {
        if (_elementsParent != null)
        {
            for (int i = 0; i < _elementsParent.childCount; i++)
            {
                ListElement newElement = Instantiate(_listElementPrefab, transform);
                newElement.SetElement(_elementsParent.GetChild(i));
                newElement.OnElementSelect += OnElementSelectHandling;
                _elementsList.Add(newElement);
            }
        }
    }

    private void OnElementSelectHandling(Transform element)
    {
        OnElementSelect?.Invoke(element);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _elementsList.Count; i++)
            _elementsList[i].OnElementSelect -= OnElementSelectHandling;
    }
}
