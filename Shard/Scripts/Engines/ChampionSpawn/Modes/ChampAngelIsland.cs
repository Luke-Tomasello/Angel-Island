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

/* Scripts/Engines/ChampionSpawn/Modes/ChampAngelIsland.cs
 *	ChangeLog:
 *  28/12/06, plasma
 *      Overrode the RestartDelay property to allow read/write from
 *      the static/xml global values in CoreAI.cs
 *	11/01/2006, plasma
 *		Added WipeMonsters() back in due to ebb and flow system
 *	10/29/2006, plasma
 *		Removed WipeMonsters call as added to core engine
 *	10/29/2006, plasma
 *		Added WipeMonsters() call in AdvanceLevel()
 *	10/28/2006, plasma
 *		Initial creation
 * 
 **/
using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ChampionSpawn
{
	public class ChampAngelIsland : ChampEngine
	{
		//28/12/06, pla
		//ovveride this property so we can get/set the CoreAI statics,
		//ONLY IF the spawn selected is the AI guard or AI spirit spawn.
		//otherwise we just assume the default delay of 5 minutes.
		[CommandProperty(AccessLevel.GameMaster)]
		public override TimeSpan RestartDelay
		{
			get
			{
				if (m_Type == ChampLevelData.SpawnTypes.AI_Guard)
					return TimeSpan.FromMinutes(CoreAI.GuardSpawnRestartDelay);
				else if (m_Type == ChampLevelData.SpawnTypes.AI_Escape)
					return TimeSpan.FromMinutes(CoreAI.SpiritRestartDelay);
				else
					return base.RestartDelay;
			}
			set
			{
				if (m_Type == ChampLevelData.SpawnTypes.AI_Guard)
					CoreAI.GuardSpawnRestartDelay = value.Minutes;
				else if (m_Type == ChampLevelData.SpawnTypes.AI_Escape)
					CoreAI.SpiritRestartDelay = value.Minutes;

				base.RestartDelay = value;
			}
		}

		[Constructable]
		public ChampAngelIsland()
			: base()
		{
			// restart timer
			m_bRestart = true;

			// set deault spawn type to AI_Guard
			SpawnType = ChampLevelData.SpawnTypes.AI_Guard;
		}

		public ChampAngelIsland(Serial serial)
			: base(serial)
		{
		}

		// #region serialize

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0);

		}
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			switch (version)
			{
				case 0: break;
			}
		}
		// #endregion

		protected override void AdvanceLevel()
		{
			// if the champ has just completed....
			if (IsFinalLevel)
			{
				// make exit gate (old code)
				if (SpawnType == ChampLevelData.SpawnTypes.AI_Escape)
				{
					Item aiExit = new AIEscapeExit();
					Item prettyshiney = new PrettyShiney();
					prettyshiney.Movable = false;
					prettyshiney.MoveToWorld(new Point3D(5753, 324, 21), Map);
					aiExit.MoveToWorld(new Point3D(5753, 324, 21), Map);

					new DeletionTimera(aiExit, prettyshiney, TimeSpan.FromSeconds(CoreAI.SpiritPortalAvailablity)).Start();
				}
				else if (SpawnType == ChampLevelData.SpawnTypes.AI_Guard)
				{
					Item CaveTele = new AICaveEntrance();
					Item prettyshiney = new PrettyShiney();
					prettyshiney.Movable = false;
					prettyshiney.MoveToWorld(new Point3D(311, 786, 0), Map);
					CaveTele.MoveToWorld(new Point3D(311, 786, 0), Map);

					new DeletionTimerb(CaveTele, prettyshiney, TimeSpan.FromSeconds(CoreAI.CavePortalAvailability)).Start();
				}
			}

			//wipe the spawn on level up
			WipeMonsters();

			// call base 
			base.AdvanceLevel();
		}



		// plasma:  deletion timers and prettyshiney below lifted from 
		// orignal angel island level system code
		private class DeletionTimera : Timer
		{
			private Item m_Telea;
			private Item m_Shineya;

			public DeletionTimera(Item tele, Item sparkles, TimeSpan delayspan)
				: base(delayspan)
			{
				m_Telea = tele;
				m_Shineya = sparkles;
				Priority = TimerPriority.TwentyFiveMS;
			}

			protected override void OnTick()
			{
				m_Telea.Delete();
				m_Shineya.Delete();
				this.Stop();
			}
		}

		//Transient Sparkle...
		//doesn't get saved on world load? (old code)
		private class PrettyShiney : Item
		{
			public PrettyShiney()
				: base(0x375A)
			{
			}
			public PrettyShiney(Serial serial)
				: base(serial)
			{
			}
			public override void Serialize(GenericWriter writer)
			{
				base.Serialize(writer);
			}
			public override void Deserialize(GenericReader reader)
			{
				base.Deserialize(reader);

				System.Console.WriteLine("Deleting PrettyShiney transient sparkle.");
				this.Delete();
			}
		}


		private class DeletionTimerb : Timer
		{
			private Item m_Teleb;
			private Item m_Shineyb;

			public DeletionTimerb(Item tele, Item sparkles, TimeSpan delayspan)
				: base(delayspan)
			{
				m_Teleb = tele;
				m_Shineyb = sparkles;
				Priority = TimerPriority.TwentyFiveMS;
			}

			protected override void OnTick()
			{
				m_Teleb.Delete();
				m_Shineyb.Delete();
				this.Stop();
			}
		}

	}
}
