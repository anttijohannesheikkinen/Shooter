namespace Shooter.Systems.SaveLoad
{
    public interface ISaveLoad <T>
        where T : class
    {

        string FileExtension { get; }

        string GetSaveFilePath(string fileName);

        void Save(T objectToSave, string fileName);
        T Load(string fileName);
        bool DoesSaveExist(string fileName);
    }
}