using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonClickScaleEffect : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private float _scaleAmount = 1.2f;
    [SerializeField] private float _scaleDuration = 0.2f;

    private Vector3 _originalScale;

    private void Awake()
    {
        if (_button == null)
        {
            _button = GetComponent<Button>();
        }

        _originalScale = transform.localScale;
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        transform.DOScale(_originalScale * _scaleAmount, _scaleDuration)
                 .OnComplete(() => transform.DOScale(_originalScale, _scaleDuration));
    }
}
