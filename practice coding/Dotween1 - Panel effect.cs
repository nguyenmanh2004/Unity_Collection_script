using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class UIManager : MonoBehaviour
{
    [SerializeField] private float _fadeTime = 1f;
    [SerializeField] private Ease _easeIn = Ease.OutQuad;
    [SerializeField] private Ease _easeOut = Ease.InQuad;
    [SerializeField] private Ease _easeImage = Ease.OutBack;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private RectTransform _rect;
    [SerializeField] private List<GameObject> _items = new List<GameObject>();
    [SerializeField] private AudioClip _audioPop;
    [SerializeField] private GameObject _buttonHome;
    private AudioSource _audioSourcePop;

    private void Start()
    {
        _audioSourcePop = GetComponent<AudioSource>();
    }

    public void PanelFadeIn()
    {
        _buttonHome.SetActive(false);
        _canvasGroup.alpha = 0f;
        _rect.localPosition = new Vector3(0f, -1000f, 0f);
        _rect.DOAnchorPos(new Vector2(0f, 0f), _fadeTime, false).SetEase(_easeIn);
        _canvasGroup.DOFade(1, _fadeTime);
        StartCoroutine(ItemAnimation());
    }

    public void PanelFadeOut()
    {
        _buttonHome.SetActive(true);
        _canvasGroup.alpha = 1f;
        _rect.localPosition = new Vector3(0f, 0f, 0f);
        _rect.DOAnchorPos(new Vector2(0f, -1000f), _fadeTime, false).SetEase(_easeOut);
        _canvasGroup.DOFade(0, _fadeTime);
    }

    private IEnumerator ItemAnimation()
    {
        foreach (var item in _items)
        {
            item.transform.localScale = Vector3.zero;
        }

        foreach (var item in _items)
        {
            _audioSourcePop.PlayOneShot(_audioPop);
            item.transform.DOScale(1f, _fadeTime).SetEase(_easeImage);
            yield return new WaitForSeconds(0.25f);
        }
    }
}