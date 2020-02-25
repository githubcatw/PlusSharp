using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NUDev.PlusSharp {
    public static class VectorExtension {
        /// <summary>
        /// Discards the Y value of the Vector.
        /// </summary>
        public static Vector3 discardY(this Vector3 yed) {
            return new Vector3(yed.x, 0, yed.z);
        }
    }
}