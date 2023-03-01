using System;
namespace FrameWorkDesign.CounterApp
{
    /// <summary>
    /// 计算机数据
    /// </summary>
    public class CounterDataModel
    {
        private static int mCount = 0;


        public static int Count
        {
            get => mCount;
            set
            {
                if (value != mCount)
                {
                    mCount = value;
                    OnCountChangeEvent.Trigger();
                }
            }
        }
    }
}

