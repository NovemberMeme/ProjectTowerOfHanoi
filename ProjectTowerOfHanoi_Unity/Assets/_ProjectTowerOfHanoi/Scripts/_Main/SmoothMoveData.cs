using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    /// <summary>
    /// Pure c# class to simplify parameters for smooth move functions
    /// </summary>
    public class SmoothMoveData
    {
        public Disk ToMove;
        public List<Vector3> Destinations = new List<Vector3>();

        public SmoothMoveData(Disk _toMove, List<Vector3> _destinations)
        {
            ToMove = _toMove;
            Destinations = _destinations;
        }
    }
}