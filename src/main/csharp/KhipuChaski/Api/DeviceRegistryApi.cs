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
    public interface IDeviceRegistryApi
    {
        
        /// <summary>
        /// Registro de dispositivo
        /// </summary>
        /// <remarks>
        /// Registra un dispositivo identificado por su tokenId
        /// </remarks>
        /// <param name="device">Dispositivo a registrar</param>
        /// <returns>SuccessResponse</returns>
        SuccessResponse AddDevice (Device device);
  
        /// <summary>
        /// Registro de dispositivo
        /// </summary>
        /// <remarks>
        /// Registra un dispositivo identificado por su tokenId
        /// </remarks>
        /// <param name="device">Dispositivo a registrar</param>
        /// <returns>SuccessResponse</returns>
        System.Threading.Tasks.Task<SuccessResponse> AddDeviceAsync (Device device);
        
        /// <summary>
        /// Registro de dispositivo eliminando alias anteriores
        /// </summary>
        /// <remarks>
        /// Registra un dispositivo identificado por su tokenId, elimina alias anteriores
        /// </remarks>
        /// <param name="device">Dispositivo a registrar</param>
        /// <returns>SuccessResponse</returns>
        SuccessResponse AddUniqueAliasDevice (Device device);
  
        /// <summary>
        /// Registro de dispositivo eliminando alias anteriores
        /// </summary>
        /// <remarks>
        /// Registra un dispositivo identificado por su tokenId, elimina alias anteriores
        /// </remarks>
        /// <param name="device">Dispositivo a registrar</param>
        /// <returns>SuccessResponse</returns>
        System.Threading.Tasks.Task<SuccessResponse> AddUniqueAliasDeviceAsync (Device device);
        
        /// <summary>
        /// Obtiene dispositivo
        /// </summary>
        /// <remarks>
        /// Obtiene la informacion de un dispositivo especifico
        /// </remarks>
        /// <param name="tokenId">Token que identifica al dispositivo. Tiene la forma &lt;platform&gt;:&lt;registryId&gt;, donde platform puede tomar los valores \&quot;and\&quot; o \&quot;ios\&quot;.</param>
        /// <returns>Device</returns>
        Device GetDevice (string tokenId);
  
        /// <summary>
        /// Obtiene dispositivo
        /// </summary>
        /// <remarks>
        /// Obtiene la informacion de un dispositivo especifico
        /// </remarks>
        /// <param name="tokenId">Token que identifica al dispositivo. Tiene la forma &lt;platform&gt;:&lt;registryId&gt;, donde platform puede tomar los valores \&quot;and\&quot; o \&quot;ios\&quot;.</param>
        /// <returns>Device</returns>
        System.Threading.Tasks.Task<Device> GetDeviceAsync (string tokenId);
        
        /// <summary>
        /// Agregar receptor
        /// </summary>
        /// <remarks>
        /// Agregar receptor de un dispositivo especifico
        /// </remarks>
        /// <param name="tokenId">Token que identifica al dispositivo. Tiene la forma &lt;platform&gt;:&lt;registryId&gt;, donde platform puede tomar los valores \&quot;and\&quot; o \&quot;ios\&quot;.</param>
        /// <param name="recipientId">Identificador asociado a un receptor de mensajes push</param>
        /// <returns>SuccessResponse</returns>
        SuccessResponse AddDeviceRecipient (string tokenId, string recipientId);
  
        /// <summary>
        /// Agregar receptor
        /// </summary>
        /// <remarks>
        /// Agregar receptor de un dispositivo especifico
        /// </remarks>
        /// <param name="tokenId">Token que identifica al dispositivo. Tiene la forma &lt;platform&gt;:&lt;registryId&gt;, donde platform puede tomar los valores \&quot;and\&quot; o \&quot;ios\&quot;.</param>
        /// <param name="recipientId">Identificador asociado a un receptor de mensajes push</param>
        /// <returns>SuccessResponse</returns>
        System.Threading.Tasks.Task<SuccessResponse> AddDeviceRecipientAsync (string tokenId, string recipientId);
        
        /// <summary>
        /// Elimina receptor
        /// </summary>
        /// <remarks>
        /// Elimina receptor de un dispositivo especifico
        /// </remarks>
        /// <param name="tokenId">Token que identifica al dispositivo. Tiene la forma &lt;platform&gt;:&lt;registryId&gt;, donde platform puede tomar los valores \&quot;and\&quot; o \&quot;ios\&quot;.</param>
        /// <param name="recipientId">Identificador asociado a un receptor de mensajes push</param>
        /// <returns>SuccessResponse</returns>
        SuccessResponse RemoveDeviceRecipient (string tokenId, string recipientId);
  
        /// <summary>
        /// Elimina receptor
        /// </summary>
        /// <remarks>
        /// Elimina receptor de un dispositivo especifico
        /// </remarks>
        /// <param name="tokenId">Token que identifica al dispositivo. Tiene la forma &lt;platform&gt;:&lt;registryId&gt;, donde platform puede tomar los valores \&quot;and\&quot; o \&quot;ios\&quot;.</param>
        /// <param name="recipientId">Identificador asociado a un receptor de mensajes push</param>
        /// <returns>SuccessResponse</returns>
        System.Threading.Tasks.Task<SuccessResponse> RemoveDeviceRecipientAsync (string tokenId, string recipientId);
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DeviceRegistryApi : IDeviceRegistryApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceRegistryApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DeviceRegistryApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceRegistryApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DeviceRegistryApi(String basePath)
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
        /// Registro de dispositivo Registra un dispositivo identificado por su tokenId
        /// </summary>
        /// <param name="device">Dispositivo a registrar</param> 
        /// <returns>SuccessResponse</returns>            
        public SuccessResponse AddDevice (Device device)
        {
            
            // verify the required parameter 'device' is set
            if (device == null) throw new ApiException(400, "Missing required parameter 'device' when calling AddDevice");
            
    
            var path = "/devices";
    
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
            
            
            
            
            postBody = ApiClient.Serialize(device); // http body (model) parameter
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling AddDevice: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling AddDevice: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SuccessResponse) ApiClient.Deserialize(response.Content, typeof(SuccessResponse), response.Headers);
        }
    
        /// <summary>
        /// Registro de dispositivo Registra un dispositivo identificado por su tokenId
        /// </summary>
        /// <param name="device">Dispositivo a registrar</param>
        /// <returns>SuccessResponse</returns>
        public async System.Threading.Tasks.Task<SuccessResponse> AddDeviceAsync (Device device)
        {
            // verify the required parameter 'device' is set
            if (device == null) throw new ApiException(400, "Missing required parameter 'device' when calling AddDevice");
            
    
            var path = "/devices";
    
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
            
            
            
            
            postBody = ApiClient.Serialize(device); // http body (model) parameter
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling AddDevice: " + response.Content, response.Content);

            return (SuccessResponse) ApiClient.Deserialize(response.Content, typeof(SuccessResponse), response.Headers);
        }
        
        /// <summary>
        /// Registro de dispositivo eliminando alias anteriores Registra un dispositivo identificado por su tokenId, elimina alias anteriores
        /// </summary>
        /// <param name="device">Dispositivo a registrar</param> 
        /// <returns>SuccessResponse</returns>            
        public SuccessResponse AddUniqueAliasDevice (Device device)
        {
            
            // verify the required parameter 'device' is set
            if (device == null) throw new ApiException(400, "Missing required parameter 'device' when calling AddUniqueAliasDevice");
            
    
            var path = "/devices/uniqueAlias";
    
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
            
            
            
            
            postBody = ApiClient.Serialize(device); // http body (model) parameter
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling AddUniqueAliasDevice: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling AddUniqueAliasDevice: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SuccessResponse) ApiClient.Deserialize(response.Content, typeof(SuccessResponse), response.Headers);
        }
    
        /// <summary>
        /// Registro de dispositivo eliminando alias anteriores Registra un dispositivo identificado por su tokenId, elimina alias anteriores
        /// </summary>
        /// <param name="device">Dispositivo a registrar</param>
        /// <returns>SuccessResponse</returns>
        public async System.Threading.Tasks.Task<SuccessResponse> AddUniqueAliasDeviceAsync (Device device)
        {
            // verify the required parameter 'device' is set
            if (device == null) throw new ApiException(400, "Missing required parameter 'device' when calling AddUniqueAliasDevice");
            
    
            var path = "/devices/uniqueAlias";
    
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
            
            
            
            
            postBody = ApiClient.Serialize(device); // http body (model) parameter
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling AddUniqueAliasDevice: " + response.Content, response.Content);

            return (SuccessResponse) ApiClient.Deserialize(response.Content, typeof(SuccessResponse), response.Headers);
        }
        
        /// <summary>
        /// Obtiene dispositivo Obtiene la informacion de un dispositivo especifico
        /// </summary>
        /// <param name="tokenId">Token que identifica al dispositivo. Tiene la forma &lt;platform&gt;:&lt;registryId&gt;, donde platform puede tomar los valores \&quot;and\&quot; o \&quot;ios\&quot;.</param> 
        /// <returns>Device</returns>            
        public Device GetDevice (string tokenId)
        {
            
            // verify the required parameter 'tokenId' is set
            if (tokenId == null) throw new ApiException(400, "Missing required parameter 'tokenId' when calling GetDevice");
            
    
            var path = "/devices/{tokenId}";
    
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
            if (tokenId != null) pathParams.Add("tokenId", ApiClient.ParameterToString(tokenId)); // path parameter
            
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetDevice: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetDevice: " + response.ErrorMessage, response.ErrorMessage);
    
            return (Device) ApiClient.Deserialize(response.Content, typeof(Device), response.Headers);
        }
    
        /// <summary>
        /// Obtiene dispositivo Obtiene la informacion de un dispositivo especifico
        /// </summary>
        /// <param name="tokenId">Token que identifica al dispositivo. Tiene la forma &lt;platform&gt;:&lt;registryId&gt;, donde platform puede tomar los valores \&quot;and\&quot; o \&quot;ios\&quot;.</param>
        /// <returns>Device</returns>
        public async System.Threading.Tasks.Task<Device> GetDeviceAsync (string tokenId)
        {
            // verify the required parameter 'tokenId' is set
            if (tokenId == null) throw new ApiException(400, "Missing required parameter 'tokenId' when calling GetDevice");
            
    
            var path = "/devices/{tokenId}";
    
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
            if (tokenId != null) pathParams.Add("tokenId", ApiClient.ParameterToString(tokenId)); // path parameter
            
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetDevice: " + response.Content, response.Content);

            return (Device) ApiClient.Deserialize(response.Content, typeof(Device), response.Headers);
        }
        
        /// <summary>
        /// Agregar receptor Agregar receptor de un dispositivo especifico
        /// </summary>
        /// <param name="tokenId">Token que identifica al dispositivo. Tiene la forma &lt;platform&gt;:&lt;registryId&gt;, donde platform puede tomar los valores \&quot;and\&quot; o \&quot;ios\&quot;.</param> 
        /// <param name="recipientId">Identificador asociado a un receptor de mensajes push</param> 
        /// <returns>SuccessResponse</returns>            
        public SuccessResponse AddDeviceRecipient (string tokenId, string recipientId)
        {
            
            // verify the required parameter 'tokenId' is set
            if (tokenId == null) throw new ApiException(400, "Missing required parameter 'tokenId' when calling AddDeviceRecipient");
            
            // verify the required parameter 'recipientId' is set
            if (recipientId == null) throw new ApiException(400, "Missing required parameter 'recipientId' when calling AddDeviceRecipient");
            
    
            var path = "/devices/{tokenId}/recipients/{recipientId}";
    
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
            if (tokenId != null) pathParams.Add("tokenId", ApiClient.ParameterToString(tokenId)); // path parameter
            if (recipientId != null) pathParams.Add("recipientId", ApiClient.ParameterToString(recipientId)); // path parameter
            
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling AddDeviceRecipient: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling AddDeviceRecipient: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SuccessResponse) ApiClient.Deserialize(response.Content, typeof(SuccessResponse), response.Headers);
        }
    
        /// <summary>
        /// Agregar receptor Agregar receptor de un dispositivo especifico
        /// </summary>
        /// <param name="tokenId">Token que identifica al dispositivo. Tiene la forma &lt;platform&gt;:&lt;registryId&gt;, donde platform puede tomar los valores \&quot;and\&quot; o \&quot;ios\&quot;.</param>
        /// <param name="recipientId">Identificador asociado a un receptor de mensajes push</param>
        /// <returns>SuccessResponse</returns>
        public async System.Threading.Tasks.Task<SuccessResponse> AddDeviceRecipientAsync (string tokenId, string recipientId)
        {
            // verify the required parameter 'tokenId' is set
            if (tokenId == null) throw new ApiException(400, "Missing required parameter 'tokenId' when calling AddDeviceRecipient");
            // verify the required parameter 'recipientId' is set
            if (recipientId == null) throw new ApiException(400, "Missing required parameter 'recipientId' when calling AddDeviceRecipient");
            
    
            var path = "/devices/{tokenId}/recipients/{recipientId}";
    
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
            if (tokenId != null) pathParams.Add("tokenId", ApiClient.ParameterToString(tokenId)); // path parameter
            if (recipientId != null) pathParams.Add("recipientId", ApiClient.ParameterToString(recipientId)); // path parameter
            
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling AddDeviceRecipient: " + response.Content, response.Content);

            return (SuccessResponse) ApiClient.Deserialize(response.Content, typeof(SuccessResponse), response.Headers);
        }
        
        /// <summary>
        /// Elimina receptor Elimina receptor de un dispositivo especifico
        /// </summary>
        /// <param name="tokenId">Token que identifica al dispositivo. Tiene la forma &lt;platform&gt;:&lt;registryId&gt;, donde platform puede tomar los valores \&quot;and\&quot; o \&quot;ios\&quot;.</param> 
        /// <param name="recipientId">Identificador asociado a un receptor de mensajes push</param> 
        /// <returns>SuccessResponse</returns>            
        public SuccessResponse RemoveDeviceRecipient (string tokenId, string recipientId)
        {
            
            // verify the required parameter 'tokenId' is set
            if (tokenId == null) throw new ApiException(400, "Missing required parameter 'tokenId' when calling RemoveDeviceRecipient");
            
            // verify the required parameter 'recipientId' is set
            if (recipientId == null) throw new ApiException(400, "Missing required parameter 'recipientId' when calling RemoveDeviceRecipient");
            
    
            var path = "/devices/{tokenId}/recipients/{recipientId}";
    
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
            if (tokenId != null) pathParams.Add("tokenId", ApiClient.ParameterToString(tokenId)); // path parameter
            if (recipientId != null) pathParams.Add("recipientId", ApiClient.ParameterToString(recipientId)); // path parameter
            
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RemoveDeviceRecipient: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RemoveDeviceRecipient: " + response.ErrorMessage, response.ErrorMessage);
    
            return (SuccessResponse) ApiClient.Deserialize(response.Content, typeof(SuccessResponse), response.Headers);
        }
    
        /// <summary>
        /// Elimina receptor Elimina receptor de un dispositivo especifico
        /// </summary>
        /// <param name="tokenId">Token que identifica al dispositivo. Tiene la forma &lt;platform&gt;:&lt;registryId&gt;, donde platform puede tomar los valores \&quot;and\&quot; o \&quot;ios\&quot;.</param>
        /// <param name="recipientId">Identificador asociado a un receptor de mensajes push</param>
        /// <returns>SuccessResponse</returns>
        public async System.Threading.Tasks.Task<SuccessResponse> RemoveDeviceRecipientAsync (string tokenId, string recipientId)
        {
            // verify the required parameter 'tokenId' is set
            if (tokenId == null) throw new ApiException(400, "Missing required parameter 'tokenId' when calling RemoveDeviceRecipient");
            // verify the required parameter 'recipientId' is set
            if (recipientId == null) throw new ApiException(400, "Missing required parameter 'recipientId' when calling RemoveDeviceRecipient");
            
    
            var path = "/devices/{tokenId}/recipients/{recipientId}";
    
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
            if (tokenId != null) pathParams.Add("tokenId", ApiClient.ParameterToString(tokenId)); // path parameter
            if (recipientId != null) pathParams.Add("recipientId", ApiClient.ParameterToString(recipientId)); // path parameter
            
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RemoveDeviceRecipient: " + response.Content, response.Content);

            return (SuccessResponse) ApiClient.Deserialize(response.Content, typeof(SuccessResponse), response.Headers);
        }
        
    }
    
}
