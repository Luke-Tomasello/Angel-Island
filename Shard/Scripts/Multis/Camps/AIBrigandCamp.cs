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

// /Scripts/Multis/Camps/AIBrigandCamp.cs
// Created 3/27/04 by mith
// ChangeLog
// 3/27/04 
//	Copied from BankerCamp.cs. Replaced Bankers with Brigands. We spawn 4 brigands with a wander range of 5.
//	Removed doors and sign post from wagon.

using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Multis
{
	public class AIBrigandCamp : BaseCamp
	{
		[Constructable]
		public AIBrigandCamp()
			: base(0x1F6)	// BankerCamp type, seemed most appropriate
		{
		}

		public override void AddComponents()
		{
			/* 
			BaseDoor west, east;

			AddItem( west = new LightWoodGate( DoorFacing.WestCW ), -4, 4, 7 );
			AddItem( east = new LightWoodGate( DoorFacing.EastCCW ), -3, 4, 7 );

			west.Link = east;
			east.Link = west;

			AddItem( new Sign( SignType.Mage, SignFacing.West ), -5, 5, -4 );
			*/

			AddMobile(new Brigand(), 5, -4, 3, 7);
			AddMobile(new Brigand(), 5, 4, -2, 0);
			AddMobile(new Brigand(), 5, -2, -3, 0);
			AddMobile(new Brigand(), 5, 2, -3, 0);
		}

		public AIBrigandCamp(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}