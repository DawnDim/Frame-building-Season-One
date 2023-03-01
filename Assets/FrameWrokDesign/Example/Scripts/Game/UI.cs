using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkDesign.Example
{

    public class UI : MonoBehaviour
    {
        private void Awake()
        {
            GamePassEvent.Register(OnGameEnd);
        }

        private void OnGameEnd()
        {
            transform.Find("Canvas/GamePasstPanel").gameObject.SetActive(true);
        }


        private void OnDestroy()
        {
            GamePassEvent.UnRegister(OnGameEnd);

        }
    }
}
