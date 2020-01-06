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

/* ./Scripts/Mobiles/Animals/Felines/Panther.cs
 *	ChangeLog :
 *  8/16/06, Rhiannon
 *		Changed speed settings to match SpeedInfo table.
 *	7/26/05, erlein
 *		Automated removal of AoS resistance related function calls. 5 lines removed.
*/

using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName("a panther corpse")]
	public class Panther : BaseCreature
	{
		[Constructable]
		public Panther()
			: base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.25, 0.5)
		{
			Name = "a panther";
			Body = 0xD6;
			Hue = 0x901;
			BaseSoundID = 0x462;

			SetStr(61, 85);
			SetDex(86, 105);
			SetInt(26, 50);

			SetHits(37, 51);
			SetMana(0);

			SetDamage(4, 12);

			SetSkill(SkillName.MagicResist, 15.1, 30.0);
			SetSkill(SkillName.Tactics, 50.1, 65.0);
			SetSkill(SkillName.Wrestling, 50.1, 65.0);

			Fame = 450;
			Karma = 0;

			VirtualArmor = 16;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 53.1;
		}

		public override int Meat { get { return 1; } }
		public override int Hides { get { return 10; } }
		public override FoodType FavoriteFood { get { return FoodType.Meat | FoodType.Fish; } }
		public override PackInstinct PackInstinct { get { return PackInstinct.Feline; } }

		public Panther(Serial serial)
			: base(serial)
		{
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
		}
	}
}
