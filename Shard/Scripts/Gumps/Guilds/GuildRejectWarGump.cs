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

using System;
using Server;
using Server.Guilds;
using Server.Network;

namespace Server.Gumps
{
	public class GuildRejectWarGump : GuildListGump
	{
		public GuildRejectWarGump(Mobile from, Guild guild)
			: base(from, guild, true, guild.WarInvitations)
		{
		}

		protected override void Design()
		{
			AddHtmlLocalized(20, 10, 400, 35, 1011148, false, false); // Select the guild to reject their invitations: 

			AddButton(20, 400, 4005, 4007, 1, GumpButtonType.Reply, 0);
			AddHtmlLocalized(55, 400, 245, 30, 1011101, false, false);  // Reject war invitations.

			AddButton(300, 400, 4005, 4007, 2, GumpButtonType.Reply, 0);
			AddHtmlLocalized(335, 400, 100, 35, 1011012, false, false); // CANCEL
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			if (GuildGump.BadLeader(m_Mobile, m_Guild))
				return;

			if (info.ButtonID == 1)
			{
				int[] switches = info.Switches;

				if (switches.Length > 0)
				{
					int index = switches[0];

					if (index >= 0 && index < m_List.Count)
					{
						Guild g = (Guild)m_List[index];

						if (g != null)
						{
							m_Guild.WarInvitations.Remove(g);
							g.WarDeclarations.Remove(m_Guild);

							GuildGump.EnsureClosed(m_Mobile);

							if (m_Guild.WarInvitations.Count > 0)
								m_Mobile.SendGump(new GuildRejectWarGump(m_Mobile, m_Guild));
							else
								m_Mobile.SendGump(new GuildmasterGump(m_Mobile, m_Guild));
						}
					}
				}
			}
			else if (info.ButtonID == 2)
			{
				GuildGump.EnsureClosed(m_Mobile);
				m_Mobile.SendGump(new GuildmasterGump(m_Mobile, m_Guild));
			}
		}
	}
}