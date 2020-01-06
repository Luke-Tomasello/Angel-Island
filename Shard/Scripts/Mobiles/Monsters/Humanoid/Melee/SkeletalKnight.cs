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

/* Scripts/Mobiles/Monsters/Humanoid/Melee/SkeletalKnight.cs
 * ChangeLog
 *  8/16/06, Rhiannon
 *		Changed speed settings to match SpeedInfo table.
 *	7/26/05, erlein
 *		Automated removal of AoS resistance related function calls. 7 lines removed.
 *	4/13/05, Kit
 *		Switch to new region specific loot model
 *	12/11/04, Pix
 *		Changed ControlSlots for IOBF.
 *  11/16/04, Froste
 *      Added IOBAlignment=IOBAlignment.Undead, added the random IOB drop to loot
 *  6/5/04, Pix
 *		Merged in 1.0RC0 code.
 */

using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Engines.IOBSystem;

namespace Server.Mobiles
{
	[CorpseName("a skeletal knight corpse")]
	public class SkeletalKnight : BaseCreature
	{
		[Constructable]
		public SkeletalKnight()
			: base(AIType.AI_Melee, FightMode.All | FightMode.Closest, 10, 1, 0.25, 0.5)
		{
			Name = "a skeletal knight";
			Body = 147;
			BaseSoundID = 451;
			IOBAlignment = IOBAlignment.Undead;
			ControlSlots = 3;

			SetStr(196, 250);
			SetDex(76, 95);
			SetInt(36, 60);

			SetHits(118, 150);

			SetDamage(8, 18);

			SetSkill(SkillName.MagicResist, 65.1, 80.0);
			SetSkill(SkillName.Tactics, 85.1, 100.0);
			SetSkill(SkillName.Wrestling, 85.1, 95.0);

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 40;
		}

		public SkeletalKnight(Serial serial)
			: base(serial)
		{
		}

		public override void GenerateLoot()
		{
			if (Core.UOAI || Core.UOAR)
			{
				switch (Utility.Random(6))
				{
					case 0: PackItem(new PlateArms()); break;
					case 1: PackItem(new PlateChest()); break;
					case 2: PackItem(new PlateGloves()); break;
					case 3: PackItem(new PlateGorget()); break;
					case 4: PackItem(new PlateLegs()); break;
					case 5: PackItem(new PlateHelm()); break;
				}

				PackPotion();
				PackPotion();
				PackItem(new Scimitar());
				PackItem(new Arrow(10));
				PackItem(new WoodenShield());
				PackGold(100, 130);
				PackItem(new Bone(Utility.Random(8, 12)));
				// Froste: 12% random IOB drop
				if (0.12 > Utility.RandomDouble())
				{
					Item iob = Loot.RandomIOB();
					PackItem(iob);
				}

				if (IOBRegions.GetIOBStronghold(this) == IOBAlignment)
				{
					// 30% boost to gold
					PackGold(base.GetGold() / 3);
				}
			}
			else
			{
				if (Core.UOSP || Core.UOMO)
				{	// http://web.archive.org/web/20021014235931/uo.stratics.com/hunters/skeletalknight.shtml
					// 50 to 150 Gold, Potions, Arrows, Gems, Platemail Armor, Wooden Shield, Weapon Carried

					if (Spawning)
					{
						PackGold(50, 150);
					}
					else
					{
						PackPotion();
						PackPotion(0.5);
						PackItem(new Arrow(10));	// TODO: no idea how many, use AI's value
						PackGem(1, .9);
						PackGem(1, .05);

						switch (Utility.Random(6))
						{
							case 0: PackItem(new PlateArms()); break;
							case 1: PackItem(new PlateChest()); break;
							case 2: PackItem(new PlateGloves()); break;
							case 3: PackItem(new PlateGorget()); break;
							case 4: PackItem(new PlateLegs()); break;
							case 5: PackItem(new PlateHelm()); break;
						}

						PackItem(new Scimitar());
						PackItem(new WoodenShield());
					}
				}
				else
				{
					if (Spawning)
					{
						switch (Utility.Random(6))
						{
							case 0: PackItem(new PlateArms()); break;
							case 1: PackItem(new PlateChest()); break;
							case 2: PackItem(new PlateGloves()); break;
							case 3: PackItem(new PlateGorget()); break;
							case 4: PackItem(new PlateLegs()); break;
							case 5: PackItem(new PlateHelm()); break;
						}

						PackItem(new Scimitar());
						PackItem(new WoodenShield());
					}

					AddLoot(LootPack.Average);
					AddLoot(LootPack.Meager);
				}
			}
		}

		public override OppositionGroup OppositionGroup
		{
			get { return OppositionGroup.FeyAndUndead; }
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
