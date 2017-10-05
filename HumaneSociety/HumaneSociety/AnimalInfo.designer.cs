﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HumaneSociety
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="HumaneSociety")]
	public partial class AnimalInfoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public AnimalInfoDataContext() : 
				base(global::HumaneSociety.Properties.Settings.Default.HumaneSocietyConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AnimalInfoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AnimalInfoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AnimalInfoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AnimalInfoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Animal_Info> Animal_Infos
		{
			get
			{
				return this.GetTable<Animal_Info>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Animal_Info")]
	public partial class Animal_Info
	{
		
		private int _ID;
		
		private string _Animal_type;
		
		private string _Name;
		
		private int _Age;
		
		private int _Room_;
		
		private bool _IsAdopted;
		
		private bool _HasShots;
		
		private string _Amount_of_Food;
		
		private decimal _Price;
		
		public Animal_Info()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL")]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Animal type]", Storage="_Animal_type", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Animal_type
		{
			get
			{
				return this._Animal_type;
			}
			set
			{
				if ((this._Animal_type != value))
				{
					this._Animal_type = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Age", DbType="Int NOT NULL")]
		public int Age
		{
			get
			{
				return this._Age;
			}
			set
			{
				if ((this._Age != value))
				{
					this._Age = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Room#", Storage="_Room_", DbType="Int NOT NULL")]
		public int Room_
		{
			get
			{
				return this._Room_;
			}
			set
			{
				if ((this._Room_ != value))
				{
					this._Room_ = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsAdopted", DbType="Bit NOT NULL")]
		public bool IsAdopted
		{
			get
			{
				return this._IsAdopted;
			}
			set
			{
				if ((this._IsAdopted != value))
				{
					this._IsAdopted = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HasShots", DbType="Bit NOT NULL")]
		public bool HasShots
		{
			get
			{
				return this._HasShots;
			}
			set
			{
				if ((this._HasShots != value))
				{
					this._HasShots = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Amount of Food]", Storage="_Amount_of_Food", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Amount_of_Food
		{
			get
			{
				return this._Amount_of_Food;
			}
			set
			{
				if ((this._Amount_of_Food != value))
				{
					this._Amount_of_Food = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Money NOT NULL")]
		public decimal Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this._Price = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
