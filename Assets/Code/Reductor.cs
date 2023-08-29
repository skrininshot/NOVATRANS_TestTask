using System;
using UnityEngine;

public class Reductor : MonoBehaviour
{
    public Action<ReductorMode> OnModeChanged;

    [SerializeField] private ElementsList _elementsList;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _explosionVFX;
    private Transform _selectedElementTransform = null;
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
            HideAllExceptSelected();
        }
        else
        {
            _selectedElementTransform = null;
            ShowAll();
        }  
    }

    private void HideAllExceptSelected()
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
            child.SetActive(true);
        }
    }

    public void ExplodeOrRecovery()
    {
        _isExploded = !_isExploded;

        if (_isExploded)
        {
            _animator.SetTrigger("Explosion");
            OnModeChanged?.Invoke(ReductorMode.Exploded);
            ExplosionFX();
        }
        else
        {
            _animator.SetTrigger("Recovery");
            OnModeChanged?.Invoke(ReductorMode.Recovery);
        }

        ShowAll();
    }

    private void ExplosionFX()
    {
        _explosionVFX.Play();
    }

    private void OnDestroy()
    {
        _elementsList.OnElementSelect -= ShowElement;
    }
}

public enum ReductorMode
{
    Exploded,
    Recovery,
    Default
}