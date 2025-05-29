using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game.Sripts
{
    public class LoadManager : MonoBehaviour
    {
        [SerializeField]
        private string nextSceneName;
        private void OnEnable() 
        {
            EventBus.Instance.LevelRestarting += ReloadCurrentLevel; 
            EventBus.Instance.NextLevelStarting += LoadNextScene; 
        }
        private void OnDisable()
        {
            EventBus.Instance.LevelRestarting -= ReloadCurrentLevel;
            EventBus.Instance.NextLevelStarting -= LoadNextScene;
        }
        private void ReloadCurrentLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }

        public void LoadNextScene()
        {
            if (!string.IsNullOrEmpty(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.LogWarning("Next scene name is not set.");
            }
        }

    }
}
