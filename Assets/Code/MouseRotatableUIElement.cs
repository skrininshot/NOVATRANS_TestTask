using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class MouseRotatableUIElement : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] private Transform _rotatableObject;
    [SerializeField] private Camera _cam;
    [SerializeField] private float _rotationSpeed = 1f;
    private Vector3 _mouseOrigin;

    public void OnPointerDown(PointerEventData eventData)
    {
        _mouseOrigin = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var delta = Input.mousePosition - _mouseOrigin;
        _mouseOrigin = Input.mousePosition;

        var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * delta;
        _rotatableObject.rotation = Quaternion.AngleAxis(delta.magnitude * _rotationSpeed, axis) * _rotatableObject.rotation;

    }
} 