/*
 * Author: Stefan Sander
 * Date: 21.11.2018
 */
using System;

namespace IbanOop
{
	public class IbanEntity
	{
		#region properties
		private string _iban;
		private CountryEntity _countryEntity;
		private string _bban;
		#endregion
		
		#region accessors
		public override string ToString() {
			return this.GetIban();
		}
		public string GetCountryAbbreviation() {
			return this._countryEntity._countryAbbreviation;
		}
		public string GetBban() {
			return this._bban;
		}
		public string GetIban() { 
			return this._iban;
		}
		public CountryEntity GetCountryEntity() {
			return this._countryEntity;
		}
		#endregion
		
		#region constructors
		private string Generate() {
			return GenerateIbanController.GenerateIban(this._countryEntity,this._bban).GetIban();
		}
		
		public bool Validate() {
			if (GenerateIbanController.GenerateIban(this._countryEntity,this._bban).GetIban()==this.GetIban()) {
				return true;
			} else {
				return false;
			}
		}
		public IbanEntity(CountryEntity CountryEntity,string bban)
		{
			this._countryEntity = CountryEntity;
			this._bban = bban;
			this._iban = this.Generate();
		}
		public IbanEntity(string iban,CountryEntity CountryEntity)
		{
			this._countryEntity =CountryEntity;
			this._bban = iban.Substring(4);
			this._iban = iban;
		}
		public IbanEntity(string iban,CountryEntityController CountryEntityController)
		{
			this._countryEntity = CountryEntityController.GetCountryEntityByCountryAbbreviation(iban.Substring(0,2));
			this._bban = iban.Substring(4);
			this._iban = iban;
		}
		#endregion
		
		#region workers
		#endregion
	}
}
