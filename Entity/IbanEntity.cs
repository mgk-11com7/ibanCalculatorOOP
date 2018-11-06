/*
 * User: derStoffel
 * Date: 01.11.2018
 * Time: 18:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace IbanOop
{
	public class IbanEntity
	{
		private string _iban;
		private ValidateIbanController _ibanValidator;
		private GenerateIbanController _ibanGenerator;
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
		private ValidateIbanController ibanValidator
        {
            get
            {
                return this._ibanValidator;
            }
            set
            {
                _ibanValidator = value;
            }
        }
		private GenerateIbanController ibanGenerator
        {
            get
            {
                return this._ibanGenerator;
            }
            set
            {
                _ibanGenerator = value;
            }
        }
		#endregion
		
		#region public accessors
		public string getIban() {
			return this.iban;
		}
		#endregion
		
		public IbanEntity(CountryStruct[] countryStructs,GenerateIbanStruct ibanStruct)
		{
			this.ibanGenerator = new GenerateIbanController(countryStructs,ibanStruct);
			this.iban = this.ibanGenerator.GetIban();
		}
		
		public IbanEntity(CountryStruct[] countryStructs,string iban)
		{
			this.ibanValidator = new ValidateIbanController(countryStructs,iban);
			this.iban = iban;
		}
		
		public bool IsValid() {
			return this.ibanValidator.IsValid();
		}
	}
}
