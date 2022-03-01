using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util.TwoD {
    public static class Geometry
    {
        /// <summary>
        /// Gives you a point on a circle defined by centerpoint and radius.
        /// </summary>
        /// <param name="centerPoint"> The Center point of the circle. </param>
        /// <param name="radius"> The Radius of the circle. </param>
        /// <param name="yPos"> Any y position on the circle (must be less than the radius)</param>
        /// <returns>Returns a point on the circle in world space</returns>
        public static Vector3 PositionOnCircle(Vector3 centerPoint, float radius, float yPos)
        {
            // Circle Formula : (x-h)^2 + (y-k)^2 = r^2
            // Adjusted Form: x = sqrt(r^2 - (y-k)^2) + h
            if (yPos > radius) throw new Exception();
            float x = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow((yPos) - centerPoint.x, 2) + centerPoint.y);
            return new Vector3(centerPoint.x + -x, centerPoint.y + yPos, 0);
        }
    }
}

