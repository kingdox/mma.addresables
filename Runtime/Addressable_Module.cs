#region Access
using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
//using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine;
#endregion
namespace Architecture.BASE_FILE_Addressable
{
    public static class Key
    {
        public const string Initialize = "Addresables_Initialize";
        public const string LoadAsset = "Addresables_LoadAsset";
        //public const string Catalog = "";
        //public const string OnLoadAsset = "";
        //public const string OnLoadCatalog = "";
    }
    //public static class Import
    //{
    //    //public const string _ = _;
    //}
    public sealed class Addressable_Module : Module
    {
        #region References
        //[Header("Applications")]
        //[SerializeField] public ApplicationBase interface_Addressables;
        #endregion
        #region Reactions ( On___ )
        // Contenedor de toda las reacciones del Addressables
        protected override void OnSubscription(bool condition)
        {
            // Initialize
            Middleware.Subscribe_Task(condition, Key.Initialize, Initialize);

            // LoadAsset
            Middleware<string, object>.Subscribe_Task(condition, Key.LoadAsset, LoadAsset);
        }
        #endregion
        #region Methods
        // Contenedor de toda la logica del Addressables
        #endregion
        #region Request ( Coroutines )
        // Contenedor de toda la Esperas de corutinas del Addressables
        #endregion
        #region Task ( async )
        // Contenedor de toda la Esperas asincronas del Addressables
        private Task Initialize() => Addressables.InitializeAsync().Task;
        private Task<object> LoadAsset(string key) => Addressables.LoadAssetAsync<object>(key).Task;
        //TODO private Task<object> LoadGroup(string key) => Addressables.LoadContentCatalogAsync(key).Task;
        #endregion
    }
}