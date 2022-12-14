
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

namespace Polly.AR.Vuforia
{
    /// <summary>
    /// 圖片辨識管理器
    /// </summary>
    public class CardManager : MonoBehaviour
    {
        [SerializeField, Header("KID圖片")]
        private DefaultObserverEventHandler observerKID;
        [SerializeField, Header("太空人")]
        private Animator Astronaut;
        
        [SerializeField, Header("跑步按鈕")]
        private Button btnRun;

        [SerializeField, Header("走路按鈕")]
        private Button btnWalk;
        [SerializeField, Header("虛擬按鈕跳躍")]
        private VirtualButtonBehaviour vbbJump;

        private string parFloat = "觸發飄浮";
        private string parWalk = "走路";
        private string parJump = "觸發跳躍";
        private string parRun = "觸發跑步";
        
        private AudioSource audBGM;

        private void Awake()
        {
            observerKID.OnTargetFound.AddListener(CardFound);
            observerKID.OnTargetLost.AddListener(CardLost);
            btnRun.onClick.AddListener(Run);
            btnWalk.onClick.AddListener(Walk);
            vbbJump.RegisterOnButtonPressed(OnJumpPressed);
            audBGM = GameObject.Find("BGM").GetComponent<AudioSource>();

        }

        private void OnJumpPressed(VirtualButtonBehaviour obj)
        {
            print("<color=#3366dd>跳躍~</color>");
            Astronaut.SetTrigger(parJump);
        }

        /// <summary>
        /// 圖片辨識成功
        /// </summary>
        private void CardFound()
        {
            print("<color=yellow> 找到卡片</color>");
            Astronaut.SetTrigger(parFloat);
            
            audBGM.Play();
        }
        /// <summary>
        /// 圖片辨識失敗
        /// </summary>
        private void CardLost()
        {
            print("<color=pink> 卡片辨識失敗</color>");
            audBGM.Stop();
        }
        private void Run()
        {
            print("<color=#5566aa> Run~ </color>");
            Astronaut.SetTrigger(parRun);
        }
        private void Walk()
        {
            print("<color=#006666> Walk </color>");
            Astronaut.SetBool(parWalk, true);
        }

    }
    

}

