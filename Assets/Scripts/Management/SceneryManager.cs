using System;
using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Management
{
    public class SceneryManager : MonoBehaviour
    {
        [SerializeField] private SceneryLoadId[] loadIds;
        
        private void OnEnable()
        {
            if (EventManager<IId>.Instance)
            {
                foreach (var loadId in loadIds)
                {
                    if (loadId == null)
                        continue;
                    EventManager<IId>.Instance.SubscribeToEvent(loadId, HandleLoadScenery);
                }
            }
        }

        private void HandleLoadScenery(IId loadId)
        {
            if (loadId is SceneryLoadId)
            {
                var sceneryLoadId = loadId as SceneryLoadId;
                LoadScenery(sceneryLoadId.SceneIndexes);
            }
        }

        public void LoadScenery(int[] sceneIndexes)
        {
            foreach (var sceneIndex in sceneIndexes)
            {
                SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
            }
        }
    }
}
