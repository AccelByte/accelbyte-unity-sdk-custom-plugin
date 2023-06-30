// Copyright (c) 2023 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using UnityEngine;
using AccelByte.Core;
using AccelByte.Models;
using System;

namespace AccelByte.Api
{
    public static class AccelByteCustomPlugin
    {
        private static MultiCustomConfigs multiConfigs;
        private static CustomConfig config;

        private static SettingsEnvironment activeEnvironment = SettingsEnvironment.Default;
        private static bool initialized = false;

        public static CustomConfig Config
        {
            get
            {
                CheckPlugin();

                return config;
            }
        }

        /// <summary>
        /// Set active environment 
        /// </summary>
        /// <param name="environment"> Choosen settings environment </param>
        public static void SetEnvironment(SettingsEnvironment environment)
        {
            activeEnvironment = environment;
        }

        /// <summary>
        /// Get active environment 
        /// </summary>
        public static SettingsEnvironment GetEnvironment()
        {
            return activeEnvironment;
        }

        /// <summary>
        /// Reset the initialization to reload the config
        /// </summary>
        public static void ResetConfig()
        {
            initialized = false;
        }

        private static void CheckPlugin()
        {
            if (!initialized)
            {
                LoadSDKConfigFile();

                if (config == null)
                {
                    config = new CustomConfig();
                }

                config.AssignDefaultCustomUrl();

                initialized = true;
            }
        }

        private static void LoadSDKConfigFile()
        {
            MultiCustomConfigs configs = null;

            var configFile = Resources.Load(AccelByteSettingsV2.SDKConfigResourcePath(false));

            if (configFile != null)
            {
                string wholeJsonText = ((TextAsset)configFile).text;
                configs = wholeJsonText.ToObject<MultiCustomConfigs>();
            }

            multiConfigs = configs;

            config = multiConfigs.GetConfigFromEnvironment(activeEnvironment);
        }
    }
}