using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public static class Utils
    {
        public static Material SetNewMaterial(Color _color, Material _baseMaterial)
        {
            Material newMat = new Material(_baseMaterial);
            newMat.color = _color;
            return newMat;
        }

        public static void SmoothMove(SmoothMoveData _data, float _speed, SO_StateData _diskStateData)
        {
            _data.ToMove.StartCoroutine(_BeginSmoothMove(_data, _speed, _diskStateData));
        }

        private static IEnumerator _BeginSmoothMove(SmoothMoveData _data, float _speed, SO_StateData _diskState)
        {
            int i = 0;
            while (i < _data.Destinations.Count)
            {
                _data.ToMove.transform.position = Vector3.MoveTowards(_data.ToMove.transform.position, _data.Destinations[i], Time.deltaTime * _speed * _data.Destinations.Count);
                yield return null;
                if (Vector3.Distance(_data.ToMove.transform.position, _data.Destinations[i]) < 0.01f)
                    i++;
            }
            DelegateManager.onDiskStateChanged?.Invoke(_diskState);
        }
    }
}