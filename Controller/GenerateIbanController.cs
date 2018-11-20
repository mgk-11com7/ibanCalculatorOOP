﻿/*
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
		public GenerateIbanController(CountryEntity[] countryStructs)
		{
			MenuChoiceEntity[] menuElements= new MenuChoiceEntity[countryStructs.Length];
			for(int i = 0; i < countryStructs.Length; i++)
			{
				menuElements[i] =  new MenuChoiceEntity(countryStructs[i]._countryName);
			}
			MenuController generateIbanMenu = new MenuController(menuElements);
			int pos = generateIbanMenu.handle();
			string bban = "12341232123412";
			string iban = this.GenerateIban(countryStructs[pos]._countryCode,bban);
			Console.Write(iban);
			Utils.Wait();
		}
		#endregion
		
		#region workers
		/* 
		 * generates country code numbers used for iban vailidation 
		 * by given 2-Characters Country string
		 * 
		 * @param string strCountry (2 Characters)
		 * @return string country code as numbers 
		 */
		private  string CountryCodeLookUp(string countryCode)
		{
		    string strCountryCode = "";
		    strCountryCode = Utils.MergeStringToNumbers(countryCode);
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
		private int Modulo(String num, int mod) 
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
		private string VerificationNumberGenerator(string strBasicBankAccountNumber)
		{
			string mergedBban = Utils.MergeStringToNumbers(strBasicBankAccountNumber);
			decimal decVerificationNumber = 98 - this.Modulo(mergedBban,97);
		    string strVerificationNumber = decVerificationNumber.ToString();
		    
		    // merge verification number to 2 characters
		        strVerificationNumber = "0" + strVerificationNumber;
		    while (strVerificationNumber.Length < 2)
		    {
		    }
		    return strVerificationNumber;
		}
		
		private string GenerateIban(string countryCode,string bban)
		{
		    string strCountryCode = this.CountryCodeLookUp(countryCode);
		    string strVerificationNumber = this.VerificationNumberGenerator(bban + strCountryCode);
		    string strIbanNumber =  countryCode + strVerificationNumber + bban;
		    return strIbanNumber;
		}
		
		#endregion
	}
}
