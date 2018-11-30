using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OfficeSupplyManagementSystem.Persistency
{
    class PersistencyService
    {
        /// <summary>
        /// Converts collection to string via JsonConverter
        /// Calls SerializeCollectionFileAsync asynchronous
        /// </summary>
        /// <param name="collectionInput">Collection of any type </param>
        public static async void SaveCollectionAsJsonAsync<T>(T collectionInput)
        {
            string fileName = collectionInput.GetType().ToString();
            string collectionString =
                JsonConvert.SerializeObject(collectionInput);
            SerializeCollectionFileAsync(collectionString, fileName);
        }

        /// <summary>
        /// Creates a list of type objects
        /// Calls asynchronously DeSerializeCollectionFileAsync on localFile
        /// Fills list with type objects and returns the type
        /// </summary>
        /// <param name="typeInput">The type of the target collection</param>
        /// <returns></returns>
        public static async Task<List<T>> LoadCollectionFromJsonAsync<T>()
        {
            //Type tmp = typeof(T);

            string fileName = typeof(T).ToString();
            List<T> collectionList = new List<T>();

            string result = await DeSerializeCollectionFileAsync(fileName);

            if (!String.IsNullOrWhiteSpace(result))
            {
                collectionList =
                    JsonConvert.DeserializeObject<List<T>>(result);
            }
            return collectionList;
        }

        /// <summary>
        /// Writes the string variable to a file, creates a new file if none exists
        /// </summary>
        /// <param name="collectionString">List of type objects converted to string</param>
        /// <param name="fileName">Name of the local file</param>
        private static async void SerializeCollectionFileAsync(string collectionString, string fileName)
        {
            Windows.Storage.StorageFolder localFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;

            Windows.Storage.StorageFile storageFile =
                await localFolder.CreateFileAsync(fileName,
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);

            await Windows.Storage.FileIO.WriteTextAsync(storageFile,
                collectionString);
        }

        /// <summary>
        /// Reads values from file, returns values as string
        /// </summary>
        /// <param name="fileName">Name of the local file</param>
        /// <returns></returns>
        public static async Task<string> DeSerializeCollectionFileAsync(string fileName)
        {
            string collectionString = null;

            Windows.Storage.StorageFolder localFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;

            if (await localFolder.TryGetItemAsync(fileName) != null)
            {
                Windows.Storage.StorageFile storageFile =
                    await localFolder.GetFileAsync(fileName);
                collectionString =
                    await Windows.Storage.FileIO.ReadTextAsync(storageFile);
            }
            return collectionString;
        }
    }
}
