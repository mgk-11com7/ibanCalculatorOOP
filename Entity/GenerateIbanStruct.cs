/*
 * Author: Stefan Sander
 * Date: 01.11.2018
 * Time: 02:23
 * 
 */
using System;

namespace IbanOop
{
	public struct GenerateIbanStruct
	{
		public string _countryCode;
		public string _bban;
		
		public GenerateIbanStruct(string countryCode,string bban) {
			_countryCode = countryCode;
			_bban = bban;
		}
	}
}