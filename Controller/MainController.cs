/*
 * Author: Stefan Sander
 * Date: 01.11.2018
 * Time: 02:18
 * 
 */
using System;

namespace IbanOop
{
	public class MainController
	{
		
		#region properties
		private CountryEntity[] _countryStructs;
		#endregion
		
		#region accessors
		private CountryEntity[] countryStructs
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
		#endregion
		
		#region constructors
		public MainController()
		{
			this.Init();
			this.Handle();
		}
		#endregion
		
		#region workers
		#region publicworkers
		private void Init() {
			this.countryStructs = this.CountryEntityLoader();
		}
		
		private void Handle() {
			MenuChoiceEntity[] menuElements= {
				new MenuChoiceEntity("IBAN generieren",this.GenerateIbanRoute),
				new MenuChoiceEntity("IBAN validieren",this.ValidateIbanRoute),
				new MenuChoiceEntity("Programm beenden",Utils.Exit),
			};
			MenuController mainMenu = new MenuController(menuElements);
			while(true) {	//Main Menu runs in endless loop until exit is chosen
				mainMenu.handle();
			}
		}
		#endregion
		
		#region privateworkers
		
		
		private string[] LoadCsv(string filename,string path,int tries) {
			string[] data;
			
			try {
				data = System.IO.File.ReadAllLines(@path+filename);
			} catch (Exception exception)  {
				if (tries==0) {
					data = new string[] { "error" };
					Utils.ThrowError("Cant Load " + filename);
					Utils.Wait();
					Utils.Exit();
				} else {
					data = this.LoadCsv(filename, "../"+path,tries-1);
				}
			}
			return data;
		}
		
		private CountryEntity[] CountryEntityLoader() {
			string[] countries;
			countries = this.LoadCsv("countries.csv","Data/",2);
			
			CountryEntity[] countriesStruct = new CountryEntity[countries.Length];
			int c = 0;
			foreach (string country in countries) {
				string[] data = country.Split(';');
				countriesStruct[c] = new CountryEntity(data[0],Int32.Parse(data[1]),data[2],data[3]);
				c++;
			}
			return countriesStruct;
		}
		
		
		private void GenerateIbanRoute() {
			GenerateIbanController ibanGenerator = new GenerateIbanController(this.countryStructs);
		}
		
		private void ValidateIbanRoute() {
			ValidateIbanController ibanValidator = new ValidateIbanController(this.countryStructs);
		}
			
		#endregion
			
		#endregion
		
	}
}
