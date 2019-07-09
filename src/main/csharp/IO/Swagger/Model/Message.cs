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
  public class Message {
    
    /// <summary>
    /// Asunto de mensaje
    /// </summary>
    /// <value>Asunto de mensaje</value>
    [DataMember(Name="subject", EmitDefaultValue=false)]
    public string Subject { get; set; }

    
    /// <summary>
    /// Lista de identificadores de receptores del mensaje
    /// </summary>
    /// <value>Lista de identificadores de receptores del mensaje</value>
    [DataMember(Name="recipientIdSet", EmitDefaultValue=false)]
    public List<string> RecipientIdSet { get; set; }

    
    /// <summary>
    /// Cuerpo del mensaje
    /// </summary>
    /// <value>Cuerpo del mensaje</value>
    [DataMember(Name="body", EmitDefaultValue=false)]
    public string Body { get; set; }

    
    /// <summary>
    /// Lista de propiedades del mensaje
    /// </summary>
    /// <value>Lista de propiedades del mensaje</value>
    [DataMember(Name="msgProperties", EmitDefaultValue=false)]
    public List<MsgProperty> MsgProperties { get; set; }

    

    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Message {\n");
      
      sb.Append("  Subject: ").Append(Subject).Append("\n");
      
      sb.Append("  RecipientIdSet: ").Append(RecipientIdSet).Append("\n");
      
      sb.Append("  Body: ").Append(Body).Append("\n");
      
      sb.Append("  MsgProperties: ").Append(MsgProperties).Append("\n");
      
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
