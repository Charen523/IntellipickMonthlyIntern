using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

public enum eResourceType
{
    Datas,
    Animators
}

public class DataManager : Singleton<DataManager>
{
    private Dictionary<string, UnityEngine.Object> assetDic = new Dictionary<string, UnityEngine.Object>();
    public Dictionary<string, IData> dataDic = new Dictionary<string, IData>();

    protected override void Awake()
    {
        base.Awake();
        InitData();
    }

    private void InitData()
    {
        var csvFiles = Resources.LoadAll<TextAsset>(eResourceType.Datas.ToString());
        foreach (var csvFile in csvFiles)
        {
            string className = Path.GetFileNameWithoutExtension(csvFile.name);
            Type dataType = Assembly.GetExecutingAssembly().GetType(className);

            if (dataType != null)
            {
                ParseCsvToData(csvFile.text, dataType);
            }
        }
    }

    private void ParseCsvToData(string csvTxt, Type dataType)
    {
        var lines = csvTxt.Split('\n');
        
        foreach (var line in lines.Skip(1))
        {
            if (string.IsNullOrEmpty(line)) continue;

            var values = line.Split(',');
            var dataInstance = Activator.CreateInstance(dataType);

            var fields = dataType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < fields.Length; i++)
            {
                var fieldType = fields[i].FieldType;
                object value = Convert.ChangeType(values[i], fieldType);
                fields[i].SetValue(dataInstance, value);
            }

            IData data = (IData)dataInstance;
            dataDic[data.Id] = data;
        }
    }

    public T LoadAsset<T>(string key, eResourceType type) where T: UnityEngine.Object
    {
        if (assetDic.ContainsKey(key)) return (T)assetDic[key];

        string path = $"{type}/{key}";

        //TODO: Load at Start if needed.
        var asset = Resources.Load<T>(path);
        if (asset != null) assetDic.Add(key, asset);
        return asset;
    }

    public T LoadData<T>(string id) where T: IData 
    {
        return (T)dataDic[id];
    }
}