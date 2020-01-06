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
/* ChangeLog:
 * *  12/28/05, Kit
 *		Added day/night light checking to turn off light source causeing lag
	6/5/04, Pix
		Merged in 1.0RC0 code.
*/

using System;
using Server.Targeting;
using Server.Network;
using Server.Misc;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells.Seventh
{
    public class EnergyFieldSpell : Spell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Energy Field", "In Sanct Grav",
                SpellCircle.Seventh,
                221,
                9022,
                false,
                Reagent.BlackPearl,
                Reagent.MandrakeRoot,
                Reagent.SpidersSilk,
                Reagent.SulfurousAsh
            );

        public EnergyFieldSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override bool CheckCast()
        {

            return base.CheckCast();
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(IPoint3D p)
        {
            if (!Caster.CanSee(p))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (SpellHelper.CheckTown(p, Caster) && CheckSequence())
            {
                SpellHelper.Turn(Caster, p);

                SpellHelper.GetSurfaceTop(ref p);

                int dx = Caster.Location.X - p.X;
                int dy = Caster.Location.Y - p.Y;
                int rx = (dx - dy) * 44;
                int ry = (dx + dy) * 44;

                bool eastToWest;

                if (rx >= 0 && ry >= 0)
                {
                    eastToWest = false;
                }
                else if (rx >= 0)
                {
                    eastToWest = true;
                }
                else if (ry >= 0)
                {
                    eastToWest = true;
                }
                else
                {
                    eastToWest = false;
                }

                Effects.PlaySound(p, Caster.Map, 0x20B);

                TimeSpan duration;

                if (Core.AOS)
                    duration = TimeSpan.FromSeconds((15 + (Caster.Skills.Magery.Fixed / 5)) / 7);
                else
                    duration = TimeSpan.FromSeconds(Caster.Skills[SkillName.Magery].Value * 0.28 + 2.0); // (28% of magery) + 2.0 seconds

                int itemID = eastToWest ? 0x3946 : 0x3956;

                for (int i = -2; i <= 2; ++i)
                {
                    Point3D loc = new Point3D(eastToWest ? p.X + i : p.X, eastToWest ? p.Y : p.Y + i, p.Z);
                    bool canFit = SpellHelper.AdjustField(ref loc, Caster.Map, 12, false);

                    if (!canFit)
                        continue;

                    Item item = new InternalItem(loc, Caster.Map, duration, itemID, Caster);

                    int hours, minutes;

                    Server.Items.Clock.GetTime(Caster.Map, loc.X, loc.Y, out hours, out minutes);

                    if (hours >= 6 && hours < 22 && item.Light != LightType.Empty && !SpellHelper.IsFeluccaDungeon(item.Map, item.Location)) //its daytime disable light
                        item.Light = LightType.Empty;
                    else
                        item.Light = LightType.Circle300;

                    item.ProcessDelta();

                    Effects.SendLocationParticles(EffectItem.Create(loc, Caster.Map, EffectItem.DefaultDuration), 0x376A, 9, 10, 5051);
                }
            }

            FinishSequence();
        }

        [DispellableField]
        private class InternalItem : Item
        {
            private Timer m_Timer;

            public override bool BlocksFit { get { return true; } }

            public InternalItem(Point3D loc, Map map, TimeSpan duration, int itemID, Mobile caster)
                : base(itemID)
            {
                Visible = false;
                Movable = false;
                Light = LightType.Circle300;

                MoveToWorld(loc, map);

                if (caster.InLOS(this))
                    Visible = true;
                else
                    Delete();

                if (Deleted)
                    return;

                m_Timer = new InternalTimer(this, duration);
                m_Timer.Start();
            }

            public InternalItem(Serial serial)
                : base(serial)
            {
                m_Timer = new InternalTimer(this, TimeSpan.FromSeconds(5.0));
                m_Timer.Start();
            }

            public override void Serialize(GenericWriter writer)
            {
                base.Serialize(writer);

                writer.Write((int)0); // version
            }

            public override void Deserialize(GenericReader reader)
            {
                base.Deserialize(reader);

                int version = reader.ReadInt();
            }

            public override void OnAfterDelete()
            {
                base.OnAfterDelete();

                if (m_Timer != null)
                    m_Timer.Stop();
            }

            private class InternalTimer : Timer
            {
                private InternalItem m_Item;

                public InternalTimer(InternalItem item, TimeSpan duration)
                    : base(duration)
                {
                    Priority = TimerPriority.OneSecond;
                    m_Item = item;
                }

                protected override void OnTick()
                {
                    m_Item.Delete();
                }
            }
        }

        private class InternalTarget : Target
        {
            private EnergyFieldSpell m_Owner;

            public InternalTarget(EnergyFieldSpell owner)
                : base(12, true, TargetFlags.None)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is IPoint3D)
                    m_Owner.Target((IPoint3D)o);
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}