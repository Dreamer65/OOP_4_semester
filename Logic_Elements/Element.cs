using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Elements
{
    abstract class Element
    {
        private string name;
        private byte inputsQuontity;
        private byte outputsQuontity;

        public Element()
        {
            name = "";
            inputsQuontity = 1;
            outputsQuontity = 1;
        }

        public Element(string name) : this()
        {
            this.name = name;
        }

        public Element(string name, byte inputsQuontity, byte outputsQuontity){
            this.name = name;
            this.inputsQuontity = inputsQuontity;
            this.outputsQuontity = outputsQuontity;
        }

        public string Name
        {
            get => name;
        }

        public byte InputQuontity{ get => inputsQuontity; set => inputsQuontity = value; }

        public byte OutputQuontity { get => outputsQuontity; set => outputsQuontity = value; }

        public abstract override bool Equals(object obj);
    }
}
