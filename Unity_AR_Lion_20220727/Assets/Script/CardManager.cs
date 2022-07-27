
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

namespace Polly.AR.Vuforia
{
    /// <summary>
    /// �Ϥ����Ѻ޲z��
    /// </summary>
    public class CardManager : MonoBehaviour
    {
        [SerializeField, Header("KID�Ϥ�")]
        private DefaultObserverEventHandler observerKID;
        [SerializeField, Header("�ӪŤH")]
        private Animator Astronaut;
        
        [SerializeField, Header("�]�B���s")]
        private Button btnRun;
        [SerializeField, Header("�������s���D")]
        private VirtualButtonBehaviour vbbJump;

        private string parFloat = "Ĳ�o�ƯB";
        private string parWalk = "����";
        private AudioSource audBGM;

        private void Awake()
        {
            observerKID.OnTargetFound.AddListener(CardFound);
            observerKID.OnTargetLost.AddListener(CardLost);
            btnRun.onClick.AddListener(Run);
            vbbJump.RegisterOnButtonPressed(OnJumpPressed);
            audBGM = GameObject.Find("BGM").GetComponent<AudioSource>();
        }

        private void OnJumpPressed(VirtualButtonBehaviour obj)
        {
            print("<color=#3366dd>���D~</color>");
        }

        /// <summary>
        /// �Ϥ����Ѧ��\
        /// </summary>
        private void CardFound()
        {
            print("<color=yellow> ���d��</color>");
            Astronaut.SetTrigger(parFloat);
            Astronaut.SetBool(parWalk, true);
            audBGM.Play();
        }
        /// <summary>
        /// �Ϥ����ѥ���
        /// </summary>
        private void CardLost()
        {
            print("<color=pink> �d�����ѥ���</color>");
            audBGM.Stop();
        }
        private void Run()
        {
            print("<color=#5566aa>Run~</color>");
        }

    }
    

}

