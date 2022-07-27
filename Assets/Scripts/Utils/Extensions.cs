using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using TMPro;

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

    public static async void SetOptionsLocalized(this TMP_Dropdown dropdown, LocalizationHandler.Tables localizationTable, List<string> optionsKeys)
    {
        List<Task> dropdownsLocalizationTasks = new List<Task>();
        List<string> newQualityOptions = new List<string>();

        dropdown.ClearOptions();
        for (int i = 0; i < optionsKeys.Count; i++)
        {
            var op = LocalizationHandler.Instance.GetLocalizedTextAsync(localizationTable, optionsKeys[i]);
            op.Completed += (op) => newQualityOptions.Add(op.Result);
            dropdownsLocalizationTasks.Add(op.Task);
        }

        await Task.WhenAll(dropdownsLocalizationTasks);
        dropdown.AddOptions(newQualityOptions);
        dropdown.RefreshShownValue();
    }
}
