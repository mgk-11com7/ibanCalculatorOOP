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
		private GenerateIbanStruct _generateIbanStruct;
		#endregion
		
		#region accessors
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
		
		public IbanGenerator(GenerateIbanStruct generateIbanStruct)
		{
			
		}
	}
}
