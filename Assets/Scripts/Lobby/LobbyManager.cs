using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : Singleton<LobbyManager>
{
    public List<Animator> animators = new List<Animator>();
    public Enum.LobbyPageStage LobbyPageStage = Enum.LobbyPageStage.MainmenuPage;
    public Enum.LobbyPageStage SelectionStage = Enum.LobbyPageStage.StatisticPage;
    public bool canChange = true;
    [Space(10), Header("Background"), Space(5)]
    public List<Image> Backgrounds;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0) && canChange)
        {
            canChange = false;
            animators[(int)SelectionStage].transform.SetSiblingIndex(animators[0].transform.GetSiblingIndex() - 1);
            Backgrounds[(int)LobbyPageStage - 1].gameObject.SetActive(false);
            Backgrounds[(int)SelectionStage - 1].gameObject.SetActive(true);
            animators[(int)LobbyPageStage].Play("Close");
            //StatisticPage.Instance.RunAnimation();
        }*/
    }

    public void ChangeStage(int stage)
    {
        Enum.LobbyPageStage page = Enum.LobbyPageStage.MainmenuPage; ;
        switch (stage)
        {
            case 0:
                page = Enum.LobbyPageStage.MainmenuPage;
                break;
            case 1:
                page = Enum.LobbyPageStage.StatisticPage;
                break;
        }
        if (!canChange || page == LobbyPageStage) return;
        SelectionStage = page;
        canChange = false;
        animators[(int)SelectionStage].transform.SetSiblingIndex(animators[0].transform.GetSiblingIndex() - 1);
        Backgrounds[(int)LobbyPageStage - 1].gameObject.SetActive(false);
        Backgrounds[(int)SelectionStage - 1].gameObject.SetActive(true);
        animators[(int)LobbyPageStage].Play("Close");
    }
}
