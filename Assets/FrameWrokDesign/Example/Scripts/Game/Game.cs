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
            //开始事件
            GameStartEvent.Register(OnGameStart);
            //击杀事件
            KillOneEnemyEvent.Register(OnGamePass);
        }

        private void OnGamePass()
        {
            //添加击杀数
            GameModel.KilledCount++;
            //判断是否达成结束条件
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
