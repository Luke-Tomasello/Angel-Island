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

/* Scripts/Mobiles/Monsters/Elemental/Magic/IceElemental.cs
 * ChangeLog
 *  8/16/06, Rhiannon
 *		Changed speed settings to match SpeedInfo table.
 *	7/26/05, erlein
 *		Automated removal of AoS resistance related function calls. 7 lines removed.
 *	7/6/04, Adam
 *		1. implement Jade's new Category Based Drop requirements
 *  6/5/04, Pix
 *		Merged in 1.0RC0 code.
 */

using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName("an ice elemental corpse")]
	public class IceElemental : BaseCreature
	{
		[Constructable]
		public IceElemental()
			: base(AIType.AI_Mage, FightMode.All | FightMode.Closest, 10, 1, 0.25, 0.5)
		{
			Name = "an ice elemental";
			Body = 161;
			BaseSoundID = 268;

			SetStr(156, 185);
			SetDex(96, 115);
			SetInt(171, 192);

			SetHits(94, 111);

			SetDamage(10, 21);

			SetSkill(SkillName.EvalInt, 10.5, 60.0);
			SetSkill(SkillName.Magery, 10.5, 60.0);
			SetSkill(SkillName.MagicResist, 30.1, 80.0);
			SetSkill(SkillName.Tactics, 70.1, 100.0);
			SetSkill(SkillName.Wrestling, 60.1, 100.0);

			Fame = 4000;
			Karma = -4000;

			VirtualArmor = 40;
		}

		public override AuraType MyAura { get { return AuraType.Ice; } }

		public IceElemental(Serial serial)
			: base(serial)
		{
		}

		public override void GenerateLoot()
		{
			if (Core.UOAI || Core.UOAR)
			{
				PackGem();
				PackGem();

				PackGold(130, 190);
				PackMagicEquipment(1, 2, 0.10, 0.10);
				PackItem(new BlackPearl(2));
				PackReg(5);

				// Category 2 MID
				PackMagicItem(1, 1, 0.05);
			}
			else
			{
				if (Core.UOSP || Core.UOMO)
				{	// http://web.archive.org/web/20020403072321/uo.stratics.com/hunters/iceelemental.shtml
					// 150 to 300 Gold, Arrows, Gems, Reagents
					if (Spawning)
					{
						PackGold(150, 300);
					}
					else
					{
						PackItem(new Arrow(Utility.RandomMinMax(1, 4)));
						PackGem(Utility.RandomMinMax(1, 4));
						PackItem(new BlackPearl());
						PackReg(3);
					}
				}
				else
				{
					if (Spawning)
					{
						PackItem(new BlackPearl());
						PackReg(3);
					}

					AddLoot(LootPack.Average, 2);
					AddLoot(LootPack.Gems, 2);
				}
			}

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
