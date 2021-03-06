using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UnityStandardAssets.Utility
{
    [RequireComponent(typeof (TextMeshProUGUI))]
    public class FPSCounter : MonoBehaviour
   {

        const float fpsMeasurePeriod = 0.5f;
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
        const string display = "{0} FPS";
        private TextMeshProUGUI m_Text;

		private Color baseColor;


        private void Start()
        {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
            m_Text = GetComponent<TextMeshProUGUI>();

			baseColor = m_Text.color;
        }


        private void Update()
        {
            // measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
                m_CurrentFps = (int) (m_FpsAccumulator/fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
                m_Text.text = string.Format(display, m_CurrentFps);
				if(m_CurrentFps <= 20) {
					m_Text.color = Color.red;
				} else {
					m_Text.color = baseColor;
				}
            }
        }
    }
}
