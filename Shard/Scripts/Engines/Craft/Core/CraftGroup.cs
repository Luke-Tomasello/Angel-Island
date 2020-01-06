/*
 *	This program is the CONFIDENTIAL and PROPRIETARY property 
 *	of Tomasello Software LLC. Any unauthorized use, reproduction or
 *	transfer of this computer program is strictly prohibited.
 *
 *      Copyright (c) 2004 Tomasello Software LLC.
 *	This is an unpublished work, and is subject to limited distribution and
 *	restricted disclosure only. ALL RIGHTS RESERVED.
 *
 *			RESTRICTED RIGHTS LEGEND
 *	Use, duplication, or disclosure by the Government is subject to
 *	restrictions set forth in subparagraph (c)(1)(ii) of the Rights in
 * 	Technical Data and Computer Software clause at DFARS 252.227-7013.
 *
 *	Angel Island UO Shard	Version 1.0
 *			Release A
 *			March 25, 2004
 */

using System;

namespace Server.Engines.Craft
{
	public class CraftGroup
	{
		private CraftItemCol m_arCraftItem;

		private string m_NameString;
		private int m_NameNumber;

		public CraftGroup(string groupName)
		{
			m_NameString = groupName;
			m_arCraftItem = new CraftItemCol();
		}

		public CraftGroup(int groupName)
		{
			m_NameNumber = groupName;
			m_arCraftItem = new CraftItemCol();
		}

		public void AddCraftItem(CraftItem craftItem)
		{
			m_arCraftItem.Add(craftItem);
		}

		public CraftItemCol CraftItems
		{
			get { return m_arCraftItem; }
		}

		public string NameString
		{
			get { return m_NameString; }
		}

		public int NameNumber
		{
			get { return m_NameNumber; }
		}
	}
}