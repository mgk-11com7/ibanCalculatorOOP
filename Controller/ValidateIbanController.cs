/*
 * Created by SharpDevelop.
 * User: derStoffel
 * Date: 01.11.2018
 * Time: 03:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace IbanOop
{
	public class ValidateIbanController
	{
		#region properties
		private CountryStruct[] _countryStructs;
		private string _iban;
		#endregion
		
		#region accessors
		private string iban
	    {
	        get
	        {
	            return this._iban;
	        }
	        set
	        {
	            _iban = value;
	        }
	    }
		#endregion
		
		public ValidateIbanController(CountryStruct[] countryStructs,string iban)
		{
			this._countryStructs = countryStructs;
			this.iban = iban;
		}
		
		public bool IsValid() {
			return true;
		}
	}
}
