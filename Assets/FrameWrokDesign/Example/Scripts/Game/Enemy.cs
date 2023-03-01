using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FrameWorkDesign.Example
{
    public class Enemy : MonoBehaviour
    {

 


        private void OnMouseDown()
        {
            KillOneEnemyEvent.Trigger();
            Destroy(gameObject);
        }
    }
}
