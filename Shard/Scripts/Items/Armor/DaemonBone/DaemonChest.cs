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

/* ./Scripts/Items/Armor/DaemonBone/DaemonChest.cs
 *	ChangeLog :
 *	7/26/05, erlein
 *		Automated removal of AoS resistance related function calls. 5 lines removed.
*/

using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute(0x144f, 0x1454)]
	public class DaemonChest : BaseArmor
	{

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		public override int AosStrReq { get { return 60; } }
		public override int OldStrReq { get { return 40; } }

		public override int OldDexBonus { get { return -6; } }

		public override int ArmorBase { get { return 46; } }

		public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Bone; } }
		public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

		public override int LabelNumber { get { return 1041372; } } // daemon bone armor

		[Constructable]
		public DaemonChest()
			: base(0x144F)
		{
			Weight = 6.0;
			Hue = 0x648;
		}

		public DaemonChest(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);

			if (Weight == 1.0)
				Weight = 6.0;
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}
