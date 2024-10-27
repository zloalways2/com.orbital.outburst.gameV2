using UnityEngine;

namespace OOG
{
    public class OOGRipple : MonoBehaviour
    {
        [SerializeField] private Material _rippleMaterial;
        [SerializeField] private float _maxAmount = 50f;

        [Range(0, 1)] [SerializeField] private float _friction;

        private float _OOGamount;
        private static readonly int OOGCenterY = Shader.PropertyToID("_CenterY");
        private static readonly int OOGCenterX = Shader.PropertyToID("_CenterX");
        private static readonly int OOGAmount = Shader.PropertyToID("_Amount");

        private void Update()
        {
            _rippleMaterial.SetFloat(OOGAmount, _OOGamount);
            _OOGamount *= _friction;
        }

        public void OOGRippleEffect(Vector2 position)
        {
            _OOGamount = _maxAmount;
            _rippleMaterial.SetFloat(OOGCenterX, position.x);
            _rippleMaterial.SetFloat(OOGCenterY, position.y);
        }

        void OnRenderImage(RenderTexture src, RenderTexture dst)
        {
            Graphics.Blit(src, dst, _rippleMaterial);
        }
    }
}