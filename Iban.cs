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
		
		public Iban(GenerateIbanStruct ibanStruct)
		{
			
		}
		public Iban(string iban)
		{
			this._iban = iban;
			this._ibanValidator = new IbanValidator(this._iban);
		}
		
		public bool IsValid() {
			return this._ibanValidator.IsValid();
		}
	}
}
