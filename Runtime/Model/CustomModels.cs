// Copyright (c) 2023 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using System.Runtime.Serialization;
using UnityEngine.Scripting;

namespace AccelByte.Models
{
    [DataContract, Preserve]
    public class CustomModels
    {
        [DataMember(Name = "customDataItem")] public string[] CustomDataItem;
    }

    [DataContract, Preserve]
    public class CustomResultModelsList
    {
        [DataMember(Name = "json")] public CustomModels Json;
    }
}
