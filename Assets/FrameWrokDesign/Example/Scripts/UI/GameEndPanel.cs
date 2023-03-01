using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FrameWorkDesign.Example
{

    public class GameEndPanel : MonoBehaviour
    {

        private Button btn_EndPanel;

        private GameObject Panel_EndPanel;
        void Start()
        {
            Panel_EndPanel = this.gameObject;
            btn_EndPanel = transform.Find("BtnEnd").GetComponent<Button>();
            btn_EndPanel.onClick.AddListener(() =>
            {
              //  Panel_StartPanel.SetActive(false);
              //  Enemies.SetActive(true);
            });
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
