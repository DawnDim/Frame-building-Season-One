using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FrameWorkDesign.Example
{
    public class Enemy : MonoBehaviour
    {

        private static int mKilledEnemyCount = 0;


        private void OnMouseDown()
        {

            mKilledEnemyCount++;
            if (mKilledEnemyCount == 10)
            {
                GamePassEvent.Trigger();
            }
            Destroy(gameObject);
        }
    }
}
