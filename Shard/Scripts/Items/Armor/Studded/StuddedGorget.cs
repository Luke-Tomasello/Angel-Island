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

/* Scripts/Items/Armor/Studded/StuddedGorget.cs
* ChangeLog
*	7/26/05, erlein
*		Automated removal of AoS resistance related function calls. 10 lines removed.
*	9/11/04, Pigpen
*	Add Wyrm Skin variant of this Studded piece.
*/

using System;
using Server.Items;
using System.Collections;
using Server.Network;

namespace Server.Items
{
	public class StuddedGorget : BaseArmor
	{

		public override int InitMinHits { get { return 35; } }
		public override int InitMaxHits { get { return 45; } }

		public override int AosStrReq { get { return 25; } }
		public override int OldStrReq { get { return 25; } }

		public override int ArmorBase { get { return 16; } }

		public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

		[Constructable]
		public StuddedGorget()
			: base(0x13D6)
		{
			Weight = 1.0;
		}

		public StuddedGorget(Serial serial)
			: base(serial)
		{
		}

// old name removed, see base class

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			if (Weight == 2.0)
				Weight = 1.0;
		}
	}

	public class WyrmSkinGorget : BaseArmor
	{

		public override int InitMinHits { get { return 35; } }
		public override int InitMaxHits { get { return 45; } }

		public override int AosStrReq { get { return 25; } }
		public override int OldStrReq { get { return 25; } }

		public override int ArmorBase { get { return 16; } }

		public override ArmorMaterialType MaterialType { get { return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource { get { return CraftResource.RegularLeather; } }

		[Constructable]
		public WyrmSkinGorget()
			: base(0x13D6)
		{
			Weight = 1.0;
			Hue = 1367;
			ProtectionLevel = ArmorProtectionLevel.Guarding;
			Durability = ArmorDurabilityLevel.Massive;
			if (Utility.RandomDouble() < 0.20)
				Quality = ArmorQuality.Exceptional;
			Name = "Wyrm Skin Gorget";
		}

		public WyrmSkinGorget(Serial serial)
			: base(serial)
		{
		}

		// Special version that DOES NOT show armor attributes and tags
		public override void OnSingleClick(Mobile from)
		{
			ArrayList attrs = new ArrayList();

			int number;

			if (Name == null)
			{
				number = LabelNumber;
			}
			else
			{
				this.LabelTo(from, Name);
				number = 1041000;
			}

			if (attrs.Count == 0 && Crafter == null && Name != null)
				return;

			EquipmentInfo eqInfo = new EquipmentInfo(number, Crafter, false, (EquipInfoAttribute[])attrs.ToArray(typeof(EquipInfoAttribute)));

			from.Send(new DisplayEquipmentInfo(this, eqInfo));

		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int)0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			if (Weight == 2.0)
				Weight = 1.0;
		}
	}
}
