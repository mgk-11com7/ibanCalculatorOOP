/*
 * Author: Stefan Sander
 * Date: 01.11.2018
 * Time: 16:30
 * 
 */
using System;

namespace IbanOop
{
	public static class Utils
	{

	    private static string[] _header = {
	        " ██╗██████╗  █████╗ ███╗   ██╗",
	        " ██║██╔══██╗██╔══██╗████╗  ██║",
	        " ██║██████╔╝███████║██╔██╗ ██║",
	        " ██║██╔══██╗██╔══██║██║╚██╗██║",
	        " ██║██████╔╝██║  ██║██║ ╚████║",
	        " ╚═╝╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝",
	        "",
	    };
		
		/*
		 *  Waits for User interaction
		 *	note: method overloading.
		 * 
		 *  @param (optional) true: requires Enter to continue / else: any key to continue
		 * 	@return void
		 */
		public static void Wait() { Wait(false); }
		public static void Wait(bool requireEnter) {
			if (requireEnter==false) {
			    Console.WriteLine("");
			    Console.WriteLine("Drücken Sie eine beliebige Taste zum fortfahren...");
			    Console.ReadKey(true);
			} else {
				ConsoleKeyInfo cki;
		        Console.WriteLine("");
		        Console.WriteLine("Drücken Sie die ENTER-Taste zum fortfahren...");
				cki = Console.ReadKey(true);
				while(cki.Key.ToString()!="Enter") {
					cki = Console.ReadKey(true);
				}
			}
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
		}
		
		public static string SpaceShifter(string str,int step) {
			for (int i = step; i <= str.Length; i += step)
			    {
			        str = str.Insert(i, " ");
			        i++;
			    }
			return str;
		}
		
		public static void Exit() {
       		System.Environment.Exit(1);
		}
		
		/* 
		 *  clears the console and prints a useless ascii-art header
		 *  
		 *	@return void
		 */
		public static void PrintHeader()
		{
		    Console.Clear();
		    Console.ForegroundColor = ConsoleColor.DarkRed;
		    foreach (string line in _header)
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

		public static CountryEntity GetCountryEntityByCountryCode(CountryEntity[] countryStructs,string countryCode) {
			CountryEntity countryStruct = new CountryEntity("",0,"","");
			foreach(CountryEntity e in countryStructs) {
				if (e._countryCode==countryCode)
					countryStruct=e;
			}
			return countryStruct;
		}
		
	}
}
