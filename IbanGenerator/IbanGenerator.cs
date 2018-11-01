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
		
		public string getIban() {
			return this.iban;
		}
		public IbanGenerator(GenerateIbanStruct generateIbanStruct)
		{
			this.iban = "DE0712341234123412";
		}
	}
}
