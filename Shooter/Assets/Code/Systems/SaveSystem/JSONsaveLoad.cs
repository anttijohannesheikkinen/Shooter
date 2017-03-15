using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Systems.SaveLoad;
using System;
using System.IO;

namespace Shooter.Systems.SaveLoad
{
    public class JSONsaveLoad<T> : ISaveLoad<T>
        where T : class
    {
        public string FileExtension
        {
            get
            {
                return ".json";
            }
        }

        public bool DoesSaveExist(string fileName)
        {
            return File.Exists(GetSaveFilePath(fileName));
        }

        public string GetSaveFilePath(string fileName)
        {
            return Path.Combine(Application.persistentDataPath, fileName) + FileExtension;
        }

        public T Load(string fileName)
        {
            if (DoesSaveExist(fileName))
            {
                string jsonObject = File.ReadAllText(GetSaveFilePath(fileName), System.Text.Encoding.UTF8);
                return JsonUtility.FromJson<T>(jsonObject);
            }

            return default(T);
        }

        public void Save(T objectToSave, string fileName)
        {
            string jsonObject = JsonUtility.ToJson(objectToSave, true);
            File.WriteAllText(GetSaveFilePath(fileName), jsonObject, System.Text.Encoding.UTF8);

        }
    }
}