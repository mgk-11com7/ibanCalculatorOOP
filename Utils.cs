/*
 * Created by SharpDevelop.
 * User: derStoffel
 * Date: 01.11.2018
 * Time: 16:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
		
		public static string[] LoadCsv(string filename,string path,int tries) {
			string[] data;
			
			try {
				data = System.IO.File.ReadAllLines(@path+filename);
			} catch (Exception exception)  {
				if (tries==0) {
					data = new string[] { "error" };
					Utils.ThrowError("Cant Load " + filename);
					Wait();
					Exit();
				} else {
					data = Utils.LoadCsv(filename, "../"+path,tries-1);
				}
			}
			return data;
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
		 * modulo operation by string because default data types cant handle such big numbers
		 * 
		 * @param string num the number used as base for the calculation
		 * @param int the modulo operation value
		 * @return int the result of the calculaton
		 */
		public static int Modulo(String num, int mod) 
		{ 
		    int result = 0;
		    for (int i = 0; i < num.Length; i++) {
		        result = (result * 10 + (int)num[i]- '0') % mod; 
		    }
		    return result; 
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
		
	}
}
