using System.Collections;
using UnityEngine;

namespace Utils
{
    public class Blink : MonoBehaviour
    {
        private readonly int _emissionColor = Shader.PropertyToID("_EmissionColor");

        [SerializeField] private float _effectTime = 1f;
        [SerializeField] private Renderer[] _renderers;

        public void StartBlink(int arg) => StartCoroutine(StartEffect());

        private IEnumerator StartEffect()
        {
            for (var t = _effectTime; t > 0; t -= Time.deltaTime)
            {
                var r = Mathf.Sin(t * 30) * 0.5f + 0.5f;

                foreach (var renderer in _renderers)
                {
                    foreach (var material in renderer.materials)
                    {
                        material.SetColor(_emissionColor, new Color(r, 0, 0, 0));       
                    }
                }

                yield return null;
            }
            
            ClearRenderers();
        }

        private void ClearRenderers()
        {
            foreach (var renderer in _renderers)
            {
                foreach (var material in renderer.materials)
                {
                    material.SetColor(_emissionColor, new Color(0, 0, 0, 0));       
                }
            }
        }
    }
}