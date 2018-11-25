/*
 * Author: Stefan Sander
 * Date: 21.11.2018
 */
using System;

namespace IbanOop
{
	public class ValidateIbanIOHandler : AbstractIOHandler
	{
		#region properties
		private CountryEntityController _countryEntityController;
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors
		public ValidateIbanIOHandler(CountryEntityController CountryEntityController) {
			this._countryEntityController = CountryEntityController;
		}
		#endregion
		
		#region workers
	   	public void ValidateIbanOutput(bool success,CountryEntity CountryEntity,string iban,bool showResult,int pos) {
			IbanFormatKeyEntity FieldEntity;
			string field = null;
			string ibanFormatLine = CountryEntity._ibanFormat;
		  	PrintHeader();
		  	if (showResult==false) {
				if (pos<2) {
	   	 		Console.WriteLine();
	   	 		Console.WriteLine();
	       	 		field = "Ländercode";
				}
			  	if (CountryEntity._ibanLength==0) {	
		  			
		  		} else { 
			  		if (CountryEntity._ibanLength!=pos) {
						FieldEntity = GetFieldEntityByKey(_ibanFormatKeyEntities,CountryEntity._ibanFormat.Substring(pos,1));
						field = FieldEntity._name;
			  		}
			  		if (pos<4) {
			       	 	field = "Prüfziffer";
			  		}
			  		Console.WriteLine("Land: " + CountryEntity._countryName);
			  		Console.WriteLine("IBAN Format: " + SpaceShifter(ibanFormatLine,4));
			  	}
		        if (field!=null && field!="") {
		       	 	Console.WriteLine("Bitte "+ field +" eingeben");
		        }
			  	Console.Write("IBAN: " + SpaceShifter(iban,4));
		  	} else  {
	   	 		Console.WriteLine();
	   	 		Console.WriteLine();
	   	 		Console.WriteLine();
		      	if (success==true) {
		  			Console.Write("IBAN: ");
		        	Console.ForegroundColor = ConsoleColor.Green;
		  			Console.Write(SpaceShifter(iban,4));
		   			Console.ResetColor();
		      		Console.Write(" ist");
		        	Console.ForegroundColor = ConsoleColor.Green;
		      		Console.Write(" VALIDE");
		      	} else {
		  			Console.Write("IBAN: ");
		        	Console.ForegroundColor = ConsoleColor.Red;
		  			Console.Write(SpaceShifter(iban,4));
		   			Console.ResetColor();
		      		Console.Write(" ist");
		        	Console.ForegroundColor = ConsoleColor.Red;
		      		Console.Write(" NICHT VALIDE");
		      	}
	   	 		Console.WriteLine();
	   	 		Console.WriteLine();
		  	}
		   	Console.ResetColor();
		}
			
		   public string ValidateIbanInput()
		   {
		   	CountryEntityController CountryEntityController = this._countryEntityController;
			CountryEntity CountryEntity = new CountryEntity();
			ConsoleKeyInfo key;
			string ibanFormat = "";
			string input="";
			char cki;
			int pos = 0;
			int n;
			bool allowLetter=true;
			bool allowNumber=false;
			bool isNumeric = false;
			while (ibanFormat.Length==0 || pos!=ibanFormat.Length) {
		    	if (pos<2) {	//CountryAbbreviation Input
					allowLetter=true;
					allowNumber=false;
				}
		    	if (pos==2) {	// after CountryAbbreviation typed in
		    		CountryEntity = CountryEntityController.GetCountryEntityByCountryAbbreviation(input);
		    		if (CountryEntity._countryName!=null) {
		    			ibanFormat =  CountryEntity._ibanFormat;
		    		}  else {}
		    	}
		    	if (pos==2 || pos==3) {	//Verification Number
					allowLetter=false;
					allowNumber=true;
				} else if (3<pos) {
					allowNumber=true;
					allowLetter=true;
	       			if (CountryEntity._bbanFormat.Substring(pos-4,1)=="n") {
						allowLetter=false;
					} else { }
					if (CountryEntity._bbanFormat.Substring(pos-4,1)=="a") {
						allowNumber=false;
					} else { }
					isNumeric = int.TryParse(CountryEntity._ibanFormat.Substring(pos,1), out n);
		    	}
				if (pos==2 && CountryEntity._countryName==null) {
				        	input = input.Substring(0,input.Length-1);
				        	pos--;
				} else {
						
					if (isNumeric==true) {	// costa rica fix (costa rica bban always begins with a "0")
			  			input = input + CountryEntity._ibanFormat.Substring(pos,1);
			      	   	pos++;
					} else {
						this.ValidateIbanOutput(false,CountryEntity,input,false,pos);
				        key = Console.ReadKey(true);
				        cki = key.KeyChar;
				        if (key.Key.ToString()=="Backspace" && pos>0) {
				        	input = input.Substring(0,input.Length-1);
				        	pos--;
				        } else {
					       if (
					       	(cki >= 48 && cki <= 57 && allowNumber==true)
					       	|| (cki >= 65 && cki <= 90 && allowLetter==true)
					       	|| (cki >= 97 && cki <= 122 && allowLetter==true)
					       ) {
					  			input = input + cki.ToString().ToUpper();
					      	   	pos++;
				        	} else {
				        		//input not valid
				        	}
				        }
					}
				}
			}
			this.ValidateIbanOutput(false,CountryEntity,input,false,pos);
			return input;
		   }
		#endregion
	}
}
