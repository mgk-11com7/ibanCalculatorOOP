/*
 * Created by SharpDevelop.
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
		#endregion
		
		#region constructors
		public IbanController()
		{
			this.Init();
		}
		#endregion
		
		#region workers
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
				new MenuChoiceStruct("IBAN generieren",this.GenerateIban),
				new MenuChoiceStruct("IBAN validieren",this.ValidateIban),
				new MenuChoiceStruct("Programm beenden",Utils.Exit),
			};
			this.menuChoices = menuElements;
			this.countryStructs = this.CountryStructLoader();
		}
		
		public void Menu() {
			new Menu(this.menuChoices);
		}
		
		private void GenerateIban() {
			GenerateIbanStruct generateIbanStruct = new GenerateIbanStruct("DE","12341234123412");
			Iban iban = new Iban(generateIbanStruct);
			Console.Write(iban.getIban());
			Utils.Wait();
		}
		
		private void ValidateIban() {
			Iban iban = new Iban("DE0712341234123412");
			
			if (true==iban.IsValid()) {
				Console.Write("given iban is valide!");
			} else {
				Console.Write("given iban is NOT valide!");
			}
			Utils.Wait();
		}
		
		#endregion
	}
}
