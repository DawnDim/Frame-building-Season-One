using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FrameWorkDesign.CounterApp
{
    /// <summary>
    /// 控制计算机脚本
    /// </summary>
    public class ConterViewController : MonoBehaviour
    {
        private void Awake()
        {
            OnCountChangeEvent.Register(OnCountChanged);
            GameObject.Find("UI").transform.Find("Canvas/Panel/Btn_Increase").GetComponent<Button>().onClick.AddListener(() =>
            {
                //交互逻辑
                CounterDataModel.Count++;
            });
            GameObject.Find("UI").transform.Find("Canvas/Panel/Btn_Reduce").GetComponent<Button>().onClick.AddListener(() =>
            {
                //交互逻辑
                CounterDataModel.Count--;
            });
            //主动调用一次
            OnCountChanged();
        }

        private void OnCountChanged()
        {
            GameObject.Find("UI").transform.Find("Canvas/Panel/Txt_Count").GetComponent<Text>().text = CounterDataModel.Count.ToString();
        }




        private void OnDisable()
        {
            OnCountChangeEvent.UnRegister(OnCountChanged);
        }
    }
}

