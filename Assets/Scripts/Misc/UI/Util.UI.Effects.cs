using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Util.UI
{
    public class Effects : MonoBehaviour
    {
        public static IEnumerator glowEffect(TMP_Text textComponent, float glowSpeed)
        {

            textComponent.fontMaterial.SetFloat("_GlowPower", Mathf.PingPong(Time.time * 2, 1));
            while (textComponent.fontMaterial.GetFloat("_GlowPower") < 1)
            {
                textComponent.fontMaterial.SetFloat("_GlowPower", textComponent.fontMaterial.GetFloat("_GlowPower") + Time.deltaTime * glowSpeed);
                yield return null;
            }
            while (textComponent.fontMaterial.GetFloat("_GlowPower") > 0)
            {
                textComponent.fontMaterial.SetFloat("_GlowPower", textComponent.fontMaterial.GetFloat("_GlowPower") - Time.deltaTime * glowSpeed);
                yield return null;
            }


        }
    }

}