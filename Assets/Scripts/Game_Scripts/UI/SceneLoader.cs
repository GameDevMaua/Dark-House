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
            sceneDarker.SetTrigger("change scene");
            StartCoroutine(LoadAfterSeconds(delayTime));
        }

        IEnumerator LoadAfterSeconds(float time)
        {
            yield return new WaitForSeconds(time);
            sceneDarker.speed = 0;
            SceneManager.LoadScene(sceneName);
        }
    }
}