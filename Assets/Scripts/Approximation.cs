using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Approx
{
    public static class Approximation
    {
        /// <summary>
        /// When checking if two vectors are "==" in conditions, the approximation is too thin by default, so I made an approximation function
        /// </summary>

        public static bool VectorsEqual(Vector3 firstVec, Vector3 secondVec, float delta)
        {
            return (Mathf.Abs(firstVec.x - secondVec.x) < delta 
                && Mathf.Abs(firstVec.y - secondVec.y) < delta 
                && Mathf.Abs(firstVec.z - secondVec.z) < delta);
        }
    }

}
