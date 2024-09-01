using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// ���࣬��Ҫ����
/// </summary>
internal class ButtonSimple : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //����
    private float _sizeOnButtonDown = 0.9f;
    private float _animationSpeedOnButtonUp = 2f;
    private bool _isPressed = false;
    private Coroutine _coroutine = null;

    //�����ӳ٣����°�ť���ӳٴ����¼�����
    [SerializeField] private float _delayTime = 0f;
    //�Ƿ�Ϊ���δ���,�ð�ťֻ��Чһ��
    [SerializeField] private bool _isOneShot = false;

    [SerializeField] private Sprite _spriteDown;
    private Sprite _spriteEmpty;
    private Button _button;

    protected virtual void  Start()
    {
        _button = GetComponent<Button>();
        _spriteEmpty = _button.image.sprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_spriteDown) _button.image.sprite = _spriteDown;
        transform.localScale = Vector3.one * _sizeOnButtonDown;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_spriteDown) _button.image.sprite = _spriteEmpty;
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(OnButtonUpCoroutine());
    }

    protected IEnumerator OnButtonUpCoroutine()
    {
        while (transform.localScale.x < 1)
        {
            transform.localScale += Time.deltaTime * _animationSpeedOnButtonUp * Vector3.one;
            yield return null;
        }
        yield return new WaitForSeconds(_delayTime);
        if (_isOneShot)
        {
            if (!_isPressed)
            {
                _isPressed = true;
                OnButtonClickEvent();
            }
        }
        else
        {
            OnButtonClickEvent();
        }
    }

    protected void OnEnable()
    {
        transform.localScale = Vector3.one;
    }

    protected virtual void OnButtonClickEvent()
    {

    }

}
