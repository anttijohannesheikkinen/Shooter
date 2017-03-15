using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Shooter.Systems.SaveLoad
{

    public class BinaryFormatterSaveLoad<T> : ISaveLoad<T>
        where T : class
    {
        public string FileExtension
        {
            get
            {
                return ".dat";
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
                byte[] data = File.ReadAllBytes(GetSaveFilePath(fileName));

                BinaryFormatter bf = new BinaryFormatter();

                //Closes the stream when stops using.
                using (MemoryStream stream = new MemoryStream(data))
                {
                    return (T)bf.Deserialize(stream);
                }
            }

            return default(T);
        }

        public void Save(T objectToSave, string fileName)
        {

            // Overwrites the existing file!!!


            BinaryFormatter bf = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();

            bf.Serialize(stream, objectToSave);

            File.WriteAllBytes(GetSaveFilePath(fileName), stream.GetBuffer());

            // Apparently don't have to do this, because stream is destroyed anyway, when not in use. Said Kojo.
            stream.Close();
        }
    }
}