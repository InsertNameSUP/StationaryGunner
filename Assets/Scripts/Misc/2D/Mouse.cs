using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util.TwoD
{
    public static class Mouse
    {
        
        /// <summary>
        /// Gets a point where the mouse is (in world pos).
        /// </summary>
        /// <returns>Returns a Vector3 where the mouse is hovering (z value is always zero)</returns>
        public static Vector3 GetMouseWorldPos()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            return mousePos;
        }

    }

}
