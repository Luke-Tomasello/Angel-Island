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
 *   08/03/06,Rhiannon
 *		Initial creation
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
	public class DisplayCaseMediumSouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new DisplayCaseMediumSouthAddonDeed();
			}
		}

		[Constructable]
		public DisplayCaseMediumSouthAddon()
		{
			AddComponent(new AddonComponent(2723), -1, -1, 0);
			AddComponent(new AddonComponent(2723), -1, -1, 6);
			AddComponent(new AddonComponent(2832), -1, -1, 3);
			AddComponent(new AddonComponent(2722), 0, -1, 6);
			AddComponent(new AddonComponent(2839), 0, -1, 3);
			AddComponent(new AddonComponent(2722), 1, -1, 6);
			AddComponent(new AddonComponent(2839), 1, -1, 3);
			AddComponent(new AddonComponent(2724), 2, -1, 0);
			AddComponent(new AddonComponent(2724), 2, -1, 6);
			AddComponent(new AddonComponent(2835), 2, -1, 3);
			AddComponent(new AddonComponent(2720), 1, 1, 6);
			AddComponent(new AddonComponent(2837), 1, 1, 3);
			AddComponent(new AddonComponent(2831), 1, 0, 3);
			AddComponent(new AddonComponent(2831), 0, 0, 3);
			AddComponent(new AddonComponent(2720), 0, 1, 6);
			AddComponent(new AddonComponent(2837), 0, 1, 3);
			AddComponent(new AddonComponent(2721), -1, 0, 6);
			AddComponent(new AddonComponent(2838), -1, 0, 3);
			AddComponent(new AddonComponent(2719), 2, 0, 6);
			AddComponent(new AddonComponent(2836), 2, 0, 3);
			AddComponent(new AddonComponent(2840), 2, 1, 0);
			AddComponent(new AddonComponent(2840), 2, 1, 6);
			AddComponent(new AddonComponent(2833), 2, 1, 3);
			AddComponent(new AddonComponent(2725), -1, 1, 0);
			AddComponent(new AddonComponent(2725), -1, 1, 6);
			AddComponent(new AddonComponent(2834), -1, 1, 3);
			AddonComponent ac = null;
			ac = new AddonComponent(2723);
			AddComponent(ac, -1, -1, 0);
			ac = new AddonComponent(2722);
			AddComponent(ac, 1, -1, 6);
			ac = new AddonComponent(2722);
			AddComponent(ac, 0, -1, 6);
			ac = new AddonComponent(2721);
			AddComponent(ac, -1, 0, 6);
			ac = new AddonComponent(2723);
			AddComponent(ac, -1, -1, 6);
			ac = new AddonComponent(2831);
			AddComponent(ac, 0, 0, 3);
			ac = new AddonComponent(2839);
			AddComponent(ac, 1, -1, 3);
			ac = new AddonComponent(2839);
			AddComponent(ac, 0, -1, 3);
			ac = new AddonComponent(2838);
			AddComponent(ac, -1, 0, 3);
			ac = new AddonComponent(2832);
			AddComponent(ac, -1, -1, 3);

		}

		public DisplayCaseMediumSouthAddon(Serial serial)
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

	public class DisplayCaseMediumSouthAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new DisplayCaseMediumSouthAddon();
			}
		}

		[Constructable]
		public DisplayCaseMediumSouthAddonDeed()
		{
			Name = "medium display case (south)";
		}

		public DisplayCaseMediumSouthAddonDeed(Serial serial)
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