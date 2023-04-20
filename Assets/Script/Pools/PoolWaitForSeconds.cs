using System.Collections.Generic;
using UnityEngine;

namespace Script.Pools
{
    public static class PoolWaitForSeconds
    {
        private class WaitForSeconds : CustomYieldInstruction
        {
            private float _waitUntil;

            public override bool keepWaiting
            {
                get
                {
                    if (Time.time < _waitUntil)
                        return true;

                    Pool(this);
                    return false;
                }
            }

            public void Initialize(float seconds)
            {
                _waitUntil = Time.time + seconds;
            }
        }

        private class WaitForSecondsRealtime : CustomYieldInstruction
        {
            private float _waitUntil;

            public override bool keepWaiting
            {
                get
                {
                    if (Time.realtimeSinceStartup < _waitUntil)
                        return true;

                    Pool(this);
                    return false;
                }
            }

            public void Initialize(float seconds)
            {
                _waitUntil = Time.realtimeSinceStartup + seconds;
            }
        }

        private const int PoolInitialSize = 4;

        private static readonly Stack<WaitForSeconds> WaitForSecondsPool;
        private static readonly Stack<WaitForSecondsRealtime> WaitForSecondsRealtimePool;

        static PoolWaitForSeconds()
        {
            WaitForSecondsPool = new Stack<WaitForSeconds>(PoolInitialSize);
            WaitForSecondsRealtimePool = new Stack<WaitForSecondsRealtime>(PoolInitialSize);

            for (int i = 0; i < PoolInitialSize; i++)
            {
                WaitForSecondsPool.Push(new WaitForSeconds());
                WaitForSecondsRealtimePool.Push(new WaitForSecondsRealtime());
            }
        }

        public static CustomYieldInstruction Wait(float seconds)
        {
            WaitForSeconds instance;
            if (WaitForSecondsPool.Count > 0)
                instance = WaitForSecondsPool.Pop();
            else
                instance = new WaitForSeconds();

            instance.Initialize(seconds);
            return instance;
        }

        public static CustomYieldInstruction WaitRealtime(float seconds)
        {
            WaitForSecondsRealtime instance;
            if (WaitForSecondsRealtimePool.Count > 0)
                instance = WaitForSecondsRealtimePool.Pop();
            else
                instance = new WaitForSecondsRealtime();

            instance.Initialize(seconds);
            return instance;
        }

        private static void Pool(WaitForSeconds instance)
        {
            WaitForSecondsPool.Push(instance);
        }

        private static void Pool(WaitForSecondsRealtime instance)
        {
            WaitForSecondsRealtimePool.Push(instance);
        }
    }
}