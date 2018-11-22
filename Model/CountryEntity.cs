/*
 * Author: Stefan Sander
 * Since: 01.11.2018
 */


using System;

namespace IbanOop
{
	public class CountryEntity
	{
		
	    public string _countryName;
	    public int _ibanLength;
	    public string _countryAbbreviation;
	    public string _ibanFormat;
	    public string _bbanFormatCode;
	    public string _bbanFormat;
	    public string _countryCode;
	    
	    private void Init(string countryName,int ibanLength,string ibanFormat,string bbanFormatCode) {
	    	_countryName = countryName;
	    	_ibanLength = ibanLength;
	    	_ibanFormat = ibanFormat;
		    _bbanFormatCode = bbanFormatCode;
	    	if (ibanLength!=0) {
    			_countryAbbreviation = ibanFormat.Substring(0, 2);
		    	_bbanFormat = CountryEntity.BbanFormatLookUp(bbanFormatCode);
	    	}
	    	
	    }
	    public CountryEntity() {
	    	this.Init(null,0,null,null);
	    }
	    public CountryEntity(string countryName,int ibanLength,string ibanFormat,string bbanFormatCode) {
	    	this.Init(countryName,ibanLength,ibanFormat,bbanFormatCode);
	    }
	    
			
		private static string BbanFormatLookUp(string bbanFormatCode) {
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
	}
}