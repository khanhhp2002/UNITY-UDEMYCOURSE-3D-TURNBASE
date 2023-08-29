using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainmenuPage : Singleton<MainmenuPage>
{
    [Space(10), Header("Component"), Space(5)]
    [SerializeField] private TMP_Text _chaperNumber;
    [SerializeField] private TMP_Text _partNumber;
    // Start is called before the first frame update
    void Start()
    {
        InitProgress();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            InitProgress();
        }
    }

    private void InitProgress()
    {
        NumberCounter.Instance.CountAnimation(_chaperNumber, 0, 7);
        NumberCounter.Instance.CountAnimation(_partNumber, 0, 13);
    }
    public void OnAnimationEnd()
    {
        this.transform.SetAsFirstSibling();
        LobbyManager.Instance.animators[0].Play("Transition");
    }
}
