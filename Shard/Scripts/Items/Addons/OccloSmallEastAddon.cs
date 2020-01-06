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
/*   changelog.
 *   9/16/04,Lego
 *           Changed Display Name of deed 
 *
 *
 *
 */
/////////////////////////////////////////////////
//
// Automatically generated by the
// AddonGenerator script by Arya
//
/////////////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class OccloSmallEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new OccloSmallEastAddonDeed();
			}
		}

		public override bool BlocksDoors { get { return false; } }

		[Constructable]
		public OccloSmallEastAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent(2797);
			AddComponent(ac, 0, 0, 0);
			ac = new AddonComponent(2797);
			AddComponent(ac, 0, 1, 0);
			ac = new AddonComponent(2799);
			AddComponent(ac, -1, -1, 0);
			ac = new AddonComponent(2800);
			AddComponent(ac, -1, 2, 0);
			ac = new AddonComponent(2802);
			AddComponent(ac, -1, 0, 0);
			ac = new AddonComponent(2802);
			AddComponent(ac, -1, 1, 0);
			ac = new AddonComponent(2803);
			AddComponent(ac, 0, -1, 0);
			ac = new AddonComponent(2805);
			AddComponent(ac, 0, 2, 0);
			ac = new AddonComponent(2798);
			AddComponent(ac, 1, 2, 0);
			ac = new AddonComponent(2801);
			AddComponent(ac, 1, -1, 0);
			ac = new AddonComponent(2804);
			AddComponent(ac, 1, 1, 0);
			ac = new AddonComponent(2804);
			AddComponent(ac, 1, 0, 0);

		}

		public OccloSmallEastAddon(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // Version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}

	public class OccloSmallEastAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new OccloSmallEastAddon();
			}
		}

		[Constructable]
		public OccloSmallEastAddonDeed()
		{
			Name = "Occlo Small Carpet [East]";
		}

		public OccloSmallEastAddonDeed(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // Version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}