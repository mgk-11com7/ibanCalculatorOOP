/*
 * User: Stefan Sander
 * Date: 01.11.2018
 * Time: 03:53
 * 
 */
using System;

namespace IbanOop
{
	public class GenerateIbanController
	{
		#region properties
		private CountryStruct[] _countryStructs;
		private string _iban;
		private GenerateIbanStruct _generateIbanStruct;
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
		private GenerateIbanStruct generateIbanStruct
        {
            get
            {
                return this._generateIbanStruct;
            }
            set
            {
                _generateIbanStruct = value;
            }
        }
		#endregion
		
		#region constructors
		public GenerateIbanController(CountryStruct[] countryStructs,GenerateIbanStruct generateIbanStruct)
		{
			this.generateIbanStruct = generateIbanStruct;
			this.iban = this.GenerateIban();
		}
		#endregion
		
		#region workers
		public string GetIban() {
			return this.iban;
		}
		
		private string GenerateIban()
		{
		    string strCountryCode = Utils.CountryCodeLookUp(this.generateIbanStruct._countryCode);
		    string strVerificationNumber = Utils.VerificationNumberGenerator(this.generateIbanStruct._bban + strCountryCode);
		    string strIbanNumber =  this.generateIbanStruct._countryCode + strVerificationNumber + this.generateIbanStruct._bban;
		    return strIbanNumber;
		}
		
		#endregion
	}
}
