using UnityEngine;

public class Reductor : MonoBehaviour
{
    [SerializeField] private ElementsList _elementsList;
    private Transform _selectedElementTransform = null;
    [SerializeField] private Animator _animator;
    private bool _isExploded;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        _elementsList.OnElementSelect += ShowElement;
    }

    private void ShowElement(Transform element)
    {
        if (_selectedElementTransform != element)
        {
            _selectedElementTransform = element;
            HideAllExcept();
        }
        else
        {
            _selectedElementTransform = null;
            ShowAll();
        }  
    }

    private void HideAllExcept()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);

        _selectedElementTransform.gameObject.SetActive(true);
    }

    private void ShowAll()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;

            if (!child.activeSelf)
                child.SetActive(true);
        }
    }

    public void ExplodeOrRecovery()
    {
        _isExploded = !_isExploded;

        if (_isExploded)
            _animator.SetTrigger("Explosion");
        else
            _animator.SetTrigger("Recovery");

    }

    private void OnDestroy()
    {
        _elementsList.OnElementSelect -= ShowElement;
    }
}
