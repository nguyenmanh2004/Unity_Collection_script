using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Example : MonoBehaviour
{
    private AsyncOperationHandle<GameObject> handle;
    private AsyncOperationHandle<Sprite> handle1;
    private AsyncOperationHandle handle2;
    private GameObject clone; // Tham chiếu đến đối tượng đã tạo
    private GameObject clone1;
    [SerializeField] SpriteRenderer SpriteRenderer;
    [SerializeField] AssetReference obj;
    [SerializeField] AssetReference obj1;
    [SerializeField] AssetReference Scene;
    [SerializeField] AssetLabelReference label;
    [SerializeField] Transform testtf;
    public List<GameObject> spawnedObjects = new List<GameObject>();
    private void Start()
    {
        LoadPrefabAsyncWithAddress("Assets/food (1) 1.prefab", testtf);
    }
    void Update()
    {
        switch (true)
        {
            case var _ when Input.GetKeyDown(KeyCode.Alpha0):
                LoadSpawn();
                break;

            case var _ when Input.GetKeyDown(KeyCode.Backspace):

                foreach (GameObject obj in spawnedObjects)
                {
                    Destroy(obj); // Hủy từng đối tượng
                }
                spawnedObjects.Clear(); // Xóa danh sách để tránh tham chiếu cũ
                Addressables.Release(handle); // Giải phóng tài nguyên
                
                break;

            case var _ when Input.GetKeyDown(KeyCode.Alpha1):
                LoadSpawn1();
                break;

            case var _ when Input.GetKeyDown(KeyCode.Alpha2):

                if (obj.IsValid())
                {
                    Addressables.Release(obj); // Giải phóng tài nguyên sử dụng handle
                    obj = default; // Đặt lại handle
                }
                SpriteRenderer.sprite = null;
                break;

            case var _ when Input.GetKeyDown(KeyCode.Alpha3):
                LoadSpawn3();
                break;
            case var _ when Input.GetKeyDown(KeyCode.D):
                SpawnScene();
                break;

            default:
                // Handle other keys or do nothing
                break;
        }
      
    }

    void LoadSpawn()
    {
       handle = Addressables.LoadAssetAsync<GameObject>("Assets/food (1) 1.prefab"); // Đảm bảo địa chỉ chính xác
        handle.Completed += Handle_Completed1;
    }

    private void Handle_Completed1(AsyncOperationHandle<GameObject> obj)
    {
        GameObject newObject = Instantiate(obj.Result);
        spawnedObjects.Add(newObject);
    }

    void LoadSpawn2()
    {
       var handle1 = Addressables.LoadAssetsAsync<GameObject>(label, (GameObject result) => 
        {
            GameObject instance = result.gameObject;
            GameObject clone1 = Instantiate(instance);
            clone.transform.position = Vector3.zero;
            
        });
    }
    private async void LoadSpawn3()
    {
        handle2 = Addressables.InstantiateAsync(obj1);
        await handle2.Task; // Chờ cho tác vụ hoàn thành

        handle2.Completed += task =>
        {
            if (task.Status == AsyncOperationStatus.Succeeded)
            {
                // Gán kết quả cho clone nếu tải thành công
                clone1 = (GameObject)task.Result;
                Instantiate(clone1);
            }
            else
            {
                // Xử lý lỗi nếu tải không thành công
                Debug.LogError("Failed to load prefab.");
            }

        };
        Addressables.Release(handle2);
    }
    void LoadSpawn1()
    {
        handle1 = Addressables.LoadAssetAsync<Sprite>(obj); // Đảm bảo địa chỉ chính xác
        handle1.Completed += Handle1_Completed;
    }

    private void Handle1_Completed(AsyncOperationHandle<Sprite> obj)
    {
        SpriteRenderer.sprite=obj.Result;
    }
    void SpawnScene()
    {
        Addressables.LoadSceneAsync(Scene);
    }
    private async void LoadPrefabAsyncWithAddress(string assetAddress, Transform Parent)
    {
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(assetAddress);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject prefab = handle.Result;
            GameObject exampleObject = Instantiate(prefab);
            
            // Đối tượng exampleObject vẫn tồn tại trong scene
        }

        // Giải phóng tài nguyên prefab đã tải
        Addressables.Release(handle);
    }
}