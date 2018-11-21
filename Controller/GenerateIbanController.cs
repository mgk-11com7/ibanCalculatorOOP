/*
 * Author: Stefan Sander
 * Date: 01.11.2018
 * Time: 03:53
 * 
 */
using System;

namespace IbanOop
{
	public class GenerateIbanController
	{
		#region properties
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors
			public GenerateIbanController(CountryEntity[] countryEntities)
			{
				GenerateIbanView GenerateIbanView = new GenerateIbanView();
				
				SelectCountryMenu SelectCountryMenu = new SelectCountryMenu(countryEntities);
				MenuController GenerateIbanMenu = new MenuController(SelectCountryMenu);
				int pos = GenerateIbanMenu.handle();
				string bban = GenerateIbanView.fetchBban(countryEntities[pos]);
				IbanEntity IbanEntity = new IbanEntity(countryEntities[pos]._countryCode,bban);
				//string iban = GenerateIbanController.GenerateIban(countryEntities[pos]._countryCode,GenerateIbanView.fetchBban(countryEntities[pos]));
				GenerateIbanView.PrintResult(IbanEntity.GetIban());
			}
		#endregion
		
		#region workers
			
			/* 
			 * merges iban letters to numbers used for validation
			 * (A=65,B=66,... becomes A=10,B=11,... and so on)
			 * 
			 * @param string the letter containing text
			 * @return string only numbers containing text
			 */
			public static string MergeStringToNumbers(string text) {
			    int index;
				string textCode="";
			    foreach (char c in text)
			    {
			    	if (Char.IsNumber(c)) {
			    		textCode = textCode + c;
			    	} else {
			        // using ascii table to match letters to Numbers (A=65,B=66,... becomes A=10,B=11,... and so on)
			        	index = char.ToUpper(c) - 64 + 9;
			        	textCode = textCode + index;
			    	}
			    }
				return textCode;
			}
			
			/* 
			 * generates country code numbers used for iban vailidation 
			 * by given 2-Characters Country string
			 * 
			 * @param string strCountry (2 Characters)
			 * @return string country code as numbers 
			 */
			private static string CountryCodeLookUp(string countryCode)
			{
			    string strCountryCode = "";
			    strCountryCode = GenerateIbanController.MergeStringToNumbers(countryCode);
			    // merge country code to 6 characters
			    while (strCountryCode.Length < 6)
			    {
			        strCountryCode = strCountryCode + "0";
			    }
			    return strCountryCode;
			}
			
	
			/*
			 * modulo operation by string because default data types cant handle such big numbers
			 * 
			 * @param string num the number used as base for the calculation
			 * @param int the modulo operation value
			 * @return int the result of the calculaton
			 */
			private static int Modulo(String num, int mod) 
			{ 
			    int result = 0;
			    for (int i = 0; i < num.Length; i++) {
			        result = (result * 10 + (int)num[i]- '0') % mod; 
			    }
			    return result; 
			}
			
			/* 
			 * Generates the verification number of a given BBAN
			 * 
			 * @param string the bban used as base for the calculation
			 * @return string the verification number
			 */
			private static string GenerateVerificationNumber(string strBasicBankAccountNumber)
			{
				string mergedBban = GenerateIbanController.MergeStringToNumbers(strBasicBankAccountNumber);
				decimal decVerificationNumber = 98 - GenerateIbanController.Modulo(mergedBban,97);
			    string strVerificationNumber = decVerificationNumber.ToString();
			    
			    // merge verification number to 2 characters
			    while (strVerificationNumber.Length < 2)
			    {
			        strVerificationNumber = "0" + strVerificationNumber;
			    }
			    return strVerificationNumber;
			}
			
			public static IbanEntity GenerateIban(string countryCode,string bban)
			{
				string strCountryCode;
				int n;
				bool isNumeric = int.TryParse(countryCode, out n);
				if (isNumeric==true) {
					strCountryCode = countryCode;
				} else {
			    	strCountryCode = GenerateIbanController.CountryCodeLookUp(countryCode);
				}
			    string strVerificationNumber = GenerateIbanController.GenerateVerificationNumber(bban + strCountryCode);
			    string strIbanNumber =  countryCode + strVerificationNumber + bban;
			    IbanEntity IbanEntity = new IbanEntity(strIbanNumber);
			    return IbanEntity;
			}
		
		#endregion
	}
}
