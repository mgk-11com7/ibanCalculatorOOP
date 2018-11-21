/*
 * Author: Stefan Sander
 * Date: 21.11.2018
 */
using System;

namespace IbanOop
{
	public class GenerateIbanView
	{
		#region properties
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors
			public GenerateIbanView()
			{
			}
		#endregion
		
		#region workers
		public void PrintResult(string iban) {
			
			Utils.PrintHeader();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write(Utils.SpaceShifter(iban,4));
			Console.ResetColor();
			MainController.Wait(true);
		}
		
	   private IbanFormatKeyEntity GetFieldEntityByKey(IbanFormatKeyEntity[] IbanFormatKeyEntities,string key) {
			IbanFormatKeyEntity IbanFormatKeyEntity = new IbanFormatKeyEntity(null,null);
			foreach(IbanFormatKeyEntity e in IbanFormatKeyEntities) {
				if (e._key == key)
					IbanFormatKeyEntity = e;
			}
			return IbanFormatKeyEntity;
		}
		
		private void fetchBbanOutput(IbanFormatKeyEntity[] ibanFormatKeyEntities,bool success,string country,string fieldId,string iban,int pos) {
			IbanFormatKeyEntity FieldEntity = this.GetFieldEntityByKey(ibanFormatKeyEntities,fieldId);
			string field = FieldEntity._name;
	     	Utils.PrintHeader();
	        Console.WriteLine("Land: " + country);
	        if (field!="" && success!=true) {
	       	 	Console.WriteLine("Bitte "+ field +" eingeben");
	        } else {
	        	Console.WriteLine();
	        }
	        Console.WriteLine();
	       	Console.Write("IBAN: ");
	        if (success==true) {
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write(Utils.SpaceShifter(iban,4));
				Console.ResetColor();
				Console.WriteLine();
	        } else {
	       		int spacesToAdd = iban.Length/4;
	       		int posSpaces = pos/4;
	       		iban = Utils.SpaceShifter(iban,4);
	        	Console.Write(iban.Substring(0,pos+posSpaces));
	        	Console.ForegroundColor = ConsoleColor.Red;
	            Console.Write(iban.Substring(pos+posSpaces,1));
	       		Console.ResetColor();
	            Console.Write(iban.Substring(pos+posSpaces+1));
	        }
		}
		
	   public string fetchBban(CountryEntity CountryEntity)
	   {
			
	   		IbanFormatKeyEntity[] IbanFormatKeyEntities = {
				new IbanFormatKeyEntity( "b","BIC/BLZ"),
				new IbanFormatKeyEntity( "k","Account Number/Kontonummer"),
				new IbanFormatKeyEntity( "d","Account Number/Kontonummer (Account-Type)"),
				new IbanFormatKeyEntity( "K","Account Number/Kontonummer (Control Number)"),
				new IbanFormatKeyEntity( "s","Branch Code"),
				new IbanFormatKeyEntity( "r","Regional Code"),
			};
	   	
	   		bool allowLetter;
			bool allowNumber;
	   		char ckiChar;
			ConsoleKeyInfo cki;
			int n;
			
	   		string bban = "";
	   		string input = "";
	   		int pos = 4;	//pos 0-3 reservered; 0-1: country code; 2-3: verification number
	   		
	   		Utils.PrintHeader();
	   		
	   		while (pos!=CountryEntity._ibanLength) {
	   			bban = CountryEntity._ibanFormat.Substring(0,4) + input + CountryEntity._ibanFormat.Substring(4).Substring(input.Length);
	   			this.fetchBbanOutput(IbanFormatKeyEntities,false,CountryEntity._countryName,CountryEntity._ibanFormat.Substring(pos,1),bban,pos);
	   			IbanFormatKeyEntity FieldEntity = this.GetFieldEntityByKey(IbanFormatKeyEntities,CountryEntity._ibanFormat.Substring(pos,1));
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
							Console.WriteLine(CountryEntity._bbanFormat.Substring(pos-4,1));
							if (CountryEntity._bbanFormat.Substring(pos-4,1)=="n") {
								allowLetter=false;
							} else if (CountryEntity._bbanFormat.Substring(pos-4,1)=="a") {
								allowNumber=false;
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
								else if (((allowNumber==true) && (ckiChar >= 48 && ckiChar <= 57)) || ((allowLetter==true) && ((ckiChar >= 65 && ckiChar <= 90))))
								{
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
