using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FrameWorkDesign.Example
{

    public class GameStartPanel : MonoBehaviour
    {
        private Button btn_StartPanel;
        private GameObject Panel_StartPanel;
        void Start()
        {
            Panel_StartPanel =this.gameObject;
            btn_StartPanel = transform.Find("BtnStart").GetComponent<Button>();
            btn_StartPanel.onClick.AddListener(() =>
            {
                Panel_StartPanel.SetActive(false);
                GameStartEvent.Trigger();
            });
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
