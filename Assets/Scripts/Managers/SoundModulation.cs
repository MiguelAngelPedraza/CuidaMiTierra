using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MalbersAnimations.Controller;

public class SoundModulation : MonoBehaviour
{
    public MAnimal animal;
    [Header("Settings")]
    [SerializeField] public bool enable = true;
    private RectTransform _soundEffect;
    private Image _soundImage;
    private Image _alertImage;
    private float _currentMaxSoundEffectSize = 4;
    [SerializeField] public float maxSoundEffectSize = 4;
    [SerializeField] public float maxSoundEffectWhenSneaky = 1;
    private const float SOUND_EFFECT_SIZE_ADJUSTMENT = 2.5f;
    private Animator _animator;
    private float _movementScale = 0;
    [SerializeField] private bool _sneak = false;
    [SerializeField] public bool isSneak { get { return _sneak; } }
    private SoundModulationState _currentState = SoundModulationState.UNDETECTED;
    private Color _currentEffectColor = Color.white;
    private const float COLOR_CHANGE_SPEED = 5f;

    private void Awake()
    {
        animal = transform.parent.GetComponentInParent<MAnimal>();
        _animator = animal.GetComponent<Animator>();
        _soundEffect = GetComponent<RectTransform>();
        _soundImage = GetComponent<Image>();
        _alertImage = transform.GetChild(0).GetComponent<Image>();
        ToggleSneak(false);
        ChangeState(SoundModulationState.UNDETECTED);
    }

    void Update()
    {
        if (!enable)
        {
            _soundEffect.localScale = Vector2.zero;
            return;
        }

        _movementScale = _animator.GetFloat("Vertical") / SOUND_EFFECT_SIZE_ADJUSTMENT;

        _soundImage.color = Color.Lerp(_soundImage.color, _currentEffectColor, Time.deltaTime * COLOR_CHANGE_SPEED);

        AdjustSoundEffectSize();
        AdjustSoundEffectPosition();  
    }

    void AdjustSoundEffectSize()
    {
        //sound effect size adjustment represents the top of which "vertical" can reach.
        _currentMaxSoundEffectSize = _sneak ? maxSoundEffectWhenSneaky : maxSoundEffectSize;
        _movementScale = Mathf.Clamp(_movementScale, 0, _currentMaxSoundEffectSize);
        _soundEffect.localScale = Vector3.one * _movementScale;
    }

    void AdjustSoundEffectPosition()
    {
        Vector3 initialPosition = _animator.transform.position + Vector3.up * 0.1f;
        RaycastHit hit;
        Ray ray = new Ray(initialPosition, Vector3.down);

        _soundEffect.rotation = Quaternion.Euler(90,0,0);
        if (Physics.Raycast(ray, out hit))
        {
            _soundEffect.transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
    }

    public void ToggleSneak(bool mode)
    {
        Debug.Log("Animal " + (mode ? "entered" : "exited") + " sneak mode");
        _sneak = mode;
    }

    public void ToggleSneak()
    {
        ToggleSneak(!_sneak);
    }

    public void OnTriggerEnter(Collider other)
    {
        //Add AI Interactions.
        //Change state.
    }

    public void ChangeState(SoundModulationState state)
    {
        switch (state)
        {
            case SoundModulationState.UNDETECTED:
                _currentEffectColor = Color.white;
                _alertImage.gameObject.SetActive(false);
                break;
            case SoundModulationState.WARNED:
                _currentEffectColor = Color.yellow;
                _alertImage.gameObject.SetActive(false);
                break;
            case SoundModulationState.ALERTED:
                _currentEffectColor = Color.red;
                _alertImage.gameObject.SetActive(true);
                //Display "you were spotted!"
                break;
        }
    }
}

public enum SoundModulationState
{
    UNDETECTED,
    WARNED,
    ALERTED,
}