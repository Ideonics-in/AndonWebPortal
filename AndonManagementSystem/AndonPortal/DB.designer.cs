﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AndonPortal
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="IAS_Schneider")]
	public partial class DBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["IAS_SchneiderConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<issue> issues
		{
			get
			{
				return this.GetTable<issue>();
			}
		}
		
		public System.Data.Linq.Table<issue_tracker> issue_trackers
		{
			get
			{
				return this.GetTable<issue_tracker>();
			}
		}
		
		public System.Data.Linq.Table<department> departments
		{
			get
			{
				return this.GetTable<department>();
			}
		}
		
		public System.Data.Linq.Table<station> stations
		{
			get
			{
				return this.GetTable<station>();
			}
		}
		
		public System.Data.Linq.Table<line> lines
		{
			get
			{
				return this.GetTable<line>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.issues")]
	public partial class issue
	{
		
		private int _slNo;
		
		private System.Nullable<int> _line;
		
		private int _station;
		
		private int _department;
		
		private string _data;
		
		private string _status;
		
		private System.Nullable<System.DateTime> _timestamp;
		
		private string _message;
		
		public issue()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_slNo", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int slNo
		{
			get
			{
				return this._slNo;
			}
			set
			{
				if ((this._slNo != value))
				{
					this._slNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_line", DbType="Int")]
		public System.Nullable<int> line
		{
			get
			{
				return this._line;
			}
			set
			{
				if ((this._line != value))
				{
					this._line = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_station", DbType="Int NOT NULL")]
		public int station
		{
			get
			{
				return this._station;
			}
			set
			{
				if ((this._station != value))
				{
					this._station = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_department", DbType="Int NOT NULL")]
		public int department
		{
			get
			{
				return this._department;
			}
			set
			{
				if ((this._department != value))
				{
					this._department = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_data", DbType="NVarChar(50)")]
		public string data
		{
			get
			{
				return this._data;
			}
			set
			{
				if ((this._data != value))
				{
					this._data = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="NVarChar(50)")]
		public string status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this._status = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_timestamp", DbType="DateTime")]
		public System.Nullable<System.DateTime> timestamp
		{
			get
			{
				return this._timestamp;
			}
			set
			{
				if ((this._timestamp != value))
				{
					this._timestamp = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_message", DbType="NVarChar(MAX)")]
		public string message
		{
			get
			{
				return this._message;
			}
			set
			{
				if ((this._message != value))
				{
					this._message = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.issue_tracker")]
	public partial class issue_tracker
	{
		
		private int _slNo;
		
		private int _issue;
		
		private string _status;
		
		private System.Nullable<System.DateTime> _timestamp;
		
		public issue_tracker()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_slNo", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int slNo
		{
			get
			{
				return this._slNo;
			}
			set
			{
				if ((this._slNo != value))
				{
					this._slNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_issue", DbType="Int NOT NULL")]
		public int issue
		{
			get
			{
				return this._issue;
			}
			set
			{
				if ((this._issue != value))
				{
					this._issue = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="NVarChar(50)")]
		public string status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this._status = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_timestamp", DbType="DateTime")]
		public System.Nullable<System.DateTime> timestamp
		{
			get
			{
				return this._timestamp;
			}
			set
			{
				if ((this._timestamp != value))
				{
					this._timestamp = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.departments")]
	public partial class department
	{
		
		private int _slNo;
		
		private int _id;
		
		private string _description;
		
		private string _message;
		
		private System.Nullable<int> _timeout;
		
		public department()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_slNo", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int slNo
		{
			get
			{
				return this._slNo;
			}
			set
			{
				if ((this._slNo != value))
				{
					this._slNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL")]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this._id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(MAX)")]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this._description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_message", DbType="NVarChar(MAX)")]
		public string message
		{
			get
			{
				return this._message;
			}
			set
			{
				if ((this._message != value))
				{
					this._message = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_timeout", DbType="Int")]
		public System.Nullable<int> timeout
		{
			get
			{
				return this._timeout;
			}
			set
			{
				if ((this._timeout != value))
				{
					this._timeout = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.stations")]
	public partial class station
	{
		
		private int _slNo;
		
		private int _id;
		
		private int _line;
		
		private string _description;
		
		public station()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_slNo", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int slNo
		{
			get
			{
				return this._slNo;
			}
			set
			{
				if ((this._slNo != value))
				{
					this._slNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL")]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this._id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_line", DbType="Int NOT NULL")]
		public int line
		{
			get
			{
				return this._line;
			}
			set
			{
				if ((this._line != value))
				{
					this._line = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(MAX)")]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this._description = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.lines")]
	public partial class line
	{
		
		private int _slNo;
		
		private int _id;
		
		private string _description;
		
		private System.Nullable<int> _stations;
		
		public line()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_slNo", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int slNo
		{
			get
			{
				return this._slNo;
			}
			set
			{
				if ((this._slNo != value))
				{
					this._slNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL")]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this._id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(MAX)")]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this._description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stations", DbType="Int")]
		public System.Nullable<int> stations
		{
			get
			{
				return this._stations;
			}
			set
			{
				if ((this._stations != value))
				{
					this._stations = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
