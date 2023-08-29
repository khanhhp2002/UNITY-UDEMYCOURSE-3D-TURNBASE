using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
public class LobbyMusicManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _soundWave;
    private bool _isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<CanvasGroup>().DOKill();
        this.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<CanvasGroup>().DOKill();
        this.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
    }

    public void OnClick()
    {
        if(_isPlaying)
        {
            _isPlaying = false;
            _audioSource.DOKill();
            _audioSource.DOFade(0, 0.5f).OnComplete(() => { _audioSource.Pause(); });
            _animator.SetTrigger("Exit");
        }
        else
        {
            _isPlaying = true;
            _audioSource.DOKill();
            _audioSource.DOFade(1, 0.5f).OnComplete(() => { _audioSource.Play(); });
            _animator.Play("Play");
        }
    }

}
