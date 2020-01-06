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
	public class MinocLargeAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new MinocLargeAddonDeed();
			}
		}

		public override bool BlocksDoors { get { return false; } }

		[Constructable]
		public MinocLargeAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent(4248);
			AddComponent(ac, -2, -2, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, -2, -1, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, -1, -2, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, -1, -1, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 0, -2, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 0, -1, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 1, -2, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 1, -1, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 2, -2, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 2, -1, 0);
			ac = new AddonComponent(4249);
			AddComponent(ac, -2, -3, 0);
			ac = new AddonComponent(4249);
			AddComponent(ac, -1, -3, 0);
			ac = new AddonComponent(4249);
			AddComponent(ac, 0, -3, 0);
			ac = new AddonComponent(4249);
			AddComponent(ac, 1, -3, 0);
			ac = new AddonComponent(4249);
			AddComponent(ac, 2, -3, 0);
			ac = new AddonComponent(4250);
			AddComponent(ac, 3, -2, 0);
			ac = new AddonComponent(4250);
			AddComponent(ac, 3, -1, 0);
			ac = new AddonComponent(4252);
			AddComponent(ac, -3, -2, 0);
			ac = new AddonComponent(4252);
			AddComponent(ac, -3, -1, 0);
			ac = new AddonComponent(4253);
			AddComponent(ac, -3, -3, 0);
			ac = new AddonComponent(4254);
			AddComponent(ac, 3, -3, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, -2, 0, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, -2, 1, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, -2, 2, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, -1, 0, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, -1, 1, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, -1, 2, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 0, 0, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 0, 1, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 0, 2, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 1, 0, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 1, 1, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 1, 2, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 2, 0, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 2, 1, 0);
			ac = new AddonComponent(4248);
			AddComponent(ac, 2, 2, 0);
			ac = new AddonComponent(4250);
			AddComponent(ac, 3, 0, 0);
			ac = new AddonComponent(4250);
			AddComponent(ac, 3, 1, 0);
			ac = new AddonComponent(4250);
			AddComponent(ac, 3, 2, 0);
			ac = new AddonComponent(4251);
			AddComponent(ac, -2, 3, 0);
			ac = new AddonComponent(4251);
			AddComponent(ac, -1, 3, 0);
			ac = new AddonComponent(4251);
			AddComponent(ac, 0, 3, 0);
			ac = new AddonComponent(4251);
			AddComponent(ac, 1, 3, 0);
			ac = new AddonComponent(4251);
			AddComponent(ac, 2, 3, 0);
			ac = new AddonComponent(4252);
			AddComponent(ac, -3, 0, 0);
			ac = new AddonComponent(4252);
			AddComponent(ac, -3, 1, 0);
			ac = new AddonComponent(4252);
			AddComponent(ac, -3, 2, 0);
			ac = new AddonComponent(4255);
			AddComponent(ac, 3, 3, 0);
			ac = new AddonComponent(4256);
			AddComponent(ac, -3, 3, 0);

		}

		public MinocLargeAddon(Serial serial)
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

	public class MinocLargeAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new MinocLargeAddon();
			}
		}

		[Constructable]
		public MinocLargeAddonDeed()
		{
			Name = "Minoc Large Carpet";
		}

		public MinocLargeAddonDeed(Serial serial)
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