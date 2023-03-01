using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkDesign.Example
{

    public class Game : MonoBehaviour
    {
        private void Awake()
        {
            //��ʼ�¼�
            GameStartEvent.Register(OnGameStart);
            //��ɱ�¼�
            KillOneEnemyEvent.Register(OnGamePass);
        }

        private void OnGamePass()
        {
            //��ӻ�ɱ��
            GameModel.KilledCount++;
            //�ж��Ƿ��ɽ�������
            if (GameModel.KilledCount == 10)
            {
                GamePassEvent.Trigger();
            }
        }

        private void OnGameStart()
        {
            transform.Find("Enemies").gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            GameStartEvent.UnRegister(OnGameStart);
            KillOneEnemyEvent.UnRegister(OnGamePass);

        }
    }
}
