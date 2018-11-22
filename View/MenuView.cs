/*
 * Author: Stefan Sander
 * Date: 21.11.2018
 */
using System;

namespace IbanOop
{
	public class MenuView
	{
		#region properties
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors
			public MenuView()
			{
			}
			
		public static MenuResponse input(MenuChoiceEntity[] elements,int maxElementsPerPage,int page,int pos,string elementSelectedPrefix,string elementNotSelectedPrefix) {
		    ConsoleKeyInfo cki;
		    cki = Console.ReadKey(true);
		    if ((cki.Key.ToString() == "DownArrow") || (cki.Key.ToString() == "RightArrow"))
		    {
		    	pos++;
		        if (pos > elements.Length-1)
		        {
		        	pos=0;
		        }
		    }
		    else if ((cki.Key.ToString() == "UpArrow") || (cki.Key.ToString() == "LeftArrow"))
		    {
		    	pos--;
		        if (pos < 0)
		        {
		        	pos = elements.Length-1;
		        }
		    }
		    else if (cki.Key.ToString() == "Enter")
		    {
		    	return new MenuResponse(page,pos,true);
		    }
		    while (pos+1 >maxElementsPerPage*page) {
		    	page++;
			}
			while (pos+1 < maxElementsPerPage*page-maxElementsPerPage+1) {
		    	page--;
			}
	    	return new MenuResponse(page,pos,false);
		}
			
			public static void output(MenuChoiceEntity[] elements,int maxElementsPerPage,int page,int pos,string elementSelectedPrefix,string elementNotSelectedPrefix) {
			float floatMaxPages = (float) elements.Length/(float) maxElementsPerPage;
			Utils.PrintHeader();
			for(int i=0;i<elements.Length;i++) {
		    	if (maxElementsPerPage*page>i && i+1>maxElementsPerPage*(page-1))  {
					
					if (i == pos) {
						Console.Write(elementSelectedPrefix);
					} else {
						Console.Write(elementNotSelectedPrefix);
					}
					Console.Write(elements[i]._caption + "\n");
				}
			}
		    if (Math.Ceiling(floatMaxPages)>1) {
		   	 	Console.WriteLine("Seite " + page.ToString() + " von " + Math.Ceiling(floatMaxPages));
		    }
		}
		#endregion
		
		#region workers
		#endregion
	}
}
