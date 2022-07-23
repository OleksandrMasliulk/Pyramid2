using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

public static class Extensions
{
    public static async Task<T> LoadAssetAsyncSafe<T>(this AssetReference reference)
    {
        T returnAsset = default(T);

        if (reference.IsValid())
        {
            if (!reference.IsDone)
            {
                reference.OperationHandle.Completed += (op) =>
                {
                    returnAsset = op.Convert<T>().Result;
                };
                await reference.OperationHandle.Task;
            }
            else
            {
                returnAsset = reference.OperationHandle.Convert<T>().Result;
            }
        }
        else
        {
            var op = reference.LoadAssetAsync<T>();
            op.Completed += (op) =>
            {
                returnAsset = op.Result;
            };

            await op.Task;
        }

        return returnAsset;
    }

    public static void ChangeTreeLayer(this GameObject go, int layer)
    {
        go.layer = layer;
        foreach (Transform obj in go.GetComponentsInChildren<Transform>())
        {
            obj.gameObject.layer = layer;
        }
    }
}
