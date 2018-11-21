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
		private string _countryCode;
		private string _bban;
		#endregion
		
		#region accessors
		public override string ToString() {
			return this.GetIban();
		}
		public string GetCountryCode() {
			return this._countryCode;
		}
		public string GetBban() {
			return this._bban;
		}
		public string GetIban() {
			return this._iban;
		}
		#endregion
		
		#region constructors
		private string Generate() {
			return GenerateIbanController.GenerateIban(this._countryCode,this._bban).GetIban();
		}
		
		public bool Validate() {
			if (GenerateIbanController.GenerateIban(this._countryCode,this._bban).GetIban()==this.GetIban()) {
				return true;
			} else {
				return false;
			}
		}
		public IbanEntity(string countryCode,string bban)
		{
			this._countryCode = countryCode;
			this._bban = bban;
			this._iban = this.Generate();
		}
		public IbanEntity(string iban)
		{
			this._countryCode = iban.Substring(0,2);
			this._bban = iban.Substring(4);
			this._iban = iban;
		}
		#endregion
		
		#region workers
		#endregion
	}
}
