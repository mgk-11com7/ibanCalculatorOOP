﻿/*
 * Created by SharpDevelop.
 * User: derStoffel
 * Date: 01.11.2018
 * Time: 15:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */


using System;

namespace IbanOop
{

	
	struct CountryStruct
	{
		public static string BbanFormatLookUp(string bbanFormatCode) {
			string i;
			int iSum;
			string bbanFormat="";
			string letter="";
			string[] sectors = bbanFormatCode.Split(',');
			foreach (string sector in sectors) {
				iSum=0;
				i = "";
				foreach (char c in sector)
				{
					if (char.IsNumber(c)) {
						i = i + ((int)c - 48).ToString() ;
					}
					if (char.IsLetter(c)) {
						letter=c.ToString();
					}
				}
				iSum = iSum + Int32.Parse(i);
				for(int counter=0;counter<iSum;counter++) {
					bbanFormat=bbanFormat+letter;
				}
			}
			return bbanFormat;
		}
		
	    public string _countryName;
	    public int _ibanLength;
	    public string _countryCode;
	    public string _ibanFormat;
	    public string _bbanFormatCode;
	    public string _bbanFormat;
	    public CountryStruct(string countryName,int ibanLength,string ibanFormat,string bbanFormatCode) {
	    	_countryName = countryName;
	    	_ibanLength = ibanLength;
    		_countryCode = ibanFormat.Substring(0, 2);
	    	_ibanFormat = ibanFormat;
		    _bbanFormatCode = bbanFormatCode;
		    _bbanFormat = BbanFormatLookUp(bbanFormatCode);
	    }
	}
}