using UnityEngine;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(Animator))]
public class AnimatedCamera : MonoBehaviour
{
    [SerializeField] private ElementsList _elementsList;
    [SerializeField] private Animator _animator;
    private Transform _currentElement;

    private void Awake()
    {
        _elementsList.OnElementSelect += HandleAction;
    }

    private void HandleAction(Transform element)
    {
        if (element != null && _currentElement == null)
            _animator.SetTrigger("Approach");
        if (element == null && _currentElement != null)
            _animator.SetTrigger("Distance");

        _currentElement = element;
    }

    private void OnDestroy()
    {
        _elementsList.OnElementSelect -= HandleAction;
    }
}
