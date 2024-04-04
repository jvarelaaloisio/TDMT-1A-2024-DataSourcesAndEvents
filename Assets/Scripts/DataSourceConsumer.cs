using System;
using System.Collections;
using UnityEngine;

public class DataSourceConsumer: MonoBehaviour
{
    [SerializeField] private Camera cameraReference;
    [SerializeField] private CameraSource dataSource;

    private void OnEnable()
    {
        StartCoroutine(WaitForCamera());
    }

    [ContextMenu("Look for camera through camera.main")]
    private void LookForCameraThroughCamMain()
    {
        if (Camera.main != null)
        {
            cameraReference = Camera.main;
        }
    }

    [ContextMenu("Look for camera through data source")]
    private void LookForCameraInDataSource()
    {
        if (dataSource
            && dataSource.Reference != null)
        {
            cameraReference = dataSource.Reference;
            Debug.Log($"camera ref is {cameraReference.name}");
        }
        else
            Debug.LogError($"{name}: datasource reference is {dataSource.Reference}");
    }

    private IEnumerator WaitForCamera()
    {
        if (dataSource == null)
        {
            Debug.LogError($"{name}: {nameof(dataSource)} is null!");
            yield break;
        }

        //Option 1
        yield return new WaitWhile(() => dataSource.Reference == null);
        
        //Option 2 (they are the same)
        while (dataSource.Reference != null)
        {
            //Yielding null means to only wait until the next frame.
            yield return null;
        }
        
        cameraReference = dataSource.Reference;
        Debug.Log($"camera ref is {cameraReference.name}");
    }
}