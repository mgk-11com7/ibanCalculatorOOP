/*
 * User: derStoffel
 * Date: 01.11.2018
 * Time: 02:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace IbanOop
{
	public class IbanController
	{
		
		#region properties
		private MenuChoiceStruct[] _menuChoices;
		private CountryStruct[] _countryStructs;
		private MenuController _generateIbanMenu;
		#endregion
		
		#region accessors
		private CountryStruct[] countryStructs
        {
            get
            {
                return this._countryStructs;
            }
            set
            {
                _countryStructs = value;
            }
        }
		private MenuChoiceStruct[] menuChoices
        {
            get
            {
                return this._menuChoices;
            }
            set
            {
                _menuChoices = value;
            }
        }
		private MenuController generateIbanMenu
        {
            get
            {
                return this._generateIbanMenu;
            }
            set
            {
                _generateIbanMenu = value;
            }
        }
		#endregion
		
		#region constructors
		public IbanController()
		{
			this.Init();
		}
		#endregion
		
		#region workers
		
		#region publicworkers
		
		public void MainMenu() {
			MenuController mainMenu = new MenuController(this.menuChoices);
			while(true) {	//Main Menu runs in endless loop until exit is chosen
				mainMenu.handle();
			}
		}
		
		public void GenerateIban() {
			string bban = "12341234123412";
			GenerateIbanStruct generateIbanStruct = new GenerateIbanStruct(this.countryStructs[generateIbanMenu.pos]._countryCode,bban);
			IbanEntity iban = new IbanEntity(this.countryStructs,generateIbanStruct);
			Console.Write(iban.getIban());
			Utils.Wait();
		}
			
		#endregion
		
		#region privateworkers
			
		private CountryStruct[] CountryStructLoader() {
			string[] countries;
			countries = Utils.LoadCsv("countries.csv","Data/",2);
			
			CountryStruct[] countriesStruct = new CountryStruct[countries.Length];
			int c = 0;
			foreach (string country in countries) {
				string[] data = country.Split(';');
				countriesStruct[c] = new CountryStruct(data[0],Int32.Parse(data[1]),data[2],data[3]);
				c++;
			}
			return countriesStruct;
		}
		
		private void Init() {
			MenuChoiceStruct[] menuElements= {
				new MenuChoiceStruct("IBAN generieren",this.GenerateIbanController),
				new MenuChoiceStruct("IBAN validieren",this.ValidateIban),
				new MenuChoiceStruct("Programm beenden",Utils.Exit),
			};
			this.menuChoices = menuElements;
			this.countryStructs = this.CountryStructLoader();
		}
		
		private void GenerateIbanController() {
			MenuChoiceStruct[] menuElements= new MenuChoiceStruct[this.countryStructs.Length];
			for(int i = 0; i < this.countryStructs.Length; i++)
			{
				menuElements[i] =  new MenuChoiceStruct(this.countryStructs[i]._countryName,this.GenerateIban);
			}
			this.generateIbanMenu = new MenuController(menuElements);
			this.generateIbanMenu.handle();
		}
		
		private void ValidateIban() {
			IbanEntity iban = new IbanEntity(this.countryStructs,"DE0712341234123412");
			
			if (true==iban.IsValid()) {
				Console.Write("given iban is valid!");
			} else {
				Console.Write("given iban is NOT valid!");
			}
			Utils.Wait();
		}
			
		#endregion
			
		#endregion
		
	}
}
