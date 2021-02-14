using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WereAllGonnaDieAnywayNew
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private bool isPaused = false;

        [SerializeField] private float startTime = 0;

        [SerializeField] private TimeData timeData;

        private void Awake()
        {
            timeData.CurrentTime = startTime;
        }

        private void Update()
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            if (isPaused)
                return;

            timeData.CurrentTime += Time.deltaTime;
        }
    }
}