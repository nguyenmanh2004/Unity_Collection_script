using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameAction.Manager
{
    public class mapmanager : MonoBehaviour
    {
        public static mapmanager Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public List<GameObject> maps;
        public List<string> namemaps;
        public string currentMapName;
        private void Start()
        {
            // Bật/tắt tất cả các map mặc định
            ActivateAllMaps(false);
            ActivateMapByName(namemaps[1]);
        }

        public void ActivateMapByName(string mapName)
        {
            // Tìm GameObject với tên mapName trong list maps
            GameObject targetMap = maps.Find(map => map.name == mapName);

            if (targetMap != null)
            {
                // Bật GameObject đã tìm thấy
                targetMap.SetActive(true);
                currentMapName = mapName;
            }
            else
            {
                Debug.LogWarning($"Không tìm thấy GameObject với tên '{mapName}' trong danh sách maps.");
            }
        }
        private void ActivateAllMaps(bool state)
        {
            foreach (GameObject map in maps)
            {
                map.SetActive(state);
            }
        }
        public void DeactivateMapByName(string mapName)
        {
            // Tìm GameObject với tên mapName trong list maps
            GameObject targetMap = maps.Find(map => map.name == mapName);

            if (targetMap != null)
            {
                // Tắt GameObject đã tìm thấy
                targetMap.SetActive(false);
            }
            else
            {
                Debug.LogWarning($"Không tìm thấy GameObject với tên '{mapName}' trong danh sách maps.");
            }
        }
    }
}