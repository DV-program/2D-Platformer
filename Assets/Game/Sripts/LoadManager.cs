using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game.Sripts
{
    public class LoadManager : MonoBehaviour
    {
        private void OnEnable() => EventBus.Instance.LevelRestarting += ReloadCurrentLevel;
        private void OnDisable() => EventBus.Instance.LevelRestarting -= ReloadCurrentLevel;
        private void ReloadCurrentLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
