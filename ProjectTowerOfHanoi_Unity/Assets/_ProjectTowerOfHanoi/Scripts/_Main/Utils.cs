using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    /// <summary>
    /// Global helper functions
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Dynamically creates a new material for every unique new disk and sets its color based on
        /// the calculated color from whichever script is calling this function and assigning its color parameter.
        /// </summary>
        /// <param name="_color"></param>
        /// <param name="_baseMaterial"></param>
        /// <returns></returns>
        public static Material SetNewMaterial(Color _color, Material _baseMaterial)
        {
            Material newMat = new Material(_baseMaterial);
            newMat.color = _color;
            return newMat;
        }

        /// <summary>
        /// Smoothly moves a gameobject (in this case usually a disk) to a target location, 
        /// usually pickup or place positions
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_speed"></param>
        /// <param name="_diskStateData"></param>
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