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
        /// Converts the input type to a string filename.
        /// Converts the collection to a string using Json.Convert
        /// Calls SerializeCollectionFileAsync on the collection string and filename string
        /// </summary>
        /// <typeparam name="T">Denotes which type the collection consist of</typeparam>
        /// <param name="collectionInput">The collection in question</param>
        public static async void SaveCollectionAsJsonAsync<T>(T collectionInput)
        {
            string fileName = collectionInput.GetType().ToString();
            string collectionString =
                JsonConvert.SerializeObject(collectionInput);
            SerializeCollectionFileAsync(collectionString, fileName);
        }

        /// <summary>
        /// Converts the input type to a string filename.
        /// Calls DeSerializeCollectionFileAsync on the input type as a string filename.
        /// Converts the result of the method to a list of input type objects, and returns said list.
        /// </summary>
        /// <typeparam name="T">Denotes the type of the desired collection</typeparam>
        /// <returns>Returns a list of input type objects</returns>
        public static async Task<List<T>> LoadCollectionFromJsonAsync<T>()
        {
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
        /// Locates localFolder and the localFile based of the string input.
        /// If the target localFile exist, overwrites with the new data,
        /// else creates a new localFile with the string input name.
        /// </summary>
        /// <param name="collectionString">The collection converted to string via JsonConvert</param>
        /// <param name="fileName">The desired filename string</param>
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
        /// Locates localFolder and the localFile based of the string input.
        /// Creates an empty collection string and fills it based of the data from the localFile.
        /// Returns said collection string
        /// </summary>
        /// <param name="fileName">The desired filename string</param>
        /// <returns>Returns a string to be converted using Json</returns>
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
