using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class SceneSwitch : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private int _nextScene = -1;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        FadeOutEffect();
    }

    private void FadeInEffect()
    {
        _animator.SetTrigger("FadeIn");
    }

    private void FadeOutEffect()
    {
        _animator.SetTrigger("FadeOut");
    }

    public void SwitchScene(int scene)
    {
        _nextScene = scene;
        FadeInEffect();
    }

    public void LoadScene()
    {
        if (_nextScene != -1)
            SceneManager.LoadScene(_nextScene);
    }
}
