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
  public class MsgProperty {
    
    /// <summary>
    /// nombre de la propiedad
    /// </summary>
    /// <value>nombre de la propiedad</value>
    [DataMember(Name="key", EmitDefaultValue=false)]
    public string Key { get; set; }

    
    /// <summary>
    /// valor de la propiedad
    /// </summary>
    /// <value>valor de la propiedad</value>
    [DataMember(Name="value", EmitDefaultValue=false)]
    public string Value { get; set; }

    

    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class MsgProperty {\n");
      
      sb.Append("  Key: ").Append(Key).Append("\n");
      
      sb.Append("  Value: ").Append(Value).Append("\n");
      
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
