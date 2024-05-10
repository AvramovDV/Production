using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.Production
{
    public class ScreensManager : MonoBehaviour
    {
        [SerializeField] private List<BaseScreen> _screens;
        [SerializeField] private Transform _screensParentTransform;

        private Dictionary<Type, BaseScreen> _screensPool = new Dictionary<Type, BaseScreen>();

        public T GetScreen<T>() where T : BaseScreen
        {
            if (!_screensPool.ContainsKey(typeof(T)))
                CreateScreen<T>();

            return (T)_screensPool[typeof(T)];
        }

        private void CreateScreen<T>() where T : BaseScreen
        {
            T screenPrefab = (T)_screens.Find(x => x is T);

            if (screenPrefab == null)
                Debug.Log($"Screen {typeof(T)} not found");

            T screen = Instantiate(screenPrefab, _screensParentTransform);
            screen.SetActive(false);
            _screensPool.Add(typeof(T), screen);
        }
    }
}
