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
	public class IbanValidator
	{
		#region properties
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
		
		public IbanValidator(string iban)
		{
			this.iban = iban;
		}
		
		public bool IsValid() {
			return true;
		}
	}
}
