/*
 * Author: Stefan Sander
 * Date: 20.11.2018
 */
using System;

namespace IbanOop
{
	public static class Utils
	{
		#region properties
	    private static string[] _header = {
	        " ██╗██████╗  █████╗ ███╗   ██╗",
	        " ██║██╔══██╗██╔══██╗████╗  ██║",
	        " ██║██████╔╝███████║██╔██╗ ██║",
	        " ██║██╔══██╗██╔══██║██║╚██╗██║",
	        " ██║██████╔╝██║  ██║██║ ╚████║",
	        " ╚═╝╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝",
	        "",
	    };
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors
		#endregion
		
		#region workers
		
		/* 
		 *  clears the console and prints a useless ascii-art header
		 *  
		 *	@return void
		 */
		public static void PrintHeader()
		{
		    Console.Clear();
		    Console.ForegroundColor = ConsoleColor.DarkRed;
		    foreach (string line in Utils._header)
		    {
		        System.Console.Write(line + "\n");
		    }
		    Console.ResetColor();
		}
		
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
		
		
		public static CountryEntity GetCountryEntityByCountryCode(CountryEntity[] countryEntities,string countryCode) {
			CountryEntity countryEntity = new CountryEntity();
			foreach(CountryEntity e in countryEntities) {
				if (e._countryCode==countryCode)
					countryEntity=e;
			}
			return countryEntity;
		}
		
		/* 
		 *  Error Output and redirect to main menu
		 * 
		 *  @param string the error message to be displayed
		 *	@return void
		 */
		public static void ThrowError(string errorMsg) {
			Utils.PrintHeader();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("");
			Console.Write("Fehler: ");
			Console.ResetColor();
			Console.Write(errorMsg);
			Console.WriteLine("");
			MainController.Wait();
		}
		
		/*
		 *	Adds Spaces to a String stepwise
		 */
		public static string SpaceShifter(string str,int step) {
			for (int i = step; i <= str.Length; i += step)
			    {
			        str = str.Insert(i, " ");
			        i++;
			    }
			return str;
		}
		#endregion
	}
}
