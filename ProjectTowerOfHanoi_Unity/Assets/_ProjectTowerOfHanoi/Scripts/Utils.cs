using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public static class Utils
    {
        public static bool IsMoving = false;

        public static void SmoothMove(SmoothMoveData _data, float _speed)
        {
            _data.ToMove.StartCoroutine(_BeginSmoothMove(_data, _speed));
        }

        private static IEnumerator _BeginSmoothMove(SmoothMoveData _data, float _speed)
        {
            IsMoving = true;
            int i = 0;
            while (i < _data.Destinations.Count)
            {
                _data.ToMove.transform.position = Vector3.MoveTowards(_data.ToMove.transform.position, _data.Destinations[i], Time.deltaTime * _speed * _data.Destinations.Count);
                yield return null;
                if (Vector3.Distance(_data.ToMove.transform.position, _data.Destinations[i]) < 0.1f)
                    i++;
            }
            IsMoving = false;
        }
    }
}