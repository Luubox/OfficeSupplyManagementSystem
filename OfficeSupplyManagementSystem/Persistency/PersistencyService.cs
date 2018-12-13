using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OfficeSupplyManagementSystem.Persistency
{
    class PersistencyService
    {
        /// <summary>
        /// Converts the typeInput to a string to be used as a fileName,
        /// Converts the collectionInput to a string containing the collection via JsonConvert,
        /// Calls SerializeCollectionFileAsync on the collection string and the filename string.
        /// </summary>
        /// <typeparam name="T">The type of collection</typeparam>
        /// <param name="collectionInput">The name of the collection to be saved</param>
        /// <param name="typeInput">The type of objects in the collection, to be used as fileName</param>
        public static async void SaveCollectionAsJsonAsync<T>(T collectionInput, Type typeInput)
        {
            string fileName = typeInput.ToString() + ".json";
            string collectionString =
                JsonConvert.SerializeObject(collectionInput);
            SerializeCollectionFileAsync(collectionString, fileName);
            Debug.WriteLine("Done writing to: " + fileName);
        }

        /// <summary>
        /// Converts the typeInput to a string to be used as a fileName,
        /// Creates a new empty list of typeInput objects,
        /// Calls DeSerializeCollectionFileAsync on the filename string,
        /// Fills the empty list with the result of said method via JsonConvert
        /// </summary>
        /// <typeparam name="T">The type of objects to be loaded from the local folder</typeparam>
        /// <returns>A list of typeInput objects</returns>
        public static async Task<List<T>> LoadCollectionFromJsonAsync<T>()
        {
            //TODO: Fix load. Den overskriver det eksisterende med default.
            string fileName = typeof(T).ToString() + ".json";
            List<T> collectionList = new List<T>();

            string result = await DeSerializeCollectionFileAsync(fileName);

            if (!String.IsNullOrWhiteSpace(result))
            {
                collectionList =
                    JsonConvert.DeserializeObject<List<T>>(result);
            }
            Debug.WriteLine("Done loading from: " + fileName);
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
