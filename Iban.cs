/*
 * Created by SharpDevelop.
 * User: derStoffel
 * Date: 01.11.2018
 * Time: 18:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace IbanOop
{
	public class Iban
	{
		private string _iban;
		private IbanValidator _ibanValidator;
		private IbanGenerator _ibanGenerator;
		
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
		private IbanValidator ibanValidator
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
		private IbanGenerator ibanGenerator
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
		
		public Iban(GenerateIbanStruct ibanStruct)
		{
			this.ibanGenerator = new IbanGenerator(ibanStruct);
			this.iban = this.ibanGenerator.GetIban();
		}
		
		public Iban(string iban)
		{
			this.ibanValidator = new IbanValidator(iban);
			this.iban = iban;
		}
		
		public bool IsValid() {
			return this.ibanValidator.IsValid();
		}
	}
}
