// Copyright (c) 2023 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using AccelByte.Core;
using AccelByte.Models;
using UnityEngine.Assertions;
using UnityEngine.Scripting;

namespace AccelByte.Api
{
    public class Custom : WrapperBase
    {
        private readonly CustomApi api;
        private readonly CoroutineRunner coroutineRunner;
        private readonly UserSession session;

        [Preserve]
        internal Custom(CustomApi inApi
            , UserSession inSession
            , CoroutineRunner inCoroutineRunner)
        {
            Assert.IsNotNull(inApi, "inApi==null (@ constructor)");
            Assert.IsNotNull(inCoroutineRunner, "inCoroutineRunner==null (@ constructor)");

            api = inApi;
            session = inSession;
            coroutineRunner = inCoroutineRunner;
        }

        /// <summary>
        /// Sample for Custom Post Request
        /// </summary>
        /// <param name="parameters">List of parameters</param>
        /// <param name="callback">Return a result containing result data</param>
        public void CustomApiPostRequest(string[] parameters, ResultCallback<CustomResultModelsList> callback)
        {
            Report.GetFunctionLog(this.GetType().Name);

            var body = new CustomModels
            {
                CustomDataItem = parameters
            };

            this.coroutineRunner.Run(
                api.CustomApiPostRequest(body, callback));

        }

        /// <summary>
        /// Sample for Custom Get Request
        /// </summary>
        /// <param name="callback">Return a result containing result data</param>
        public void CustomApiGetRequestAll(ResultCallback<CustomResultModelsList> callback)
        {
            Report.GetFunctionLog(this.GetType().Name);

            this.coroutineRunner.Run(
                api.CustomApiGetRequestAll(callback));
        }

        /// <summary>
        /// Sample for Custom Get Request
        /// </summary>
        /// <param name="parameter">parameter for get query</param>
        /// <param name="callback">Return a result containing result data</param>
        public void CustomApiGetRequestByParam(string parameter, ResultCallback<CustomResultModelsList> callback)
        {
            Report.GetFunctionLog(this.GetType().Name);

            this.coroutineRunner.Run(
                api.CustomApiGetRequestByParam(parameter, callback));
        }

        /// <summary>
        /// Sample for Custom Delete Request
        /// </summary>
        /// <param name="parameter">parameter for delete query</param>
        /// <param name="callback">Return a result via callback</param>
        public void CustomApiDeleteRequest(string parameter, ResultCallback callback)
        {
            Report.GetFunctionLog(this.GetType().Name);

            this.coroutineRunner.Run(
                api.CustomApiDeleteRequest(parameter, callback));
        }
    }
}
