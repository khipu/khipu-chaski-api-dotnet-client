using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Device {
    
    /// <summary>
    /// token para notificaciones asociado al dispositivo. Tiene la forma <platform>:<registryId>, donde platform puede tomar los valores \"and\" o \"ios\".
    /// </summary>
    /// <value>token para notificaciones asociado al dispositivo. Tiene la forma <platform>:<registryId>, donde platform puede tomar los valores \"and\" o \"ios\".</value>
    [DataMember(Name="tokenId", EmitDefaultValue=false)]
    public string TokenId { get; set; }

    
    /// <summary>
    /// Lista de receptores asociados al dispositivo
    /// </summary>
    /// <value>Lista de receptores asociados al dispositivo</value>
    [DataMember(Name="recipients", EmitDefaultValue=false)]
    public List<string> Recipients { get; set; }

    
    /// <summary>
    /// informacion adicional del dispositivo
    /// </summary>
    /// <value>informacion adicional del dispositivo</value>
    [DataMember(Name="extraData", EmitDefaultValue=false)]
    public string ExtraData { get; set; }

    

    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Device {\n");
      
      sb.Append("  TokenId: ").Append(TokenId).Append("\n");
      
      sb.Append("  Recipients: ").Append(Recipients).Append("\n");
      
      sb.Append("  ExtraData: ").Append(ExtraData).Append("\n");
      
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
