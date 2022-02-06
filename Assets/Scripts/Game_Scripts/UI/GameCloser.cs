using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameMenus.MyButtons
{
    public class GameCloser : ButtonTemplate
    {
        public float delayTime;

        protected override void OnButtonClicked()
        {
            Time.timeScale = 1;
           // sceneDarker.SetTrigger("change scene"); 
           StartCoroutine(LeaveAfterSeconds(delayTime));
        }

        IEnumerator LeaveAfterSeconds(float time)
        {
            yield return new WaitForSeconds(time);
            sceneDarker.speed = 0;
            Application.Quit();
        }
    }
}