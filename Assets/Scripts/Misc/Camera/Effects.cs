using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util.Effects.Camera {
    public static class CameraShake
    {
        public static bool isShaking = false;
        /// <summary>
        /// Shakes the camera for sexy effect
        /// </summary>
        /// <param name="camera">Camera to shake</param>
        /// <param name="duration">Duration of shake</param>
        /// <param name="magnitude">How violent the shaking is</param>
        /// <param name="shakeFadeTime">How quickly the shaking slows</param>
        /// <returns></returns>
        public static IEnumerator Shake(Transform camera, float duration, float magnitude)
        {
            isShaking = true;
            Vector3 originalPos = camera.localPosition;
            float elasped = 0.0f;
            while (elasped < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                camera.localPosition = new Vector3(x, y, originalPos.z);
                elasped += Time.deltaTime;
                magnitude = Mathf.MoveTowards(magnitude, 0f, magnitude / duration * Time.deltaTime);
                yield return null;
            }
            isShaking = false;
            camera.localPosition = originalPos;
        }
    }
}

