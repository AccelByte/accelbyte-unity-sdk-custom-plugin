// Copyright (c) 2023 AccelByte Inc. All Rights Reserved.
// This is licensed software from AccelByte Inc, for limitations
// and restrictions contact your company contract manager.

using AccelByte.Core;
using AccelByte.Models;
using System.Collections;
using UnityEngine.Scripting;

namespace AccelByte.Api
{
    public class CustomApi : ApiBase
    {
        /// <summary>
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="config">baseUrl==CustomServerUrl</param>
        /// <param name="session"></param>
        [Preserve]
        internal CustomApi(IHttpClient httpClient
            , Config config
            , ISession session)
            : base(httpClient, config, AccelByteCustomPlugin.Config.CustomServerUrl, session)
        {
        }

        /// <summary>
        /// Sample for Custom Post Request
        /// </summary>
        /// <param name="body">List of parameters</param>
        /// <param name="callback">Return a result containing result data</param>
        public IEnumerator CustomApiPostRequest(CustomModels body, ResultCallback<CustomResultModelsList> callback)
        {
            var request = HttpRequestBuilder
               .CreatePost(BaseUrl + "/post")
               .WithBearerAuth(AuthToken)
               .WithContentType(MediaType.ApplicationJson)
               .Accepts(MediaType.ApplicationJson)
               .WithBody(body.ToUtf8Json())
               .GetResult();

            IHttpResponse response = null;

            yield return HttpClient.SendRequest(request,
                rsp => response = rsp);

            var result = response.TryParseJson<CustomResultModelsList>();
            callback.Try(result);
        }

        /// <summary>
        /// Sample for Custom Get Request
        /// </summary>
        /// <param name="callback">Return a result containing result data</param>
        public IEnumerator CustomApiGetRequestAll(ResultCallback<CustomResultModelsList> callback)
        {
            var request = HttpRequestBuilder
               .CreateGet(BaseUrl + "/get")
               .WithBearerAuth(AuthToken)
               .Accepts(MediaType.ApplicationJson)
               .GetResult();

            IHttpResponse response = null;

            yield return HttpClient.SendRequest(request,
                rsp => response = rsp);

            var result = response.TryParseJson<CustomResultModelsList>();
            callback.Try(result);
        }

        /// <summary>
        /// Sample for Custom Get Request
        /// </summary>
        /// <param name="parameter">parameter for get query</param>
        /// <param name="callback">Return a result containing result data</param>
        public IEnumerator CustomApiGetRequestByParam(string parameter, ResultCallback<CustomResultModelsList> callback)
        {
            var request = HttpRequestBuilder
               .CreateGet(BaseUrl + "/get/{parameter}")
               .WithPathParam("parameter", parameter)
               .WithBearerAuth(AuthToken)
               .Accepts(MediaType.ApplicationJson)
               .GetResult();

            IHttpResponse response = null;

            yield return HttpClient.SendRequest(request,
                rsp => response = rsp);

            var result = response.TryParseJson<CustomResultModelsList>();
            callback.Try(result);

        }

        /// <summary>
        /// Sample for Custom Delete Request
        /// </summary>
        /// <param name="parameter">parameter for delete query</param>
        /// <param name="callback">Return a result via callback</param>
        public IEnumerator CustomApiDeleteRequest(string parameter, ResultCallback callback)
        {
            var request = HttpRequestBuilder
              .CreateDelete(BaseUrl + "/delete/{parameter}")
              .WithPathParam("parameter", parameter)
              .WithBearerAuth(AuthToken)
              .Accepts(MediaType.ApplicationJson)
              .GetResult();

            IHttpResponse response = null;

            yield return HttpClient.SendRequest(request,
                rsp => response = rsp);

            var result = response.TryParse();
            callback.Try(result);
        }
    }
}
