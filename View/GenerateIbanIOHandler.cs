/*
 * Author: Stefan Sander
 * Date: 21.11.2018
 */
using System;

namespace IbanOop
{
	public class GenerateIbanIOHandler : AbstractIOHandler
	{
		#region properties
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors
		#endregion
		
		#region workers
		public void PrintResult(string iban) {
			
			PrintHeader();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(SpaceShifter(iban,4));
			Console.ResetColor();
			Wait(true);
		}
		
		private void fetchBbanOutput(bool success,CountryEntity CountryEntity,string input,int pos) {
			string fieldId = CountryEntity._ibanFormat.Substring(pos,1);
			IbanFormatKeyEntity FieldEntity = GetFieldEntityByKey(_ibanFormatKeyEntities,fieldId);
			string field = FieldEntity._name;
	     	PrintHeader();
	        Console.WriteLine("Land: " + CountryEntity._countryName);
	        if (field!="" && success!=true) {
	       	 	Console.WriteLine("Bitte "+ field +" eingeben");
	        } else {
	        	Console.WriteLine();
	        }
	        Console.WriteLine();
	       	Console.Write("IBAN: ");
	        if (success==true) {
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write(SpaceShifter(input,4));
				Console.ResetColor();
				Console.WriteLine();
	        } else {
	       		int spacesToAdd = input.Length/4;
	       		int posSpaces = pos/4;
	       		input = SpaceShifter(input,4);
	        	Console.Write(input.Substring(0,pos+posSpaces));
	        	Console.ForegroundColor = ConsoleColor.Red;
	            Console.Write(input.Substring(pos+posSpaces,1));
	       		Console.ResetColor();
	            Console.Write(input.Substring(pos+posSpaces+1));
	        }
		}
		
	   public string fetchBban(CountryEntity CountryEntity)
	   {
	   		bool allowLetter;
			bool allowNumber;
	   		char ckiChar;
			ConsoleKeyInfo cki;
			int n;
			
	   		string bban = "";
	   		string input = "";
	   		int pos = 4;	//pos 0-3 reservered; 0-1: country code; 2-3: verification number
	   		
	   		PrintHeader();
	   		
	   		while (pos!=CountryEntity._ibanLength) {
	   			bban = CountryEntity._ibanFormat.Substring(0,4) + input + CountryEntity._ibanFormat.Substring(4).Substring(input.Length);
	   			this.fetchBbanOutput(false,CountryEntity,bban,pos);
	   			IbanFormatKeyEntity FieldEntity = GetFieldEntityByKey(_ibanFormatKeyEntities,CountryEntity._ibanFormat.Substring(pos,1));
	   			bool isNumeric = int.TryParse(CountryEntity._ibanFormat.Substring(pos,1), out n);
	   			if (isNumeric==true) {	// costa rica fix (costa rica bban always begins with a "0")
			  			input = input + CountryEntity._ibanFormat.Substring(pos,1);
			      	   	pos++;
					} else {
						cki = Console.ReadKey(true);
						ckiChar = cki.KeyChar;
						
				        if (cki.Key.ToString()=="Backspace" && pos>4) {
					    	input = input.Substring(0,input.Length-1);
					    	pos--;
						} else {
							allowNumber=true;
							allowLetter=true;
							if (CountryEntity._bbanFormat.Substring(pos-4,1)=="n") {
								allowLetter=false;
							} else if (CountryEntity._bbanFormat.Substring(pos-4,1)=="a") {
								allowNumber=false;
								allowLetter=true;
							}
							if ((cki.Key.ToString()=="Enter") || (ckiChar >= 48 && ckiChar <= 57) || (ckiChar >= 65 && ckiChar <= 90) || (ckiChar >= 97 && ckiChar <= 122) )
					        {
								if ((cki.Key.ToString()=="Enter") && (allowNumber==true) && FieldEntity._key=="k") {
									//HIT ENTER TO ADD ZEROs TO FRONT FEATURE
									char ch = 'k';
									int index = CountryEntity._bbanFormat.IndexOf(ch);
									int count = CountryEntity._ibanFormat.Substring(pos).Split('k').Length - 1;
									string inputnew = input.Substring(0,index-4);
									for (int i=0;i<count;i++) {
										inputnew =  inputnew + "0";
										pos++;
									}
									input = inputnew +  input.Substring(index-4);
								}
							else if (
					       	(ckiChar >= 48 && ckiChar <= 57 && allowNumber==true)
					       	|| (ckiChar >= 65 && ckiChar <= 90 && allowLetter==true)
					       	|| (ckiChar >= 97 && ckiChar <= 122 && allowLetter==true)
					       ) {
						  			input = input + ckiChar.ToString().ToUpper();
						      	   	pos++;
								}
							}
						}
				}
	   		}
	   		return input+CountryEntity._ibanFormat.Substring(4).Substring(input.Length);
	   }
		#endregion
	}
}
