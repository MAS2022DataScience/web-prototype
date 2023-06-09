// ------------------------------------------------------------------------------
// <auto-generated>
//    Generated by avrogen, version 1.11.1
//    Changes to this file may cause incorrect behavior and will be lost if code
//    is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
namespace com.mas2022datascience.avro.v1
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using global::Avro;
	using global::Avro.Specific;
	
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("avrogen", "1.11.1")]
	public partial class PlayerBall : global::Avro.Specific.ISpecificRecord
	{
		public static global::Avro.Schema _SCHEMA = global::Avro.Schema.Parse(@"{""type"":""record"",""name"":""PlayerBall"",""namespace"":""com.mas2022datascience.avro.v1"",""fields"":[{""name"":""ts"",""type"":{""type"":""long"",""logicalType"":""timestamp-millis""}},{""name"":""playerId"",""type"":{""type"":""string"",""avro.java.string"":""String""}},{""name"":""teamId"",""default"":null,""type"":[""null"",{""type"":""string"",""avro.java.string"":""String""}]},{""name"":""matchId"",""type"":{""type"":""string"",""avro.java.string"":""String""}},{""name"":""isBallInPlay"",""default"":null,""type"":[""null"",{""type"":""string"",""avro.java.string"":""String""}]},{""name"":""ballPossession"",""default"":null,""type"":[""null"",{""type"":""string"",""avro.java.string"":""String""}]},{""name"":""zone"",""default"":null,""type"":[""null"",""int""]},{""name"":""x"",""type"":""int""},{""name"":""y"",""type"":""int""},{""name"":""z"",""type"":""int""},{""name"":""velocity"",""default"":null,""type"":[""null"",""double""]},{""name"":""accelleration"",""default"":null,""type"":[""null"",""double""]},{""name"":""distance"",""default"":null,""type"":[""null"",""double""]}]}");
		private System.DateTime _ts;
		private string _playerId;
		private string _teamId;
		private string _matchId;
		private string _isBallInPlay;
		private string _ballPossession;
		private System.Nullable<System.Int32> _zone;
		private int _x;
		private int _y;
		private int _z;
		private System.Nullable<System.Double> _velocity;
		private System.Nullable<System.Double> _accelleration;
		private System.Nullable<System.Double> _distance;
		public virtual global::Avro.Schema Schema
		{
			get
			{
				return PlayerBall._SCHEMA;
			}
		}
		public System.DateTime ts
		{
			get
			{
				return this._ts;
			}
			set
			{
				this._ts = value;
			}
		}
		public string playerId
		{
			get
			{
				return this._playerId;
			}
			set
			{
				this._playerId = value;
			}
		}
		public string teamId
		{
			get
			{
				return this._teamId;
			}
			set
			{
				this._teamId = value;
			}
		}
		public string matchId
		{
			get
			{
				return this._matchId;
			}
			set
			{
				this._matchId = value;
			}
		}
		public string isBallInPlay
		{
			get
			{
				return this._isBallInPlay;
			}
			set
			{
				this._isBallInPlay = value;
			}
		}
		public string ballPossession
		{
			get
			{
				return this._ballPossession;
			}
			set
			{
				this._ballPossession = value;
			}
		}
		public System.Nullable<System.Int32> zone
		{
			get
			{
				return this._zone;
			}
			set
			{
				this._zone = value;
			}
		}
		public int x
		{
			get
			{
				return this._x;
			}
			set
			{
				this._x = value;
			}
		}
		public int y
		{
			get
			{
				return this._y;
			}
			set
			{
				this._y = value;
			}
		}
		public int z
		{
			get
			{
				return this._z;
			}
			set
			{
				this._z = value;
			}
		}
		public System.Nullable<System.Double> velocity
		{
			get
			{
				return this._velocity;
			}
			set
			{
				this._velocity = value;
			}
		}
		public System.Nullable<System.Double> accelleration
		{
			get
			{
				return this._accelleration;
			}
			set
			{
				this._accelleration = value;
			}
		}
		public System.Nullable<System.Double> distance
		{
			get
			{
				return this._distance;
			}
			set
			{
				this._distance = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.ts;
			case 1: return this.playerId;
			case 2: return this.teamId;
			case 3: return this.matchId;
			case 4: return this.isBallInPlay;
			case 5: return this.ballPossession;
			case 6: return this.zone;
			case 7: return this.x;
			case 8: return this.y;
			case 9: return this.z;
			case 10: return this.velocity;
			case 11: return this.accelleration;
			case 12: return this.distance;
			default: throw new global::Avro.AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.ts = (System.DateTime)fieldValue; break;
			case 1: this.playerId = (System.String)fieldValue; break;
			case 2: this.teamId = (System.String)fieldValue; break;
			case 3: this.matchId = (System.String)fieldValue; break;
			case 4: this.isBallInPlay = (System.String)fieldValue; break;
			case 5: this.ballPossession = (System.String)fieldValue; break;
			case 6: this.zone = (System.Nullable<System.Int32>)fieldValue; break;
			case 7: this.x = (System.Int32)fieldValue; break;
			case 8: this.y = (System.Int32)fieldValue; break;
			case 9: this.z = (System.Int32)fieldValue; break;
			case 10: this.velocity = (System.Nullable<System.Double>)fieldValue; break;
			case 11: this.accelleration = (System.Nullable<System.Double>)fieldValue; break;
			case 12: this.distance = (System.Nullable<System.Double>)fieldValue; break;
			default: throw new global::Avro.AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
        public bool ShouldSerializeSchema()
        {
            //only serialize Schema if SerializeSensitiveInfo == true
            return (false);
        }
    }
}
