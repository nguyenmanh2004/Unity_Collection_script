using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] GameObject _coinPrefab;
    [SerializeField] GameObject _coinEnableObject;
    [SerializeField] Transform _coinScaleTransform;
    [SerializeField] Transform _coinParentTransform;
    [SerializeField] Transform _coinStartTransform;
    [SerializeField] Transform _coinEndTransform;
    [SerializeField] float _moveDuration;
    [SerializeField] Ease _easeCoinEffect;
    [SerializeField] AudioClip _audioClipCoin;
    AudioSource _coinAudioSource;

    [SerializeField] Vector3 initialCoinScale = Vector3.one;
    [SerializeField] Vector3 scaleCoinScale = new Vector3(1.5f, 1.5f, 1.5f);
    [SerializeField] int coinAmount;
    [SerializeField] float coinPerDelay;

    private void Start()
    {
        _coinAudioSource = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        
        for (int i = 0; i < coinAmount; i++)
        {
            var targetDelay = i * coinPerDelay;
            ShowCoin(targetDelay);
        }
    }

    void ShowCoin(float target)
    {
        var coinObject = Instantiate(_coinPrefab, _coinParentTransform);
        var offset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
        var startPosition = _coinStartTransform.position + offset;
        coinObject.transform.position = startPosition;

        var coinScaleTask = DOTween.Sequence()
            .Append(_coinScaleTransform.DOScale(scaleCoinScale, 0.1f))
            .Append(_coinScaleTransform.DOScale(initialCoinScale, 0.25f))
            .SetEase(Ease.InOutBounce)
            .Pause();

        coinObject.transform.DOMove(_coinEndTransform.position, _moveDuration)
            .SetEase(_easeCoinEffect)
            .SetDelay(target)
            .OnComplete(() =>
            {
                coinScaleTask.Play();
                Destroy(coinObject);
                _coinAudioSource.PlayOneShot(_audioClipCoin);
                if (--coinAmount == 0)
                {
                    _coinEnableObject.SetActive(false);
                }
            });
       
    }
}