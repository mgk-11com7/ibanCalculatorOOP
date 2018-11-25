/*
 * Author: Stefan Sander
 * Date: 20.11.2018
 */
using System;

namespace IbanOop
{
	public abstract class AbstractIOHandler
	{
		#region properties
		
   		protected static IbanFormatKeyEntity[] _ibanFormatKeyEntities = {
			new IbanFormatKeyEntity( "p","Prüfziffer"),
			new IbanFormatKeyEntity( "b","BIC/BLZ"),
			new IbanFormatKeyEntity( "k","Account Number/Kontonummer"),
			new IbanFormatKeyEntity( "d","Account Number/Kontonummer (Account-Type)"),
			new IbanFormatKeyEntity( "K","Account Number/Kontonummer (Control Number)"),
			new IbanFormatKeyEntity( "s","Branch Code"),
			new IbanFormatKeyEntity( "r","Regional Code"),
		};
		
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
		
	   protected static IbanFormatKeyEntity GetFieldEntityByKey(IbanFormatKeyEntity[] IbanFormatKeyEntities,string key) {
			IbanFormatKeyEntity IbanFormatKeyEntity = new IbanFormatKeyEntity(null,null);
			foreach(IbanFormatKeyEntity e in IbanFormatKeyEntities) {
				if (e._key == key)
					IbanFormatKeyEntity = e;
			}
			return IbanFormatKeyEntity;
		}
		/*
		 *  Waits for User interaction
		 *	note: method overloading.
		 * 
		 *  @param bool (optional)	require Enter to continue or not
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
		 *  clears the console and prints a useless ascii-art header
		 *  
		 *	@return void
		 */
		public static void PrintHeader()
		{
		    Console.Clear();
		    Console.ForegroundColor = ConsoleColor.DarkRed;
		    foreach (string line in AbstractIOHandler._header)
		    {
		        System.Console.Write(line + "\n");
		    }
		    Console.ResetColor();
		}
		
		/* 
		 *  Error Output and redirect to main menu
		 * 
		 *  @param string the error message to be displayed
		 *	@return void
		 */
		public static void ThrowError(string errorMsg) {
			ThrowError(errorMsg,"");
		}
		public static void ThrowError(string errorMsg,Exception exception) {
			ThrowError(errorMsg,exception.Message);
		}
		public static void ThrowError(string errorMsg,string exceptionMsg) {
			AbstractIOHandler.PrintHeader();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("");
			Console.Write("Fehler: ");
			Console.ResetColor();
			Console.WriteLine(errorMsg);
			Console.WriteLine("");
			Console.WriteLine(exceptionMsg);
			AbstractIOHandler.Wait();
		}
		
		/*
		 *	Adds Spaces to a String stepwise
		 */
		protected static string SpaceShifter(string str,int step) {
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
