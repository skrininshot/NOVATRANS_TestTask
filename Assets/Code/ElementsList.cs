using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
[RequireComponent(typeof(ContentSizeFitter))]
public class ElementsList : MonoBehaviour
{
    [SerializeField] private Transform _elementsParent;
    [SerializeField] private ListElement _listElementPrefab;
    private List<ListElement> _elementsList = new();
    Transform selectedElementTransform = null;

    private void Awake()
    {
        if (_elementsParent != null)
        {
            for (int i = 0; i < _elementsParent.childCount; i++)
            {
                ListElement newElement = Instantiate(_listElementPrefab, transform);
                newElement.SetElement(_elementsParent.GetChild(i));
                newElement.OnElementSelect += ShowElement;
                _elementsList.Add(newElement);
            }
        } 
    }

    private void ShowElement(Transform element)
    {
        if (selectedElementTransform != element)
        {
            selectedElementTransform = element;
            HideAllExcept(element);
        }
        else
        {
            selectedElementTransform = null;
            ShowAll();
        }
    }

    private void HideAllExcept(Transform element)
    {
        for (int i = 0; i < _elementsParent.childCount; i++)
        {
            Transform child = _elementsParent.GetChild(i);

            if (child.transform == element)
            {
                if (!child.gameObject.activeSelf)
                    child.gameObject.SetActive(true);

                continue;
            }

            _elementsParent.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void ShowAll()
    {
        for (int i = 0; i < _elementsParent.childCount; i++)
        {
            GameObject child = _elementsParent.GetChild(i).gameObject;

            if (!child.activeSelf)
                child.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _elementsList.Count; i++)
            _elementsList[i].OnElementSelect -= ShowElement;
    }
}
