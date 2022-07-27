using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Polly.AR.Vuforia
{
    /// <summary>
    /// 圖片辨識管理器
    /// </summary>
    public class CardManager : MonoBehaviour
    {
        [SerializeField, Header("KID圖片")]
        private DefaultObserverEventHandler observerKID;
        private void Awake()
        {
            observerKID.OnTargetFound.AddListener(CardFound);
            observerKID.OnTargetLost.AddListener(CardLost);
        }
        /// <summary>
        /// 圖片辨識成功
        /// </summary>
        private void CardFound()
        {
            print("<color=yellow> 找到卡片<color>");
        }
        /// <summary>
        /// 圖片辨識失敗
        /// </summary>
        private void CardLost()
        {
            print("<color=yellow> 卡片辨識失敗</color>");
        }

    }
    

}

