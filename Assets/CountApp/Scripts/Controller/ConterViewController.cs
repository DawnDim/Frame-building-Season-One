using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FrameWorkDesign.CounterApp
{
    /// <summary>
    /// ���Ƽ�����ű�
    /// </summary>
    public class ConterViewController : MonoBehaviour
    {
        private void Awake()
        {
            OnCountChangeEvent.Register(OnCountChanged);
            GameObject.Find("UI").transform.Find("Canvas/Panel/Btn_Increase").GetComponent<Button>().onClick.AddListener(() =>
            {
                //�����߼�
                CounterDataModel.Count++;
            });
            GameObject.Find("UI").transform.Find("Canvas/Panel/Btn_Reduce").GetComponent<Button>().onClick.AddListener(() =>
            {
                //�����߼�
                CounterDataModel.Count--;
            });
            //��������һ��
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

