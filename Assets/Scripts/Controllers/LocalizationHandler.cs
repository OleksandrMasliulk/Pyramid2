using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LocalizationHandler : MonoBehaviour
{
    public static LocalizationHandler Instance { get; private set; }

    public enum Tables
    {
        BUTTONS,
        SETTINGS,
        TOOLTIPS,
        NPCs
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    public AsyncOperationHandle<string> GetLocalizedTextAsync(Tables table, string key)
    {
        string tableName = GetTableName(table);

        var op = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(tableName, key);
        op.Completed += (op) =>
        {
            Debug.LogWarning($"{tableName}/{key}: {op.Result}");
        };

        return op;
    }
    
    public AsyncOperationHandle<string> GetLocalizedTextAsync(LocalizedString reference)
    {
        var op = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(reference.TableReference, reference.TableEntryReference);
        op.Completed += (op) =>
        {
            Debug.LogWarning($"{reference.TableReference}/{reference.TableEntryReference}: {op.Result}");
        };

        return op;
    }

    //public string GetTextLocalized(Tables table, string key)
    //{
    //    string tableName = GetTableName(table);
    //    if (tableName == null)
    //    {
    //        Debug.Log("Invalid table!");
    //        return null;
    //    }

    //    //var op = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(tableName, key);
    //    return LocalizationSettings.StringDatabase.GetLocalizedString(tableName, key);
    //    //if (op.IsDone)
    //    //{
    //    //    return op.Result;
    //    //}
    //    //else
    //    //{
    //    //    op.Completed += (op) => Debug.Log(op.Result);
    //    //}
    //}

    //public string GetTextLocalized(LocalizedString reference)
    //{
    //    return LocalizationSettings.StringDatabase.GetLocalizedString(reference.TableReference, reference.TableEntryReference);
    //}

    private string GetTableName(Tables table)
    {
        switch(table)
        {
            case Tables.BUTTONS:
                return "UIButtons";
            case Tables.SETTINGS:
                return "SettingsWindow";
            case Tables.TOOLTIPS:
                return "Tooltips";
            case Tables.NPCs:
                return "NPCNames";
            default:
                return null;
        }
    }

    public void SetLocale(int locale)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[locale];
    }

    public AsyncOperationHandle InitLocales()
    {
        var op = LocalizationSettings.InitializationOperation;
        return op;
    }
}
