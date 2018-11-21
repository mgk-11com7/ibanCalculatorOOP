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
		private void Generate() {
			this._iban = GenerateIbanController.GenerateIban(this._countryCode,this._bban).GetIban();
		}
		
		private void Validate() {
			
		}
			public IbanEntity(string countryCode,string bban)
			{
				this._countryCode = countryCode;
				this._bban = bban;
				this.Generate();
			}
			public IbanEntity(string iban)
			{
				this._iban = iban;
				this._countryCode = iban.Substring(0,2);
				this._bban = iban.Substring(4);
			}
		#endregion
		
		#region workers
		#endregion
	}
}
