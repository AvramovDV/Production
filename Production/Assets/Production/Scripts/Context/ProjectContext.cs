using System;
using System.Collections.Generic;
using UnityEngine;

namespace Avramov.Production
{
    public class ProjectContext : MonoBehaviour
    {
        [SerializeField] private MapSettings _mapSettings;
        [SerializeField] private ItemsSettings _itemsSettings;
        [SerializeField] private Assets _assets;

        private InventoryModel _inventoryModel;
        private MatchModel _matchModel;

        private static ProjectContext _instance;

        private Dictionary<Type, object> _objects = new Dictionary<Type, object>();

        public static ProjectContext Instance
        {
            get
            {
                if (_instance == null)
                    Setup();

                return _instance;
            }
        }

        private static void Setup()
        {
            _instance = Instantiate(Resources.Load<ProjectContext>("ProjectContext"));
            DontDestroyOnLoad(_instance);

            _instance._inventoryModel = new InventoryModel(_instance._itemsSettings);
            _instance._matchModel = new MatchModel(_instance._mapSettings, _instance._inventoryModel);

            _instance.Add(_instance._mapSettings);
            _instance.Add(_instance._itemsSettings);
            _instance.Add(_instance._assets);
            _instance.Add(_instance._inventoryModel);
            _instance.Add(_instance._matchModel);
        }

        private void Add<T>(T obj)
        {
            _instance._objects.Add(typeof(T), obj);
        }

        public Dictionary<Type, object> GetNewContext() => new Dictionary<Type, object>(_objects);

        public T Get<T>() => (T)_objects[typeof(T)];
    }
}
