using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    public class Jedi
    {
        private string name;
        [XmlAttribute("Nev")]
        public string Name { get; set; }

        private int midiChlorianCount;
        [XmlAttribute("MidiChlorianSzam")]
        public int MidiChlorianCount
        {
            get {  return midiChlorianCount; }
            set
            {
                if(value <= 35)
                {
                    throw new ArgumentException("You are not a true jedi!");
                }
                midiChlorianCount = value;
            }
        }
    }
}
