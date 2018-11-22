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
		public int _page;
		public int _pos;
		public bool _selected;
		#endregion
		
		#region accessors
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
