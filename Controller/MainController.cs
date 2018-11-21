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
		private CountryEntity[] _countryEntities;
		#endregion
		
		#region accessors
		private CountryEntity[] countryEntities
        {
            get
            {
                return this._countryEntities;
            }
            set
            {
                _countryEntities = value;
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
			this.countryEntities = MainController.CountryEntityLoader();
		}
		
		private void Handle() {
			MainMenu MainMenu = new MainMenu(this.countryEntities);
			
			MenuController mainMenu = new MenuController(MainMenu);
			while(true) {	//Main Menu runs in endless loop until exit is chosen
				mainMenu.handle();
			}
		}
		#endregion
		
		
		#region static methods
		
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
		#endregion 
		
		#region privateworkers
		private static string[] LoadCsv(string filename,string path,int tries) {
			string[] data;
			try {
				data = System.IO.File.ReadAllLines(@path+filename);
			} catch (Exception exception)  {
				if (tries==0) {
					data = new string[] { "error" };
					Utils.ThrowError("Cant Load " + filename);
       				System.Environment.Exit(1);
				} else {
					data = MainController.LoadCsv(filename, "../" + path,tries-1);
				}
			}
			return data;
		}
		
		private static CountryEntity[] CountryEntityLoader() {
			string[] countries;
			countries = MainController.LoadCsv("countries.csv","Ressources/",2);
			
			CountryEntity[] CountryEntities = new CountryEntity[countries.Length];
			int c = 0;
			foreach (string country in countries) {
				string[] data = country.Split(';');
				CountryEntities[c] = new CountryEntity(data[0],Int32.Parse(data[1]),data[2],data[3]);
				c++;
			}
			return CountryEntities;
		}
		#endregion
			
		#endregion
		
	}
}
