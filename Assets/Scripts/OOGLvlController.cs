using UnityEngine;
using UnityEngine.UI;

namespace OOG
{
    public class OOGLvlController : MonoBehaviour
    {
        [SerializeField] private OOGUILvlItem[] _oogLvlItems;

        [SerializeField] private Button _oogLeft;
        [SerializeField] private Button _oogRight;
        
        private int _oogStartLvl;

        private void Start()
        {
            OOGFill();
            
            _oogRight.onClick.AddListener(OGGRight);
            _oogLeft.onClick.AddListener(OGGLeft);
        }
        
        private void OGGRight()
        {
            _oogStartLvl += 9;
            _oogStartLvl = Mathf.Clamp(_oogStartLvl, 0, int.MaxValue);
            OOGFill();
        }

        private void OOGFill()
        {
            var pass = PlayerPrefs.GetInt(OGGULTIMA.OOGPassLvlKey, 1);
            
            var oogIndex = _oogStartLvl + 1;
            foreach (var lvlItem in _oogLvlItems)
            {
                lvlItem.OOGInit(oogIndex, pass >= oogIndex);
                oogIndex++;
            }
        }
        
                    
        private void OGGLeft()
        {
            _oogStartLvl -= 9;
            _oogStartLvl = Mathf.Clamp(_oogStartLvl, 0, int.MaxValue);
            OOGFill();
        }
    }
}