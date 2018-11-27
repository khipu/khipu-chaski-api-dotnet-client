using System;
using System.IO;
using System.Collections.Generic;
using RestSharp;
using KhipuChaski.Client;
using KhipuChaski.Model;

namespace KhipuChaski.Api
{
    
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IPushNotificationsApi
    {
        
        /// <summary>
        /// Enviar un nuevo mensaje
        /// </summary>
        /// <remarks>
        /// Encolar un nuevo mensaje para dispositivos moviles.
        /// </remarks>
        /// <param name="message">Mensaje a enviar</param>
        /// <returns>SuccessResponse</returns>
        SuccessResponse SendMessage (Message message);
  
        /// <summary>
        /// Enviar un nuevo mensaje
        /// </summary>
        /// <remarks>
        /// Encolar un nuevo mensaje para dispositivos moviles.
        /// </remarks>
        /// <param name="message">Mensaje a enviar</param>
        /// <returns>SuccessResponse</returns>
        System.Threading.Tasks.Task<SuccessResponse> SendMessageAsync (Message message);
        
        /// <summary>
        /// Enviar un nuevo mensaje
        /// </summary>
        /// <remarks>
        /// Encolar un nuevo mensaje para dispositivos moviles.
        /// </remarks>
        /// <param name="recipientIdSet">Receptores del mensaje. Los ids de receptor van separados por coma.</param>
        /// <param name="subject">Asunto del mensaje</param>
        /// <param name="body">cuerpo del mensaje</param>
        /// <returns>SuccessResponse</returns>
        SuccessResponse SendMsg (string recipientIdSet, string subject, string body);
  
        /// <summary>
        /// Enviar un nuevo mensaje
        /// </summary>
        /// <remarks>
        /// Encolar un nuevo mensaje para dispositivos moviles.
        /// </remarks>
        /// <param name="recipientIdSet">Receptores del mensaje. Los ids de receptor van separados por coma.</param>
        /// <param name="subject">Asunto del mensaje</param>
        /// <param name="body">cuerpo del mensaje</param>
        /// <returns>SuccessResponse</returns>
        System.Threading.Tasks.Task<SuccessResponse> SendMsgAsync (string recipientIdSet, string subject, string body);
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PushNotificationsApi : IPushNotificationsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushNotificationsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public PushNotificationsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="PushNotificationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PushNotificationsApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        
        /// <summary>
        /// Enviar un nuevo mensaje Encolar un nuevo mensaje para dispositivos moviles.
        /// </summary>
        /// <param name="message">Mensaje a enviar</param> 
        /// <returns>SuccessResponse</returns>            
        public SuccessResponse SendMessage (Message message)
        {
            
            // verify the required parameter 'message' is set
            if (message == null) throw new ApiException(400, "Missing required parameter 'message' when calling SendMessage");
            
    
            var path = "/message";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            
            
            
            postBody = ApiClient.Serialize(message); // http body (model) parameter
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling SendMessage: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling SendMessage: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SuccessResponse) ApiClient.Deserialize(response.Content, typeof(SuccessResponse), response.Headers);
        }
    
        /// <summary>
        /// Enviar un nuevo mensaje Encolar un nuevo mensaje para dispositivos moviles.
        /// </summary>
        /// <param name="message">Mensaje a enviar</param>
        /// <returns>SuccessResponse</returns>
        public async System.Threading.Tasks.Task<SuccessResponse> SendMessageAsync (Message message)
        {
            // verify the required parameter 'message' is set
            if (message == null) throw new ApiException(400, "Missing required parameter 'message' when calling SendMessage");
            
    
            var path = "/message";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            
            
            
            postBody = ApiClient.Serialize(message); // http body (model) parameter
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling SendMessage: " + response.Content, response.Content);

            return (SuccessResponse) ApiClient.Deserialize(response.Content, typeof(SuccessResponse), response.Headers);
        }
        
        /// <summary>
        /// Enviar un nuevo mensaje Encolar un nuevo mensaje para dispositivos moviles.
        /// </summary>
        /// <param name="recipientIdSet">Receptores del mensaje. Los ids de receptor van separados por coma.</param> 
        /// <param name="subject">Asunto del mensaje</param> 
        /// <param name="body">cuerpo del mensaje</param> 
        /// <returns>SuccessResponse</returns>            
        public SuccessResponse SendMsg (string recipientIdSet, string subject, string body)
        {
            
            // verify the required parameter 'recipientIdSet' is set
            if (recipientIdSet == null) throw new ApiException(400, "Missing required parameter 'recipientIdSet' when calling SendMsg");
            
            // verify the required parameter 'subject' is set
            if (subject == null) throw new ApiException(400, "Missing required parameter 'subject' when calling SendMsg");
            
            // verify the required parameter 'body' is set
            if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling SendMsg");
            
    
            var path = "/msg";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            
            
            if (recipientIdSet != null) formParams.Add("recipientIdSet", ApiClient.ParameterToString(recipientIdSet)); // form parameter
            if (subject != null) formParams.Add("subject", ApiClient.ParameterToString(subject)); // form parameter
            if (body != null) formParams.Add("body", ApiClient.ParameterToString(body)); // form parameter
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling SendMsg: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling SendMsg: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SuccessResponse) ApiClient.Deserialize(response.Content, typeof(SuccessResponse), response.Headers);
        }
    
        /// <summary>
        /// Enviar un nuevo mensaje Encolar un nuevo mensaje para dispositivos moviles.
        /// </summary>
        /// <param name="recipientIdSet">Receptores del mensaje. Los ids de receptor van separados por coma.</param>
        /// <param name="subject">Asunto del mensaje</param>
        /// <param name="body">cuerpo del mensaje</param>
        /// <returns>SuccessResponse</returns>
        public async System.Threading.Tasks.Task<SuccessResponse> SendMsgAsync (string recipientIdSet, string subject, string body)
        {
            // verify the required parameter 'recipientIdSet' is set
            if (recipientIdSet == null) throw new ApiException(400, "Missing required parameter 'recipientIdSet' when calling SendMsg");
            // verify the required parameter 'subject' is set
            if (subject == null) throw new ApiException(400, "Missing required parameter 'subject' when calling SendMsg");
            // verify the required parameter 'body' is set
            if (body == null) throw new ApiException(400, "Missing required parameter 'body' when calling SendMsg");
            
    
            var path = "/msg";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            
            
            if (recipientIdSet != null) formParams.Add("recipientIdSet", ApiClient.ParameterToString(recipientIdSet)); // form parameter
            if (subject != null) formParams.Add("subject", ApiClient.ParameterToString(subject)); // form parameter
            if (body != null) formParams.Add("body", ApiClient.ParameterToString(body)); // form parameter
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling SendMsg: " + response.Content, response.Content);

            return (SuccessResponse) ApiClient.Deserialize(response.Content, typeof(SuccessResponse), response.Headers);
        }
        
    }
    
}
