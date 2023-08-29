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
    [SerializeField] private Reductor _reductor; 
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

        _reductor.OnModeChanged += OnReductorModeChanged;
    }

    private void OnElementSelectHandling(Transform element)
    {
        OnElementSelect?.Invoke(element);
    }

    private void OnReductorModeChanged(ReductorMode mode)
    {
        switch (mode)
        {
            case ReductorMode.Exploded:
                ShowList(false);
                break;

            case ReductorMode.Recovery:
                ShowList(true);
                break;
        }
    }

    private void ShowList(bool show)
    {
        for (int i = 0; i < _elementsList.Count; i++)
            _elementsList[i].gameObject.SetActive(show);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _elementsList.Count; i++)
            _elementsList[i].OnElementSelect -= OnElementSelectHandling;

        _reductor.OnModeChanged -= OnReductorModeChanged;
    }
}
