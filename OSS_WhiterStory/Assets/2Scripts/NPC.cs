using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public RectTransform uiGroup;
    public RectTransform uiGroup1;
    public RectTransform uiGroup2;
    public RectTransform uiGroup3;
    public RectTransform uiGroup4;
    public RectTransform uiGroup5;
    public Text startTalktext;
    public Animator anim;
    public GameManager manager;

    bool IsPause;

    Player enterPlayer;

    void Start()
    {
        IsPause = false;
    }

    public void Enter(Player player) //입장
    {
        enterPlayer = player;
        if (manager.stage == 2)
            startTalktext.text = "이게 누구야!! 흰둥이 아니야??";
        uiGroup.anchoredPosition = Vector3.zero;
        if (IsPause == false)
        {
            Time.timeScale = 0;
            IsPause = true;
        }
    }

    public void NpcExit() //일반 대화 퇴장
    {
        Time.timeScale = 1;
        IsPause = false;
        anim.SetTrigger("doHello");
        uiGroup.anchoredPosition = Vector3.down * 2049;
        uiGroup1.anchoredPosition = Vector3.down * 2573;
        uiGroup2.anchoredPosition = Vector3.down * 3087;
        uiGroup3.anchoredPosition = Vector3.down * 3613;
        uiGroup4.anchoredPosition = Vector3.down * 6750;
        uiGroup5.anchoredPosition = Vector3.down * 7275;
    }

    public void NpcTalk()
    {
        if(manager.stage == 1)
        {
            uiGroup.anchoredPosition = Vector3.down * 2049;
            uiGroup1.anchoredPosition = Vector3.zero;
        }
        else if(manager.stage == 2)
        {
            uiGroup.anchoredPosition = Vector3.down * 2049;
            uiGroup4.anchoredPosition = Vector3.zero;
        }
    }
    public void NpcTalk1()
    {
        uiGroup1.anchoredPosition = Vector3.down * 2573;
        uiGroup2.anchoredPosition = Vector3.zero;
    }
    public void NpcTalk2()
    {
        uiGroup2.anchoredPosition = Vector3.down * 3087;
        uiGroup3.anchoredPosition = Vector3.zero;
    }
    public void NpcTalk3()
    {
        uiGroup4.anchoredPosition = Vector3.down * 6750;
        uiGroup5.anchoredPosition = Vector3.zero;
    }
    public void GameStart()
    {
        anim.SetTrigger("doHello");
        if(manager.stage == 1)
            uiGroup3.anchoredPosition = Vector3.down * 3613;
        else if(manager.stage == 2)
            uiGroup5.anchoredPosition = Vector3.down * 7275;
        Time.timeScale = 1;
        IsPause = false;
    }
}
