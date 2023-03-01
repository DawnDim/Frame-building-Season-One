using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkDesign
{
    public class Event<T> where T:Event<T>
    {
        private static Action mOnEvent;

        public static void Register(Action OnEvent)
        {
            mOnEvent += OnEvent;
        }

        public static void UnRegister(Action OnEvent)
        {
            mOnEvent -= OnEvent;
        }

        public static void Trigger()
        {
            mOnEvent?.Invoke();
        }
    }
}
