using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public static class Utils
    {
        public static bool IsMoving = false;

        public static Material SetNewMaterial(Color _color, Material _baseMaterial)
        {
            Material newMat = new Material(_baseMaterial);
            newMat.color = _color;
            return newMat;
        }

        public static void SmoothMove(SmoothMoveData _data, float _speed)
        {
            _data.ToMove.StartCoroutine(_BeginSmoothMove(_data, _speed));
        }

        private static IEnumerator _BeginSmoothMove(SmoothMoveData _data, float _speed)
        {
            DelegateManager.onHeldDiskMove?.Invoke(true);
            int i = 0;
            while (i < _data.Destinations.Count)
            {
                _data.ToMove.transform.position = Vector3.MoveTowards(_data.ToMove.transform.position, _data.Destinations[i], Time.deltaTime * _speed * _data.Destinations.Count);
                yield return null;
                if (Vector3.Distance(_data.ToMove.transform.position, _data.Destinations[i]) < 0.01f)
                    i++;
            }
            DelegateManager.onHeldDiskMove?.Invoke(false);
        }
    }
}