using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameMenus
{
    public class SceneLoader : ButtonTemplate
    {
        [SerializeField]
        public string sceneName;
        
        public float delayTime;
        protected override void OnButtonClicked()
        {
            Time.timeScale = 1;
            sceneDarker.SetTrigger("change scene");
            StartCoroutine(LoadAfterSeconds(delayTime));
        }

        IEnumerator LoadAfterSeconds(float time)
        {
            yield return new WaitForSeconds(time);
            Load();
        }

        public void Load()
        {
            sceneDarker.speed = 0;
            SceneManager.LoadScene(sceneName);
        }
    }
}