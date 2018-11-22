/*
 * Author: Stefan Sander
 * Date: 21.11.2018
 */
using System;

namespace IbanOop
{
	public class ValidateIbanIOHandler
	{
		#region properties
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors
		#endregion
		
		#region workers
		   public void ValidateIbanOutput(bool success,string ibanFormatLine,string iban,bool showResult) {
			  	OutputUtilities.PrintHeader();
			  	if (ibanFormatLine.Length==0) {
			  		Console.WriteLine("");
			  	} else {
			  		Console.WriteLine("IBAN Format: " + OutputUtilities.SpaceShifter(ibanFormatLine,4));
			  	}
			  	if (showResult==false) {
			  		Console.Write("IBAN: " + OutputUtilities.SpaceShifter(iban,4));
			  	} else  {
			      	if (success==true) {
			  			Console.Write("IBAN: ");
			        	Console.ForegroundColor = ConsoleColor.Green;
			  			Console.Write(OutputUtilities.SpaceShifter(iban,4));
			   			Console.ResetColor();
			      		Console.Write(" ist");
			        	Console.ForegroundColor = ConsoleColor.Green;
			      		Console.Write(" VALIDE");
			      	} else {
			  			Console.Write("IBAN: ");
			        	Console.ForegroundColor = ConsoleColor.Red;
			  			Console.Write(OutputUtilities.SpaceShifter(iban,4));
			   			Console.ResetColor();
			      		Console.Write(" ist");
			        	Console.ForegroundColor = ConsoleColor.Red;
			      		Console.Write(" NICHT VALIDE");
			      	}
			  	}
			   	Console.ResetColor();
			  	Console.WriteLine("");
			}
			
		   public string ValidateIbanInput(CountryEntityController CountryEntityController)
		   {
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
						this.ValidateIbanOutput(false,ibanFormat,input,false);
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
			this.ValidateIbanOutput(false,ibanFormat,input,false);
			return input;
		   }
		#endregion
	}
}
