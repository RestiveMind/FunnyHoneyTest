using System.IO;
using System.Xml.Serialization;
using Core.Annotations;

namespace Core.Service
{
    /// <summary>
    ///     Help to save object on disk or load it.
    /// </summary>
    public static class CacheHelper
    {
        /// <summary>
        ///     Save object to disk.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSave"></param>
        /// <param name="fileName"></param>
        public static void Save<T>(T objectToSave, [NotNull] string fileName)
        {
            CreateDirectoryIfNotExist(fileName);

            using (var writer = new StreamWriter(fileName))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, objectToSave);
                writer.Flush();
            }
        }

        /// <summary>
        ///     Load object from disk
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T Load<T>(string fileName) where T : class
        {
            using (var stream = File.OpenRead(fileName))
            {
                var serializer = new XmlSerializer(typeof(T));
                return serializer.Deserialize(stream) as T;
            }
        }

        private static void CreateDirectoryIfNotExist(string fileName)
        {
            var dir = Path.GetDirectoryName(fileName);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }
    }
}