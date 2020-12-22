using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts.Controllers
{
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField] private Image _loadSceneImage;

        public void Start()
        {
            LoadedScene();
        }

        public async Task LoadGameScene()
        {
            _loadSceneImage.raycastTarget = true;
            await _loadSceneImage.DOFade(1, 1f).AsyncWaitForCompletion();
            SceneManager.LoadScene("GameScene");
        }

        public async Task LoadStartScene()
        {
            _loadSceneImage.raycastTarget = true;
            await _loadSceneImage.DOFade(1, 1f).AsyncWaitForCompletion();
            SceneManager.LoadScene("StartScene");
        }

        private void LoadedScene()
        {
            _loadSceneImage.raycastTarget = false;
            _loadSceneImage.DOFade(0, .5f);
        }
    }
}
