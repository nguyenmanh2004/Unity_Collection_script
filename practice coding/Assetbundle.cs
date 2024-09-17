using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Assetbundle_test : MonoBehaviour
{
    private AssetBundle loadedAssetBundle;
    void Start()
    {
        LoadBundle();
    }
    void LoadBundle()
    {
        string bundlePath = "Assets/StreamingAssets/bg";
        loadedAssetBundle = AssetBundle.LoadFromFile(bundlePath);

        if (loadedAssetBundle != null)
        {
            GameObject prefab = loadedAssetBundle.LoadAsset<GameObject>("food (1) 1.prefab");
            Instantiate(prefab);
        }
    }
    void OnDestroy()
    {
        if (loadedAssetBundle != null)
        {
            loadedAssetBundle.Unload(false);
        }
    }
}
