using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StatisticPage : Singleton<StatisticPage>
{
    [Space(10), Header("Component"), Space(5)]
    [SerializeField] private Transform _recentMatch;
    [SerializeField] private Transform _sessions;
    [SerializeField] private Transform _rank;
    [SerializeField] private Transform _overView;
    [SerializeField] private Transform _topPerformance;

    [Space(10), Header("Background"), Space(5)]
    public Image _backGround;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RunAnimation()
    {
        _rank.transform.DOMoveY(0, 0.4f).SetEase(Ease.InQuad);
        this.GetComponent<CanvasGroup>().DOFade(0, 0.55f);
    }

    public void OnAnimationEnd()
    {
        this.transform.SetAsFirstSibling();
        LobbyManager.Instance.animators[0].Play("Transition");
    }
}
