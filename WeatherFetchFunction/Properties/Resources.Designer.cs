﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherFetchFunction.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WeatherFetchFunction.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ApiKey.
        /// </summary>
        internal static string WeatherFetchApiKey {
            get {
                return ResourceManager.GetString("WeatherFetchApiKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ApiUrl.
        /// </summary>
        internal static string WeatherFetchApiUrl {
            get {
                return ResourceManager.GetString("WeatherFetchApiUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to json.
        /// </summary>
        internal static string WeatherFetchBlobType {
            get {
                return ResourceManager.GetString("WeatherFetchBlobType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error with getting api key.
        /// </summary>
        internal static string WeatherFetchError_ApiKey {
            get {
                return ResourceManager.GetString("WeatherFetchError.ApiKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error with getting storage connection string.
        /// </summary>
        internal static string WeatherFetchError_ConnectionString {
            get {
                return ResourceManager.GetString("WeatherFetchError.ConnectionString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to General error - {1}.
        /// </summary>
        internal static string WeatherFetchError_Default {
            get {
                return ResourceManager.GetString("WeatherFetchError.Default", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Http error - {1}.
        /// </summary>
        internal static string WeatherFetchError_Http {
            get {
                return ResourceManager.GetString("WeatherFetchError.Http", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error converting &apos;from&apos; parameter to date.
        /// </summary>
        internal static string WeatherFetchError_InvalidFromParameter {
            get {
                return ResourceManager.GetString("WeatherFetchError.InvalidFromParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error converting &apos;to&apos; parameter to date.
        /// </summary>
        internal static string WeatherFetchError_InvalidToParameter {
            get {
                return ResourceManager.GetString("WeatherFetchError.InvalidToParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing &apos;from&apos; parameter.
        /// </summary>
        internal static string WeatherFetchError_MissingFromParameter {
            get {
                return ResourceManager.GetString("WeatherFetchError.MissingFromParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing &apos;to&apos; parameter.
        /// </summary>
        internal static string WeatherFetchError_MissingToParameter {
            get {
                return ResourceManager.GetString("WeatherFetchError.MissingToParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Object not found.
        /// </summary>
        internal static string WeatherFetchError_NotFound {
            get {
                return ResourceManager.GetString("WeatherFetchError.NotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Http response was not successful.
        /// </summary>
        internal static string WeatherFetchError_Response {
            get {
                return ResourceManager.GetString("WeatherFetchError.Response", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error with getting url.
        /// </summary>
        internal static string WeatherFetchError_Url {
            get {
                return ResourceManager.GetString("WeatherFetchError.Url", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to weatherfetchlogs.
        /// </summary>
        internal static string WeatherFetchLogsTable {
            get {
                return ResourceManager.GetString("WeatherFetchLogsTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failure.
        /// </summary>
        internal static string WeatherFetchLogType_Failure {
            get {
                return ResourceManager.GetString("WeatherFetchLogType.Failure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Success.
        /// </summary>
        internal static string WeatherFetchLogType_Success {
            get {
                return ResourceManager.GetString("WeatherFetchLogType.Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to weatherfetchpayloads.
        /// </summary>
        internal static string WeatherFetchPayloadsBlob {
            get {
                return ResourceManager.GetString("WeatherFetchPayloadsBlob", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C# HTTP trigger get payload by key function processed a request.
        /// </summary>
        internal static string WeatherFetchRequestByKey_Start {
            get {
                return ResourceManager.GetString("WeatherFetchRequestByKey.Start", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Succesful request by key.
        /// </summary>
        internal static string WeatherFetchRequestByKey_Success {
            get {
                return ResourceManager.GetString("WeatherFetchRequestByKey.Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C# HTTP trigger get logs by time period function processed a request.
        /// </summary>
        internal static string WeatherFetchRequestByTimePeriod_Start {
            get {
                return ResourceManager.GetString("WeatherFetchRequestByTimePeriod.Start", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to from.
        /// </summary>
        internal static string WeatherFetchRequestParameter_From {
            get {
                return ResourceManager.GetString("WeatherFetchRequestParameter.From", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to to.
        /// </summary>
        internal static string WeatherFetchRequestParameter_To {
            get {
                return ResourceManager.GetString("WeatherFetchRequestParameter.To", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Succesful weather api request.
        /// </summary>
        internal static string WeatherFetchStatus_Success {
            get {
                return ResourceManager.GetString("WeatherFetchStatus.Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to AzureWebJobsStorage.
        /// </summary>
        internal static string WeatherFetchStorage {
            get {
                return ResourceManager.GetString("WeatherFetchStorage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Timestamp.
        /// </summary>
        internal static string WeatherFetchStorageTimestampColumnName {
            get {
                return ResourceManager.GetString("WeatherFetchStorageTimestampColumnName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C# Timer trigger function ended.
        /// </summary>
        internal static string WeatherFetchTrigger_End {
            get {
                return ResourceManager.GetString("WeatherFetchTrigger.End", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C# Timer trigger function executed.
        /// </summary>
        internal static string WeatherFetchTrigger_Start {
            get {
                return ResourceManager.GetString("WeatherFetchTrigger.Start", resourceCulture);
            }
        }
    }
}
