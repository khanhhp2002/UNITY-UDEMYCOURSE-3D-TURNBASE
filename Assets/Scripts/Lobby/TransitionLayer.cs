using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Enum;

public class TransitionLayer : Singleton<TransitionLayer>
{
    [Space(10), Header("Image"), Space(5)]
    [SerializeField] private Image _topImage;
    [SerializeField] private Image _bottomImage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnAnimationEnd()
    {
        LobbyManager.Instance.Backgrounds[(int)LobbyManager.Instance.SelectionStage - 1].gameObject.SetActive(true);
        transform.SetSiblingIndex(LobbyManager.Instance.animators[(int)LobbyManager.Instance.SelectionStage].transform.GetSiblingIndex());
        _topImage.sprite = LobbyManager.Instance.Backgrounds[(int)LobbyManager.Instance.SelectionStage - 1].sprite;
        _bottomImage.sprite = LobbyManager.Instance.Backgrounds[(int)LobbyManager.Instance.SelectionStage - 1].sprite;
        LobbyManager.Instance.animators[(int)LobbyManager.Instance.LobbyPageStage].SetTrigger("Exit");
        LobbyManager.Instance.animators[0].SetTrigger("Exit");
        //Enum.LobbyPageStage temp = LobbyManager.Instance.LobbyPageStage;
        LobbyManager.Instance.LobbyPageStage = LobbyManager.Instance.SelectionStage;
        //LobbyManager.Instance.SelectionStage = temp;
        LobbyManager.Instance.canChange = true;

    }
}
