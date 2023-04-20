using System.Collections;
using Script.Pools;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Script.Managers
{
    public class SceneManager : MonoBehaviour
    {
        public void LoadScene(string scenePath)
        {
            StartCoroutine(LoadSceneRoutine(scenePath));
        }

        private IEnumerator LoadSceneRoutine(string scenePath)
        {
            var asyncLoad = Addressables.LoadSceneAsync(scenePath, LoadSceneMode.Single, false);
            while (!asyncLoad.IsDone)
            {
                yield return null;
            }

            yield return PoolWaitForSeconds.Wait(0.5f);
            asyncLoad.Result.ActivateAsync();
        }
    }
}