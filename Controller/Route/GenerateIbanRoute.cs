﻿/*
 * Author: Stefan Sander
 * Since: 01.11.2018
 */
using System;

namespace IbanOop
{
	public class GenerateIbanRoute : RouteInterface
	{
		#region properties
		private string _caption = "IBAN generieren";
		private CountryEntityController _countryEntityController;
		#endregion
		
		#region accessors
		public string GetCaption() {
			return this._caption;
		}
		#endregion
		
		public void Init(CountryEntityController CountryEntityController) {
			this._countryEntityController = CountryEntityController;
		}
		#region constructors
			public void Handle()
			{
				CountryEntityController CountryEntityController = this._countryEntityController;
				GenerateIbanIOHandler GenerateIbanIOHandler = new GenerateIbanIOHandler();
				
				CountryEntity[] countryEntities = CountryEntityController._countryEntities;
				SelectCountryMenu SelectCountryMenu = new SelectCountryMenu(countryEntities);
				MenuController GenerateIbanMenu = new MenuController(SelectCountryMenu);
				int pos = GenerateIbanMenu.handle();
				string bban = GenerateIbanIOHandler.fetchBban(countryEntities[pos]);
				IbanEntity IbanEntity = new IbanEntity(countryEntities[pos],bban);
				GenerateIbanIOHandler.PrintResult(IbanEntity.GetIban());
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
			private static string CountryCodeLookUp(string countryAbbreviation)
			{
			    string strCountryCode = GenerateIbanRoute.MergeStringToNumbers(countryAbbreviation);
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
				string mergedBban = GenerateIbanRoute.MergeStringToNumbers(strBasicBankAccountNumber);
				decimal decVerificationNumber = 98 - GenerateIbanRoute.Modulo(mergedBban,97);
			    string strVerificationNumber = decVerificationNumber.ToString();
			    
			    // merge verification number to 2 characters
			    while (strVerificationNumber.Length < 2)
			    {
			        strVerificationNumber = "0" + strVerificationNumber;
			    }
			    return strVerificationNumber;
			}
			
			public static IbanEntity GenerateIban(CountryEntity CountryEntity,string bban)
			{
				string strCountryCode;
				int n;
				if (int.TryParse(CountryEntity._countryAbbreviation, out n)==true) {
					strCountryCode = CountryEntity._countryAbbreviation;
				} else {
			    	strCountryCode = GenerateIbanRoute.CountryCodeLookUp(CountryEntity._countryAbbreviation);
				}
			    string strVerificationNumber = GenerateIbanRoute.GenerateVerificationNumber(bban + strCountryCode);
			    string strIbanNumber =  CountryEntity._countryAbbreviation + strVerificationNumber + bban;
			    IbanEntity IbanEntity = new IbanEntity(strIbanNumber,CountryEntity);
			    return IbanEntity;
			}
		
		#endregion
	}
}