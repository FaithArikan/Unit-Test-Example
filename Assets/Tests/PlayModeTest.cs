using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Test
{
    public class PlayModeTest : MonoBehaviour
    {
        [UnityTest]
        [UnityPlatform(RuntimePlatform.WindowsEditor)]
        public IEnumerator IsThisSceneMainSceneCheck()
        {
            // FIRSTLY OPENS THE MAIN SCENE
            string mainScene = "MainScene";
            SceneManager.LoadSceneAsync(mainScene, LoadSceneMode.Single);
            
            yield return new WaitUntil(() => SceneManager.GetActiveScene().name == mainScene);
            Assert.AreEqual(SceneManager.GetActiveScene().name, mainScene);
        }

        [UnityTest]
        public IEnumerator IsThisSceneUISceneCheck()
        {
            // SECONDLY OPENS THE UISCENE
            string uiScene = "UIScene";
            SceneManager.LoadSceneAsync(uiScene, LoadSceneMode.Single).completed += SetAllActionsOnUISceneLoaded;
            yield return new WaitUntil(() => SceneManager.GetActiveScene().name == uiScene);
        }
        private void SetAllActionsOnUISceneLoaded(AsyncOperation async)
        {
            // IN UISCENE CHECKS THE OBJECTS AND SCRIPTS
            CheckTheSceneToUISceneChange();
            CalculateButtonCountOnSceneLoaded();
            IsShop();
        }
        private void CheckTheSceneToUISceneChange()
        {
            Assert.AreEqual(SceneManager.GetActiveScene().name, "UIScene");
        }
        private void CalculateButtonCountOnSceneLoaded()
        {
            Button[] buttonObjects = FindObjectsOfType<Button>();
            
            foreach (var button in buttonObjects)
            {
                button.onClick.Invoke();
            }
            Assert.AreEqual(3, buttonObjects.Length);
        }

        #region StringToInt

        private static int StringToInt(string value)
        {
            int result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                char letter = value[i];
                result = 10 * result + (letter - 48);
            }
            return result;
        }


        #endregion
        private void IsShop()
        {
            ShopController shopController = FindObjectOfType<ShopController>();
            
            //IS GOLD AMOUNT IS EXPECTED
            Assert.AreEqual(shopController.goldAmount, 35);
            
            //IS TEXT EXPECTED
            int txtInt = StringToInt(shopController.mainTxt.text);
            Assert.AreEqual(txtInt, 35);
            Debug.Log("txtInt is" + txtInt);
        }

        [UnityTest]
        public IEnumerator IsTimerEnded()
        {
            Timer timer = FindObjectOfType<Timer>();
            yield return new WaitUntil(() => timer.timeRemaining == 0);

            Assert.AreEqual(timer.timeRemaining, 0);
        }
    }
}
