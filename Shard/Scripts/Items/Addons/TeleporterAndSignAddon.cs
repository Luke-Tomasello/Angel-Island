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

/* CHANGELOG
 *	11/30/05,Adam
 *		First time check in of the Teleporter platform
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
	public class TeleporterAndSignAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new TeleporterAndSignAddonDeed();
			}
		}

		[Constructable]
		public TeleporterAndSignAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent(1876);
			AddComponent(ac, 0, 0, 0);
			ac = new AddonComponent(1872);
			AddComponent(ac, 1, 0, 0);
			ac = new AddonComponent(7977);
			AddComponent(ac, -2, -1, 15);
			ac = new AddonComponent(9);
			AddComponent(ac, -2, -1, 0);
			ac = new AddonComponent(14170);
			AddComponent(ac, 2, 0, 6);
			ac = new AddonComponent(1878);
			AddComponent(ac, 3, 1, 0);
			ac = new AddonComponent(1880);
			AddComponent(ac, 0, 1, 0);
			ac = new AddonComponent(1873);
			AddComponent(ac, 1, 1, 0);
			ac = new AddonComponent(1873);
			AddComponent(ac, 2, 1, 0);
			ac = new AddonComponent(1877);
			AddComponent(ac, 0, -1, 0);
			ac = new AddonComponent(1879);
			AddComponent(ac, 3, -1, 0);
			ac = new AddonComponent(1875);
			AddComponent(ac, 2, -1, 0);
			ac = new AddonComponent(1875);
			AddComponent(ac, 1, -1, 0);
			ac = new AddonComponent(1872);
			AddComponent(ac, 2, 0, 0);
			ac = new AddonComponent(1874);
			AddComponent(ac, 3, 0, 0);

		}

		public TeleporterAndSignAddon(Serial serial)
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

	public class TeleporterAndSignAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new TeleporterAndSignAddon();
			}
		}

		[Constructable]
		public TeleporterAndSignAddonDeed()
		{
			Name = "TeleporterAndSign";
		}

		public TeleporterAndSignAddonDeed(Serial serial)
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