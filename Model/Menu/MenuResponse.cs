/*
 * Author: Stefan Sander
 * Date: 22.11.2018
 */
using System;

namespace IbanOop
{
	public class MenuResponse
	{
		#region properties
			private int _page;
			private int _pos;
			private bool _selected;
		#endregion
		
		#region accessors
		public int GetPage() {
			return this._page;
		}
		public int GetPos() {
			return this._pos;
			
		}
		public bool GetSelected() {
			return this._selected;
		}
		#endregion
		
		#region constructors
			public MenuResponse(int page,int pos,bool selected)
			{
				this._page = page;
				this._pos = pos;
				this._selected = selected;
			}
		#endregion
		
		#region workers
		#endregion
	}
}
