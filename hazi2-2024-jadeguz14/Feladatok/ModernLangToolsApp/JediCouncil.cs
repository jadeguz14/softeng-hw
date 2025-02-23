using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernLangToolsApp
{

    public delegate void JediCouncilChangedMemberDelegate(string msg);

    public class JediCouncil
    {
         List<Jedi> members = new List<Jedi>();
        public event JediCouncilChangedMemberDelegate JediCouncilChangedMember;

        public void Add(Jedi jedi)
        {
            members.Add(jedi);
            JediCouncilChangedMember?.Invoke($"Új taggal bővültünk");
        }

        public void Remove()
        {
            int cnt = members.Count();
            members.RemoveAt(cnt - 1);

            if(JediCouncilChangedMember != null )
            {
                if (cnt == 1)
                {
                    JediCouncilChangedMember.Invoke($"A tanács elesett");
                }
                else
                    JediCouncilChangedMember.Invoke($"Zavart érzek az erőben");

            }
        }
        public List<Jedi> Search_Delegate()
        {
            return members.FindAll(LowMidiChlorian);
        }
        private bool LowMidiChlorian(Jedi jedi)
        {
            return jedi.MidiChlorianCount < 530;
        }

        public List<Jedi> Search_Lambda()
        {
            return members.FindAll(jedi => jedi.MidiChlorianCount < 1000);
        }
    }
}
