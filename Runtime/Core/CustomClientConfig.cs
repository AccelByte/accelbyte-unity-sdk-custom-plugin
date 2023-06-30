// Copyright (c) 2023 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;
using AccelByte.Api;
using UnityEngine.Scripting;

namespace AccelByte.Models
{
    [DataContract, Preserve]
    public class CustomConfig
    {
        // Add custom server URL members here
        [DataMember] public string CustomServerUrl;

        // Add default value for custom server URL members here
        private string defaultCustomServerUrl = "/custom-service";

        /// <summary>
        /// Compare config values with other config values
        /// </summary>
        public bool Compare(CustomConfig otherConfig)
        {
            // Add other custom service URL (using && operator) here 
            return CustomServerUrl == otherConfig.CustomServerUrl; 
        }

        /// <summary>
        /// Assign custom service URL with default value
        /// </summary>
        public void AssignDefaultCustomUrl()
        {
            string baseUrl = AccelBytePlugin.Config.BaseUrl;

            // Add assigning default value for custom service URL here
            if (string.IsNullOrEmpty(CustomServerUrl))
            {
                CustomServerUrl = baseUrl + defaultCustomServerUrl;
            }
        }
    }

    [DataContract, Preserve]
    public class MultiCustomConfigs
    {
        [DataMember] public CustomConfig Development;
        [DataMember] public CustomConfig Certification;
        [DataMember] public CustomConfig Production;
        [DataMember] public CustomConfig Default;

        public CustomConfig GetConfigFromEnvironment(SettingsEnvironment targetEnvironment)
        {
            switch (targetEnvironment)
            {
                case SettingsEnvironment.Development:
                    return Development;
                case SettingsEnvironment.Certification:
                    return Certification;
                case SettingsEnvironment.Production:
                    return Production;
                case SettingsEnvironment.Default:
                default:
                    return Default;
            }
        }
    }
}
