/*
 * Author: Stefan Sander
 * Date: 22.11.2018
 */
using System;

namespace IbanOop
{
	public class CountryEntityController
	{
		#region properties
		private const string _dataDirectory = "Ressources/";
		private const string _dataFile = "countries.csv";
		
		//Warum ist das public?
		public CountryEntity[] _countryEntities;
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors
		public CountryEntityController() {
			this._countryEntities=this.CountryEntityLoader();
		}
		#endregion
		
		#region workers
		private string[] LoadCsvRecursive(string filename,string path,int tries) {
			string[] data;
			try {
				data = System.IO.File.ReadAllLines(@path+filename);
			} catch (Exception exception)  {
				if (tries==0) {
					data = new string[] { "error" };
					AbstractIOHandler.ThrowError("Cant Load " + filename/*,exception*/);
       				System.Environment.Exit(1);
				} else {
					data = this.LoadCsvRecursive(filename, "../" + path,tries-1);
				}
			}
			return data;
		}
		
		private CountryEntity[] CountryEntityLoader() {
			string[] countries;
			countries = this.LoadCsvRecursive(CountryEntityController._dataFile,CountryEntityController._dataDirectory,2);
			CountryEntity[] CountryEntities = new CountryEntity[countries.Length];
			for(int i = 0; i < countries.Length; i++) {
				string[] data = countries[i].Split(';');
				CountryEntities[i] = new CountryEntity(data[0],Int32.Parse(data[1]),data[2],data[3]);
			}
			return CountryEntities;
		}
		
		public CountryEntity GetCountryEntityByCountryAbbreviation(string countryAbbreviation) {
			// Schau mal nach Linq Namespace und dann nach _countryEntities.FirstOrDefault()
			// und überlege ob es nicht sinnvoller ist null zurückzugeben, wenn es kein
			// richtiges Ergebnis gibt.
			CountryEntity countryEntity = new CountryEntity();
			foreach(CountryEntity e in this._countryEntities) {
				if (e._countryAbbreviation==countryAbbreviation)
					countryEntity=e;
			}
			return countryEntity;
		}
		#endregion
	}
}
