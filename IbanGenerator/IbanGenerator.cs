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
	public class IbanGenerator
	{
		#region properties
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
		public IbanGenerator(GenerateIbanStruct generateIbanStruct)
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
		    string strCountryCode = CountryCodeLookUp();
		    string strVerificationNumber = VerificationNumberGenerator(this.generateIbanStruct._bban + strCountryCode);
		    string strIbanNumber =  this.generateIbanStruct._countryCode + strVerificationNumber + this.generateIbanStruct._bban;
		    return strIbanNumber;
		}
		
		/* 
		 * generates country code numbers used for iban vailidation 
		 * by given 2-Characters Country string
		 * 
		 * @param string strCountry (2 Characters)
		 * @return string country code as numbers 
		 */
		private string CountryCodeLookUp()
		{
		    string strCountryCode = "";
		    strCountryCode = Utils.MergeStringToNumbers(this.generateIbanStruct._countryCode);
		    // merge country code to 6 characters
		    while (strCountryCode.Length < 6)
		    {
		        strCountryCode = strCountryCode + "0";
		    }
		    return strCountryCode;
		}
		
		/* 
		 * Generates the verification number of a given BBAN
		 * 
		 * @param string the bban used as base for the calculation
		 * @return string the verification number
		 */
		private string VerificationNumberGenerator(string strBasicBankAccountNumber)
		{
			string mergedBban = Utils.MergeStringToNumbers(strBasicBankAccountNumber);
			decimal decVerificationNumber = 98 - Utils.Modulo(mergedBban,97);
		    string strVerificationNumber = decVerificationNumber.ToString();
		    
		    // merge verification number to 2 characters
		    while (strVerificationNumber.Length < 2)
		    {
		        strVerificationNumber = "0" + strVerificationNumber;
		    }
		    return strVerificationNumber;
		}
		#endregion
	}
}
