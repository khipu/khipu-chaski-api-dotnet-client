using System;
using System.IO;
using System.Collections.Generic;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDeviceRegistryListApi
    {
        
        /// <summary>
        /// Lista de dispositivos
        /// </summary>
        /// <remarks>
        /// Obtiene la lista de dispositivos registrados
        /// </remarks>
        /// <returns>DeviceList</returns>
        DeviceList GetDevices ();
  
        /// <summary>
        /// Lista de dispositivos
        /// </summary>
        /// <remarks>
        /// Obtiene la lista de dispositivos registrados
        /// </remarks>
        /// <returns>DeviceList</returns>
        System.Threading.Tasks.Task<DeviceList> GetDevicesAsync ();
        
        /// <summary>
        /// Lista de dispositivos asociados a un id de receptor
        /// </summary>
        /// <remarks>
        /// Obtiene la lista de dispositivos asociados a un receptor
        /// </remarks>
        /// <param name="recipientId">Identificador asociado a un receptor de mensajes push</param>
        /// <returns>DeviceList</returns>
        DeviceList GetRecipientDevices (string recipientId);
  
        /// <summary>
        /// Lista de dispositivos asociados a un id de receptor
        /// </summary>
        /// <remarks>
        /// Obtiene la lista de dispositivos asociados a un receptor
        /// </remarks>
        /// <param name="recipientId">Identificador asociado a un receptor de mensajes push</param>
        /// <returns>DeviceList</returns>
        System.Threading.Tasks.Task<DeviceList> GetRecipientDevicesAsync (string recipientId);
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DeviceRegistryListApi : IDeviceRegistryListApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceRegistryListApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public DeviceRegistryListApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceRegistryListApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DeviceRegistryListApi(String basePath)
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
        /// Lista de dispositivos Obtiene la lista de dispositivos registrados
        /// </summary>
        /// <returns>DeviceList</returns>            
        public DeviceList GetDevices ()
        {
            
    
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
            
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetDevices: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetDevices: " + response.ErrorMessage, response.ErrorMessage);
    
            return (DeviceList) ApiClient.Deserialize(response.Content, typeof(DeviceList), response.Headers);
        }
    
        /// <summary>
        /// Lista de dispositivos Obtiene la lista de dispositivos registrados
        /// </summary>
        /// <returns>DeviceList</returns>
        public async System.Threading.Tasks.Task<DeviceList> GetDevicesAsync ()
        {
            
    
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
            
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetDevices: " + response.Content, response.Content);

            return (DeviceList) ApiClient.Deserialize(response.Content, typeof(DeviceList), response.Headers);
        }
        
        /// <summary>
        /// Lista de dispositivos asociados a un id de receptor Obtiene la lista de dispositivos asociados a un receptor
        /// </summary>
        /// <param name="recipientId">Identificador asociado a un receptor de mensajes push</param> 
        /// <returns>DeviceList</returns>            
        public DeviceList GetRecipientDevices (string recipientId)
        {
            
            // verify the required parameter 'recipientId' is set
            if (recipientId == null) throw new ApiException(400, "Missing required parameter 'recipientId' when calling GetRecipientDevices");
            
    
            var path = "/recipients/{recipientId}/devices";
    
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
            if (recipientId != null) pathParams.Add("recipientId", ApiClient.ParameterToString(recipientId)); // path parameter
            
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetRecipientDevices: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetRecipientDevices: " + response.ErrorMessage, response.ErrorMessage);
    
            return (DeviceList) ApiClient.Deserialize(response.Content, typeof(DeviceList), response.Headers);
        }
    
        /// <summary>
        /// Lista de dispositivos asociados a un id de receptor Obtiene la lista de dispositivos asociados a un receptor
        /// </summary>
        /// <param name="recipientId">Identificador asociado a un receptor de mensajes push</param>
        /// <returns>DeviceList</returns>
        public async System.Threading.Tasks.Task<DeviceList> GetRecipientDevicesAsync (string recipientId)
        {
            // verify the required parameter 'recipientId' is set
            if (recipientId == null) throw new ApiException(400, "Missing required parameter 'recipientId' when calling GetRecipientDevices");
            
    
            var path = "/recipients/{recipientId}/devices";
    
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
            if (recipientId != null) pathParams.Add("recipientId", ApiClient.ParameterToString(recipientId)); // path parameter
            
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "khipu" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetRecipientDevices: " + response.Content, response.Content);

            return (DeviceList) ApiClient.Deserialize(response.Content, typeof(DeviceList), response.Headers);
        }
        
    }
    
}
