using UnityEngine;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(Animator))]
public class AnimatedCamera : MonoBehaviour
{
    [SerializeField] private ElementsList _elementsList;
    [SerializeField] private Animator _animator;
    private Transform _currentElement;
    private bool _isApproached;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        _elementsList.OnElementSelect += HandleAction;
    }

    private void HandleAction(Transform element)
    {
        if (!_isApproached)
        {
            _animator.SetTrigger("Approach");
            _isApproached = true;
        }
        else if (_isApproached && element == _currentElement)
        {
            _animator.SetTrigger("Distance");
            _isApproached = false;
        }

        _currentElement = element;
    }

    private void OnDestroy()
    {
        _elementsList.OnElementSelect -= HandleAction;
    }
}
