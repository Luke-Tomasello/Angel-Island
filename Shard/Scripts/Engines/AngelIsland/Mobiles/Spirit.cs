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

/* Scripts/Engines/AngelIsland/AILevelSystem/Mobiles/Spirit.cs
 * ChangeLog
 *	7/15/07, Adam
 *		- Update mob's STR and not hits. Updating hits 'heals' the creature, and we don't want that
 *			Basically, all players that attack the mob will increase it's STR
 *	6/15/06, Adam
 *		- Move dynamic threat stuff into common base class BaseDynamicThreat
 *		- change hue to white from see-through
 *	4/8/05, Adam
 *		add the VirtualArmor to the CoreAI global variables and make setable
 *		withing the CoreManagementConsole
 *	9/26/05, Adam
 *		More rebalancing of stats and skills
 *		Normalize with their assigned mob equivalents (pixie, orcish mage, lich, meer eternal)
 *	9/25/05, Adam
 *		Basic rebalancing of stats and skills
 *	9/16/04, Adam
 *		Minor tweaks to the AttackSkill calc.
 *	9/15/04, Adam
 *		Totally redesign the way stats and skills are calculated based on "Threat Analysis"
 *	9/11/04, Adam
 *		Remove gems and scrolls
 *	5/10/04, mith
 *		Modified the way we set this mob's hitpoints.
 *  4/29/04, mith
 *		Modified to use variables in CoreAI.
 */

using System;
using Server;
using Server.Misc;
using Server.Items;


namespace Server.Mobiles
{
	[CorpseName("a ghostly corpse")]
	public class Spirit : BaseDynamicThreat
	{
		[Constructable]
		public Spirit()
			: base(AIType.AI_Mage, FightMode.All | FightMode.Weakest, 10, 1, 0.2, 0.4)
		{
			Name = "Spirit of " + NameList.RandomName("spirit");
			Body = 128;
			Hue = 0x481;
			BaseSoundID = 0x467;
			BardImmune = true;
			BaseHits = CoreAI.SpiritFirstWaveHP;
			BaseVirtualArmor = CoreAI.SpiritFirstWaveVirtualArmor;

			Fame = 0;
			Karma = 0;

			InitStats(BaseHits, BaseVirtualArmor);

			AddItem(new LightSource());
		}

		public override void InitStats(int iHits, int iVirtualArmor)
		{
			// PIXIE Stats
			// Adam: Setting Str and not hits makes hits and str equiv
			//	Don't set hits as it 'heals' the mob, we are instead increasing STR 
			//	which will bump hits too
			// SetStr( 21, 30 );
			SetStr(iHits);
			SetDex(301, 400);
			SetInt(201, 250);
			//SetHits(BaseHits);
			SetDamage(9, 15);

			SetSkill(SkillName.EvalInt, 90.1, 100.0);
			SetSkill(SkillName.Magery, 90.1, 100.0);
			SetSkill(SkillName.Meditation, 90.1, 100.0);
			SetSkill(SkillName.MagicResist, 100.5, 150.0);
			SetSkill(SkillName.Tactics, 10.1, 20.0);
			SetSkill(SkillName.Wrestling, 10.1, 12.5);

			VirtualArmor = iVirtualArmor;
		}

		public override bool InitialInnocent { get { return true; } }

		public Spirit(Serial serial)
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